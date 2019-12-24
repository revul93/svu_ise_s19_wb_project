using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class EditOrphanage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
            {
                sqlConnection.Open();
                DataTable orphanageTable = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(String.Format("SELECT * FROM [dbo].[Orphanage];"), sqlConnection))
                {
                    sqlDataAdapter.Fill(orphanageTable);
                }

                ListItem firstItem = new ListItem("---- اختر دار أيتام لتعديلها ---", "0");
                firstItem.Attributes["selected"] = "selected";
                firstItem.Attributes["disabled"] = "disabled";
                orphanageDropDownList.Items.Add(firstItem);
                foreach (DataRow row in orphanageTable.Rows)
                {
                    orphanageDropDownList.Items.Add(new ListItem(row["name"].ToString(), row["id"].ToString()));
                }
            }
        }
    }

    protected void orphanageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            SqlDataReader orphanageRow;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = String.Format("SELECT * FROM [dbo].[Orphanage] WHERE id = {0};", orphanageDropDownList.SelectedValue);
                orphanageRow = sqlCommand.ExecuteReader();
                orphanageRow.Read();
                nameTextBox.Text = orphanageRow["name"].ToString();
                descriptionTextBox.Text = orphanageRow["description"].ToString();
                cityTextBox.Text = orphanageRow["address_city"].ToString();
                streetTextBox.Text = orphanageRow["address_street"].ToString();
                addressDescriptionTextBox.Text = orphanageRow["address_description"].ToString();
                coordinateTextBox.Text = orphanageRow["address_coordinates"].ToString();
                telephoneTextBox.Text = orphanageRow["telephone"].ToString();
                emailTextBox.Text = orphanageRow["email"].ToString();
                capacityTextBox.Text = orphanageRow["capacity"].ToString();
                sponsoredOrphansTextBox.Text = orphanageRow["sponsored_orphans"].ToString();
            }

            managerDropDownList.Items.Clear();
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = String.Format("SELECT id, name, orphanage_id FROM [dbo].[User] WHERE orphanage_id IS NULL OR orphanage_id = {0};",
                    int.Parse(orphanageDropDownList.SelectedValue));
                SqlDataReader users = sqlCommand.ExecuteReader();
                while(users.Read())
                {
                    ListItem listItem = new ListItem
                    {
                        Text = users["name"].ToString(),
                        Value = users["id"].ToString()
                    };
                    if (users["orphanage_id"].ToString().Equals(orphanageDropDownList.SelectedValue))
                    {
                        listItem.Attributes["selected"] = "selected";
                    }
                    managerDropDownList.Items.Add(listItem);
                }
            }
        }
    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            SqlDataReader dataReader;
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = String.Format("SELECT * FROM [dbo].[Orphanage] WHERE id = {0};", orphanageDropDownList.SelectedValue);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                int orphanage_id = int.Parse(dataReader["id"].ToString());
                int manager_id = int.Parse(dataReader["manager_id"].ToString());
                dataReader.Close();

                sqlCommand.CommandText = String.Format("UPDATE [dbo].[User] SET orphanage_id = '' WHERE id = {0};", manager_id);
                try
                {
                    sqlCommand.ExecuteScalar();
                }
                catch (SqlException) { 
                    
                };
                sqlCommand.CommandText = String.Format("DELETE FROM [dbo].[Orphanage] WHERE id = {0};", orphanage_id);
                sqlCommand.ExecuteScalar();
                Response.Redirect(Request.RawUrl.ToString());
            }
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
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
                        "UPDATE [dbo].[Orphanage] " +
                        "SET name = N'{0}', " +
                        "description = N'{1}', " +
                        (logoFileUpload.HasFile ? "SET logo = N'{2}', " : "") +
                        "address_city = N'{3}', " +
                        "address_street = N'{4}', " +
                        "address_description = N'{5}', " +
                        "address_coordinates = '{6}', " +
                        "telephone = '{7}', " +
                        "email = '{8}', " +
                        "capacity = '{9}', " +
                        "sponsored_orphans = '{10}'," +
                        "manager_id = {11} " +
                        "WHERE id = {12};" +
                        "SELECT CAST(SCOPE_IDENTITY() AS int);",
                        nameTextBox.Text, descriptionTextBox.Text, logoFileUpload.FileName,
                        cityTextBox.Text, streetTextBox.Text, addressDescriptionTextBox.Text, coordinateTextBox.Text,
                        telephoneTextBox.Text, emailTextBox.Text, int.Parse(capacityTextBox.Text), int.Parse(sponsoredOrphansTextBox.Text),
                        int.Parse(managerDropDownList.SelectedValue), int.Parse(orphanageDropDownList.SelectedValue)
                    );
                    sqlCommand.ExecuteScalar();

                    sqlCommand.CommandText = String.Format("UPDATE [dbo].[User] SET orphanage_id = {0} WHERE id = {1};",
                                                int.Parse(orphanageDropDownList.SelectedValue), int.Parse(managerDropDownList.SelectedValue));
                    sqlCommand.ExecuteScalar();
                    Response.Write("<script>alert('تم حفظ التعديلات بنجاح');</script>");
                }
            }
        }
    }

}