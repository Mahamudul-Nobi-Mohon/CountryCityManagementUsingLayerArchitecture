using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CountryCityInformationManagementSystem.Database_Link;
using System.Drawing;
using CountryCityInformationManagementSystem.BLL;
using CountryCityInformationManagementSystem.Classes;

namespace CountryCityInformationManagementSystem.UI
{
    public partial class CityVIewUI : System.Web.UI.Page
    {
        string connectionString = @"Server=Mohon;Database=CountryCityManagementSystemDB;Integrated Security=true";
       
        CityManager cityManager = new CityManager();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropdownListBind();
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            BindGridview();
            //if (cityListGridView.Rows.Count < 1)
            //{
            //    messageLabel.Text = "<h3>No Data Found.</h3>";
            //    //  messageLabel.ForeColor = ConsoleColor.Red;
            //    messageLabel.ForeColor = Color.Red;
            //}
            //else
            //{
              
            //}
        }

        //protected void BindGridview(CIty cityName)
        //{



           // List<CIty> myCIties = cityManager.GetCityByName(cityName.Name);

            //DataSet ds = new DataSet();
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    if (cityNameRadioButton.Checked)
            //    {
            //        string name = cityNameTextBox.Text;
            //        SqlCommand cmd = new SqlCommand("select cityName,city.about,noOfDwellers,location,weather,country.countryName,country.about from city inner join country on country.countryName = city.countryName where cityName ='"+name+"'", con);
            //          SqlDataAdapter da = new SqlDataAdapter(cmd);
            //         da.Fill(ds);
            //    }
            //    else if (countryRadioButton.Checked)
            //    {
            //        string name = cityNameTextBox.Text;
            //        SqlCommand cmd = new SqlCommand("select cityName,city.about,noOfDwellers,location,weather,country.countryName,country.about from city inner join country on country.countryName = city.countryName where country.countryName ='" + countryDropDownList.SelectedItem + "'", con);
            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        da.Fill(ds);
            //    }


            //    con.Close();
            //    cityListGridView.DataSource = ds;
            //    cityListGridView.DataBind();
            //}

        //}

        protected void BindGridview()
        {
            cityListGridView.Visible = false;

            try
            {
                CIty city = new CIty();
                city.Name = cityNameTextBox.Text;
                bool isCountryNameExist;
                if (cityNameRadioButton.Checked)
                {
                    isCountryNameExist = cityManager.IsCityNameExist(city.Name);
                    if (isCountryNameExist == true)
                    {
                        CIty getCityByName = cityManager.GetCityByName(city.Name);
                        List<CIty> aCountry = new List<CIty>();
                        aCountry.Add(getCityByName);
                        cityListGridView.DataSource = aCountry;
                        cityListGridView.DataBind();
                        if (getCityByName.Name != "")
                        {
                            cityListGridView.Visible = true;
                            messageLabel.Text = "";
                        }
                        else
                        {
                            messageLabel.Text = "<h3>Please type a Country Name.</h3>";
                            messageLabel.ForeColor = Color.Red;

                        }
                    }

                    else
                    {
                        messageLabel.Text = "<h3>City Not Found</h3>";
                        messageLabel.ForeColor = Color.Red;

                    }
                }

                else if (countryRadioButton.Checked)
                {
                    isCountryNameExist = cityManager.IsCountryNameExist(countryDropDownList.SelectedItem.ToString());
                    if (isCountryNameExist == true)
                    {
                        CIty GetCountryByName = cityManager.GetCountryByName(countryDropDownList.SelectedItem.ToString());
                        List<CIty> aCountry = new List<CIty>();
                        aCountry.Add(GetCountryByName);
                        cityListGridView.DataSource = aCountry;
                        cityListGridView.DataBind();
                        if (GetCountryByName.Name != "")
                        {
                            cityListGridView.Visible = true;
                            messageLabel.Text = "";
                        }
                        else
                        {
                            messageLabel.Text = "<h3>Please type a Country Name.</h3>";
                            messageLabel.ForeColor = Color.Red;

                        }
                    }

                    else
                    {
                        messageLabel.Text = "<h3>country Not Found</h3>";
                        messageLabel.ForeColor = Color.Red;

                    }
                }

            }
            catch (Exception exception)
            {
                messageLabel.Text = exception.Message;
                messageLabel.ForeColor = Color.Red;

            }


        }
        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cityListGridView.PageIndex = e.NewPageIndex;
            BindGridview();
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
    }
}