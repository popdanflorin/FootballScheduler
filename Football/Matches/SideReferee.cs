using Football.Interfaces;

namespace Football.Business
{
    public class SideReferee : Person, IAwardSomething
    {
        public string DoSomething()
        {
            return "Raise flag, signal fieldReferee";
        }
    }
}
