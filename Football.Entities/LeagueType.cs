using System.ComponentModel.DataAnnotations;

namespace Football.Entities
{
   public class LeagueType
    {
        [Key]
        public int LeagueTypeId { get; set; }

        public string Name { get; set; }
        public string Region { get; set; }
        public int Year { get; set; }
        public int NumberOfTeams { get; set; }
    }
}
