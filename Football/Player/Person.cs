using System;

namespace Football.Business
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }

        public string Profile
        {
            get
            {
                return "Name: " + Name + "\n" + "Birthdate: " + BirthDate + "\n" + "Country: " + Country;
            }
            set { }
        }
    }
}