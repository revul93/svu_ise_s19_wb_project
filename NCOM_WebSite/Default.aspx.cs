using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "SELECT COUNT(Id) FROM [dbo].[Orphanage];";
                numOrphanages.Text = sqlCommand.ExecuteScalar().ToString();

                sqlCommand.CommandText = "SELECT SUM(SponsoredOrphans) FROM [dbo].[Orphanage];";
                numSpoOrphans.Text = sqlCommand.ExecuteScalar().ToString();

                sqlCommand.CommandText = "SELECT COUNT(Id) FROM [dbo].[Donor];";
                numDonors.Text = sqlCommand.ExecuteScalar().ToString();

                sqlCommand.CommandText = "SELECT SUM(Amount) FROM [dbo].[Donation];";
                totalDonations.Text = sqlCommand.ExecuteScalar().ToString();
            }
        }
    }
}