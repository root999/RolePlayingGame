using RolePlayingGame.Dtos.Character;
using RolePlayingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolePlayingGame.Services.CharacterService
{
    public interface ICharacterService
    {

        Task<ServiceResponse<List<GetCharacterDto>>> GetUsersAllCharacters();
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();

        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);

        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newChar);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacterToUser (int charId);

        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}
