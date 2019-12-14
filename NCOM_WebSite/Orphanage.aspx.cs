using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Orphanage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Orphanage", sqlConnection))
            {
                sqlDataAdapter.Fill(dataTable);
            }
        }

        foreach (DataRow dataRow in dataTable.Rows)
        {
            orphanagesList.Controls.Add(new Literal()
            {
                Text = String.Format(
                "<div class=\"orphanage\">\n" +
                "<img src=\"{1}\" alt=\"Logo of {0}\" />" +
                "<address>\n" +
                "<span class=\"orphanageName\">{0}</span><br />\n" +
                "{2}<br />\n" +
                "{3}, {4}, {5}<br />\n" +
                "Capacity: {6}, Number of sponsored Orphans: {7}<br />\n" +
                "<a href=\"tel:{8}\">{8}</a><br />\n" +
                "<a href=\"mailto:{9}\">{9}</a><br />\n" +
                "</address>\n" +
                "<iframe frameborder=\"0\" src=\"https://www.google.com/maps/embed/v1/view?key=AIzaSyDtAg4hm3DCht1NFjtO3UbPtP1rtShz-cs&center={10}&zoom=15\" allowfullscreen></iframe>" +
                "</div>\n",
                    dataRow["Name"], dataRow["Logo"], dataRow["Description"],
                    dataRow["Address.City"], dataRow["Address.Street"], dataRow["Address.Description"],
                    dataRow["Capacity"], dataRow["SponsoredOrphans"],
                    dataRow["Telephone"], dataRow["Email"],
                    dataRow["Address.Coordinates"]
                )
            });
        }
        dataTable.Dispose();
    }
}