using System.Collections.Generic;


namespace Football.Business
{
    public class Ambulance
    {
        public int DoctorsNo { get; set; }
        public bool Availability { get; set; }
        public int StartYear { get; set; }
        public List<DoctorType> Doctors { get; set; }
    }
}

