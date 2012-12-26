using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using SES.CMS.AdminCP;

namespace SES.CMS.ofeditor
{
    public partial class ListArticles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Type"]))
                {
                    int numberType;
                    bool isNumber = int.TryParse(Request.QueryString["Type"], out numberType);
                    if (isNumber) // ĐÚng là kiểu int
                    {
                        if (!IsPostBack)
                        {
                            LoadContent(numberType, int.Parse(Session["UserID"].ToString()));
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Redirect("~/ofeditor/Login.aspx");
            }
        }
        protected void LoadContent(int userType, int userCreate)
        {
            if (userType == 0)
            {
                //Panel
                pnelNhap.Visible = true;
                //End panel
                //Gridview
                grvNhapDataSource(3, 0, 0);
                //Grindview
                Functions.ddlDatabinder(cboCategoryNhap, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectByType(0));
            }
        }
        #region Bài viết nháp(BTV)
        // Danh sách bài viết nháp(BTV)
        protected void grvNhapDataSource(int trangThai, int userCreate, int cate)
        {
            grvNhap.DataSource = new cmsArticleBL().SelectByTrangThaiAndUserCreate(trangThai, userCreate, cate);
            grvNhap.DataBind();
        }
        protected void cboCategoryNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["filter"] = "Cate";
            grvNhapDataSource(0, int.Parse(Session["UserID"].ToString()), int.Parse(cboCategoryNhap.SelectedValue));
        }
        protected void grvNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ArticleID = int.Parse(grvNhap.DataKeys[grvNhap.SelectedIndex].Value.ToString());
            Response.Redirect("AddNews.aspx?ArticleID=" + ArticleID.ToString());
        }
        protected void grvNhap_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int articleID = Convert.ToInt32(grvNhap.DataKeys[e.RowIndex].Value);
            new cmsArticleBL().Delete(new cmsArticleDO { ArticleID = articleID });
            new cmsArticleCategoryBL().DeleteByArticleID(articleID);
            Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
        }
        protected void grvNhap_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvNhap.PageIndex = e.NewPageIndex;
            if (Session["filter"] != null)
            {
                if (Session["filter"].ToString().Equals("Cate"))
                {
                    grvNhapDataSource(0, int.Parse(Session["UserID"].ToString()), int.Parse(cboCategoryNhap.SelectedValue));
                }
            }
            else
            {
                grvNhapDataSource(0, int.Parse(Session["UserID"].ToString()), 0);
            }
        }
        #endregion
        protected void btnGuiXuatBan1_Click(object sender, EventArgs e)
        {
            string articleList = "";
            for (int i = 0; i < grvNhap.Rows.Count; i++)
            {
                GridViewRow row = grvNhap.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    articleList += grvNhap.DataKeys[row.RowIndex].Value.ToString() + ",";
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
                int bienTapVienID = int.Parse(Session["UserID"].ToString());
                new cmsArticleBL().ChuyenTrangThai_BienTapVien(articleList, 2, bienTapVienID, DateTime.Now);
                Ultility.Alert("Gửi bài viết chờ xuất bản thành công",Request.Url.AbsolutePath);
            }
        }

        protected void btnXoa1_Click(object sender, EventArgs e)
        {
            string articleList = "";
            for (int i = 0; i < grvNhap.Rows.Count; i++)
            {
                GridViewRow row = grvNhap.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    articleList += grvNhap.DataKeys[row.RowIndex].Value.ToString() + ",";
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
                int bienTapVienID = int.Parse(Session["UserID"].ToString());
                new cmsArticleBL().MultiDelete(articleList);
                Ultility.Alert("Xóa bài viết thành công", Request.Url.AbsolutePath);
            }
        }
    }
}