using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class Manager : System.Web.UI.Page
{
    int user_id;
    int orphanage_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null) {
            Response.Redirect("NotAuthorized.aspx");
            return;
        }
        user_id = int.Parse(Session["user_id"].ToString());
        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnection"].ToString()))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = String.Format("SELECT orphanage_id FROM [dbo].[User] WHERE id = {0};", user_id);
                orphanage_id = int.Parse(sqlCommand.ExecuteScalar().ToString());

                DataTable dataTable = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(String.Format("SELECT * FROM [dbo].[Plan] WHERE orphanage_id = {0};", orphanage_id), sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
                if (dataTable.Rows.Count == 0)
                {
                    Response.Redirect("NoPlans.aspx");
                }

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    int amountCollectedValue;
                    using (SqlCommand readAmountColleected = new SqlCommand())
                    {
                        readAmountColleected.CommandText = String.Format("SELECT SUM(amount) FROM [dbo].[Donation]" +
                                                "WHERE donation_collected = 1 AND plan_id = {0}", dataRow["id"]);
                        readAmountColleected.Connection = sqlConnection;
                        try
                        {
                            amountCollectedValue = int.Parse(readAmountColleected.ExecuteScalar().ToString());
                        }
                        catch (FormatException)
                        {
                            amountCollectedValue = 0;
                        }
                    }

                    Label itemName = new Label
                    {
                        Text = dataRow["name"].ToString(),
                        CssClass = "item-name"
                    };
                    Label itemDescription = new Label
                    {
                        Text = dataRow["description"].ToString(),
                        CssClass = "item-description"
                    };
                    Literal info = new Literal
                    {
                        Text = String.Format(
                            "\t<p><span class=\"info\">طريقة التبرع: " + "{0}</span><br />\n" +
                            "\t\t<span class=\"info\">الكمية المطلوبة: " + "{1}</span><br />\n" +
                            "\t\t<span class=\"info\">الكمية المحصلة: " + "{2}</span><br /></p>\n",
                            dataRow["type"].ToString().Equals("cash") ? "نقدي" : "عيني", dataRow["amount_required"], amountCollectedValue)
                    };

                    HtmlForm form = new HtmlForm();
                    form.Method = "POST";
                    form.Attributes["runAt"] = "server";
                    form.Attributes["AutoPostBack"] = "false";

                    Panel listItem = new Panel();
                    listItem.CssClass = "list-item";
                    listItem.Controls.Add(itemName);
                    listItem.Controls.Add(itemDescription);
                    listItem.Controls.Add(info);
                    listItem.Controls.Add(form);

                    planList.Controls.Add(listItem);
                }
            }
        }
    }
}