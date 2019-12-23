using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class AddPlan : System.Web.UI.Page
{
    int userId, orphanageId;
    protected void Page_Load(object sender, EventArgs e)
    {
        userId = 18;
        orphanageId = 25;
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
                        int.Parse(amountTextBox.Text), orphanageId);

                    if (Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0)
                    {
                        Response.Write("<script>alert('!تم إضافة الحملة بنجاح');</script>");
                    }
                }
            }
        }
    }
}