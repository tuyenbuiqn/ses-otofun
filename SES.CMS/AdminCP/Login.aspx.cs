﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SES.CMS.BL;
using SES.CMS.DO;

namespace SES.CMS.AdminCP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            if (Request.QueryString["Option"] != null)
                if (Request.QueryString["Option"].ToString() == "Logout")
                    Session.RemoveAll();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string txtPass = Functions.EncryptMd5(txtPassword.Text);
            DataTable dtUser = new sysUserBL().SelectLogin(txtUsername.Text, txtPass);
            if (dtUser.Rows.Count > 0)
            {
                int UserType;
                if (dtUser.Rows[0]["UserType"] != null)
                {
                    UserType = int.Parse(dtUser.Rows[0]["UserType"].ToString());
                    if (UserType == 2 || UserType == 3)
                    {
                        Session["UserType"] = UserType;
                        Session["Username"] = dtUser.Rows[0]["Username"].ToString();
                        Session["UserID"] = dtUser.Rows[0]["UserID"].ToString();
                        Response.Redirect("Default.aspx");
                    }
                    else Functions.Alert("Bạn không có quyền vào trang quản trị!", Request.Url.ToString());
                }
            }
            else
            {
                Functions.Alert("Sai tên đăng nhập hoặc mật khẩu", Request.Url.ToString());
            }
        }
    }
}
