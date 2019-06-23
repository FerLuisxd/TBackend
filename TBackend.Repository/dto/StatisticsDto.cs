using System;
using System.Collections.Generic;
using TBackend.Entity;
using System.ComponentModel.DataAnnotations;

namespace TBackend.Repository.dto
{
    public class StatisticsDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public Match Match {get;set;}
        public int PlayerId { get; set; }
        public string PlayerName  { get; set; }

        public float Kills { get; set; }
        public float Deaths { get; set; }
        public float Assists { get; set; }
        public float Damage { get; set; }
    }
}