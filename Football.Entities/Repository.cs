using Football.Entities.Migrations;
using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Football.Entities
{
    public class Repository
    {
        private static FootballDbContext db = new FootballDbContext();

        public Repository()
        {  //ca sa nuy accsesez prin business layer direct db, il accesez prin repository
            //asigura ca se fac migrari daca se adauga noi tabele in clasa de Context
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FootballDbContext, Configuration>());
        }

        public List<LeagueType> GetLeagueTypes()
        {
            return db.LeagueTypes.ToList();
        }
        public List<Team> GetTeams()
        {
            return db.Teams.ToList();
        }
        public List<League> GetLeagues()
        {  //pt ca leagueteam si matches sunt ipreuna, ii destul sa fac getLEagues doar
            return db.Leagues.Include(l => l.LeagueTeams.Select(lt => lt.Team)).Include(l => l.Matches).ToList();
        }

        public void StartLeague(League league)  //sau save, insert league
        {
            db.Leagues.Add(league);
            db.SaveChanges();  //metoda a dbContextului, salveaza toate modificarile facute pe context
        }

        public void UpdateResults(List<LeagueTeam> leagueTeams, List<Match> matches)
        {
            foreach (var item in leagueTeams)
            {
                db.Set<LeagueTeam>().AddOrUpdate(item);
            }
            foreach (var item in matches)
            {
                db.Set<Match>().AddOrUpdate(item);
            }
            db.SaveChanges();
        }
    }
}
