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
    public partial class ucDuyetComment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                gvAt.DataSource = new cmsCommentBL().SelectAll();
                gvAt.DataBind();
                Functions.ddlDatabinder(ddlArticle, cmsArticleDO.ARTICLEID_FIELD, cmsArticleDO.TITLE_FIELD, new cmsArticleBL().SelectAll());
                Functions.ddlDatabinder(ddlUserCreate, sysUserDO.USERID_FIELD, sysUserDO.USERNAME_FIELD, new sysUserBL().SelectAll());
            }
        }

        protected void gvArticle_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
        }
        protected void ddlArticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlArticle.SelectedIndex <= 0)
            {
                gvAt.DataSource = new cmsCommentBL().SelectAll();
                gvAt.DataBind();
            }
            else
            {
                Functions.GvDatabinder(gvAt, new cmsCommentBL().SelectByArt(int.Parse(ddlArticle.SelectedValue)));
            }
        }

        protected void gvAt_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new cmsCommentBL().Delete(new cmsCommentDO { CommentID = Convert.ToInt32(gvAt.DataKeys[e.RowIndex].Value) });
            Functions.Alert("Xóa bình luận thành công!", Request.Url.ToString());
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(Session["UserID"].ToString());
            int articleID = int.Parse(ddlArticle.SelectedValue.ToString());
            int isAccepted = int.Parse(ddlTrangThai.SelectedValue.ToString());
            gvAt.DataSource = new cmsCommentBL().CommentXetDuyet_Filter(articleID, isAccepted, userID);
            gvAt.DataBind();
        }
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            string commentList = "";
            for (int i = 0; i < gvAt.Rows.Count; i++)
            {
                GridViewRow row = gvAt.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    commentList += gvAt.DataKeys[row.RowIndex].Value.ToString() + ",";
                }
            }
            commentList += "-9999";
            if (commentList.Equals("-9999"))
            {
                Functions.Alert("Vui lòng chọn bài viết");
                return;
            }
            else
            {
                int userXetDuyet = int.Parse(Session["UserID"].ToString());
                new cmsCommentBL().XetDuyetNhieuBinhLuan(commentList, true, userXetDuyet);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "otofun.net", "alert('Xét duyệt thành công!');window.open('Default.aspx?Page=DuyetComment','_self');", true);
            }
        }
        protected void btnNotAccept_Click(object sender, EventArgs e)
        {
            string commentList = "";
            for (int i = 0; i < gvAt.Rows.Count; i++)
            {
                GridViewRow row = gvAt.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    commentList += gvAt.DataKeys[row.RowIndex].Value.ToString() + ",";
                }
            }
            commentList += "-9999";
            if (commentList.Equals("-9999"))
            {
                Functions.Alert("Vui lòng chọn bài viết");
                return;
            }
            else
            {
                int userXetDuyet = int.Parse(Session["UserID"].ToString());
                new cmsCommentBL().XetDuyetNhieuBinhLuan(commentList, false, userXetDuyet);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "otofun.net", "alert('Xét duyệt thành công!');window.open('Default.aspx?Page=DuyetComment','_self');", true);
            }
        }
        protected void gvAt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAt.PageIndex = e.NewPageIndex;
            int userID = int.Parse(ddlUserCreate.SelectedValue.ToString());
            int commentID = int.Parse(ddlArticle.SelectedValue.ToString());
            int isAccepted = int.Parse(ddlTrangThai.SelectedValue.ToString());
            gvAt.DataSource = new cmsCommentBL().CommentXetDuyet_Filter(commentID, isAccepted, userID);
            gvAt.DataBind();
        }
    }
}