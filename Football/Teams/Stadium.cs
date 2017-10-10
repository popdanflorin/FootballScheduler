using System.Collections.Generic;

namespace Football.Business
{
    public class Stadium
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Address { get; set; }
        public int Year { get; set; }
        public string Owner { get; set; }
        public List<string> Teams { get; set; }
        public string FieldSize { get; set; }
        public List<Ambulance> Ambulance { get; set; }
        public int TicketsSold { get; set; }

        public string Profile
        {
            get
            {
                return Name + ", " + Address + ", " + Capacity;
            }
            set { }
        }
    }
}
