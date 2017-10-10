using System;
using System.Collections.Generic;
using System.Linq;

namespace Football.Business
{
    public class League
    {
        public int LeagueId { get; set; }

        public int LeagueTypeId { get; set; }
        public string LeagueTypeName { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }
        public string Champion { get ; set; }

        public int NextAvailableRound { get; set; }

        public List<Team> Standings { get; set; }

        public List<Team> Teams { get; set; }
        public List<Match> Matches { get; set; }

        public void GenerateSchedule()
        {
            if (Teams.Count < 2 || Teams.Count % 2 != 0)
                return;

            Matches = new List<Match>();

            var n = Teams.Count();

            //k reprezinta etapa
            for (int k = 0; k < n - 1; k++)
            {
                // i reprezinta nr meciului din etapa k
                for (int i = 0; i < n / 2; i++)
                {
                    if (k % 2 == 0)
                        Matches.Add(new Match { Home = Teams[i], Guest = Teams[n - 1 - i], Round = k + 1 });
                    else
                        Matches.Add(new Match { Home = Teams[n - 1 - i], Guest = Teams[i], Round = k + 1 });
                }
                var last = Teams.Last();
                Teams.Remove(last);
                Teams.Insert(1, last);
            }

            var returnMatches = new List<Match>();
            foreach (var match in Matches)
            {
                returnMatches.Add(new Match { Home = match.Guest, Guest = match.Home, Round = n - 1 + match.Round });
            }
            Matches.AddRange(returnMatches);
        }
        public void GenerateStandings()
        {
            Standings = Teams.OrderByDescending(t => t.Points).ThenByDescending(t => t.GoalDifference).ThenByDescending(t => t.GoalsFor).ToList();
            if (Status == "Finished")
            {
                GenerateChampion();
            }
        }

        public void GenerateChampion()
        {         
            Champion = Standings.ElementAt(0).Name;
        }
    }
}
