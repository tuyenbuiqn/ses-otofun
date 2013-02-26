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
    public partial class TinMostReadHome : System.Web.UI.Page
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
                    if (!IsPostBack){
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
            DataTable dtCateParent = new cmsMostReadBL().SelectHomepageMostRead(6);
            grvListTinNoiBat.DataSource = dtCateParent;
            grvListTinNoiBat.DataBind();
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        protected void grvListTinNoiBat_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            cmsMostReadDO objMostRead = new cmsMostReadDO();

            objMostRead.MostReadID = Convert.ToInt32(((Label)grvListTinNoiBat.Rows[e.RowIndex].Cells[0].FindControl("lblTopNews")).Text);
            objMostRead = new cmsMostReadBL().Select(objMostRead);
            objMostRead.OrderID = int.Parse(((TextBox)grvListTinNoiBat.Rows[e.RowIndex].Cells[4].FindControl("txtOrderID")).Text);
            new cmsMostReadBL().Update(objMostRead);
            grvListTinNoiBat.EditIndex = -1;
            rptCategoryParentDataSource();
        }
        protected void grvListTinNoiBat_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvListTinNoiBat.EditIndex = -1;
            rptCategoryParentDataSource();
        }
        protected void grvListTinNoiBat_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvListTinNoiBat.EditIndex = e.NewEditIndex;
            rptCategoryParentDataSource();
        }
        protected void grvListTinNoiBat_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new cmsMostReadBL().Delete(new cmsMostReadDO { MostReadID = Convert.ToInt32(grvListTinNoiBat.DataKeys[e.RowIndex].Value) });
            Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
        }
        protected void grvListTinNoiBat_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mostReadID = int.Parse(grvListTinNoiBat.DataKeys[grvListTinNoiBat.SelectedIndex].Value.ToString());

            cmsMostReadDO objMostRead = new cmsMostReadDO();
            objMostRead.MostReadID = mostReadID;
            Session["MostReadHomeID"] = objMostRead.MostReadID;

            objMostRead = new cmsMostReadBL().Select(objMostRead);
            cmsArticleDO objArt = new cmsArticleDO();
            objArt.ArticleID = objMostRead.ArticleID;
            objArt = new cmsArticleBL().Select(objArt);

            lblOldArticleID.Text = objArt.ArticleID.ToString();
            lblOldTitle.Text = objArt.Title.ToString();
            lblOrderID.Text = objMostRead.OrderID.ToString();
            divEdit.Visible = true;
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            cmsMostReadDO objMostRead = new cmsMostReadDO();
            if (Session["MostReadHomeID"] != null)
            {
                int mostReadID =  int.Parse(Session["MostReadHomeID"].ToString());

                objMostRead.MostReadID = mostReadID;
                objMostRead = new cmsMostReadBL().Select(objMostRead);
                if (!hdfID1.Value.Equals(""))
                {
                    if (!hdfID1.Value.Contains(","))
                    {
                        objMostRead.ArticleID = int.Parse(hdfID1.Value);
                        new cmsMostReadBL().Update(objMostRead);

                        lblOldTitle.Text = "";
                        lblOldArticleID.Text = "";
                        lblOrderID.Text = "";
                        Session["MostReadHomeID"] = null;
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