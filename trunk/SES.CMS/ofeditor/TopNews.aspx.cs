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
    public partial class TopNews : System.Web.UI.Page
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
            DataTable dtCateParent = new cmsTopNewsBL().SelectAll(0);
            grvListTopNews.DataSource = dtCateParent;
            grvListTopNews.DataBind();
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        protected void grvListTopNews_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            cmsTopNewsDO objTinNoiBat = new cmsTopNewsDO();

            objTinNoiBat.TopNews = Convert.ToInt32(((Label)grvListTopNews.Rows[e.RowIndex].Cells[0].FindControl("lblTopNews")).Text);
            objTinNoiBat = new cmsTopNewsBL().Select(objTinNoiBat);
            objTinNoiBat.OrderID = int.Parse(((TextBox)grvListTopNews.Rows[e.RowIndex].Cells[4].FindControl("txtOrderID")).Text);
            new cmsTopNewsBL().Update(objTinNoiBat);
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
            new cmsTopNewsBL().Delete(new cmsTopNewsDO { TopNews = Convert.ToInt32(grvListTopNews.DataKeys[e.RowIndex].Value) });
            Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
        }
        protected void grvListTopNews_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tinNoiBatID = int.Parse(grvListTopNews.DataKeys[grvListTopNews.SelectedIndex].Value.ToString());

            cmsTopNewsDO objTinNoiBat = new cmsTopNewsDO();
            objTinNoiBat.TopNews = tinNoiBatID;
            Session["TinNoiBatID"] = objTinNoiBat.TopNews;

            objTinNoiBat = new cmsTopNewsBL().Select(objTinNoiBat);
            cmsArticleDO objArt = new cmsArticleDO();
            objArt.ArticleID = objTinNoiBat.ArticleID;
            objArt = new cmsArticleBL().Select(objArt);

            lblOldArticleID.Text = objArt.ArticleID.ToString();
            lblOldTitle.Text = objArt.Title.ToString();
            lblOrderID.Text = objTinNoiBat.OrderID.ToString();
            divEdit.Visible = true;
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            cmsTopNewsDO objTinNoiBat = new cmsTopNewsDO();
            if (Session["TopNews"] != null)
            {
                int tinNoiBat = int.Parse(Session["TopNews"].ToString());

                objTinNoiBat.TopNews = tinNoiBat;
                objTinNoiBat = new cmsTopNewsBL().Select(objTinNoiBat);
                if (!hdfID1.Value.Equals(""))
                {
                    if (!hdfID1.Value.Contains(","))
                    {
                        objTinNoiBat.ArticleID = int.Parse(hdfID1.Value);
                        new cmsTopNewsBL().Update(objTinNoiBat);

                        lblOldTitle.Text = "";
                        lblOldArticleID.Text = "";
                        lblOrderID.Text = "";
                        Session["TopNews"] = null;
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