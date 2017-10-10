using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Football.Entities
{
    public class FootballDbContext : DbContext
    {
        //public FootballDbContext() : base("FootballDbContext")
        //{
        //    Configuration.LazyLoadingEnabled = false;
        //}

        public DbSet<LeagueType> LeagueTypes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<LeagueTeam> LeagueTeams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set;}

        /*
         Fluent API configuration is applied as EF builds the model from your domain classes
         You can inject the configurations by overriding the DbContext class' OnModelCreating method.
             */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
