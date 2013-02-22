using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using System.Data;
using Telerik.Web.UI;

namespace SES.CMS.ofeditor
{
    public partial class TinSetTop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] == null || Session["UserName"] == null)
            {
                Response.Redirect("/ofeditor/Login.aspx");
            }
            else
            {
                int userType = int.Parse(Session["UserType"].ToString());
                if (userType == 2)
                {
                    if (!IsPostBack)
                    {
                        rptCategoryParentDataSource();
                        BindRelatedNews("0");
                    }
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
            }
        }
        private void BindRelatedNews(string RelatedNews1)
        {
            RadGrid1.DataSource = new cmsArticleBL().GetListMultiID(RelatedNews1);
            RadGrid1.DataBind();

        }
        protected void rptCategoryParentDataSource()
        {
            DataTable dtCateParent = new cmsSetTopBL().SelectAll(0);
            grvListTopNews.DataSource = dtCateParent;
            grvListTopNews.DataBind();
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        protected void grvListTopNews_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            cmsSetTopDO objSetTop = new cmsSetTopDO();

            objSetTop.SetTopID = Convert.ToInt32(((Label)grvListTopNews.Rows[e.RowIndex].Cells[0].FindControl("lblTopNews")).Text);
            objSetTop = new cmsSetTopBL().Select(objSetTop);
            objSetTop.OrderID = int.Parse(((TextBox)grvListTopNews.Rows[e.RowIndex].Cells[4].FindControl("txtOrderID")).Text);
            new cmsSetTopBL().Update(objSetTop);
            grvListTopNews.EditIndex = -1;
            rptCategoryParentDataSource();
        }
        protected void grvListTopNews_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvListTopNews.EditIndex = -1;
            rptCategoryParentDataSource();
        }
        protected void grvListTopNews_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvListTopNews.EditIndex = e.NewEditIndex;
            rptCategoryParentDataSource();
        }
        protected void grvListTopNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new cmsSetTopBL().Delete(new cmsSetTopDO { SetTopID = Convert.ToInt32(grvListTopNews.DataKeys[e.RowIndex].Value) });
            Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
        }
        protected void grvListTopNews_SelectedIndexChanged(object sender, EventArgs e)
        {
            int setTopID = int.Parse(grvListTopNews.DataKeys[grvListTopNews.SelectedIndex].Value.ToString());

            cmsSetTopDO objSetTop = new cmsSetTopDO();
            objSetTop.SetTopID = setTopID;
            Session["SetTop"] = objSetTop.SetTopID;

            objSetTop = new cmsSetTopBL().Select(objSetTop);
            cmsArticleDO objArt = new cmsArticleDO();
            objArt.ArticleID = objSetTop.ArticleID;
            objArt = new cmsArticleBL().Select(objArt);
            Session["CateSetTop"] = objSetTop.CategoryID;

            lblOldArticleID.Text = objArt.ArticleID.ToString();
            lblOldTitle.Text = objArt.Title.ToString();
            lblOrderID.Text = objSetTop.OrderID.ToString();
            divEdit.Visible = true;
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            cmsSetTopDO objSetTop = new cmsSetTopDO();
            if (Session["SetTop"] != null)
            {
                int setTopID = int.Parse(Session["SetTop"].ToString());

                objSetTop.SetTopID = setTopID;
                objSetTop = new cmsSetTopBL().Select(objSetTop);
                if (!hdfID1.Value.Equals(""))
                {
                    if (!hdfID1.Value.Contains(","))
                    {
                        objSetTop.ArticleID = int.Parse(hdfID1.Value);
                        new cmsSetTopBL().Update(objSetTop);

                        lblOldTitle.Text = "";
                        lblOldArticleID.Text = "";
                        lblOrderID.Text = "";
                        Session["SetTop"] = null;
                        Ultility.Alert("Cập nhật bản ghi thành công!", Request.Url.ToString());
                    }
                    else
                    {
                        lblError.Text = "Chỉ chọn được 1 bài viết 1 lần!";
                    }
                }
                else
                {
                    lblError.Text = "Vui lòng chọn bài viết thay thế!";
                    return;
                }
                //Response.Redirect("TinNoiBat.aspx");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            divEdit.Visible = false;
            lblOldTitle.Text = "";
            lblOldArticleID.Text = "";
            Response.Redirect(Request.Url.ToString());
        }
    }
}