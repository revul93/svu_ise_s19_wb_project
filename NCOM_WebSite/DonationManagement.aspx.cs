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

                sqlCommand.CommandText = String.Format("SELECT id FROM [dbo].[Orphanage] WHERE manager_id = {0}", user_id);
                orphanage_id = int.Parse(sqlCommand.ExecuteScalar().ToString());

                DataTable dataTable = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(String.Format(
                    "SELECT [Donor].[name] AS donorName, [Donor].[mobile] AS donorMobile, [Donor].[email] AS donorEmail, " +
                    "CONCAT([Donor].[address_city], ',', [Donor].[address_street], ',', [Donor].[address_description]) AS donorAddress, " +
                    "[Donation].[amount] As donationAmount, [Donation].[method] AS donationMethod, " +
                    "[Donation].[donor_contacted] AS donorContacted, [Donation].[donation_collected] donationCollected, " +
                    "[Plan].[name] AS planName " +
                    "FROM [dbo].[Donor] " +
                    "INNER JOIN[dbo].[Donation] ON [Donor].id = [Donation].[donor_id]" +
                    "INNER JOIN[dbo].[Plan] ON [Donation].[plan_id] = [Plan].[id]" +
                    "WHERE [dbo].[Plan].[orphanage_id] = {0}", orphanage_id), sqlConnection))
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