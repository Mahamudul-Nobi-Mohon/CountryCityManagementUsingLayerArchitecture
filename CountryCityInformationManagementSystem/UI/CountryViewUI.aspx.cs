using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CountryCityInformationManagementSystem.Classes;
using CountryCityInformationManagementSystem.Database_Link;
using System.Drawing;
using CountryCityInformationManagementSystem.BLL;


namespace CountryCityInformationManagementSystem.UI
{
    public partial class CountryViewUI : System.Web.UI.Page
    {
        CountryManager countryManager = new CountryManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            messageLabel.Text = "";
            
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            BindGridview();
        }


        protected void BindGridview()
        {
            countryListGridView.Visible = false;
           
            try
            {
                Country country = new Country();
                country.Name = countryNameTextBox.Text;
                bool isCountryNameExist = countryManager.IsCountryNameExist(country.Name);
                if (isCountryNameExist == true)
                {
                   Country getCountryByName = countryManager.GetCountryByName(country.Name);
                    List<Country> aCountry = new List<Country>();
                    aCountry.Add(getCountryByName);
                   countryListGridView.DataSource = aCountry;
                   countryListGridView.DataBind();
                   if (getCountryByName.Name != "")
                    {
                        countryListGridView.Visible = true;
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
            catch (Exception exception)
            {
                messageLabel.Text = exception.Message;
                messageLabel.ForeColor = Color.Red;
                
            }

            
        }
        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            countryListGridView.PageIndex = e.NewPageIndex;
            BindGridview();
        }

    }
}