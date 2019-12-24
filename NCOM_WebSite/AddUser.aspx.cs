using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = String.Format("Select id, name FROM [dbo].[Orphanage];");
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();

                    ListItem firstItem = new ListItem();
                    firstItem.Text = "---- الرجاء اختيار دار الأيتام المسؤول عنها ----";
                    firstItem.Attributes["selected"] = "selected";
                    firstItem.Attributes["disabled"] = "disabled";
                    firstItem.Value = "-1";
                    orphanageDropDownList.Items.Add(firstItem);
                    while (dataReader.Read())
                    {
                        orphanageDropDownList.Items.Add(new ListItem(dataReader["name"].ToString(), dataReader["id"].ToString()));
                    }
                    dataReader.Close();
                }
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
                    sqlCommand.CommandText = String.Format("Select * FROM [dbo].[User] WHERE username = '{0}'", usernameTextBox.Text);
                    if (Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0)
                    {
                        Response.Write("<script>alert('اسم المستخدم مسجل مسبقا لمستخدم آخر !!');</script>");
                        return;
                    }

                    if (int.Parse(orphanageDropDownList.SelectedValue) == -1 )
                    {
                        Response.Write("<script>alert('يحب اختيار دار أيتام لممستخدم !!');</script>");
                        return;
                    }

                    sqlCommand.CommandText = String.Format(
                        "INSERT INTO [dbo].[User] (username, password, name, role, mobile, email, orphanage_id)" +
                        "VALUES(N'{0}', N'{1}', N'{2}', N'{3}', '{4}', '{5}', {6});" +
                        "SELECT CAST(SCOPE_IDENTITY() AS int);",
                        usernameTextBox.Text, passwordTextBox.Text, nameTextBox.Text, roleTextBox.Text,
                        mobileTextBox.Text, emailTextBox.Text, orphanageDropDownList.SelectedValue);

                    if (Convert.ToInt32(sqlCommand.ExecuteScalar().ToString()) > 0)
                    {
                        Response.Redirect("UserManagement.aspx");
                    }
                }
            }
        }
    }
}