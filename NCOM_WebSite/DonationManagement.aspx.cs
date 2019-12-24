using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class DonationManagement : System.Web.UI.Page
{
    int user_id, orphanage_id;

    IDictionary<string, List<CheckBox>> checkBoxes;
    List<Button> saveButtons;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            checkBoxes = new Dictionary<string, List<CheckBox>>();
            saveButtons = new List<Button>();
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
                                Text = "العنوان: " + dataRow["donorAddress"].ToString(),
                                CssClass = "info"
                            };

                            CheckBox donorContacted = new CheckBox();
                            donorContacted.Attributes["runat"] = "server";
                            donorContacted.Checked = bool.Parse(dataRow["donorContacted"].ToString());
                            donorContacted.Text = "تم التواصل مع المتبرع.";

                            CheckBox donationCollected = new CheckBox();
                            donationCollected.Attributes["runat"] = "server";
                            donationCollected.Checked = bool.Parse(dataRow["donationCollected"].ToString());
                            donationCollected.Text = "تم استلام التبرع.";

                            checkBoxes.Add(dataRow["donationId"].ToString(), new List<CheckBox> { donorContacted, donationCollected });

                            Button saveButton = new Button
                            {
                                Text = "حفظ التعديلات",
                                CssClass = "btn btn-success btn-lg form-control button-control"
                            };
                            saveButton.Attributes["runat"] = "server";
                            saveButton.Attributes["AutoPostBack"] = "false";
                            saveButton.ID = "saveButton_" + dataRow["donationId"].ToString();
                            saveButton.Attributes["donation_id"] = dataRow["donationId"].ToString();
                            saveButton.Click += this.SaveChanges;
                            saveButtons.Add(saveButton);

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
                            listItem.Controls.Add(saveButton);
                            donationList.Controls.Add(listItem);
                        }
                    }
                }
            }
        }
    }

    protected void SaveChanges(object sender, EventArgs e)
    {
        Response.Write("<script>alet('OK');</script>");
        Button button = (Button)sender;
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = String.Format(
                        "UPDATE [dbo].[Donation] SET donor_contacted = {0}, donation_collected = {1} " +
                        "WHERE id = {2};",
                        checkBoxes[button.Attributes["donation_id"]][0].Checked,
                        checkBoxes[button.Attributes["donation_id"]][1].Checked,
                        int.Parse(button.Attributes["donation_id"])
                    );
            }
        }
    }
}