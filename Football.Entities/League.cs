using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.Entities
{
    public class League
    {
        [Key]
        public int LeagueId { get; set; }

        public DateTime StartDate { get; set; }

        [ForeignKey("LeagueType")]
        public int LeagueTypeId { get; set; }
        public LeagueType LeagueType { get; set; }

        public ICollection<Match> Matches { get; set; }
        public ICollection<LeagueTeam> LeagueTeams { get; set; }
    }
}
