using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class EditDonation : System.Web.UI.Page
{
    int user_id, orphanage_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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

                    sqlCommand.CommandText = String.Format(
                        "SELECT [Donor].[name] AS donorName, " +
                        "[Donation].[Id] As donationId, " +
                        "[Plan].[name] AS planName " +
                        "FROM [dbo].[Donor] " +
                        "INNER JOIN [dbo].[Donation] ON [Donor].id = [Donation].[donor_id]" +
                        "INNER JOIN [dbo].[Plan] ON [Donation].[plan_id] = [Plan].[id]" +
                        "WHERE [dbo].[Plan].[orphanage_id] = {0} AND [dbo].[Donation].[hidden] = 0", orphanage_id);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        donationDropDownList.Items.Add(new ListItem(
                            dataReader["donorName"].ToString() + ", " + dataReader["planName"].ToString(), dataReader["donationId"].ToString()));
                    }
                }
            }
        }
        deleteButton.OnClientClick = "if (confirm('سيؤدي ذلك إلى حذف التبرع، ولن تتمكن من استعراضه مجددا. استمرار ؟')) this.Click(); else return false;";
    }

    protected void donationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = String.Format(
                        "SELECT [Donor].[name] AS donorName, [Donor].[mobile] AS donorMobile, [Donor].[email] AS donorEmail, " +
                        "CONCAT([Donor].[address_city], ', ', [Donor].[address_street], ', ', [Donor].[address_description]) AS donorAddress, " +
                        "[Donation].[Id] As donationId, [Donation].[amount] As donationAmount, [Donation].[method] AS donationMethod, " +
                        "[Donation].[donor_contacted] AS donorContacted, [Donation].[donation_collected] donationCollected, " +
                        "[Plan].[name] AS planName " +
                        "FROM [dbo].[Donor] " +
                        "INNER JOIN[dbo].[Donation] ON [Donor].id = [Donation].[donor_id]" +
                        "INNER JOIN[dbo].[Plan] ON [Donation].[plan_id] = [Plan].[id]" +
                        "WHERE [dbo].[Donation].[Id] = {0};", donationDropDownList.SelectedValue);
                SqlDataReader donation = sqlCommand.ExecuteReader();
                donation.Read();
                donorNameLabel.Text = donation["donorName"].ToString();
                donorAddressLabel.Text = donation["donorAddress"].ToString();
                telephoneLabel.Text = donation["donorMobile"].ToString();
                emailTextLabel.Text = donation["donorEmail"].ToString();
                planNameLabel.Text = donation["planName"].ToString();
                typeLabel.Text = (donation["donationMethod"].ToString() == "physical" ? "عيني" :
                                    donation["donationMethod"].ToString() == "cash" ? "نقدي" :
                                    donation["donationMethod"].ToString() == "cheque" ? "شيك" : "حوالة مصرفية");
                amountLabel.Text = donation["donationAmount"].ToString();
                donorContactedCheckBox.Checked = bool.Parse(donation["donorContacted"].ToString());
                donationCollectedCheckBox.Checked = bool.Parse(donation["donationCollected"].ToString());
            }
        }
    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = String.Format(
                    "UPDATE [dbo].[Donation] " +
                    "SET hidden = 1 " +
                    "WHERE id = {0};",
                    donationDropDownList.SelectedValue);
                sqlCommand.ExecuteNonQuery();
            }
        }
        Response.Redirect(Request.RawUrl);
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = String.Format(
                    "UPDATE [dbo].[donation] " +
                    "SET donor_contacted = {0}," +
                    "donation_collected = {1} " +
                    "WHERE id = {2};",
                    donorContactedCheckBox.Checked ? 1 : 0,
                    donationCollectedCheckBox.Checked ? 1 : 0,
                    donationDropDownList.SelectedValue);
                sqlCommand.ExecuteNonQuery();
            }
        }
        Response.Redirect(Request.RawUrl);
    }
}