using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] != null)
        {
            Session.Remove("user_id");
            Session.Remove("is_admin");
        }

        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "SELECT COUNT(id) FROM [dbo].[Orphanage];";
                numOrphanages.Text = sqlCommand.ExecuteScalar().ToString();

                sqlCommand.CommandText = "SELECT SUM(sponsored_orphans) FROM [dbo].[Orphanage];";
                numSpoOrphans.Text = sqlCommand.ExecuteScalar().ToString();

                sqlCommand.CommandText = "SELECT COUNT(id) FROM [dbo].[Donor];";
                numDonors.Text = sqlCommand.ExecuteScalar().ToString();

                sqlCommand.CommandText = "SELECT SUM(amount) FROM [dbo].[Donation];";
                totalDonations.Text = sqlCommand.ExecuteScalar().ToString();
            }
        }
    }
}