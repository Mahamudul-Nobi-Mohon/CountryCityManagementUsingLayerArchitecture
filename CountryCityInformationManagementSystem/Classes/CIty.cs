using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryCityInformationManagementSystem.Classes
{
    public class CIty
    {
        public string SerialNo { get; set; }
      
        public string Name { get; set; }
        public string About { get; set; }
        public int NoOfDwellers { get; set; }
        public string Location { get; set; }
        public string Weather { get; set; }
        public Country Country { get; set; }

        public CIty()
        {
            Country = new Country();
        }

        public CIty(string name, string about, int noOfDwellers, string location, string weather, Country country)
        {
            this.Name = name;
            this.About = about;
            this.NoOfDwellers = noOfDwellers;
            this.Location = location;
            this.Weather = weather;
            this.Country = country;
        }
    }
}