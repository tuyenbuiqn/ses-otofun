using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using System.Data;
using SES.CMS.AdminCP;

namespace SES.CMS.ofeditor.Module
{
    public partial class ucDuyetComment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (Session["UserType"] != null || Session["UserName"] != null)
            {
                int userType = int.Parse(Session["UserType"].ToString());
                if (userType == 0)
                {
                    Response.Redirect("/ofeditor/Default.aspx");
                }
                else
                {
                    if (!IsPostBack)
                    {
                        gvAtDataSource();
                        Functions.ddlDatabinder(ddlArticle, cmsArticleDO.ARTICLEID_FIELD, cmsArticleDO.TITLE_FIELD, new cmsArticleBL().SelectAll());
                        Functions.ddlDatabinder(ddlUserCreate, sysUserDO.USERID_FIELD, sysUserDO.USERNAME_FIELD, new sysUserBL().SelectAll());
                    }
                }
            }
            else
            {
                Response.Redirect("/ofeditor/Login.aspx");
            }
        }

        protected void gvAtDataSource()
        {
            int userType = int.Parse(Session["UserType"].ToString());
            int bienTapVienID = int.Parse(Session["UserID"].ToString());
            gvAt.DataSource = new cmsCommentBL().SelectByPermission(userType,bienTapVienID);
            gvAt.DataBind();
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
            int userType = int.Parse(Session["UserType"].ToString());
            int userID = 0;
            if (userType == 1)
                userID = 0;
            else if(userType == 2)
                userID = int.Parse(ddlUserCreate.SelectedValue);

            int articleID = int.Parse(ddlArticle.SelectedValue.ToString());
            int isAccepted = int.Parse(ddlTrangThai.SelectedValue.ToString());
            
            int bienTapVienID = int.Parse(Session["UserID"].ToString());

            gvAt.DataSource = new cmsCommentBL().CommentXetDuyet_Filter(articleID, isAccepted, userID,userType,bienTapVienID);
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
                Functions.Alert("Vui lòng chọn bình luận");
                return;
            }
            else
            {
                int userXetDuyet = int.Parse(Session["UserID"].ToString());
                new cmsCommentBL().XetDuyetNhieuBinhLuan(commentList, true, userXetDuyet);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "otofun.net", "alert('Xét duyệt thành công!');window.open('Comments.aspx','_self');", true);
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
                Functions.Alert("Vui lòng chọn bình luận");
                return;
            }
            else
            {
                int userXetDuyet = int.Parse(Session["UserID"].ToString());
                new cmsCommentBL().XetDuyetNhieuBinhLuan(commentList, false, userXetDuyet);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "otofun.net", "alert('Bỏ duyệt thành công!');window.open('Comments.aspx','_self');", true);
            }
        }
        protected void gvAt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAt.PageIndex = e.NewPageIndex;
            int userID = int.Parse(ddlUserCreate.SelectedValue.ToString());
            int commentID = int.Parse(ddlArticle.SelectedValue.ToString());
            int isAccepted = int.Parse(ddlTrangThai.SelectedValue.ToString());
            int userType = int.Parse(Session["UserType"].ToString());
            int bienTapVienID = int.Parse(Session["UserID"].ToString());
            gvAt.DataSource = new cmsCommentBL().CommentXetDuyet_Filter(commentID, isAccepted, userID,userType,bienTapVienID);
            gvAt.DataBind();
        }

        protected void gvAt_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAt.EditIndex = e.NewEditIndex;
            gvAtDataSource();
        }

        protected void gvAt_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            cmsCommentDO objComment = new cmsCommentDO();

            objComment.CommentID = Convert.ToInt32(((Label)gvAt.Rows[e.RowIndex].Cells[0].FindControl("lblCommentID")).Text);
            objComment = new cmsCommentBL().Select(objComment);

            objComment.Contents = ((TextBox)gvAt.Rows[e.RowIndex].Cells[4].FindControl("txtContent")).Text;

            new cmsCommentBL().Update(objComment);
            gvAt.EditIndex = -1;
            gvAtDataSource();
        }

        protected void gvAt_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAt.EditIndex = -1;
            gvAtDataSource();
        }
    }
}