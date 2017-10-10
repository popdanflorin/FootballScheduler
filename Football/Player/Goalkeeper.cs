namespace Football.Business
{
    public class Goalkeeper : Player
    {
        public string SaveTechnique { get; set; }
        public string PreferredFoot { get; set; }
        public bool NationalTeam { get; set; }
        public int Saved { get; set; }
        public int Conceded { get; set; }
        public string SavedGoals
        {
            get
            {
                return Saved.ToString() + "/" + (Saved+Conceded).ToString();
            }
            set { }
        }
        public bool Dive()
        {
            return true;
        }
        public bool Save()
        {
            return true;
        }
    }
}
