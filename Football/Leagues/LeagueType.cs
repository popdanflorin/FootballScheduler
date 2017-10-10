using System.Collections.Generic;
namespace Football.Business
{
    public class LeagueType
    {
        public int LeagueTypeId { get; set; }
        public string Name { get; set; }
        public int YearFounded { get; set; }
        public string RegionOrCountry { get; set; }
        public int NumberOfTeams { get; set; }
        public string CurrentChampion { get; set; }
        public string MostSuccessfulTeam { get; set; }

        public Dictionary<int, LeagueType> PromotionsOrRelegations { get; set; }

        public string CurrentVsMostSuccessful
        {
            get
            {
                return CurrentChampion + "/" + MostSuccessfulTeam;
            }
            set { }
        }
    }
}
