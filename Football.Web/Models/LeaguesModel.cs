using Football.Business;
using System.Collections.Generic;

namespace Football.Web.Models
{
    public class LeaguesModel
    {
       public List<LeagueType> LeagueTypes { get; set; }
       public List<League> Leagues { get; set; }
      
    }
}