﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TBackend.Repository.context;

namespace TBackend.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("TBackend.Entity.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Fase");

                    b.Property<int?>("Team1Id");

                    b.Property<int?>("Team2Id");

                    b.Property<int>("TournamentId");

                    b.Property<int?>("WinnerId");

                    b.HasKey("Id");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Matchs");
                });

            modelBuilder.Entity("TBackend.Entity.Mode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Format");

                    b.HasKey("Id");

                    b.ToTable("Modes");
                });

            modelBuilder.Entity("TBackend.Entity.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GamePreferences");

                    b.Property<string>("Name");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TBackend.Entity.Statistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Assists");

                    b.Property<float>("Damage");

                    b.Property<float>("Deaths");

                    b.Property<float>("Kills");

                    b.Property<int>("MatchId");

                    b.Property<int>("PlayerId");

                    b.Property<string>("TeamName");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("TBackend.Entity.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NMembers");

                    b.Property<string>("Name");

                    b.Property<int?>("TournamentId");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TBackend.Entity.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Game");

                    b.Property<int>("ModeId");

                    b.Property<int>("NTeams");

                    b.Property<string>("Name");

                    b.Property<int>("PlayerId");

                    b.Property<string>("Winner");

                    b.HasKey("Id");

                    b.HasIndex("ModeId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("TBackend.Entity.Match", b =>
                {
                    b.HasOne("TBackend.Entity.Team", "Team1")
                        .WithMany()
                        .HasForeignKey("Team1Id");

                    b.HasOne("TBackend.Entity.Team", "Team2")
                        .WithMany()
                        .HasForeignKey("Team2Id");

                    b.HasOne("TBackend.Entity.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TBackend.Entity.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");
                });

            modelBuilder.Entity("TBackend.Entity.Player", b =>
                {
                    b.HasOne("TBackend.Entity.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("TBackend.Entity.Statistics", b =>
                {
                    b.HasOne("TBackend.Entity.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TBackend.Entity.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TBackend.Entity.Team", b =>
                {
                    b.HasOne("TBackend.Entity.Tournament", "Tournament")
                        .WithMany("Teams")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("TBackend.Entity.Tournament", b =>
                {
                    b.HasOne("TBackend.Entity.Mode", "Mode")
                        .WithMany()
                        .HasForeignKey("ModeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TBackend.Entity.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
