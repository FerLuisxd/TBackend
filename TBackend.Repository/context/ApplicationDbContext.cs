
using Microsoft.EntityFrameworkCore;
using TBackend.Entity;
namespace TBackend.Repository.context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Mode> Modes { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Match> Matchs { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<Team> Teams { get; set; }

        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options):base(options){

        }
        //   public ApplicationDbContext(DbContextOptionsBuilder optionsBuilder){

        //     optionsBuilder.UseMySQL("server=localhost;database=tournamentdb;user=root;password=admin");
        // }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseMySQL("server=localhost;database=tournamentdb;user=root;password=admin");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }
}
