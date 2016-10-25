using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CountryCityInformationManagementSystem.Classes;

namespace CItyCItyInformationManagementSystem.DAL
{
    public class CItyGateway
    {

        string connectionString = @"Server=Mohon;Database=CountryCItyManagementSystemDB;Integrated Security=true";

        public int Save(CIty city)
        {
            // Connect to the database

            SqlConnection connection = new SqlConnection(connectionString);
            // write query

            string query = "INSERT INTO CIty(CItyName,about,noOfDwellers,location,weather,countryId) VALUES('" +
                           city.Name + "','" + city.About + "','" + city.NoOfDwellers + "','" + city.Location + "','" +
                           city.Weather + "','" + city.Country.CountryId + "')";

            SqlCommand command = new SqlCommand(query, connection);
            // execute query
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public List<CIty> GetAllCities()
        {
            List<CIty> CItyList = new List<CIty>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query =
                "select cityName,city.about,noOfDwellers,location,weather,country.countryName,country.about from city inner join country on country.countryId = city.countryId ";

            //  string query = "SELECT * FROM CIty ORDER BY CItyId DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                     CIty city = new CIty();
                     city.Name = reader["cityName"].ToString();
                     city.About = reader["about"].ToString();
                     city.NoOfDwellers = Convert.ToInt32(reader["noOfDwellers"]);
                     city.Location = reader["location"].ToString();
                     city.Weather = reader["weather"].ToString();
                     city.Country.Name = reader["countryName"].ToString();
                     city.Country.About = reader["about"].ToString();

                    CItyList.Add(city);
                }
                reader.Close();
            }
            connection.Close();
            return CItyList;
        }

        public CIty GetAllByCityName(string cityName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query =
                "select cityName,city.about,noOfDwellers,location,weather,country.countryName,country.about from city inner join country on country.countryId = city.countryId where cityName ='" +
                cityName + "'";

            // string query = "SELECT * FROM CIty WHERE CItyName ='" + CItyName + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            CIty city = null;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                city = new CIty();
                city.Name = reader["cityName"].ToString();
                city.About = reader["about"].ToString();
                city.NoOfDwellers = Convert.ToInt32(reader["noOfDwellers"]);
                city.Location = reader["location"].ToString();
                city.Weather = reader["weather"].ToString();
                city.Country.Name = reader["countryName"].ToString();
                city.Country.About = reader["about"].ToString();

                reader.Close();
            }
            connection.Close();
            return city;
        }

        public CIty GetAllByCountryName(string cityName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query =
                "select cityName,city.about,noOfDwellers,location,weather,country.countryName,country.about from city inner join country on country.countryId = city.countryId where countryName ='" +
                cityName + "'";

            // string query = "SELECT * FROM CIty WHERE CItyName ='" + CItyName + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            CIty city = null;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                city = new CIty();
                city.Name = reader["cityName"].ToString();
                city.About = reader["about"].ToString();
                city.NoOfDwellers = Convert.ToInt32(reader["noOfDwellers"]);
                city.Location = reader["location"].ToString();
                city.Weather = reader["weather"].ToString();
                city.Country.Name = reader["countryName"].ToString();
                city.Country.About = reader["about"].ToString();

                reader.Close();
            }
            connection.Close();
            return city;
        }

        //internal int Save(Country city)
        //{
        //    throw new NotImplementedException();
        //}
        //public List<CIty> DropdownListBing2()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string query = "select countryId,countryName from country;";

        //        List<CIty> myCIties = new List<CIty>();
        //        SqlCommand sql = new SqlCommand(query, connection);
        //        SqlCommand sqlCountry = new SqlCommand(query, connection);
        //        SqlDataReader sqlDataReader = sqlCountry.ExecuteReader();
        //        while (sqlDataReader.Read())
        //        {
        //            CIty addCity = sqlDataReader[0].ToString();
        //            myCIties.Add(addCity);
        //            // countryDropDownList.Items.Add(sqlDataReader[0].ToString());
        //        }
        //        return myCIties;
        //    }
        //}

        public List<Country> DropdownListBing()
        {
            List<Country> CountryList = new List<Country>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select countryId,countryName from country";

            //  string query = "SELECT * FROM CIty ORDER BY CItyId DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Country country = new Country();
                    country.CountryId = Convert.ToInt32(reader["countryId"].ToString());
                    country.Name = reader["countryName"].ToString();

                    CountryList.Add(country);
                }
                reader.Close();
            }
            connection.Close();
            return CountryList;
        }



        public List<String> GetAllCountryName()
        {
            List<string> CountryList = new List<string>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select countryName from country ";

            //  string query = "SELECT * FROM CIty ORDER BY CItyId DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //CIty city = new CIty();
                    //city.Name = reader["cityName"].ToString();
                    //// city.About = reader["about"].ToString();
                    //city.NoOfDwellers = Convert.ToInt32(reader["noOfDwellers"]);
                    //// city.Location = reader["location"].ToString();
                    //// city.Weather = reader["weather"].ToString();
                    //city.Country.Name = reader["countryName"].ToString();
                    //// city.Country.About = reader["about"].ToString();
                    string addCountryName = reader[0].ToString();
                    CountryList.Add(addCountryName);
                   // CountryList.Add(city);
                }
                reader.Close();
            }
            connection.Close();
            return CountryList;
        }

    }
}