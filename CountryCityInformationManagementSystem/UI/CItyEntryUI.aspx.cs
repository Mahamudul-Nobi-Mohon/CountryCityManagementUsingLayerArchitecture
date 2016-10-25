using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CountryCityInformationManagementSystem.Classes;
using CountryCityInformationManagementSystem.Database_Link;
using System.Data;
using CountryCityInformationManagementSystem.BLL;

namespace CountryCityInformationManagementSystem.UI
{
    public partial class CItyEntryUI : System.Web.UI.Page
    {
        string connectionString = @"Server=Mohon;Database=CountryCityManagementSystemDB;Integrated Security=true";
       
        CityManager cityManager = new CityManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindGridview();
                DropdownListBind();
            }


           // ShowAllData();
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndexUI.aspx");
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
           try
            {
                CIty city = new CIty();
                city.Name = nameTextBox.Text;
                city.About = aboutTextBox.Text;
                city.NoOfDwellers = Convert.ToInt32(noOfDwellersTextBox.Text);
                city.Location = locationTextBox.Text;
                city.Weather = weatherTextBox.Text;
               // city.Country.CountryId = Convert.ToInt32(countryDropDownList.SelectedItem);
                city.Country.CountryId = Convert.ToInt32(countryDropDownList.SelectedValue);
                
                int rowsAffected = cityManager.Save(city);
                if (rowsAffected > 0)
                {
                    messageLable.Text = "<h3>Data inserted successfully</h3>";
                    messageLable.ForeColor = Color.Green;
                    BindGridview();
                }
                else
                {
                    messageLable.Text = "</h3>Data insert failed</h3>";
                    messageLable.ForeColor = Color.Red;
                }
            }
            catch (Exception exception)
            {
                messageLable.Text = exception.Message;
                messageLable.ForeColor = Color.Red;
            }



        }


        private CIty GetAllCityByCityName(string cityName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select cityName,city.about,noOfDwellers,location,weather,country.countryName,country.about from city inner join country on country.countryName = city.countryName where cityName ='" + cityName + "'";
                     
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
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
            con.Close();
            return city;
        }

        private bool IsCityExists(string cityName)
        {
            bool isCountryExists = false;
            CIty city = GetAllCityByCityName(cityName);
            if (city != null)
            {
                isCountryExists = true;
            }
            return isCountryExists;
        }


        public void DropdownListBind()
        {

            List<Country> countryList = cityManager.DropdownListBind();
            foreach (Country countryName in countryList)
            {
                countryDropDownList.Items.Add(new ListItem(countryName.Name,
                    Convert.ToInt32(countryName.CountryId).ToString()));
            }

        }

        protected void BindGridview()
        {
            List<CIty> countryList = cityManager.GetAllCities();
            cityListGridView.DataSource = countryList;
            cityListGridView.DataBind();
        }
        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cityListGridView.PageIndex = e.NewPageIndex;
            BindGridview();
        }

    }
}