using RolePlayingGame.Dtos.User;
using RolePlayingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolePlayingGame.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);

        Task<ServiceResponse<UserLoginResponseDto>> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}
