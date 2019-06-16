namespace TBackend.Entity
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NMembers { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
    }
}