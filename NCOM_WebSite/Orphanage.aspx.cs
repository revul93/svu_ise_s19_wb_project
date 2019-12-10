using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class Orphanage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString();
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;

        sqlConnection.Open();
        sqlCommand.CommandText = "SELECT * FROM Orphanage;";
        
        SqlDataReader dataReader = sqlCommand.ExecuteReader();
        if (dataReader.Read()) ;

        orphanagesList.Controls.Add(new Literal() { Text = String.Format(
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
            "</div>\n" +
            "<iframe frameborder=\"0\" src=\"https://www.google.com/maps/embed/v1/view?key=AIzaSyDtAg4hm3DCht1NFjtO3UbPtP1rtShz-cs&center={10}&zoom=15\" allowfullscreen></iframe>",
            dataReader["Name"], dataReader["Logo"], dataReader["Description"],
            dataReader["Address.City"], dataReader["Address.Street"], dataReader["Address.Description"],
            dataReader["Capacity"], dataReader["SponsoredOrphans"],
            dataReader["Telephone"], dataReader["Email"],
            dataReader["Address.Coordinates"]
        )});

        dataReader.Close();
        sqlConnection.Close();
    }
}