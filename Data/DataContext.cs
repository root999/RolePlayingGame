using Microsoft.EntityFrameworkCore;
using RolePlayingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolePlayingGame.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSkill>()
                .HasKey(cs => new { cs.CharacterId, cs.SkillId });
            modelBuilder.Entity<CharacterUser>()
               .HasKey(cs => new { cs.CharacterId, cs.UserId });
            modelBuilder.Entity<User>()
                .Property(user => user.Role).HasDefaultValue("Player");
        }
        public DbSet<Character> Characters {get;set;}
        public DbSet<User> Users { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        public DbSet<CharacterUser> CharacterUsers { get; set; }

    }
}
