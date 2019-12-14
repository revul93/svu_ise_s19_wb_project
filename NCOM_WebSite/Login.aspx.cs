using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

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
        if (usernameTextBox.Text.Equals(String.Empty) || passwordTextBox.Text.Equals(String.Empty))
        {
            return;
        }
        else
        {
            sqlCommand.CommandText = String.Format("SELECT * FROM [dbo].[User] WHERE Username = '{0}';", usernameTextBox.Text);
            dataRead = sqlCommand.ExecuteReader();
            if (dataRead.Read())
            {
                if (dataRead["Password"].ToString().Equals(passwordTextBox.Text))
                {
                    if (!bool.Parse(dataRead["isAdmin"].ToString()))
                    {
                        Response.Redirect("PlanManagement.aspx");
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                return;
            }
        }
        
    }
}