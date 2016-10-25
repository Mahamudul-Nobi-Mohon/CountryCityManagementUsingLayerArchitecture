using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CItyCItyInformationManagementSystem.DAL;
using CountryCityInformationManagementSystem.Classes;
using CountryCityInformationManagementSystem.DAL;

namespace CountryCityInformationManagementSystem.BLL
{
    public class CityManager
    {
        CItyGateway cItyGateway = new CItyGateway();
       
        public int Save(CIty city)
        {
            if (IsCityNameExist(city.Name))
            {
                throw new Exception("<h3>City Name already exist</h3>");
            }
            return cItyGateway.Save(city);
        }


        public List<CIty> GetAllCities()
        {
            return cItyGateway.GetAllCities();
        }


        public CIty GetCityByName(string cityName)
        {
            return cItyGateway.GetAllByCityName(cityName);
        }

        public CIty GetCountryByName(string countryName)
        {
            return cItyGateway.GetAllByCountryName(countryName);
        }

        public bool IsCityNameExist(string cityName)
        {
            bool isCityNameExist = false;
            CIty city = GetCityByName(cityName);
            if (city != null)
            {
                isCityNameExist = true;
            }
            return isCityNameExist;

        }

        public bool IsCountryNameExist(string cityName)
        {
            bool isCountryNameExist = false;
            CIty city = GetCountryByName(cityName);
            if (city != null)
            {
                isCountryNameExist = true;
            }
            return isCountryNameExist;

        }

        public List<Country> DropdownListBind()
        {
            return cItyGateway.DropdownListBing();
        }

    }
}