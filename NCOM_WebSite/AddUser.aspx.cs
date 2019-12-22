﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (passswordTextBox.Text != confirmTextBox.Text)
            {
                Response.Write("<script>alert('كلمة السر لا تطابق تأكيدها');</script>");
                return;
            }
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

                    sqlCommand.CommandText = String.Format(
                        "INSERT INTO [dbo].[User] (username, password, name, role, mobile, email, is_admin)" +
                        "VALUES('{0}', '{1}', N'{2}', N'{3}', '{4}', '{5}', '{6}');" +
                        "SELECT CAST(SCOPE_IDENTITY() AS int);",
                        usernameTextBox.Text, passswordTextBox.Text, nameTextBox.Text, roleTextBox.Text,
                        mobileTextBox.Text, emailTextBox.Text, isAdminCheckBox.Checked ? "1" : "0");

                    if (Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0)
                    {
                        Response.Write("<script>alert('تم تسجيل المستخدم بنجاح!');</script>");
                    }
                }
            }
        }
    }
}