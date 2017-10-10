using System.ComponentModel.DataAnnotations;

namespace Football.Entities
{
    public class LeagueTeam
    {
        [Key]
        public int LeagueTeamId { get; set; }

        public int Games { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }

        //Foreign key for League
        public int LeagueId { get; set; }
        public League League { get; set; }

        //FK for Team
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
