using System.Collections.Generic;

namespace Football.Business
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int YearFounded { get; set; }
        public string LeaguesWon { get; set; }
        public string Anthem { get; set; }
        public string Colors { get; set; }
        public string Owner { get; set; }

        public int LeagueTypeId { get; set; }

        public Stadium Stadium { get; set; }
        public Manager Manager { get; set; }
        public Sponsor Sponsor { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<FieldPlayer> FieldPlayers { get; set; }
        public List<Goalkeeper> Goalkeepers { get; set; }
        public Equipment HomeEquipmentPlayers { get; set; }
        public Equipment HomeEquipmentGoalkeeper { get; set; }
        public Equipment AwayEquipmentPlayers { get; set; }
        public Equipment AwayEquipmentGoalkeeper { get; set; }

        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference
        {
            get
            {
                return GoalsFor - GoalsAgainst;
            }
        }
        public int Points { get; set; }

        public List<string> StartingTeam
        {
            get
            {
                List<string> all = new List<string>();
                all.Add(Manager.Name);
                all.Add(Goalkeepers[0].Name);   //pe pozitia 0 din lista goalkeepers o sa am portarul care joaca azi
                for (int i = 0; i < 10; i++)
                {
                    all.Add(FieldPlayers[i].Name);  //la fel in fieldPlayer pe primele 10 pozitii o sa ii am pe aia care joaca
                }
                return all;
            }
            set { }
        }
    }
}
