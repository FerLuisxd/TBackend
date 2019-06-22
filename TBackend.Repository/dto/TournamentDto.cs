using System;
using System.Collections.Generic;
using TBackend.Entity;
using System.ComponentModel.DataAnnotations;

namespace TBackend.Repository.dto
{
    public class TournamentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Winner { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int NTeams { get; set; }
        public int ModeId { get; set; }
        public string ModeFormat { get; set; }
        //[JsonObject(IsReference = true)] 
        public IEnumerable<Team> Teams { get; set; }
    }
}