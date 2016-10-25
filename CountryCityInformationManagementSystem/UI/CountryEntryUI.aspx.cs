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
    public partial class CountryEntryUI : System.Web.UI.Page
    {
        string connectionString = @"Server=Mohon;Database=CountryCityManagementSystemDB;Integrated Security=true";
        
        CountryManager countryManager = new CountryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
              //  ShowAllData();
            
                BindGridview();
              
                messageLable.Text = "";
            
        }


        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndexUI.aspx");
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            //using (SqlConnection connection = new SqlConnection(DatabaseConnectionLink.databaseLink))
            //{
            //    Country myCountry = new Country();
            //    myCountry.Name = nameTextBox.Text;

            //    bool IsCountryExist = IsCountryExists(myCountry.Name);
                

            //        connection.Open();
            //        Country country = new Country(nameTextBox.Text, aboutTextBox.Text);
            //        string query = "insert into country values ('" + country.Name + "','" + country.About + "');";

            //        SqlCommand sql = new SqlCommand(query, connection);
            //        try
            //        {
            //            if (IsCountryExist == false)
            //            {
            //                sql.ExecuteNonQuery();
            //                messageLable.Text = "<h3>Save Successfully.</h3>";
            //                messageLable.ForeColor = Color.Green;
            //                //ShowAllData();
            //                BindGridview();
            //            }
            //            else
            //            {
            //                messageLable.Text = "<h3>Data already exists.</h3>";
            //                messageLable.ForeColor = Color.Red;
            //                BindGridview();
            //            }

            //        }
            //        catch (Exception)
            //        {
            //            messageLable.ForeColor = Color.Red;
            //            messageLable.Text = "<h3>Data not saved.</h3>";
            //        }

            //    }

            try
            {
                Country country = new Country();
                country.Name = nameTextBox.Text;
                country.About = aboutTextBox.Text;
                int rowsAffected = countryManager.Save(country);
                if (rowsAffected > 0)
                {
                    messageLable.Text = "<h3>country inserted successfully</h3>";
                    messageLable.ForeColor = Color.Green;
                    BindGridview();
                }
                else
                {
                    messageLable.Text = "</h3>country insert failed</h3>";
                    messageLable.ForeColor = Color.Red;
                }
            }
            catch (Exception exception)
            {
                messageLable.Text = exception.Message;
                messageLable.ForeColor = Color.Red;
            }


            }
        

        protected void BindGridview()
        {
            //DataSet ds = new DataSet();
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("select * from country", con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    da.Fill(ds);
            //    con.Close();
            //    countryListGridView.DataSource = ds;
            //    countryListGridView.DataBind();
            //}

            List<Country> countryList = countryManager.GetAllCountries();
            countryListGridView.DataSource = countryList;
            countryListGridView.DataBind();
        }
        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            countryListGridView.PageIndex = e.NewPageIndex;
            BindGridview();
        }


        private Country GetAllCountryBYcountryName(string countryName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM country WHERE countryName = '" + countryName + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
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
            con.Close();
            return country;
        }

        private bool IsCountryExists(string countryName)
        {
            bool isCountryExists = false;
            Country country = GetAllCountryBYcountryName(countryName);
            if (country != null)
            {
                isCountryExists = true;
            }
            return isCountryExists;
        }

    }
}