using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class DonationManagement : System.Web.UI.Page
{
    int user_id, orphanage_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            Response.Redirect("NotAuthorized.aspx");
            return;
        }
        user_id = int.Parse(Session["user_id"].ToString());

        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = String.Format("SELECT orphanage_id FROM [dbo].[User] WHERE id = {0};", user_id);
                orphanage_id = int.Parse(sqlCommand.ExecuteScalar().ToString());

                DataTable dataTable = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(String.Format(
                    "SELECT [Donor].[name] AS donorName, [Donor].[mobile] AS donorMobile, [Donor].[email] AS donorEmail, " +
                    "CONCAT([Donor].[address_city], ', ', [Donor].[address_street], ', ', [Donor].[address_description]) AS donorAddress, " +
                    "[Donation].[Id] As donationId, [Donation].[amount] As donationAmount, [Donation].[method] AS donationMethod, " +
                    "[Donation].[donor_contacted] AS donorContacted, [Donation].[donation_collected] donationCollected, " +
                    "[Plan].[name] AS planName " +
                    "FROM [dbo].[Donor] " +
                    "INNER JOIN[dbo].[Donation] ON [Donor].id = [Donation].[donor_id]" +
                    "INNER JOIN[dbo].[Plan] ON [Donation].[plan_id] = [Plan].[id]" +
                    "WHERE [dbo].[Plan].[orphanage_id] = {0} AND [dbo].[Donation].[hidden] = 0", orphanage_id), sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }

                if (dataTable.Rows.Count == 0)
                {
                    Response.Redirect("NoDonation.aspx");
                }
                else
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        Panel listItem = new Panel();
                        listItem.CssClass = "list-item";

                        Label planName = new Label
                        {
                            Text = dataRow["planName"].ToString(),
                            CssClass = "item-name"
                        };
                        Label donorName = new Label
                        {
                            Text = "اسم المتبرع: " + dataRow["donorName"].ToString(),
                            CssClass = "info"
                        };
                        Label donationMethod = new Label
                        {
                            Text = "طريقة التبرع: " + (
                            dataRow["donationMethod"].ToString() == "physical" ? "عيني" :
                            dataRow["donationMethod"].ToString() == "cash" ? "نقدي" :
                            dataRow["donationMethod"].ToString() == "cheque" ? "شيك" : "حوالة مصرفية"),
                            CssClass = "info"
                        };
                        Label donationAmount = new Label
                        {
                            Text = "الكمية: " + dataRow["donationAmount"].ToString(),
                            CssClass = "info"
                        };
                        Label donorAddress = new Label
                        {
                            Text = "العنوان: " + dataRow["donorAddress"].ToString(),
                            CssClass = "info"
                        };
                        Label donorContacted = new Label
                        {
                            Text = (bool.Parse(dataRow["donorContacted"].ToString()) ? "تم التواصل مع المتبرع" :"لم يتم التواصل مع المتبرع"),
                            CssClass = "info"
                        };
                        Label donationCollected = new Label
                        {
                            Text = (bool.Parse(dataRow["donationCollected"].ToString()) ? "تم تحصيل التبرع" : "لم يتم تحصيل التبرع"),
                            CssClass = "info"
                        };

                        listItem.Controls.Add(planName);
                        listItem.Controls.Add(donorName);
                        listItem.Controls.Add(donationMethod);
                        listItem.Controls.Add(donationAmount);
                        listItem.Controls.Add(donorAddress);
                        listItem.Controls.Add(new Literal
                        {
                            Text = String.Format("<span class=\"info\">الهاتف: <a href=\"tel:{0}\">{0}</a></span>",
                                                    dataRow["donorMobile"])
                        });
                        listItem.Controls.Add(new Literal
                        {
                            Text = String.Format("<span class=\"info\">البريد الإلكتروني: <a href=\"mailto:{0}\">{0}</a></span>",
                            dataRow["donorEmail"])
                        });
                        listItem.Controls.Add(new Literal { Text = "<hr />" });
                        listItem.Controls.Add(donorContacted);
                        listItem.Controls.Add(donationCollected);
                        donationList.Controls.Add(listItem);
                    }
                }
            }
        }
    }
}