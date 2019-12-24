using System;

public partial class ManagerLayout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            Response.Redirect("NotAuthorized.aspx");
        }
    }
}
