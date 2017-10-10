using Football.Interfaces;
using System.Collections.Generic;

namespace Football.Business
{
    public class FieldPlayer : Player, IRun
    {
        public string PreferredFoot { get; set; }
        public int BoughtFor { get; set; }
        public string GamesPlayed { get; set; }
        public string GoalsScored { get; set; }
        public string Assists { get; set; }
        public int TotalFreeKicks { get; set; }
        public List<Skill> Skills { get; set; }
        public Position Position { get; set; }

        public bool DoAction(Skill action)  //sa vad daca face ceva in momentul respectiv 
        {
            return true;
        }

        public string GoalsAndGames
        {
            get
            {
                return GoalsScored + " in " + GamesPlayed + " matches ";
            }
            private set { }
        }

        public string GoalsAndAssists
        {
            get
            {
                return "Goals: " + GoalsScored + "\n" + "Assists: " + Assists;
            }
            set { }
        }

        public bool Pass(FieldPlayer toPlayer)
        {
            return true;
        }

        public bool Dribbling(FieldPlayer dribblePlayer)  //asa de zice/scrie?
        {
            return true;
        } 

        public bool Shoot()
        {
            return true;
        }

        public bool Tackle(FieldPlayer player)
        {
            return true;
        }
        public string Run()
        {
            return "fast";
        }

        public string Out()
        {
            return Number.ToString() + " is out";
        }

        public string In()
        {
            return Number.ToString() + " is in";
        }
    }
}

