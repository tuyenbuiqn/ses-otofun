using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SES.CMS.ofeditor
{
    public partial class Editor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] == null || Session["UserName"] == null)
            {
                Response.Redirect("/ofeditor/Login.aspx");
            }
            else
            {
                lblUserName.Text = Session["UserName"].ToString();
                int userType = int.Parse(Session["UserType"].ToString());
                if (userType == 1)
                { }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
            }
        }
        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Session["UserID"] = null;
            Session["UserType"] = null;
            Session.Abandon();
            Response.Redirect("/ofeditor/Login.aspx");
        }
    }
}