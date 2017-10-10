using Football.Interfaces;

namespace Football.Business
{
    public class FieldReferee : Person, IAwardSomething
    {
        public int mistakes { get; set; }
        public string DoSomething() {
            return "whistle";
        }

        public void AwardFoul(string team)
        {
        }

        public void AwardPenalty(string team)
        {
        }

        public void AwardYellowCard(Person p)
        {
        }

        public bool StartMatch(string game)
        {
            return true;
        }

        public int AdditionalMinutes(int minutes)    
        {
            return minutes;
        } 

        public bool OverTime()    
        {
            return true;                               
        }

        public bool EndMatch(string game)
        {           
            return true;
        }
    }
}
