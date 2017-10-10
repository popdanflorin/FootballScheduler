using Football.Business;
using System.Collections.Generic;

namespace Football.Web.Models
{
    public class MatchesModel
    {
        public List<Match> Matches { get; set; }
        public List<Team> Standings { get; set; }
    }
}