namespace TBackend.Entity
{
    public class Statistics
    {
        public int Id { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public float Kills { get; set; }
        public float Deaths { get; set; }
        public float Assists { get; set; }
        public float Damage { get; set; }
        
    }
}