using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using System.Data;
namespace SES.CMS.AdminCP.PageUC
{
    public partial class ucXetDuyetBaiViet : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvAt.DataSource = new cmsArticleBL().SelectAll();
                gvAt.DataBind();
                Functions.ddlDatabinder(cboCategory, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectAll());

                Functions.ddlDatabinder(ddlUserCreate, sysUserDO.USERID_FIELD,sysUserDO.USERNAME_FIELD,new sysUserBL().SelectAll());
            }


        }

        protected void gvArticle_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

        }

        protected void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex <= 0)
            {
                gvAt.DataSource = new cmsArticleBL().SelectAll();
                gvAt.DataBind();
            }
            else
            {
                Functions.GvDatabinder(gvAt, new cmsArticleBL().SelectByCategoryID(int.Parse(cboCategory.SelectedValue)));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?Page=Article");
        }



        protected void gvAt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ArticleID = int.Parse(gvAt.DataKeys[gvAt.SelectedIndex].Value.ToString());
            Response.Redirect("Default.aspx?Page=Article&ArticleID=" + ArticleID.ToString());
        }

        protected void gvAt_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new cmsArticleBL().Delete(new cmsArticleDO { ArticleID = Convert.ToInt32(gvAt.DataKeys[e.RowIndex].Value) });
            Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(ddlUserCreate.SelectedValue.ToString());
            int categoryID = int.Parse(cboCategory.SelectedValue.ToString());
            int isAccepted = int.Parse(ddlTrangThai.SelectedValue.ToString());
            gvAt.DataSource = new cmsArticleBL().ArticleXetDuyet_Filter(categoryID, isAccepted,userID);
            gvAt.DataBind();

        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            string articleList = "";
            for (int i = 0; i < gvAt.Rows.Count; i++)
            {
                GridViewRow row = gvAt.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    articleList += gvAt.DataKeys[row.RowIndex].Value.ToString() + ",";
                }
            }
            articleList += "-9999";
            if (articleList.Equals("-9999"))
            {
                Functions.Alert("Vui lòng chọn bài viết");
                return;
            }
            else
            {
                int userXetDuyet = int.Parse(Session["UserID"].ToString());
                new cmsArticleBL().XetDuyetNhieuBaiViet(articleList, true, userXetDuyet);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "otofun.net", "alert('Xét duyệt thành công!');window.open('Default.aspx?Page=XetDuyetBaiViet','_self');", true);
            }
        }

        protected void btnNotAccept_Click(object sender, EventArgs e)
        {
            string articleList = "";
            for (int i = 0; i < gvAt.Rows.Count; i++)
            {
                GridViewRow row = gvAt.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    articleList += gvAt.DataKeys[row.RowIndex].Value.ToString() + ",";
                }
            }
            articleList += "-9999";
            if (articleList.Equals("-9999"))
            {
                Functions.Alert("Vui lòng chọn bài viết");
                return;
            }
            else
            {
                int userXetDuyet = int.Parse(Session["UserID"].ToString());
                new cmsArticleBL().XetDuyetNhieuBaiViet(articleList, false, userXetDuyet);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "otofun.net", "alert('Xét duyệt thành công!');window.open('Default.aspx?Page=XetDuyetBaiViet','_self');",true);
            }
        }

        protected void gvAt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAt.PageIndex = e.NewPageIndex;
            int userID = int.Parse(ddlUserCreate.SelectedValue.ToString());
            int categoryID = int.Parse(cboCategory.SelectedValue.ToString());
            int isAccepted = int.Parse(ddlTrangThai.SelectedValue.ToString());
            gvAt.DataSource = new cmsArticleBL().ArticleXetDuyet_Filter(categoryID, isAccepted, userID);
            gvAt.DataBind();
        }
    }
}