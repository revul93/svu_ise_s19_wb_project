using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class AddPlan : System.Web.UI.Page
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
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = String.Format("INSERT INTO [dbo].[Plan] (name, description, type, amount_required, orphanage_id) " +
                        "VALUES(N'{0}', N'{1}', '{2}', {3}, {4});" +
                        "SELECT CAST(SCOPE_IDENTITY() AS int);",
                        nameTextBox.Text, descriptionTextBox.Text, methodDropDownList.SelectedValue == "نقدي" ? "cash" : "physical",
                        int.Parse(amountTextBox.Text), orphanage_id);

                    if (Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0)
                    {
                        Response.Write("<script>alert('!تم إضافة الحملة بنجاح');</script>");
                    }
                }
            }
        }
    }
}