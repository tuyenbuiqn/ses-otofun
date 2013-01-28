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
            new SES.CMS.BL.cmsArticleBL().AutoPublish();
            if (Session["UserType"] == null || Session["UserName"] == null)
            {
                Response.Redirect("/ofeditor/Login.aspx");
            }
            else
            {
                lblUserName.Text = Session["UserName"].ToString();
                int userType = int.Parse(Session["UserType"].ToString());
                if (userType <= 3)
                {
                    LoadMenu(userType);
                }
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

        protected void LoadMenu(int userType)
        {
            if (userType == 0) //PV
            {
                divPV.Visible = true;
                divBTV.Visible = false;
                divTK.Visible = false;

                hplDuyetBinhLuan.Visible = false;
                hplQuanLyChung.Visible = false;
                hplThongKeNhuanBut.Visible = false;
            }
            else if (userType == 1) // BTV
            {
                divBTV.Visible = true;
                divPV.Visible = false;
                divTK.Visible = false;

                hplThongKeNhuanBut.Visible = false;
                hplQuanLyChung.Visible = false;
            }
            else if (userType == 2) //TK
            {
                divTK.Visible = true;
                divPV.Visible = false;
                divBTV.Visible = false;
            }
        }
    }
}