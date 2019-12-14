using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Manager : System.Web.UI.Page
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
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(String.Format("SELECT * FROM [dbo].[Plan] WHERE OrphanageId = {0}", orphanage_id), sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    int amountCollected;
                    using (SqlCommand readAmountColleected = new SqlCommand())
                    {
                        readAmountColleected.CommandText = String.Format("SELECT SUM(Amount) FROM [dbo].[Donation]" +
                                              "WHERE DonationCollected = 1 AND PlanId = {0}", dataRow["Id"]);
                        readAmountColleected.Connection = sqlConnection;
                        try
                        {
                            amountCollected = int.Parse(readAmountColleected.ExecuteScalar().ToString());
                        }
                        catch (FormatException)
                        {
                            amountCollected = 0;
                        }
                    }

                    planList.Controls.Add(new Literal()
                    {
                        Text = String.Format(
                        "<div class=\"plan\">\n" +
                        "\t<p>\n" +
                        "\t\t<span class=\"planName\">{0}</span><br />" +
                        "\t\t{1}<br />\n" +
                        "\t\tDonation type: {2}<br />\n" +
                        "\t\tAmount Required: {3}<br />\n" +
                        "\t\tAmount Collected: {4}<br />\n" +
                        "\t</p>\n" +
                        "</div>\n",
                        dataRow["Name"], dataRow["Description"], dataRow["Type"], dataRow["AmountRequired"], amountCollected
                        )
                    });
                }
            }
        }
    }
}