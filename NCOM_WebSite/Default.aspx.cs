using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString();
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;

        sqlConnection.Open();
        sqlCommand.CommandText = "SELECT COUNT(Id) FROM Orphanage;";
        numOrphanages.Text = sqlCommand.ExecuteScalar().ToString();

        sqlCommand.CommandText = "SELECT SUM(SponsoredOrphans) FROM Orphanage;";
        numSpoOrphans.Text = sqlCommand.ExecuteScalar().ToString();

        sqlCommand.CommandText = "SELECT COUNT(Id) FROM Donor;";
        numDonors.Text = sqlCommand.ExecuteScalar().ToString();

        sqlCommand.CommandText = "SELECT SUM(Amount) FROM Donation;";
        totalDonations.Text = sqlCommand.ExecuteScalar().ToString();
    }
}