using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RolePlayingGame.Data;
using RolePlayingGame.Dtos.Character;
using RolePlayingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RolePlayingGame.Services.CharacterService
{
   
    public class CharacterService : ICharacterService

    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public CharacterService(IMapper mapper, DataContext context,IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


      
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newChar)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newChar);
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();

            serviceResponse.Data = (_context.Characters.Where(c => c.CharacterUsers.Any(cu => cu.UserId == getUserId())).Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacterToUser(int charId)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == charId);
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == getUserId());
            try
            {
                CharacterUser characterUser = await _context.CharacterUsers.FirstOrDefaultAsync(cu => cu.CharacterId == charId && cu.UserId == getUserId());
                if (characterUser == null)
                {
                    characterUser = new CharacterUser
                    {
                        Character = character,
                        User = user,
                    };
                    await _context.CharacterUsers.AddAsync(characterUser);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = (_context.Characters.Where(c => c.CharacterUsers.Any(cu => cu.UserId == getUserId())).Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
                    serviceResponse.Message = "Character added to the user";
                    serviceResponse.Success = true;
                }
                else
                {
                    serviceResponse.Message = "Character already Added";
                    serviceResponse.Success = false;
                }


            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }



            return serviceResponse;
        }




        public async Task<ServiceResponse<List<GetCharacterDto>>> GetUsersAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            List < Character > characters = await _context.Characters.Include(c => c.Weapon)
                 .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                 .Where(c => c.CharacterUsers.Any(cu => cu.UserId == getUserId())).ToListAsync();
            serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            List<Character> characters = await _context.Characters.Include(c => c.Weapon)
                 .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill).ToListAsync();
            serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            Character character = await _context.Characters.Include(c => c.Weapon)
                 .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                 .FirstOrDefaultAsync(c => c.Id == id && c.CharacterUsers.Any(cu=> cu.UserId == getUserId()));

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _context.Characters.Include(c => c.CharacterSkills).FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id &&
                                                                                                  c.CharacterUsers.Any(cu => cu.UserId == getUserId()));
                if (character != null)
                {

                    character.Name = updatedCharacter.Name;
                    character.Class = updatedCharacter.Class;
                    character.Defense = updatedCharacter.Defense;
                    character.HitPoints = updatedCharacter.HitPoints;
                    character.Intelligence = updatedCharacter.Intelligence;
                    character.Strength = updatedCharacter.Strength;
                    _context.Characters.Update(character);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                    serviceResponse.Message = "The character has been saved";

                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character =
                    await _context.Characters.FirstOrDefaultAsync(c =>
                    c.Id == id && c.CharacterUsers.Any(cu => cu.UserId == getUserId()));

                if (character != null)
                {

                    _context.Characters.Remove(character);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = (_context.Characters
                            .Where(c => c.CharacterUsers.Any(cu => cu.UserId == getUserId()))
                            .Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "character not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }
        private int getUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

    }
}
