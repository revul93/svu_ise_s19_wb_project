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
            sqlCommand.CommandText = "SELECT Id, Name FROM [dbo].[Orphanage];";
            dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                orphanageDropDownList.Items.Add(new ListItem(dataReader["Name"].ToString(), dataReader["Id"].ToString()));
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
        sqlCommand.CommandText = String.Format("SELECT Id, Name, Description FROM [dbo].[Plan] WHERE OrphanageId = {0};",
                                                        int.Parse(orphanageDropDownList.SelectedValue));
        dataReader = sqlCommand.ExecuteReader();
        while (dataReader.Read())
        {
            planDropDownList.Items.Add(new ListItem(dataReader["Name"].ToString(), dataReader["Id"].ToString()));
        }
        dataReader.Close();
    }

    protected void InitiateMethodDropDownList()
    {
        sqlCommand.CommandText = String.Format("SELECT Type From [dbo].[Plan] WHERE Id = {0}",
                                            int.Parse(planDropDownList.SelectedValue));
        dataReader = sqlCommand.ExecuteReader();
        dataReader.Read();
        if (dataReader["Type"].ToString() == "physical")
        {
            methodDropDownList.Items.Add(new ListItem("عيني", "Physical"));
        }
        else if (dataReader["Type"].ToString() == "cash")
        {
            methodDropDownList.Items.Add(new ListItem("نقدي", "cash"));
            methodDropDownList.Items.Add(new ListItem("شيك", "cheque"));
            methodDropDownList.Items.Add(new ListItem("حوالة مصرفية", "bankTransfer"));
        }

        dataReader.Close();
    }
}