using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    SqlConnection sqlConnection;
    SqlCommand sqlCommand;
    SqlDataReader dataRead;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString());
        sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
        sqlCommand.CommandText = String.Format("SELECT * FROM [dbo].[User] WHERE username = '{0}';", usernameTextBox.Text);
        dataRead = sqlCommand.ExecuteReader();
        if (dataRead.Read())
        {
            if (bool.Parse(dataRead["disabled"].ToString()))
            {
                Response.Write("<script>alert('المستخدم موقوف حاليا، يرجى التواصل مع مدير النظام')</script>");
                return;
            }
            if (dataRead["password"].ToString().Equals(passwordTextBox.Text))
            {
                Session["user_id"] = dataRead["id"].ToString();
                Session["is_admin"] = dataRead["is_admin"].ToString();
                if (bool.Parse(dataRead["is_admin"].ToString()))
                {
                    Response.Redirect("OrphanageManagement.aspx");
                }
                else
                {
                    Response.Redirect("PlanManagement.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('كلمة السر غير صحيحة!')</script>");
                return;
            }
        }
        else
        {
            Response.Write("<script>alert('اسم المستخدم غير موجود')</script>");
            return;
        }
    }
}