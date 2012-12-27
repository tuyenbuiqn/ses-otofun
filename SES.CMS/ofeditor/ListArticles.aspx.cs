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
                        Actions(numberType);
                        LoadButton(numberType);
                        if (!IsPostBack)
                        {
                            LoadContent(numberType, int.Parse(Session["UserID"].ToString()));
                          //  grvListArticleDataSource(3, 0, 0);
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
        //Load button
        protected void Actions(int type)
        {
            if (type == 0)
                lblAction.Text = "Danh sách bài nháp";
            else if (type == 1)
                lblAction.Text = "Danh sách bài chờ Biên tập viên";
            else if (type == 2)
                lblAction.Text = "Danh sách bài chờ xuất bản";
            else if (type == 3)
                lblAction.Text = "Danh sách bài đã xuất bản";
            else if (type == 5)
                lblAction.Text = "Danh sách bài gửi trả lại";
        }
        protected void LoadButton(int type)
        {
            //Nhap hoac tra lai BTV
            if (type == 0 || type == 5)
            {
                btnChiuTrachNhiem1.Visible = false;
                btnChiuTrachNhiem2.Visible = false;
                btnTraLaiPhongVien1.Visible = false;
                btnTraLaiPhongVien2.Visible = false;

                btnGuiXuatBan1.Visible = true;
                btnGuiXuatBan2.Visible = true;
                btnGuiXuatBanBTV1.Visible = false;
                btnGuiXuatBanBTV2.Visible = false;
                btnXoa1.Visible = true;
                btnXoa2.Visible = true;
            }
            //Can bien tap
            else if (type == 1)
            {
                btnChiuTrachNhiem1.Visible = true;
                btnChiuTrachNhiem2.Visible = true;
                btnTraLaiPhongVien1.Visible = true;
                btnTraLaiPhongVien2.Visible = true;

                btnGuiXuatBan1.Visible = false;
                btnGuiXuatBan2.Visible = false;
                btnGuiXuatBanBTV1.Visible = true;
                btnGuiXuatBanBTV2.Visible = true;
                btnXoa1.Visible = false;
                btnXoa2.Visible = false;
            }
            // Gui Xuat ban hoac Da xuat ban
            else if (type == 2 || type == 3)
            {
                btnChiuTrachNhiem1.Visible = false;
                btnChiuTrachNhiem2.Visible = false;
                btnTraLaiPhongVien1.Visible = false;
                btnTraLaiPhongVien2.Visible = false;

                btnGuiXuatBan1.Visible = false;
                btnGuiXuatBan2.Visible = false;
                btnGuiXuatBanBTV1.Visible = false;
                btnGuiXuatBanBTV2.Visible = false;
                btnXoa1.Visible = false;
                btnXoa2.Visible = false;
            }
        }
        protected void LoadContent(int userType, int userCreate)
        {
            if (userType == 0)
            {
                grvListArticleDataSource(0, userCreate, 0);
                Functions.ddlDatabinder(cboCategoryNhap, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectByType(0));
            }
            else if (userType == 1)
            {
                grvListArticleDataSource(1,0, 0);
                Functions.ddlDatabinder(cboCategoryNhap, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectByType(0));
            }
            else if (userType == 2)
            {
                grvListArticleDataSource(2, userCreate, 0);
                Functions.ddlDatabinder(cboCategoryNhap, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectByType(0));
            }
            else if (userType == 3)
            {
                grvListArticleDataSource(3, userCreate, 0);
                Functions.ddlDatabinder(cboCategoryNhap, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectByType(0));
            }
            else if (userType == 5)
            {
                grvListArticleDataSource(5, userCreate, 0);
                Functions.ddlDatabinder(cboCategoryNhap, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectByType(0));
            }
        }
        protected void grvListArticleDataSource(int trangThai, int userCreate, int cate)
        {
            grvListArticle.DataSource = new cmsArticleBL().SelectByTrangThaiAndUserCreate(trangThai, userCreate, cate);
            grvListArticle.DataBind();
        }
        protected void cboCategoryNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["filter"] = "Cate";
            grvListArticleDataSource(0, int.Parse(Session["UserID"].ToString()), int.Parse(cboCategoryNhap.SelectedValue));
        }
        protected void grvListArticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ArticleID = int.Parse(grvListArticle.DataKeys[grvListArticle.SelectedIndex].Value.ToString());
            Response.Redirect("AddNews.aspx?ArticleID=" + ArticleID.ToString());
        }
        protected void grvListArticle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int articleID = Convert.ToInt32(grvListArticle.DataKeys[e.RowIndex].Value);
            new cmsArticleBL().Delete(new cmsArticleDO { ArticleID = articleID });
            new cmsArticleCategoryBL().DeleteByArticleID(articleID);
            Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
        }
        protected void grvListArticle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvListArticle.PageIndex = e.NewPageIndex;
            if (Session["filter"] != null)
            {
                if (Session["filter"].ToString().Equals("Cate"))
                {
                    grvListArticleDataSource(0, int.Parse(Session["UserID"].ToString()), int.Parse(cboCategoryNhap.SelectedValue));
                }
            }
            else
            {
                grvListArticleDataSource(0, int.Parse(Session["UserID"].ToString()), 0);
            }
        }
        protected void btnGuiXuatBan_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = "Gửi chờ xuất bản";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.Comment = "";
            string contents = "Biên tập viên " + Session["UserName"].ToString() + " gửi bài viết:<b> ";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();

            string articleList = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objHistory.Contents = contents + artBL.Select(objArt).Title + " </b>chờ xuất bản";
                    historyBL.Insert(objHistory);
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
                Ultility.Alert("Gửi bài viết chờ xuất bản thành công", Request.Url.ToString());
            }
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = "Xóa bài viết";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.Comment = "";
            string contents = "Biên tập viên " + Session["UserName"].ToString() + " xóa bài viết: <b>";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();

            string articleList = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objHistory.Contents = contents + artBL.Select(objArt).Title + " </b>";
                    historyBL.Insert(objHistory);
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
                Ultility.Alert("Xóa bài viết thành công", Request.Url.ToString());
            }
        }
        protected void btnBTVChiuTrachNhiem_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = "Đăng ký chịu trách nhiệm bài viết";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.Comment = "";
            string contents = "Biên tập viên " + Session["UserName"].ToString() + " đăng ký chịu trách nhiệm bài viết: <b>";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();

            bool isNotOK = false;
            string articleList = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objArt = artBL.Select(objArt);
                    //Nếu như BTV nào đó đã nhận trách nhiệm
                    if (objArt.BTVEdit != 0)
                    {
                        isNotOK = true;
                    }
                    else if (objArt.BTVEdit == 0)
                    {

                        articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                        objHistory.Contents = contents + artBL.Select(objArt).Title + " </b>";
                        historyBL.Insert(objHistory);
                        isNotOK = false;
                    }
                    // Nếu ko thì chả làm gì cả, next bản ghi tiếp
                }
            }
            articleList += "-9999";
            if (isNotOK == true)
            {
                Functions.Alert("Đăng ký không thành công, vui lòng chọn lại");
                return;
            }
            if (articleList.Equals("-9999"))
            {
                Functions.Alert("Vui lòng chọn bài viết");
                return;
            }
            else
            {
                int bienTapVienID = int.Parse(Session["UserID"].ToString());
                new cmsArticleBL().DangKyChiuTrachNhiemBaiViet(1, articleList, bienTapVienID);
                Ultility.Alert("Đăng ký thành công", Request.Url.ToString());
            }

        }
        protected void btnGuiXuatBanBTV_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = "Gửi chờ xuất bản";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.Comment = "";
            string contents = "Biên tập viên " + Session["UserName"].ToString() + " gửi bài viết: <b>";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();
            bool isNotOK = false;
            string articleList = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objArt = artBL.Select(objArt);
                    //Nếu như BTV nào đó đã nhận trách nhiệm
                    if (objArt.BTVEdit != 0)
                    {
                        // Nếu đúng là ông đang đăng nhập là ông chịu trách nhiệm này
                        if (objArt.BTVEdit == int.Parse(Session["UserID"].ToString()))
                        {
                            articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                            objHistory.Contents = contents + artBL.Select(objArt).Title + " </b>chờ xuất bản";
                            historyBL.Insert(objHistory);
                            isNotOK = false;
                        }
                        else { isNotOK = true; }
                    }
                    else
                    {
                        isNotOK = true;
                    }
                    // Nếu ko thì chả làm gì cả, next bản ghi tiếp
                }
            }
            articleList += "-9999";
            if (isNotOK == true)
            {
                Functions.Alert("Bạn không đủ quyền hạn để gửi xuất bản bài viết này!");
                return;
            }
            else if (articleList.Equals("-9999"))
            {
                Functions.Alert("Vui lòng chọn bài viết");
                return;
            }
            else
            {
                int bienTapVienID = int.Parse(Session["UserID"].ToString());
                new cmsArticleBL().ChuyenTrangThai_BienTapVien(articleList, 2, bienTapVienID, DateTime.Now);
                Ultility.Alert("Gửi bài viết chờ xuất bản thành công", Request.Url.ToString());
            }
        }
        protected void btnGuiTraLaiBai_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = "Yêu cầu phóng viên viết lại";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.Comment = "";
            string contents = "Biên tập viên " + Session["UserName"].ToString() + " trả bài viết: ";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();

            bool isNotOK = false;
            string articleList = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objArt = artBL.Select(objArt);
                    //Nếu như BTV nào đó đã nhận trách nhiệm
                    if (objArt.BTVEdit != 0)
                    {
                        // Nếu đúng là ông đang đăng nhập là ông chịu trách nhiệm này
                        if (objArt.BTVEdit == int.Parse(Session["UserID"].ToString()))
                        {
                            articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                            objHistory.Contents = contents + artBL.Select(objArt).Title + " </b> yêu cầu phóng viên viết lại";
                            historyBL.Insert(objHistory);
                            isNotOK = false;
                        }
                        else { isNotOK = true; }
                    }
                    else
                    {
                        isNotOK = true;
                    }
                    // Nếu ko thì chả làm gì cả, next bản ghi tiếp
                }
            }
            articleList += "-9999";
            if (isNotOK == true)
            {
                Functions.Alert("Bạn không đủ quyền hạn để gửi trả bài viết!");
                return;
            }
            else if (articleList.Equals("-9999"))
            {
                Functions.Alert("Vui lòng chọn bài viết");
                return;
            }
            else
            {
                int bienTapVienID = int.Parse(Session["UserID"].ToString());
                new cmsArticleBL().ChuyenTrangThai_BienTapVien(articleList, 4, bienTapVienID, DateTime.Now);
                Ultility.Alert("Trả bài viết thành công", Request.Url.ToString());
            }
        }
        protected void grvListArticle_DataBound(object sender, EventArgs e)
        {
            int type = int.Parse(Request.QueryString["Type"]);
            int userID = int.Parse(Session["UserID"].ToString());

            //Nhap BTV
            if (type == 0 | type == 5)
            {
                grvListArticle.Columns[5].Visible = false;
                grvListArticle.Columns[6].Visible = false;
                grvListArticle.Columns[7].Visible = false;
                grvListArticle.Columns[8].Visible = false;
            }
            else if (type == 1)
            {
                grvListArticle.Columns[4].Visible = false;
                grvListArticle.Columns[6].Visible = false;
                grvListArticle.Columns[7].Visible = false;
                grvListArticle.Columns[8].Visible = false;

            }
            else if (type == 2)
            {
                grvListArticle.Columns[4].Visible = false;
                grvListArticle.Columns[7].Visible = false;
                grvListArticle.Columns[8].Visible = false;
                grvListArticle.Columns[9].Visible = false;
            }
            else if (type == 3)
            {
                grvListArticle.Columns[4].Visible = false;
                grvListArticle.Columns[9].Visible = false;
            }
        }
        cmsArticleDO objArt = new cmsArticleDO();
        cmsArticleBL artBL = new cmsArticleBL();
        protected void grvListArticle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int type = int.Parse(Request.QueryString["Type"]);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (type == 1)
                {
                    ImageButton btnDelete = e.Row.FindControl("btnDelete") as ImageButton;
                    btnDelete.Visible = false;

                    // int articleID = int.Parse(e.Row.Cells[1].ToString());
                    int articleID = (Int32)DataBinder.Eval(e.Row.DataItem, "ArticleID");
                    objArt.ArticleID = articleID;
                    objArt = artBL.Select(objArt);
                    if (objArt.BTVEdit == 0)
                    {
                        ImageButton btnEdit = e.Row.FindControl("btnEdit") as ImageButton;
                        btnEdit.Visible = false;
                    }
                    else
                    {
                        if (objArt.BTVEdit == int.Parse(Session["UserID"].ToString()))
                        {
                            ImageButton btnEdit = e.Row.FindControl("btnEdit") as ImageButton;
                            btnEdit.Visible = true;
                        }
                        else
                        {
                            ImageButton btnEdit = e.Row.FindControl("btnEdit") as ImageButton;
                            btnEdit.Visible = false;
                        }
                    }

                }
            }
        }
    }
}
