using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolePlayingGame.Dtos.User
{
    public class UserLoginResponseDto
    {
        public string Username { get; set; }
        public string Token { get; set; }

        public string Role { get; set; }

    }
}
