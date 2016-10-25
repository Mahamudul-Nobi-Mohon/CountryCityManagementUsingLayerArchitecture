using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CountryCityInformationManagementSystem.Classes;
using CountryCityInformationManagementSystem.DAL;

namespace CountryCityInformationManagementSystem.BLL
{
    public class CountryManager
    {

        CountryGateway countryGateway = new CountryGateway();

        public int Save(Country country)
        {
            if (IsCountryNameExist(country.Name))
            {
                throw new Exception("Country Name already exist");
            }
            return countryGateway.Save(country);
        }


        public List<Country> GetAllCountries()
        {
            return countryGateway.GetAllCountries();
        }

       
        public Country GetCountryByName(string countryName)
        {
            return countryGateway.GetCountryByName(countryName);
        }
        public bool IsCountryNameExist(string countryName)
        {
            bool isCountryNameExist = false;
            Country country = GetCountryByName(countryName);
            if (country != null)
            {
                isCountryNameExist = true;
            }
            return isCountryNameExist;

        }

    }
}