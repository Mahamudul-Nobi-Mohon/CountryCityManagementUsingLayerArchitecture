using CountryCityInformationManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using CountryCityInformationManagementSystem.Database_Link;

namespace CountryCityInformationManagementSystem.DAL
{
    public class CountryGateway
    {
        string connectionString = @"Server=Mohon;Database=CountryCityManagementSystemDB;Integrated Security=true";
       
        public int Save(Country country)
        {
            // Connect to the database

            SqlConnection connection = new SqlConnection(connectionString);
            // write query

            string query = "INSERT INTO country(countryName,about) VALUES('" + country.Name + "','" + country.About + "')";

            SqlCommand command = new SqlCommand(query, connection);
            // execute query
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }
        public List<Country> GetAllCountries()
        {
            List<Country> countryList = new List<Country>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM country ORDER BY countryId DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Country country = new Country();
                    country.Name = reader["countryName"].ToString();
                    country.About = reader["about"].ToString();
                   
                    countryList.Add(country);
                }
                reader.Close();
            }
            connection.Close();
            return countryList;
        }

        public Country GetCountryByName(string countryName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Country WHERE countryName ='" + countryName + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            Country country = null;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                country = new Country();
                country.Name = reader["countryName"].ToString();
                country.About = reader["about"].ToString();
                
                reader.Close();
            }
            connection.Close();
            return country;
        }

        
    }
}