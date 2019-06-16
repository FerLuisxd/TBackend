using System.Collections.Generic;

namespace TBackend.Entity
{
    public class Tournament
    {
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Winner { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int NTeams { get; set; }
        public int ModeId { get; set; }
        public Mode Mode { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
