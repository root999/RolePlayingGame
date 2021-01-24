﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RolePlayingGame.Data;

namespace RolePlayingGame.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210107072020_users2characters2")]
    partial class users2characters2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("RolePlayingGame.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("Defeats")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Fights")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Victories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("RolePlayingGame.Models.CharacterSkill", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharacterSkills");
                });

            modelBuilder.Entity("RolePlayingGame.Models.CharacterUser", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("CharacterUsers");
                });

            modelBuilder.Entity("RolePlayingGame.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("RolePlayingGame.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Player");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RolePlayingGame.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("RolePlayingGame.Models.Character", b =>
                {
                    b.HasOne("RolePlayingGame.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RolePlayingGame.Models.CharacterSkill", b =>
                {
                    b.HasOne("RolePlayingGame.Models.Character", "Character")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RolePlayingGame.Models.Skill", "Skill")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("RolePlayingGame.Models.CharacterUser", b =>
                {
                    b.HasOne("RolePlayingGame.Models.Character", "Character")
                        .WithMany("CharacterUsers")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RolePlayingGame.Models.User", "User")
                        .WithMany("CharacterUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RolePlayingGame.Models.Weapon", b =>
                {
                    b.HasOne("RolePlayingGame.Models.Character", "Character")
                        .WithOne("Weapon")
                        .HasForeignKey("RolePlayingGame.Models.Weapon", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("RolePlayingGame.Models.Character", b =>
                {
                    b.Navigation("CharacterSkills");

                    b.Navigation("CharacterUsers");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("RolePlayingGame.Models.Skill", b =>
                {
                    b.Navigation("CharacterSkills");
                });

            modelBuilder.Entity("RolePlayingGame.Models.User", b =>
                {
                    b.Navigation("CharacterUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
