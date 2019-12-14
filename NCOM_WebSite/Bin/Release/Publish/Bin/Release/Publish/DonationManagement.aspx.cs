using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class DonationManagement : System.Web.UI.Page
{
    int user_id;
    int orphanage_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        user_id = 2;
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = String.Format("SELECT Id FROM [dbo].[Orphanage] WHERE ManagerId = {0}", user_id);
                orphanage_id = int.Parse(sqlCommand.ExecuteScalar().ToString());

                DataTable dataTable = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(String.Format(
                    "SELECT [Donor].[Name] AS donorName, [Donor].[Mobile] AS donorMobile, [Donor].[Email] AS donorEmail, " +
                    "CONCAT([Donor].[Address.City], ',', [Donor].[Address.Street], ',', [Donor].[Address.Description]) AS donorAddress, " +
                    "[Donation].[Amount] As donationAmount, [Donation].[Method] AS donationMethod, " +
                    "[Donation].[DonorContacted] AS donorContacted, [Donation].[DonationCollected] donationCollected, " +
                    "[Plan].[Name] AS planName " +
                    "FROM [dbo].[Donor] " +
                    "INNER JOIN[dbo].[Donation] ON [Donor].Id = [Donation].[DonorId]" +
                    "INNER JOIN[dbo].[Plan] ON [Donation].[PlanId] = [Plan].[Id]" +
                    "WHERE [dbo].[Plan].[OrphanageId] = {0}", orphanage_id), sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }

                if (dataTable.Rows.Count == 0)
                {

                }
                else
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        donationList.Controls.Add(new Literal()
                        {
                            Text = String.Format(
                                "<div class=\"donation\">\n" +
                                "\t<p>\n" +
                                "\t\t<span class=\"planName\">{0}</span><br />" +
                                "\t\tDonor Name: {1}<br />\n" +
                                "\t\tDonation method: {2}<br />\n" +
                                "\t\tAmount: {3}<br />\n" +
                                "\t\tDonor Address: {4}<br />\n" +
                                "\t\tDonor Mobile: {5}<br />\n" +
                                "\t\tDonor Email: {6}<br />\n" +
                                "\t</p>\n" +
                                "</div>\n",
                                dataRow["planName"], dataRow["donorName"], dataRow["donationMethod"], dataRow["donationAmount"],
                                dataRow["donorAddress"], dataRow["donorMobile"], dataRow["donorEmail"]
                            )
                        });
                    }
                }
            }
        }
    }
}