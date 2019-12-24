using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class UserManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
            {
                sqlConnection.Open();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [dbo].[User]", sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                usersList.Controls.Add(new Literal()
                {
                    Text = String.Format(
                    "<div class=\"list-item\">\n" +
                    "<p class=\"item-name\">{0}</p><br />\n" +
                    "<p class=\"item-description\">" + "الوظيفة: " + " {1}<br />" + "اسم المستخدم: " + "{2}</p><br />\n" +
                    "<address>\n" +
                    "<span class=\"info\"><i class=\"fas fa-phone-alt\"></i><a href=\"tel:{3}\">{3}</a></span>\n" +
                    "<span class=\"info\"><i class=\"fas fa-at\"></i><a href=\"mailto:{4}\">{4}</a><br /></span>\n" +
                    "</address>\n" +
                    "</div>\n",
                        dataRow["name"], dataRow["role"], dataRow["username"], dataRow["mobile"], dataRow["email"]
                    )
                });
            }
            dataTable.Dispose();
        }
    }
}