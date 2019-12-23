using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class EditOrphanage : System.Web.UI.Page
{
    DataTable orphanageTable;
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                orphanageTable = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(String.Format("SELECT * FROM [dbo].[Orphanage];"), sqlConnection))
                {
                    sqlDataAdapter.Fill(orphanageTable);
                }
                if (orphanageTable.Rows.Count < 1)
                {
                    Response.Write("<script>لا يوجد دور أيتام لتعديلها !</script>");
                    return;
                }
                else
                {
                    foreach(DataRow row in orphanageTable.Rows)
                    {
                        orphanageDropDownList.Items.Add(new ListItem(row["name"].ToString(), row["id"].ToString()));
                    }
                }
            }
        }
    }

    protected void editButton_Click(object sender, EventArgs e)
    {
        subPanel.Controls.Clear();

        TextBox nameTextBox = new TextBox
        {
            Text = orphanageTable.Rows[0]["name"].ToString(),
            ID = "nameTextBox",
            CssClass = "form-control"
        };
        Label nameLabel = new Label
        {
            Text = "اسم الدار",
            AssociatedControlID = "nameTextBox"
        };
        RequiredFieldValidator nameValidator = new RequiredFieldValidator
        {
            ControlToValidate = nameTextBox.ID,
            CssClass = "validation",
            ErrorMessage = "لا يمكن أن يكون اسم الدار فارغا"
        };

        TextBox descriptionTextBox = new TextBox
        {
            Text = orphanageTable.Rows[0]["description"].ToString(),
            ID = "descriptionTextBox",
            TextMode = TextBoxMode.MultiLine,
            CssClass = "form-control"
        };
        Label descriptionLabel = new Label
        {
            Text = "وصف الدار",
            AssociatedControlID = "descriptionTextBox"
        };
        RequiredFieldValidator descriptionValidator = new RequiredFieldValidator
        {
            ControlToValidate = descriptionTextBox.ID,
            CssClass = "validation",
            ErrorMessage = "لا يمكن أن يكون وصف الدار فارغا"
        };

        FileUpload logoFileUpload = new FileUpload
        {
            ID = "logoFileUpload",
            CssClass = "form-control"
        };
        Label logoFLabel = new Label
        {
            Text = "شعار الدار",
            AssociatedControlID = logoFileUpload.ID
        };




        subPanel.Controls.Add(nameLabel);
        subPanel.Controls.Add(nameTextBox);
        subPanel.Controls.Add(nameValidator);
        subPanel.Controls.Add(descriptionLabel);
        subPanel.Controls.Add(descriptionTextBox);
        subPanel.Controls.Add(descriptionValidator);
        subPanel.Controls.Add(logoFLabel);
        subPanel.Controls.Add(logoFileUpload);
        
    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        subPanel.Controls.Clear();


    }
}