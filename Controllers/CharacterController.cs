using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RolePlayingGame.Models;
using System.Collections.Generic;
using System.Linq;
using RolePlayingGame.Services.CharacterService;
using RolePlayingGame.Dtos.Character;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace RolePlayingGame.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
       
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {


            return Ok(await _characterService.GetUsersAllCharacters());
        }

        [HttpGet("add")]
        public async Task<IActionResult> GetCharacters()
        {


            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter([FromBody] int charId)
         {
           
            return Ok(await _characterService.AddCharacterToUser(charId));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updatedCharacter);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = await _characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
