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
    public partial class TinMostReadCate : System.Web.UI.Page
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
                    divQuanLyTin.Visible = true;
                    radioCheck();
                    if (!IsPostBack)
                    {

                        Ultility.ddlDatabinder(ddlMostRead, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new DataView(new cmsCategoryBL().SelectAll(), " ParentID = 0", "", DataViewRowState.CurrentRows));
                    } 
                    if (!string.IsNullOrEmpty(Request.QueryString["CategoryID"]))
                    {
                        int categoryID = int.Parse(Request.QueryString["CategoryID"]);

                        if (!IsPostBack)
                        {

                            try
                            {
                                ddlMostRead.SelectedValue = Request.QueryString["CategoryID"];
                            }
                            catch
                            {
                            }
                            rptCategoryParentDataSource(categoryID);
                            BindRelatedNews("0");
                        }
                    }
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
            }
        }

        protected void radioCheck()
        {
            try
            {
                Boolean isAuto = false;
                isAuto = Boolean.Parse(new sysConfigBL().Select(new sysConfigDO { ConfigID = 5}).ConfigValue);
                //Value = true
                //True -> Lay tu dong
                //False -> Lay bang tay
                if (isAuto == true)
                {
                    rdAuto.Checked = true;
                    rdManual.Checked = false;
                    divManual.Visible = false;
                }
                else if (isAuto == false)
                {
                    rdManual.Checked = true;
                    divManual.Visible = true;
                    rdAuto.Checked = false;
                }
            }
            catch 
            {
            }
        }
        protected void ddlMostRead_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if (int.Parse(ddlMostRead.SelectedValue) > 0)
            Response.Redirect("TinMostReadCate.aspx?CategoryID=" + ddlMostRead.SelectedValue);
        }
        private void BindRelatedNews(string RelatedNews1)
        {
            RadGrid1.DataSource = new cmsArticleBL().GetListMultiID(RelatedNews1);
            RadGrid1.DataBind();

        }
        protected void rptCategoryParentDataSource(int categoryID)
        {
            DataTable dtCateParent = new cmsMostReadBL().SelectByCategoryID(6, categoryID);
            grvListTopNews.DataSource = dtCateParent;
            grvListTopNews.DataBind();
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        protected void grvListTopNews_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            cmsMostReadDO objMostRead = new cmsMostReadDO();

            objMostRead.MostReadID = Convert.ToInt32(((Label)grvListTopNews.Rows[e.RowIndex].Cells[0].FindControl("lblTopNews")).Text);
            objMostRead = new cmsMostReadBL().Select(objMostRead);
            objMostRead.OrderID = int.Parse(((TextBox)grvListTopNews.Rows[e.RowIndex].Cells[4].FindControl("txtOrderID")).Text);
            new cmsMostReadBL().Update(objMostRead);
            grvListTopNews.EditIndex = -1;
            rptCategoryParentDataSource(int.Parse(Request.QueryString["CategoryID"]));
        }
        protected void grvListTopNews_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvListTopNews.EditIndex = -1;
            rptCategoryParentDataSource(int.Parse(Request.QueryString["CategoryID"]));
        }
        protected void grvListTopNews_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvListTopNews.EditIndex = e.NewEditIndex;
            rptCategoryParentDataSource(int.Parse(Request.QueryString["CategoryID"]));
        }
        protected void grvListTopNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new cmsMostReadBL().Delete(new cmsMostReadDO { MostReadID = Convert.ToInt32(grvListTopNews.DataKeys[e.RowIndex].Value) });
            Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
        }
        protected void grvListTopNews_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mostReadID = int.Parse(grvListTopNews.DataKeys[grvListTopNews.SelectedIndex].Value.ToString());

            cmsMostReadDO objMostRead = new cmsMostReadDO();
            objMostRead.MostReadID = mostReadID;
            Session["MostRead"] = objMostRead.MostReadID;

            objMostRead = new cmsMostReadBL().Select(objMostRead);
            cmsArticleDO objArt = new cmsArticleDO();
            objArt.ArticleID = objMostRead.ArticleID;
            objArt = new cmsArticleBL().Select(objArt);
            Session["CateSetTop"] = objMostRead.CategoryID;

            lblOldArticleID.Text = objArt.ArticleID.ToString();
            lblOldTitle.Text = objArt.Title.ToString();
            lblOrderID.Text = objMostRead.OrderID.ToString();
            divEdit.Visible = true;
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            cmsMostReadDO objMostRead = new cmsMostReadDO();
            if (Session["MostRead"] != null)
            {
                int mostReadID = int.Parse(Session["MostRead"].ToString());

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
                        Session["MostRead"] = null;
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

        protected void grvListTopNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvListTopNews.PageIndex = e.NewPageIndex;
            rptCategoryParentDataSource(int.Parse(Request.QueryString["CategoryID"]));
        }

        protected void rdAuto_CheckedChanged(object sender, EventArgs e)
        {
            divManual.Visible = false;
            sysConfigDO objSys = new sysConfigDO(){ConfigID = 5, ConfigName="Quản lý lấy tin 6 Đọc nhiều chuyên mục", ConfigValue = "True"};
            new sysConfigBL().Update(objSys);
            radioCheck();
        }
        protected void rdManual_CheckedChanged(object sender, EventArgs e)
        {
            divManual.Visible = true;
            sysConfigDO objSys = new sysConfigDO() { ConfigID = 5, ConfigName = "Quản lý lấy tin 6 Đọc nhiều chuyên mục", ConfigValue = "False" };
            new sysConfigBL().Update(objSys);
            radioCheck();
        }

    }
}