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
    public partial class TinNoiBat : System.Web.UI.Page
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
            DataTable dtCateParent = new cmsTinNoiBatBL().SelectAll(0);
            grvListTinNoiBat.DataSource = dtCateParent;
            grvListTinNoiBat.DataBind();
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        protected void grvListTinNoiBat_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            cmsTinNoiBatDO objTinNoiBat = new cmsTinNoiBatDO();
            
            objTinNoiBat.TinNoiBatID = Convert.ToInt32(((Label)grvListTinNoiBat.Rows[e.RowIndex].Cells[0].FindControl("lblTinNoiBatID")).Text);
            objTinNoiBat = new cmsTinNoiBatBL().Select(objTinNoiBat);
            objTinNoiBat.OrderID = int.Parse(((TextBox)grvListTinNoiBat.Rows[e.RowIndex].Cells[4].FindControl("txtOrderID")).Text);
            new cmsTinNoiBatBL().Update(objTinNoiBat);
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
            new cmsTinNoiBatBL().Delete(new cmsTinNoiBatDO { TinNoiBatID = Convert.ToInt32(grvListTinNoiBat.DataKeys[e.RowIndex].Value) });
            Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
        }
        protected void grvListTinNoiBat_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tinNoiBatID = int.Parse(grvListTinNoiBat.DataKeys[grvListTinNoiBat.SelectedIndex].Value.ToString());

            cmsTinNoiBatDO objTinNoiBat = new cmsTinNoiBatDO();
            objTinNoiBat.TinNoiBatID = tinNoiBatID;
            Session["TinNoiBatID"] = objTinNoiBat.TinNoiBatID;

            objTinNoiBat = new cmsTinNoiBatBL().Select(objTinNoiBat);
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
            cmsTinNoiBatDO objTinNoiBat = new cmsTinNoiBatDO();
            if (Session["TinNoiBatID"] != null)
            {
                int tinNoiBat = int.Parse(Session["TinNoiBatID"].ToString());

                objTinNoiBat.TinNoiBatID = tinNoiBat;
                objTinNoiBat = new cmsTinNoiBatBL().Select(objTinNoiBat);
                if (!hdfID1.Value.Equals(""))
                {
                    if (!hdfID1.Value.Contains(","))
                    {
                        objTinNoiBat.ArticleID = int.Parse(hdfID1.Value);
                        new cmsTinNoiBatBL().Update(objTinNoiBat);

                        lblOldTitle.Text = "";
                        lblOldArticleID.Text = "";
                        lblOrderID.Text = "";
                        Session["TinNoiBatID"] = null;
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