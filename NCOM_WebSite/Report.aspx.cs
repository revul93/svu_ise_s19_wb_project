using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
public partial class Report : System.Web.UI.Page
{
    DataTable table;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
            {
                sqlConnection.Open();
                table = new DataTable();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * FROM [dbo].[Orphanage]; ", sqlConnection))
                {
                    dataAdapter.Fill(table);
                }
            }
            foreach (DataRow row in table.Rows)
            {
                orphanageDropDownList.Items.Add(new ListItem(row["name"].ToString(), row["id"].ToString()));
            }
        }
    }

    protected void orphanageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            table = new DataTable();
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(
                                    String.Format(
                                        "SELECT [dbo].[Orphanage].name AS N'اسم الجمعية', [dbo].[Plan].name AS N'اسم الحملة', " +
                                        "SUM(Donation.amount) AS N'المبلغ المجموع', COUNT(Donation.id) AS N'عدد المتبرعين' " +
                                        "FROM Orphanage " + 
                                        "INNER JOIN[dbo].[Plan] ON Orphanage.id = [dbo].[Plan].id " + 
                                        "INNER JOIN Donation ON[dbo].[Plan].id = Donation.id " + 
                                        "WHERE Orphanage.id = {0} AND Donation.donation_collected = 1 " +
                                        "GROUP BY [Orphanage].name, [dbo].[Plan].name;", orphanageDropDownList.SelectedValue),
                                    sqlConnection))
            {
                dataAdapter.Fill(table);
            }
            tableView.DataSource = table;
            tableView.DataBind();
        }
    }
}