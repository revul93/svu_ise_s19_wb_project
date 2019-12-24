using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class EditUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
            {
                sqlConnection.Open();
                DataTable orphanageTable = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(String.Format("SELECT * FROM [dbo].[User];"), sqlConnection))
                {
                    sqlDataAdapter.Fill(orphanageTable);
                }

                ListItem firstItem = new ListItem("---- اختر مستخدم لتعديل بياناته ---", "0");
                firstItem.Attributes["selected"] = "selected";
                firstItem.Attributes["disabled"] = "disabled";
                userDropDownList.Items.Add(firstItem);
                foreach (DataRow row in orphanageTable.Rows)
                {
                    userDropDownList.Items.Add(new ListItem(row["name"].ToString(), row["id"].ToString()));
                }
            }
        }
    }

    protected void userDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            SqlDataReader userRow;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = String.Format("SELECT * FROM [dbo].[User] WHERE id = {0};", userDropDownList.SelectedValue);
                userRow = sqlCommand.ExecuteReader();
                userRow.Read();
                nameTextBox.Text = userRow["name"].ToString();
                roleTextBox.Text = userRow["role"].ToString();
                mobileTextBox.Text = userRow["mobile"].ToString();
                emailTextBox.Text = userRow["email"].ToString();
                usernameTextBox.Text = userRow["username"].ToString();
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
                    sqlCommand.CommandText = String.Format(
                        "UPDATE [dbo].[User] " +
                        "SET name = N'{0}', " +
                        "role = N'{1}', " +
                        "mobile = N'{2}', " +
                        "email = N'{3}', " +
                        "username = N'{4}' " +
                        "WHERE id = {5};" +
                        "SELECT CAST(SCOPE_IDENTITY() AS int);",
                        nameTextBox.Text, roleTextBox.Text, mobileTextBox.Text, emailTextBox.Text,
                        usernameTextBox.Text, int.Parse(userDropDownList.SelectedValue)
                    );
                    sqlCommand.ExecuteScalar();
                    Response.Write("<script>alert('تم حفظ التعديلات بنجاح');</script>");
                }
            }
        }
    }
}