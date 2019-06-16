namespace TBackend.Entity
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Range { get; set; }
        public string GamePreferences { get; set; }
        public int TeamId { get; set; }                
        public Team Team { get; set; }
        
    }
}