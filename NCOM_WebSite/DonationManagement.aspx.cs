using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class DonationManagement : System.Web.UI.Page
{
    int user_id;
    int orphanage_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        user_id = 3;
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
                    "CONCAT([Donor].[address_city], ', ', [Donor].[address_street], ', ', [Donor].[address_description]) AS donorAddress, " +
                    "[Donation].[Id] As donationId, [Donation].[amount] As donationAmount, [Donation].[method] AS donationMethod, " +
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
                            Text = "طريقة التبرع: " + dataRow["donorAddress"].ToString(),
                            CssClass = "info"
                        };

                        CheckBox donorContacted = new CheckBox();
                        donorContacted.Attributes["donationId"] = dataRow["donationId"].ToString();
                        donorContacted.Checked = bool.Parse(dataRow["donorContacted"].ToString());
                        donorContacted.Text = "تم التواصل مع المتبرع.";
                        donorContacted.CheckedChanged += this.IsContacted;

                        CheckBox donationCollected = new CheckBox();
                        donationCollected.Attributes["donationId"] = dataRow["donationId"].ToString();
                        donationCollected.Checked = bool.Parse(dataRow["donationCollected"].ToString());
                        donationCollected.Text = "تم استلام التبرع.";
                        donorContacted.CheckedChanged += this.IsCollected;


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
                        listItem.Controls.Add(new Literal { Text = "<hr />"});
                        listItem.Controls.Add(donorContacted);
                        listItem.Controls.Add(donationCollected);
                        donationList.Controls.Add(listItem);
                    }
                }
            }
        }
    }

    protected void IsContacted(object sender, EventArgs e)
    {
        
    }

    protected void IsCollected(object sender, EventArgs e)
    {
        
    }
}