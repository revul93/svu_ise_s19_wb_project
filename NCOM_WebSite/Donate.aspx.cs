using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Donate : System.Web.UI.Page
{
    string connectionString;
    SqlConnection sqlConnection;
    SqlCommand sqlCommand;
    SqlDataReader dataReader;

    protected void ConnectDB()
    {
        connectionString = ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString();
        sqlConnection = new SqlConnection(connectionString);
        sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ConnectDB();
            sqlCommand.CommandText = "SELECT id, name FROM [dbo].[Orphanage];";
            dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                orphanageDropDownList.Items.Add(new ListItem(dataReader["name"].ToString(), dataReader["id"].ToString()));
            }
            dataReader.Close();

            InitiatePlanDropDownList();
            InitiateMethodDropDownList();
            sqlConnection.Close();
        }
    }

    protected void OrphanageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        planDropDownList.Items.Clear();
        ConnectDB();
        InitiatePlanDropDownList();
        sqlConnection.Close();
    }

    protected void planDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        methodDropDownList.Items.Clear();
        ConnectDB();
        InitiateMethodDropDownList();
        sqlConnection.Close();
    }

    protected void InitiatePlanDropDownList()
    {
        sqlCommand.CommandText = String.Format("SELECT id, name, description FROM [dbo].[Plan] WHERE orphanage_id = {0};",
                                                        int.Parse(orphanageDropDownList.SelectedValue));
        dataReader = sqlCommand.ExecuteReader();
        while (dataReader.Read())
        {
            planDropDownList.Items.Add(new ListItem(dataReader["name"].ToString(), dataReader["id"].ToString()));
        }
        dataReader.Close();
    }

    protected void InitiateMethodDropDownList()
    {
        sqlCommand.CommandText = String.Format("SELECT type From [dbo].[plan] WHERE Id = {0}",
                                            int.Parse(planDropDownList.SelectedValue));
        dataReader = sqlCommand.ExecuteReader();
        dataReader.Read();
        if (dataReader["type"].ToString() == "physical")
        {
            methodDropDownList.Items.Add(new ListItem("عيني", "physical"));
        }
        else if (dataReader["type"].ToString() == "cash")
        {
            methodDropDownList.Items.Add(new ListItem("نقدي", "cash"));
            methodDropDownList.Items.Add(new ListItem("شيك", "cheque"));
            methodDropDownList.Items.Add(new ListItem("حوالة مصرفية", "bankTransfer"));
        }

        dataReader.Close();
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        ConnectDB();
        sqlCommand.CommandText = String.Format("INSERT INTO [dbo].[Donor] ([name], [address_City], [address_Street], " +
                                    "[address_description], [mobile], [email]) " +
                                    "VALUES(N'{0}', N'{1}', N'{2}', N'{3}', '{4}', '{5}');" +
                                    "SELECT CAST(SCOPE_IDENTITY() As int)",
                                nameTextBox.Text, cityDropDownList.SelectedValue, streetTextBox.Text, addressTextBox.Text, mobileTextBox.Text, emailTextBox.Text);
        int donor_id = (int.Parse(sqlCommand.ExecuteScalar().ToString()));
        sqlCommand.CommandText = "SELECT SCOPE_IDENTITY();";
        int donorId = Convert.ToInt32(sqlCommand.ExecuteScalar());

        sqlCommand.CommandText = String.Format("INSERT INTO [dbo].[Donation] ([donor_id], [plan_id], [amount], [method]) " +
                                     "VALUES('{0}', '{1}', '{2}', N'{3}'); SELECT CAST(SCOPE_IDENTITY() AS int)",
                                     donorId, planDropDownList.SelectedValue, int.Parse(amountTextBox.Text), methodDropDownList.SelectedValue);
        Response.Write(sqlCommand.CommandText);
        if (Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0) {
            Response.Redirect("Thanks.aspx");
        }
    }
}