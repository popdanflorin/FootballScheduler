using System;
using System.Collections.Generic;

namespace Football.Business
{
    public class Match
    {
        public int MatchId { get; set; }
        public Team Home { get; set; }
        public Team Guest { get; set; }
        public int Round { get; set; } //etapa
        public bool IsPlayed { get; set; }
        public int HomeGoals { get; set; }
        public int GuestGoals { get; set; }
        public AdditionalReferee AdditionalReferee { get; set; }
        public FieldReferee FieldRef { get; set; }
        public List<SideReferee> SideRefs { get; set; }
        public string Half { get; set; }
        public int Min { get; set; }
        public Stadium Stadium { get; set; }

        private static Random rnd = new Random();


        public string Score
        {
            get
            {
                return HomeGoals + "-" + GuestGoals;
            }
            set { }
        }

        public bool Overtime()
        {
            return true;
        }

        public string Minute
        {
            get
            {
                return Min.ToString();
            }

            set { }
        }

        public bool Penalties()  //o sa imi resetez scorul aici in cazul in care se ajunge la penalty-uri
        {
            HomeGoals = 0;
            GuestGoals = 0;
            return true;
        }

        public bool Status()   //si o sa am un while Match.Status == true , do blabla
        {
            return true;
        }

        public string GenerateResult()
        {
            Home.GamesPlayed++;
            Guest.GamesPlayed++;
            IsPlayed = true;

            HomeGoals = rnd.Next(0, 4);
            GuestGoals = rnd.Next(0, 4);

            Home.GoalsFor += HomeGoals;
            Home.GoalsAgainst += GuestGoals;
            Guest.GoalsFor += GuestGoals;
            Guest.GoalsAgainst += HomeGoals;

            if (HomeGoals > GuestGoals)
            {
                //ar trebui sa imi updatez clasamentul 

                Home.Wins++;
                Home.Points += 3;
                Guest.Losses++;
                return Home.Name;
            }
            else if (GuestGoals > HomeGoals)
            {
                Guest.Wins++;
                Guest.Points += 3;
                Home.Losses++;
                return Guest.Name;
            }
            else
            {
                Home.Points++;
                Guest.Points++;
                Home.Draws++;
                Guest.Draws++;
                return "Tie";
            }
        }
    }
}
