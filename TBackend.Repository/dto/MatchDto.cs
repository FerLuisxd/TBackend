using System;
using System.Collections.Generic;
using TBackend.Entity;
using System.ComponentModel.DataAnnotations;

namespace TBackend.Repository.dto
{
    public class MatchDto
    {
        public int Id { get; set; }
        public int WinnerId { get; set; }
        public string WinnerName { get; set; }

        public Team Winner { get; set; }
        public int Fase { get; set; }
        public int Team1Id { get; set; }
        public string Team1Name { get; set; }
        public Team Team1 { get; set; }
        public int Team2Id { get; set; }
        public string Team2Name { get; set; }
        public Team Team2 { get; set; }
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
    }
}