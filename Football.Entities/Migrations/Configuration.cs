using System.Linq;
namespace Football.Entities.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FootballDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FootballDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            if (!context.LeagueTypes.Any() && !context.Teams.Any())

            {
                var lt1 = new LeagueType { LeagueTypeId = 1, Name = "Serie A", Region = "Europe", NumberOfTeams = 20, Year = 1900 };
                var lt2 = new LeagueType { LeagueTypeId = 2, Name = "La Liga", Region = "Europe", NumberOfTeams = 20, Year = 1900 };
                var lt3 = new LeagueType { LeagueTypeId = 3, Name = "Premier League", Region = "Europe", NumberOfTeams = 20, Year = 1900 };
                var lt4 = new LeagueType { LeagueTypeId = 4, Name = "Bundesliga", Region = "Europe", NumberOfTeams = 20, Year = 1900 };

                context.LeagueTypes.AddOrUpdate(lt => lt.Name, lt1, lt2, lt3, lt4);

                context.Teams.AddOrUpdate(
                    t => t.Name,
                                new Team { TeamId = 1, Name = "Juventus", Colours = "white-black", YearFounded = 1897, LeagueType = lt1 },
                                new Team { TeamId = 2, Name = "AS Roma", Colours = "gold-purple", YearFounded = 1927, LeagueType = lt1 },
                                new Team { TeamId = 3, Name = "Napoli", Colours = "blue", YearFounded = 1926, LeagueType = lt1 },
                                new Team { TeamId = 4, Name = "Lazio", Colours = "white-blue", YearFounded = 1900, LeagueType = lt1 },
                                new Team { TeamId = 5, Name = "Atalanta", Colours = "black-blue", YearFounded = 1907, LeagueType = lt1 },
                                new Team { TeamId = 6, Name = "AC Milan", Colours = "red-black", YearFounded = 1899, LeagueType = lt1 },
                                new Team { TeamId = 7, Name = "Fiorentina", Colours = "purple", YearFounded = 1926, LeagueType = lt1 },
                                new Team { TeamId = 8, Name = "FC Internazionale", Colours = "black-blue", YearFounded = 1909, LeagueType = lt1 },
                                new Team { TeamId = 9, Name = "Torino", Colours = "red", YearFounded = 1906, LeagueType = lt1 },
                                new Team { TeamId = 10, Name = "Sampdoria", Colours = "black-white-red-blue", YearFounded = 1946, LeagueType = lt1 },
                                new Team { TeamId = 11, Name = "Udinese", Colours = "black-white", YearFounded = 1896, LeagueType = lt1 },
                                new Team { TeamId = 12, Name = "Cagliari", Colours = "red-blue", YearFounded = 1920, LeagueType = lt1 },
                                new Team { TeamId = 13, Name = "Chievo", Colours = "blue-yellow", YearFounded = 1929, LeagueType = lt1 },
                                new Team { TeamId = 14, Name = "Sassuolo", Colours = "black-green", YearFounded = 1920, LeagueType = lt1 },
                                new Team { TeamId = 15, Name = "Bologna", Colours = "red-blue", YearFounded = 1909, LeagueType = lt1 },
                                new Team { TeamId = 16, Name = "Genoa", Colours = "red-blue", YearFounded = 1893, LeagueType = lt1 },
                                new Team { TeamId = 17, Name = "Empoli", Colours = "white-blue", YearFounded = 1920, LeagueType = lt1 },
                                new Team { TeamId = 18, Name = "Crotone", Colours = "red-blue", YearFounded = 1910, LeagueType = lt1 },
                                new Team { TeamId = 19, Name = "Palermo", Colours = "black-pink", YearFounded = 1900, LeagueType = lt1 },
                                new Team { TeamId = 20, Name = "Pescara", Colours = "white-blue", YearFounded = 1936, LeagueType = lt1 }
                    );

                context.Teams.AddOrUpdate(
                    t => t.Name,
                                new Team { TeamId = 21, Name = "Real Madrid", Colours = "white", YearFounded = 1900, LeagueType = lt2 },
                                new Team { TeamId = 22, Name = "Barcelona", Colours = "blue-red", YearFounded = 1900, LeagueType = lt2 },
                                new Team { TeamId = 23, Name = "Atletico Madrid", Colours = "white-red", YearFounded = 1900, LeagueType = lt2 },
                                new Team { TeamId = 24, Name = "FC Sevilla", Colours = "white-red", YearFounded = 1900, LeagueType = lt2 },
                                new Team { TeamId = 25, Name = "Villareal", Colours = "yellow", YearFounded = 1923, LeagueType = lt2 },
                                new Team { TeamId = 26, Name = "Athletic Bilbao", Colours = "black-red-white", YearFounded = 1898, LeagueType = lt2 },
                                new Team { TeamId = 27, Name = "Real Sociedad", Colours = "white-blue", YearFounded = 1909, LeagueType = lt2 },
                                new Team { TeamId = 28, Name = "Eibar", Colours = "blue", YearFounded = 1940, LeagueType = lt2 },
                                new Team { TeamId = 29, Name = "Alaves", Colours = "blue-white", YearFounded = 1921, LeagueType = lt2 },
                                new Team { TeamId = 30, Name = "Espanyol", Colours = "blue-white", YearFounded = 1900, LeagueType = lt2 },
                                new Team { TeamId = 31, Name = "Malaga", Colours = "white-blue", YearFounded = 1948, LeagueType = lt2 },
                                new Team { TeamId = 32, Name = "Valencia", Colours = "white-black", YearFounded = 1923, LeagueType = lt2 },
                                new Team { TeamId = 33, Name = "Celta Vigo", Colours = "white-blue", YearFounded = 1923, LeagueType = lt2 },
                                new Team { TeamId = 34, Name = "Las Palmas", Colours = "blue-yellow", YearFounded = 1949, LeagueType = lt2 },
                                new Team { TeamId = 35, Name = "Real Betis", Colours = "white-green", YearFounded = 1907, LeagueType = lt2 },
                                new Team { TeamId = 36, Name = "Leganes", Colours = "white-blue", YearFounded = 1928, LeagueType = lt2 },
                                new Team { TeamId = 37, Name = "Deportivo", Colours = "white-blue", YearFounded = 1906, LeagueType = lt2 },
                                new Team { TeamId = 38, Name = "Sporting", Colours = "white-red-blue", YearFounded = 1905, LeagueType = lt2 },
                                new Team { TeamId = 39, Name = "Osasuna", Colours = "red-blue", YearFounded = 1920, LeagueType = lt2 },
                                new Team { TeamId = 40, Name = "Granada", Colours = "white-red", YearFounded = 1931, LeagueType = lt2 }
                );
                context.Teams.AddOrUpdate(
                    t => t.Name,
                                new Team { TeamId = 41, Name = "Chelsea", Colours = "blue-royal blue", YearFounded = 1905, LeagueType = lt3 },
                                new Team { TeamId = 42, Name = "Tottenham", Colours = "white-navy blue", YearFounded = 1882, LeagueType = lt3 },
                                new Team { TeamId = 43, Name = "Liverpool", Colours = "red", YearFounded = 1892, LeagueType = lt3 },
                                new Team { TeamId = 44, Name = "Man City", Colours = "white-blue", YearFounded = 1880, LeagueType = lt3 },
                                new Team { TeamId = 45, Name = "Arsenal", Colours = "white-red", YearFounded = 1886, LeagueType = lt3 },
                                new Team { TeamId = 46, Name = "Man United", Colours = "white-red", YearFounded = 1878, LeagueType = lt3 },
                                new Team { TeamId = 47, Name = "Everton", Colours = "white-blue", YearFounded = 1878, LeagueType = lt3 },
                                new Team { TeamId = 48, Name = "West Brom", Colours = "white-navy blue", YearFounded = 1878, LeagueType = lt3 },
                                new Team { TeamId = 49, Name = "Southampton", Colours = "white-red", YearFounded = 1885, LeagueType = lt3 },
                                new Team { TeamId = 50, Name = "Bournemouth", Colours = "black-red", YearFounded = 1899, LeagueType = lt3 },
                                new Team { TeamId = 51, Name = "Leicester City", Colours = "white-blue", YearFounded = 1884, LeagueType = lt3 },
                                new Team { TeamId = 52, Name = "West Ham", Colours = "white-blue", YearFounded = 1895, LeagueType = lt3 },
                                new Team { TeamId = 53, Name = "Crystal Palace", Colours = "red-blue", YearFounded = 1905, LeagueType = lt3 },
                                new Team { TeamId = 54, Name = "Stoke City", Colours = "white-red", YearFounded = 1863, LeagueType = lt3 },
                                new Team { TeamId = 55, Name = "Burnley FC", Colours = "blue-white", YearFounded = 1882, LeagueType = lt3 },
                                new Team { TeamId = 56, Name = "Watford", Colours = "black-red-blue-yellow", YearFounded = 1881, LeagueType = lt3 },
                                new Team { TeamId = 57, Name = "Swansea City", Colours = "white-gold", YearFounded = 1912, LeagueType = lt3 },
                                new Team { TeamId = 58, Name = "Hull City", Colours = "black-amber", YearFounded = 1904, LeagueType = lt3 },
                                new Team { TeamId = 59, Name = "Middlesbrough", Colours = "white-red", YearFounded = 1876, LeagueType = lt3 },
                                new Team { TeamId = 60, Name = "Sunderland", Colours = "white-red", YearFounded = 1879, LeagueType = lt3 }
                    );
                context.Teams.AddOrUpdate(
                    t => t.Name,
                                new Team { TeamId = 61, Name = "Bayern Munich", Colours = "white-red", YearFounded = 1900, LeagueType = lt4 },
                                new Team { TeamId = 62, Name = "RB Leipzig", Colours = "red-white", YearFounded = 2009, LeagueType = lt4 },
                                new Team { TeamId = 63, Name = "Dortmund", Colours = "yellow-black", YearFounded = 1909, LeagueType = lt4 },
                                new Team { TeamId = 64, Name = "Hoffenheim", Colours = "white-blue", YearFounded = 1899, LeagueType = lt4 },
                                new Team { TeamId = 65, Name = "Hertha BSC", Colours = "white-blue", YearFounded = 1892, LeagueType = lt4 },
                                new Team { TeamId = 66, Name = "SC Freiburg", Colours = "white-black-red", YearFounded = 1904, LeagueType = lt4 },
                                new Team { TeamId = 67, Name = "FC Koln", Colours = "white-red", YearFounded = 1948, LeagueType = lt4 },
                                new Team { TeamId = 68, Name = "Werder", Colours = "white-green", YearFounded = 1899, LeagueType = lt4 },
                                new Team { TeamId = 69, Name = "Monchengladbach", Colours = "white-black-green", YearFounded = 1900, LeagueType = lt4 },
                                new Team { TeamId = 70, Name = "Schalke 04", Colours = "white-blue", YearFounded = 1904, LeagueType = lt4 },
                                new Team { TeamId = 71, Name = "Eintracht", Colours = "white-black-red", YearFounded = 1899, LeagueType = lt4 },
                                new Team { TeamId = 72, Name = "Bayer 04 Leverkusen", Colours = "white-red", YearFounded = 1904, LeagueType = lt4 },
                                new Team { TeamId = 73, Name = "Mainz 05", Colours = "white-red", YearFounded = 1905, LeagueType = lt4 },
                                new Team { TeamId = 74, Name = "FC Ausburg", Colours = "white-red-green", YearFounded = 1907, LeagueType = lt4 },
                                new Team { TeamId = 75, Name = "Wolfsburg", Colours = "white-green", YearFounded = 1945, LeagueType = lt4 },
                                new Team { TeamId = 76, Name = "Hamburger SV", Colours = "white-black-blue", YearFounded = 1887, LeagueType = lt4 },
                                new Team { TeamId = 77, Name = "Ingolstadt", Colours = "white-black", YearFounded = 2004, LeagueType = lt4 },
                                new Team { TeamId = 78, Name = "Darmstadt 98", Colours = "white-blue", YearFounded = 1998, LeagueType = lt4 }
                    );
            }
        }
    }
}
