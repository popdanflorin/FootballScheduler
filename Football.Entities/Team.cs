using System.ComponentModel.DataAnnotations;

namespace Football.Entities
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        public string Name { get; set; }
        public string Colours { get; set; }
        public int YearFounded { get; set; }

        public int LeagueTypeId { get; set; }
        public LeagueType LeagueType { get; set; }
    }
}