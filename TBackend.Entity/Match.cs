namespace TBackend.Entity
{
    public class Match
    {
        public int Id { get; set; }
        public bool Winner { get; set; }
        public int Fase { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        //hola
    }
}