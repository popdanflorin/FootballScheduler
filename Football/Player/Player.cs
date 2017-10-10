namespace Football.Business
{
    public class Player : Person
    {
        public int Number { get; set; }
        public int SpeedKmH { get; set; }
        public int FootwearSize { get; set; }
        public int ShinGuardsSize { get; set; }
        public int Height { get; set; }

        public byte YellowCards { get; set; }
        public byte RedCards { get; set; }

        public string TotalCards
        {
            get
            {
                return YellowCards.ToString() + "/" + RedCards.ToString();
            }
            private set { }
        }
    }
}
