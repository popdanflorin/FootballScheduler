using System.ComponentModel.DataAnnotations;

namespace Football.Entities
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }

        public int Round { get; set; }

        public bool IsPlayed { get; set; }

        //FK for home team  
        public int HomeLeagueTeamId { get; set; }
        public LeagueTeam Home { get; set; }

        public int HomeGoals { get; set; }

        //FK for guest team
        public int GuestLeagueTeamId { get; set; }
        public LeagueTeam Guest { get; set; }

        public int GuestGoals { get; set; }

        //FK for League
        public int LeagueId { get; set; }
        public League League { get; set; }
    }
}
