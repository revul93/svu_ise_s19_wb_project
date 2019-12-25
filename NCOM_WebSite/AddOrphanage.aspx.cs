using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class AddOrphanage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
                        "INSERT INTO [dbo].[Orphanage] (name, logo, description, address_city, address_street, address_description," +
                        " address_coordinates, email, telephone, capacity, sponsored_orphans)" +
                        "VALUES(N'{0}', '{1}', N'{2}', N'{3}', N'{4}', N'{5}', '{6}', '{7}', '{8}', '{9}', '{10}');" +
                        "SELECT CAST(SCOPE_IDENTITY() AS int);",
                        nameTextBox.Text, "Images/Orphanages/" + logoFileUpload.FileName, descriptionTextBox.Text, 
                        cityDropDownList.SelectedValue, streetTextBox.Text, addressDescriptionTextBox.Text,
                        coordinateTextBox.Text, emailTextBox.Text, telephoneTextBox.Text,
                        capacityTextBox.Text, sponsoredOrphansTextBox.Text);

                    if (Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0) {
                        if (logoFileUpload.HasFile)
                        {
                            logoFileUpload.SaveAs(Server.MapPath("~/Images/Orphanages/" + logoFileUpload.FileName));
                        }
                        Response.Redirect("OrphanageManagement.aspx");
                    }
                }
                    
            }
        }
    }
}