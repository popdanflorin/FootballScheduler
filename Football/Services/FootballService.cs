using Football.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Football.Business
{
    public class FootballService
    {
        private Repository repo;

        public FootballService()
        {
            repo = new Repository();
        }
        public List<LeagueType> GetLeagueTypes()
        {
            var businessLeagueTypes = new List<LeagueType>();
            var entityLeagueTypes = repo.GetLeagueTypes();
            foreach (var item in entityLeagueTypes)
            {
                businessLeagueTypes.Add(new LeagueType() { LeagueTypeId = item.LeagueTypeId, Name = item.Name, RegionOrCountry = item.Region, YearFounded = item.Year, NumberOfTeams = item.NumberOfTeams });
            }

            return businessLeagueTypes;
        }
        public List<Team> GetTeams()
        {
            var businessTeams = new List<Team>();
            var entityTeams = repo.GetTeams();
            foreach (var item in entityTeams)
            {
                businessTeams.Add(new Team() { TeamId = item.TeamId, Name = item.Name, Colors = item.Colours, YearFounded = item.YearFounded, LeagueTypeId = item.LeagueTypeId });
            }

            return businessTeams;
        }

        public List<League> GetLeagues()
        {
            var businessLeagues = new List<League>();
            var entityLeagues = repo.GetLeagues();
            foreach (var item in entityLeagues)
            {
                var league = GetLeague(item.LeagueId);
                league.LeagueTypeName = item.LeagueType.Name;
                league.StartDate = item.StartDate;
                if (item.Matches != null)
                {
                    if (!item.Matches.ToList().Any(m => m.IsPlayed))
                        league.Status = "Not started";
                    else if (item.Matches.ToList().All(m => m.IsPlayed))
                        league.Status = "Finished";
                    else
                        league.Status = "In progress";
                    league.GenerateStandings();
                }
                businessLeagues.Add(league);
            }

            return businessLeagues;
        }

        public League GetLeague(int leagueId)
        {
            var businessLeague = new League() { LeagueId = leagueId };
            var entityLeague = repo.GetLeagues().FirstOrDefault(l => l.LeagueId == leagueId);
            var businessTeams = new List<Team>();
            foreach (var item in entityLeague.LeagueTeams)
            {
                businessTeams.Add(new Team()
                {
                    TeamId = item.TeamId,
                    Name = item.Team.Name,
                    GamesPlayed = item.Games,
                    Wins = item.Wins,
                    Draws = item.Draws,
                    Losses = item.Losses,
                    GoalsFor = item.GoalsFor,
                    GoalsAgainst = item.GoalsAgainst,
                    Points = item.Points
                });
            }
            businessLeague.Teams = businessTeams;
            var businessMatches = new List<Match>();
            foreach (var item in entityLeague.Matches)
            {
                businessMatches.Add(new Match()
                {
                    MatchId = item.MatchId,
                    Home = businessTeams.FirstOrDefault(bt => bt.TeamId == item.Home.TeamId),
                    Guest = businessTeams.FirstOrDefault(bt => bt.TeamId == item.Guest.TeamId),
                    Round = item.Round,
                    HomeGoals = item.HomeGoals,
                    GuestGoals = item.GuestGoals,
                    IsPlayed = item.IsPlayed
                });
            }
            businessLeague.Matches = businessMatches;
            var lastPlayedRound = 0;
            var playedMatches = businessLeague.Matches.Where(m => m.IsPlayed);
            if (playedMatches.Any())
            {
                lastPlayedRound = playedMatches.Max(m => m.Round);
            }
            businessLeague.NextAvailableRound = lastPlayedRound + 1;

            return businessLeague;
        }

        public void StartLeague(int leagueTypeId)
        {
            League league = new League() { LeagueTypeId = leagueTypeId };
            league.Teams = GetTeams().Where(t => t.LeagueTypeId == leagueTypeId).ToList();
            league.GenerateSchedule();

            var entityLeague = ConvertTo(league);
            repo.StartLeague(entityLeague);
        }

        private Entities.League ConvertTo(League league)
        {
            var entityLeague = new Entities.League();
            entityLeague.LeagueTypeId = league.LeagueTypeId;
            entityLeague.StartDate = DateTime.Now;

            var entityLeagueTeams = new List<LeagueTeam>();
            foreach (var item in league.Teams)
            {
                entityLeagueTeams.Add(new LeagueTeam() { TeamId = item.TeamId });
            }
            entityLeague.LeagueTeams = entityLeagueTeams;

            var entityMatches = new List<Entities.Match>();
            foreach (var item in league.Matches)
            {
                entityMatches.Add(new Entities.Match()
                {
                    Home = entityLeagueTeams.FirstOrDefault(lt => lt.TeamId == item.Home.TeamId),
                    Guest = entityLeagueTeams.FirstOrDefault(lt => lt.TeamId == item.Guest.TeamId),
                    Round = item.Round
                });
            }

            entityLeague.Matches = entityMatches;

            return entityLeague;
        }

        public League PlayRound(int leagueId)  //~cu update din repo
        {
            var league = GetLeague(leagueId);
            var entityLeague = repo.GetLeagues().FirstOrDefault(l => l.LeagueId == leagueId);
            var leagueTeams = new List<LeagueTeam>();
            var matches = new List<Entities.Match>();
            var roundMatches = league.Matches.Where(m => m.Round == league.NextAvailableRound);
            foreach (var item in roundMatches)
            {
                item.GenerateResult();
                var leagueTeamHome = entityLeague.LeagueTeams.FirstOrDefault(lt => lt.TeamId == item.Home.TeamId);
                var leagueTeamGuest = entityLeague.LeagueTeams.FirstOrDefault(lt => lt.TeamId == item.Guest.TeamId);
                var entityMatch = entityLeague.Matches.FirstOrDefault(m => m.MatchId == item.MatchId);
                Transcribe(item, leagueTeamHome, leagueTeamGuest, entityMatch);
                leagueTeams.Add(leagueTeamHome);
                leagueTeams.Add(leagueTeamGuest);
                matches.Add(entityMatch);
            }
            repo.UpdateResults(leagueTeams, matches);
            return league;
        }

        private void Transcribe(Match match, LeagueTeam homeTeam, LeagueTeam guestTeam, Entities.Match entityMatch)
        { //trnsform din Match in entityMatch si din LeagueTeam in entityLeagueTeam, => update
            entityMatch.HomeGoals = match.HomeGoals;
            entityMatch.GuestGoals = match.GuestGoals;
            entityMatch.IsPlayed = true;

            homeTeam.Games = match.Home.GamesPlayed;
            homeTeam.Wins = match.Home.Wins;
            homeTeam.Draws = match.Home.Draws;
            homeTeam.Losses = match.Home.Losses;
            homeTeam.Points = match.Home.Points;
            homeTeam.GoalsFor = match.Home.GoalsFor;
            homeTeam.GoalsAgainst = match.Home.GoalsAgainst;
            homeTeam.GoalDifference = match.Home.GoalsAgainst;

            guestTeam.Games = match.Guest.GamesPlayed;
            guestTeam.Wins = match.Guest.Wins;
            guestTeam.Draws = match.Guest.Draws;
            guestTeam.Losses = match.Guest.Losses;
            guestTeam.Points = match.Guest.Points;
            guestTeam.GoalsFor = match.Guest.GoalsFor;
            guestTeam.GoalsAgainst = match.Guest.GoalsAgainst;
            guestTeam.GoalDifference = match.Guest.GoalsAgainst;
        }
    }
}
