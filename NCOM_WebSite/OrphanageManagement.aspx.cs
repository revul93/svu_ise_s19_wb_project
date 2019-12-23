using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class OrphanageManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
            {
                sqlConnection.Open();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [dbo].[Orphanage]", sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }

            foreach (DataRow dataRow in dataTable.Rows)
            {
                orphanagesList.Controls.Add(new Literal()
                {
                    Text = String.Format(
                    "<div class=\"list-item\">\n" +
                    "<img class=\"logo\" src=\"{1}\" alt=\"Logo of {0}\" />" +
                    "<p class=\"item-name\">{0}</p><br />\n" +
                    "<p class=\"item-description\">{2}</p><br />\n" +
                    "<p class=\"quatnity\">السعة: " + "{3}, " + "عدد الأيتام المكفولين:  " + "{4}</p><br />\n" +
                    "<address>\n" +
                    "{5}, {6}, {7}<br />\n" +
                    "<span class=\"info\"><i class=\"fas fa-phone-alt\"></i><a href=\"tel:{8}\">{8}</a></span>\n" +
                    "<span class=\"info\"><i class=\"fas fa-at\"></i><a href=\"mailto:{9}\">{9}</a><br /></span>\n" +
                    "</address>\n" +
                    "<iframe frameborder=\"0\" src=\"https://www.google.com/maps/embed/v1/view?key=AIzaSyDtAg4hm3DCht1NFjtO3UbPtP1rtShz-cs&center={10}&zoom=15\" allowfullscreen></iframe>" +
                    "</div>\n",

                        dataRow["name"], dataRow["logo"], dataRow["description"], dataRow["capacity"], dataRow["sponsored_orphans"],
                        dataRow["address_city"], dataRow["address_street"], dataRow["address_description"], dataRow["telephone"], dataRow["email"],
                        dataRow["address_coordinates"]
                    )
                });
            }
            dataTable.Dispose();
        }
    }
}