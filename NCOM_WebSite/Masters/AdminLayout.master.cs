using System;

public partial class Masters_AdminLayout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null || !bool.Parse(Session["is_admin"].ToString()))
        {
            Response.Redirect("NotAuthorized.aspx");
        }
    }
}
