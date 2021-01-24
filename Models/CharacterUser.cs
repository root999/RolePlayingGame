﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolePlayingGame.Models
{
    public class CharacterUser
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
