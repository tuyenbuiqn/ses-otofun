﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.DO;
using SES.CMS.BL;
using SES.CMS.AdminCP;
using System.Data;

namespace SES.CMS.WEB.AdminCP.PageUC
{
    public partial class ucListUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadUser();
        }

        private void LoadUser()
        {
            gvUser.DataSource = new sysUserBL().SelectAll();
            gvUser.DataBind();
        }

        protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUser.PageIndex = e.NewPageIndex;
            LoadUser();
        }

        protected void ddlNhomQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int UserType = int.Parse(ddlNhomQuyen.SelectedValue);
            DataTable dtUser = new sysUserBL().SelectAll();
            if (UserType == -1)
                gvUser.DataSource = dtUser;
            else
                gvUser.DataSource = new DataView(dtUser, " UserType = " + UserType, "", DataViewRowState.CurrentRows);
            gvUser.DataBind();

        }
        protected void gvUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                new sysUserBL().Delete(new sysUserDO { UserID = Convert.ToInt32(gvUser.DataKeys[e.RowIndex].Value) });
                Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
            }
            catch
            {
                Functions.Alert("Có lỗi xảy ra!", Request.Url.ToString());
            }
        }

        protected void gvUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(gvUser.DataKeys[gvUser.SelectedIndex].Value);
            Functions.RedirectPage("Default.aspx?Page=User&UserID=" + UserID.ToString());
        }
    }
}