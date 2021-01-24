using RolePlayingGame.Dtos;
using RolePlayingGame.Dtos.Character;
using RolePlayingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolePlayingGame.Services.WeaponService
{
    public interface IWeaponService
    {

        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);

    }
}
