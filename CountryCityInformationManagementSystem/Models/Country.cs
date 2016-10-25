using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryCityInformationManagementSystem.Classes
{
    public class Country
    {
        public int CountryId { set; get; }
        public string Name { get; set; }
        public string About { get; set; }

        public Country()
        {
            
        }

        public Country(string name, string about)
        {
            this.Name = name;
            this.About = about;
        }
    }
}