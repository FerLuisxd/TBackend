namespace TBackend.Entity
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GamePreferences { get; set; }
        public int TeamId { get; set; }   
        public string TeamName { get; set; }              
        public Team Team { get; set; }
        
    }
}