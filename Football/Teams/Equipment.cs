using System.Collections.Generic;

namespace Football.Business
{
    public class Equipment
    {
        public string Brand { get; set; }
        public string ShortsSizeEU { get; set; }
        public string Stockings { get; set; }
        public string Jersey { get; set; }
        public string Colour { get; set; }
        public string Shirt { get; set; }
        public List<string> SponsorTags { get; set; }

        public string OnTheEquipment
        {
            get
            {
                return Brand + " " + SponsorTags;
            }
            set { }
        }

        public string Sizes
        {
            get
            {
                return "Shorts: " + ShortsSizeEU + "\nJersey: " + Jersey + "\nShirt: " + Shirt + "\n";
            }
            set { }
        }
    }
}
