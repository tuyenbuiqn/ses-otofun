﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using SES.CMS.AdminCP;
using System.Data;
using System.Web.Caching;
using Telerik.Web.UI;
namespace SES.CMS.ofeditor
{
    public partial class ListArticles : System.Web.UI.Page
    {
        private Cache cache = HttpContext.Current.Cache;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Type"]))
                {
                    int ArticleType;
                    bool isNumber = int.TryParse(Request.QueryString["Type"], out ArticleType);
                    int UserTypeID = int.Parse(Session["UserType"].ToString());
                    int UserID = int.Parse(Session["UserID"].ToString());

                    if (isNumber) // ĐÚng là kiểu int
                    {
                        Actions(ArticleType); // Hiện label
                        LoadButton(UserTypeID, ArticleType);
                        if (!CheckViewPV(UserTypeID, ArticleType)) // Check Quyền phóng viên
                            Ultility.Alert("Có vấn đề xảy ra", "Default.aspx");
                        if (!IsPostBack)
                        {

                            LoadContent();

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

        protected void LoadButton(int usertype, int ArticleType)
        {
            if (usertype == 0)  //PV 0,1,5 
            {
                if (ArticleType == 0 || ArticleType == 5) // Bài nháp hoặc gửi trả OK, bài chờ xb và biên tập ko thể xóa, ko thể gửi lại
                {
                    divPV.Visible = true; // Phóng viên
                }

            }
            else if (usertype == 1) //BTV 0,1,2,3,4,5
            {
                divBTV.Visible = true; // BTV
                if (ArticleType == 0) btnChiuTrachNhiem.Visible = btnTraLaiPhongVien.Visible = false; //Nháp thì ko hiện chịu trách nhiệm, trả lại PV
                //Bài chờ bt xem tất, bài bị trả lại BT, tương tự bài chờ bt=1 xem thoải mái
                else if (ArticleType == 2 || ArticleType == 3) //chờ xuất bản ko thể xóa, ko thể gửi trả lại, ko thể chịu trách nhiệm, ko thể gửi XB
                {
                    btnGuiXuatBan.Visible = btnChiuTrachNhiem.Visible = btnTraLaiPhongVien.Visible = btnXoaBTV.Visible = false;
                }
                else if (ArticleType == 5)  // bài trả PV, ko chịu trách nhiệm, ko gửi trả lại, xóa ok, gửi XB ok
                {
                    btnChiuTrachNhiem.Visible = btnTraLaiPhongVien.Visible = false;
                }
            }

            else if (usertype >= 2)
            {
                divTK.Visible = true; // Thư ký
                if (ArticleType == 0) //Nháp thì ko hiện trả lại BTV
                    btnTKTraPV.Visible = btnTraBTV.Visible = btnHuyDuyetXB.Visible = false;
                // bài chờ biên tập TK ko xem
                if (ArticleType == 1)
                {
                    // bài chờ biên tập ko thể trả lại biên tập, ko gỡ duyệt
                    btnTraBTV.Visible = btnHuyDuyetXB.Visible = false;
                    btnTKChiuTrachNhiem.Visible = true;
                }
                if (ArticleType == 2) // bài chờ xuất bản, ko trả lại PV, ko gỡ duyệt
                    btnTKTraPV.Visible = btnHuyDuyetXB.Visible = false;
                if (ArticleType == 3) // bài đã xuất bản, ko xuất bản lại, chỉ gỡ duyệt hoặc trả lại BTV,PV
                    btnDuyetXuatBan.Visible = false;
                if (ArticleType == 4) // bài trả Biên tập ko thể trả lại, ko gỡ duyệt
                    btnTraBTV.Visible = btnHuyDuyetXB.Visible = false;
                if (ArticleType == 5) // bài trả PV ko thể trả lại, ko gỡ duyệt
                    btnTraBTV.Visible = btnTKTraPV.Visible = btnHuyDuyetXB.Visible = false;
            }

            //
        }
        protected bool CheckViewPV(int usertype, int ArticleType)
        {
            if (usertype == 0) // Phóng viên
            {
                if (ArticleType == 0 || ArticleType == 1 || ArticleType == 3 || ArticleType == 5) return true;
            }
            else if (usertype > 0) return true;

            return false;
        }


        protected void LoadContent()
        {
            int ArticleType = int.Parse(Request.QueryString["Type"]);
            int UserType = int.Parse(Session["UserType"].ToString());
            int userCreate = int.Parse(Session["UserID"].ToString());

            /******************chưa sửa*****************/
            int CatID = 0;
            if (Request.QueryString["CatID"] != null) CatID = int.Parse(Request.QueryString["CatID"]);

            //Functions.ddlDatabinder(cboCategoryNhap, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectByType(0));
            if (ArticleType == 0) // Nếu là bài nháp --> chỉ xem bài của mình --> Lấy theo ID, ko quan tâm đến UType
            {

                grvListArticleDataSource(new cmsArticleBL().SelectByTrangThaiAndUserCreate(0, userCreate, CatID));

            }
            else if (ArticleType == 1) // Nếu là bài chờ biên tập 
            {
                //Nếu là Phóng tinh viên chỉ xem bài gửi BT của mình
                if (UserType == 0) grvListArticleDataSource(new cmsArticleBL().SelectByTrangThaiAndUserCreate(1, userCreate, CatID));
                //BTV xem các bài của chuyên mục mềnh quản lý
                else if (UserType == 1) grvListArticleDataSource(new cmsArticleBL().SelectByTrangThaiAndUserCreateBTV(ArticleType, 0, CatID, userCreate));
                //TK thì xõa đê
                else if (UserType == 2) grvListArticleDataSource(new cmsArticleBL().SelectByTrangThaiAndUserCreate(ArticleType, 0, 0));
            }
            else if (ArticleType == 2) // Nếu là bài chờ xuất bản, BTV đều được xem, TK đều được xem
            {
                //Chờ Xuất bản: Trạng thái = 3 + IsPublish = false || ArticleType == 2
                if (UserType == 1)
                    grvListArticleDataSource(new cmsArticleBL().SelectByTrangThaiAndUserCreateBTV(ArticleType, 0, CatID, userCreate));
                else if (UserType == 2)
                    grvListArticleDataSource(new cmsArticleBL().SelectByTrangThaiAndUserCreate(ArticleType, 0, CatID));
            }
            else if (ArticleType == 3) // Nếu là bài đã xuất bản, BTV đều được xem, TK đều được xem, PV chỉ xem bài của mình
            {
                // Xuất bản: Trạng thái = 3 + IsPublish = True
                if (UserType == 0) // PV chỉ xem bài mình
                    grvListArticleDataSource(new DataView(new cmsArticleBL().SelectByTrangThaiAndUserCreate(ArticleType, userCreate, CatID), " IsPublish = true", "", DataViewRowState.CurrentRows).ToTable());
                else if (UserType == 1)  //BTV xem các bài thuộc chuyên mục của mềnh
                {
                    grvListArticleDataSource(new DataView(new cmsArticleBL().SelectByTrangThaiAndUserCreateBTV(ArticleType, 0, CatID, userCreate), "IsPublish = true", "", DataViewRowState.CurrentRows).ToTable());
                }
                else if (UserType == 2) //TK đều được xem ko quan tâm user
                    grvListArticleDataSource(new DataView(new cmsArticleBL().SelectByTrangThaiAndUserCreate(ArticleType, 0, CatID), "IsPublish = true", "", DataViewRowState.CurrentRows).ToTable());
            }
            else if (ArticleType == 4) // Nếu là bài trả lại Biên tập thì chỉ Biên tập được xem, TK xem, PV ko xem
            {
                if (UserType == 1)
                    grvListArticleDataSource(new cmsArticleBL().SelectByTrangThaiAndUserCreateBTV(ArticleType, 0, CatID, userCreate));
                else if (UserType == 2) //BTV đều được xem ko quan tâm user
                    grvListArticleDataSource(new cmsArticleBL().SelectByTrangThaiAndUserCreate(ArticleType, 0, CatID));
            }
            else if (ArticleType == 5) // Nếu là bài trả lại PV thì chỉ PV được xem bài của mình, BTV được xem hết, TK ko xem
            {
                if (UserType == 0) // PV chỉ xem bài mình
                    grvListArticleDataSource(new cmsArticleBL().SelectByTrangThaiAndUserCreate(ArticleType, userCreate, CatID));
                else if (UserType == 1) //BTV đều được xem ko quan tâm user
                    grvListArticleDataSource(new cmsArticleBL().SelectByTrangThaiAndUserCreateBTV(ArticleType, 0, CatID, userCreate));
                else if (UserType == 2) //BTV đều được xem ko quan tâm user
                    grvListArticleDataSource(new cmsArticleBL().SelectByTrangThaiAndUserCreate(ArticleType, 0, CatID));
            }
        }
        protected void grvListArticleDataSource(DataTable dtsource)
        {
            grvListArticle.DataSource = dtsource;
            grvListArticle.DataBind();
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
            LoadContent();
        }

        #region Phóng viên
        protected void btnGuiBTV_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 3;// "Gửi chờ xuất bản";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
            objHistory.Comment = "";
            string contents = "Phóng viên " + Session["UserName"].ToString() + " gửi biên tập bài viết: <b>";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();

            string articleList = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objArt = artBL.Select(objArt);

                    articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                    objHistory.Contents = contents + artBL.Select(objArt).Title + " </b>";
                    objHistory.ArticleID = objArt.ArticleID;
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
                new cmsArticleBL().ChuyenTrangThai_PhongVien(articleList, 1, DateTime.Now);
                Ultility.Alert("Gửi biên tập thành công", Request.Url.ToString());
            }
            //string articleList = GetSelectedArticle();
            //if (string.IsNullOrEmpty(articleList))
            //{
            //    Functions.Alert("Vui lòng chọn bài viết");
            //    return;
            //}
            //new cmsArticleBL().ChuyenTrangThai_PhongVien(articleList, 1, DateTime.Now);
            //Ultility.Alert("Gửi biên tập thành công", Request.Url.ToString());
        }

        protected void btnXoaPV_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 10;// "Gửi chờ xuất bản";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
            objHistory.Comment = "";
            string contents = "Phóng viên " + Session["UserName"].ToString() + " xóa bài viết : <b>";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();

            string articleList = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objArt = artBL.Select(objArt);

                    articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                    objHistory.Contents = contents + artBL.Select(objArt).Title + " </b>";
                    objHistory.ArticleID = objArt.ArticleID;
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
                new cmsArticleBL().MultiDelete(articleList);
                Ultility.Alert("Xóa bài viết thành công", Request.Url.ToString());
            }
            //string articleList = GetSelectedArticle();
            //if (string.IsNullOrEmpty(articleList))
            //{
            //    Functions.Alert("Vui lòng chọn bài viết");
            //    return;
            //}
            //new cmsArticleBL().MultiDelete(articleList);
            //Ultility.Alert("Xóa bài viết thành công", Request.Url.ToString());
        }
        #endregion

        #region Biên tập viên


        protected void btnBTVChiuTrachNhiem_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 4;// "Đăng ký chịu trách nhiệm bài viết";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
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
                        objHistory.ArticleID = objArt.ArticleID;
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


        protected void btnTKChiuTrachNhiem_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 4;// "Đăng ký chịu trách nhiệm bài viết";
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.HistoryTime = DateTime.Now;
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
            objHistory.Comment = "";
            string contents = "Thư ký " + Session["UserName"].ToString() + " đăng ký chịu trách nhiệm bài viết: <b>";
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
                        objHistory.ArticleID = objArt.ArticleID;
                        historyBL.Insert(objHistory);
                        isNotOK = false;
                    }
                    // Nếu ko thì chả làm gì cả, next bản ghi tiếp
                }
            }
            articleList += "-9999";
            if (isNotOK == true)
            {
                Functions.Alert("Đăng ký không thành công, bài viết đã có người biên tập. Vui lòng chọn lại");
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
            objHistory.Action = 5;// "Gửi chờ xuất bản";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
            objHistory.Comment = "";
            string contents = "Biên tập viên " + Session["UserName"].ToString() + " gửi xuất bản bài viết: <b>";
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
                            objHistory.Contents = contents + artBL.Select(objArt).Title + " </b>";
                            objHistory.ArticleID = objArt.ArticleID;
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
        protected void btnTraLaiPhongVien_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 9;// "Biên tập viên trả bài phóng viên";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
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
                            objHistory.ArticleID = objArt.ArticleID;
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
                new cmsArticleBL().ChuyenTrangThai_BienTapVien(articleList, 5, bienTapVienID, DateTime.Now);
                Ultility.Alert("Trả bài viết thành công", Request.Url.ToString());
            }
        }
        protected void btnGuiXuatBan_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 5;// "Gửi chờ xuất bản";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
            objHistory.Comment = "";
            string contents = "Biên tập viên " + Session["UserName"].ToString() + " gửi xuất bản bài viết: <b>";
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
                    if (objArt.BTVEdit == int.Parse(Session["UserID"].ToString()))
                    {
                        articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                        objHistory.Contents = contents + artBL.Select(objArt).Title + " </b>";
                        objHistory.ArticleID = objArt.ArticleID;
                        historyBL.Insert(objHistory);
                        isNotOK = false;
                    }
                    else { isNotOK = true; }
                }
            }
            articleList += "-9999";
            if (isNotOK == true)
            {
                Functions.Alert("Bạn không đủ quyền hạn gửi xuất bản bài viết!");
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
                new cmsArticleBL().ChuyenTrangThai_BienTapVien(articleList, 2, bienTapVienID, DateTime.Now);
                Ultility.Alert("Gửi bài viết chờ xuất bản thành công", Request.Url.ToString());
            }
        }


        protected void btnXoaBTV_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 10;// "Xóa bài viết";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
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
                    objHistory.ArticleID = objArt.ArticleID;
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
        #endregion Biên tập viên

        #region Thư ký
        protected void btnTraBTV_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 8;// "Thư ký trả bài biên tập viên";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
            objHistory.Comment = "";
            string contents = "Thư ký " + Session["UserName"].ToString() + " trả bài viết: ";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();

            //  bool isNotOK = false;
            string articleList = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objArt = artBL.Select(objArt);
                    articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                    objHistory.Contents = contents + artBL.Select(objArt).Title + " </b> yêu cầu biên tập viên biên tập lại";
                    objHistory.ArticleID = objArt.ArticleID;
                    historyBL.Insert(objHistory);
                    //    isNotOK = false;
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
                int thuKyID = int.Parse(Session["UserID"].ToString());
                int thuKyEdit = thuKyID;
                new cmsArticleBL().ChuyenTrangThai_ThuKy(0, articleList, 4, thuKyID, thuKyEdit, DateTime.Now, false);
                Ultility.Alert("Trả bài viết biên tập viên thành công", Request.Url.ToString());
            }
        }

        protected void btnTKTraPV_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 9;// "Thư ký trả bài phóng viên";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
            objHistory.Comment = "";
            string contents = "Thư ký " + Session["UserName"].ToString() + " trả bài viết: ";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();

            //  bool isNotOK = false;
            string articleList = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objArt = artBL.Select(objArt);
                    articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                    objHistory.Contents = contents + artBL.Select(objArt).Title + " </b> yêu cầu phóng viên viết lại";
                    objHistory.ArticleID = objArt.ArticleID;
                    historyBL.Insert(objHistory);
                    //    isNotOK = false;
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
                int thuKyID = int.Parse(Session["UserID"].ToString());
                int thuKyEdit = thuKyID;
                new cmsArticleBL().ChuyenTrangThai_ThuKy(0, articleList, 5, thuKyID, thuKyEdit, DateTime.Now, false);
                Ultility.Alert("Trả bài viết phóng viên thành công", Request.Url.ToString());
            }
        }

        protected void btnHuyDuyetXB_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 7;// "Thư ký hủy duyệt xuất bản";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
            objHistory.Comment = "";
            string contents = "Thư ký " + Session["UserName"].ToString() + " hủy duyệt xuất bản bài viết: ";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();

            //  bool isNotOK = false;
            string articleList = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objArt = artBL.Select(objArt);
                    articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                    objHistory.Contents = contents + artBL.Select(objArt).Title + " </b>";
                    objHistory.ArticleID = objArt.ArticleID;
                    historyBL.Insert(objHistory);

                    ///Xoa cache
                    DataTable dtCategory = new cmsArticleCategoryBL().SelectByArticleID(objArt.ArticleID);
                    if (dtCategory != null && dtCategory.Rows.Count > 0)
                    {
                        for (int iCate = 0; iCate < dtCategory.Rows.Count; iCate++)
                        {
                            string keycat = "CatID=" + dtCategory.Rows[iCate]["CategoryID"];
                            cache.Remove(keycat);
                        }
                    }
                    //    isNotOK = false;
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
                int thuKyID = int.Parse(Session["UserID"].ToString());
                int thuKyEdit = thuKyID;
                new cmsArticleBL().ChuyenTrangThai_ThuKy(1, articleList, 2, thuKyID, thuKyEdit, DateTime.Now, false);
                Ultility.Alert("Hủy duyệt xuất bản thành công", Request.Url.ToString());
            }
        }

        protected void btnDuyetXuatBan_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 6;// "Thư ký duyệt xuất bản";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
            objHistory.Comment = "";
            string contents = "Thư ký " + Session["UserName"].ToString() + " duyệt xuất bản bài viết: ";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();

            //  bool isNotOK = false;
            string articleList = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objArt = artBL.Select(objArt);
                    articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                    objHistory.Contents = contents + artBL.Select(objArt).Title + " </b>";
                    objHistory.ArticleID = objArt.ArticleID;
                    historyBL.Insert(objHistory);
                    ///Xoa cache
                    DataTable dtCategory = new cmsArticleCategoryBL().SelectByArticleID(objArt.ArticleID);
                    if (dtCategory != null && dtCategory.Rows.Count > 0)
                    {
                        for (int iCate = 0; iCate < dtCategory.Rows.Count; iCate++)
                        {
                            string keycat = "CatID=" + dtCategory.Rows[iCate]["CategoryID"];
                            cache.Remove(keycat);
                        }
                    }
                    //    isNotOK = false;
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
                int thuKyID = int.Parse(Session["UserID"].ToString());
                int thuKyEdit = thuKyID;
                new cmsArticleBL().ChuyenTrangThai_ThuKy(1, articleList, 3, thuKyID, thuKyEdit, DateTime.Now, true);
                Ultility.Alert("Duyệt xuất bản thành công", Request.Url.ToString());
            }
        }

        protected void btnXoaTK_Click(object sender, EventArgs e)
        {
            int TypeID = int.Parse(Request.QueryString["Type"]);
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 10;// "Gửi chờ xuất bản";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
            objHistory.Comment = "";
            string contents = "Thư ký " + Session["UserName"].ToString() + " xóa bài viết : <b>";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();

            string articleList = "";

            string sResult = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objArt = artBL.Select(objArt);

                    articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                    objHistory.Contents = contents + artBL.Select(objArt).Title + " </b>";
                    objHistory.ArticleID = objArt.ArticleID;
                    // Nếu TypeID == 3 => ghi nhận
                    if (TypeID == 3)
                        sResult = sResult + artBL.CheckBeforeDelete(objArt.ArticleID) + "\n";
                    // Còn lại thì lưu History + Delete(Bên dưới)
                    else
                    {
                        //#1
                        historyBL.Insert(objHistory);
                    }
               
                    
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
                // Nếu như là bài đã xuất bản thì check lại, nếu ko thì xóa gì thì xóa
                if (TypeID == 3)
                {
                    // Nếu có dữ liệu trong các bảng nghi sờ vấn => tạm hoãn đã
                    if (!sResult.Equals("\n"))
                    {
                        divInfoDelete.Visible = true;
                        ltrDeleteInfo.Text = sResult;
                    }
                    // suýt quên, ko có dữ liệu trong các bảng nghi sờ vấn => xóa!
                    else
                    {
                        //#2
                        new cmsArticleBL().MultiDelete(articleList);
                        Ultility.Alert("Xóa bài viết thành công(ko có trong các bảng quan trọng)", Request.Url.ToString());
                    }
                }
                // Không phải là bài đã xuất bản, xóa vô tư, ko cần check
                else
                {
                    //#3
                        new cmsArticleBL().MultiDelete(articleList);
                        Ultility.Alert("Xóa bài viết thành công", Request.Url.ToString());
                }
            }
            //string articleList = GetSelectedArticle();
            //if (string.IsNullOrEmpty(articleList))
            //{
            //    Functions.Alert("Vui lòng chọn bài viết");
            //    return;
            //}
            //new cmsArticleBL().MultiDelete(articleList);
            //Ultility.Alert("Xóa bài viết thành công", Request.Url.ToString());
        }
        protected void btnDeleteSubmit_Click(object sender, EventArgs e)
        {
            cmsHistoryBL historyBL = new cmsHistoryBL();
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.Action = 10;// "Gửi chờ xuất bản";
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
            objHistory.Comment = "";
            string contents = "Thư ký " + Session["UserName"].ToString() + " xóa bài viết : <b>";
            cmsArticleBL artBL = new cmsArticleBL();
            cmsArticleDO objArt = new cmsArticleDO();

            string articleList = "";

            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());
                    objArt = artBL.Select(objArt);

                    articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                    objHistory.Contents = contents + artBL.Select(objArt).Title + " </b>";
                    objHistory.ArticleID = objArt.ArticleID;
                    //#4
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
                //#5
                new cmsArticleBL().MultiDelete(articleList);
                divInfoDelete.Visible = false;
                Ultility.Alert("Xóa bài viết thành công(đã xóa)", Request.Url.ToString());
            }
        }
        protected void btnDeleteCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }
        #endregion Thư ký


        private string GetSelectedArticle()
        {
            string articleList = "";
            for (int i = 0; i < grvListArticle.Rows.Count; i++)
            {
                GridViewRow row = grvListArticle.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    articleList += grvListArticle.DataKeys[row.RowIndex].Value.ToString() + ",";
                    objArt.ArticleID = int.Parse(grvListArticle.DataKeys[row.RowIndex].Value.ToString());

                }
            }
            articleList += "-9999";
            if (articleList.Equals("-9999"))
            {
                //Functions.Alert("Vui lòng chọn bài viết");
                return string.Empty; ;
            }
            return articleList;

        }
        public string returnPub(string ids)
        {
            cmsArticleDO obk = new cmsArticleDO();
            obk.ArticleID = int.Parse(ids);
            obk = new cmsArticleBL().Select(obk);
            if (obk.IsWaitingPublish) return "<span style='color:red; font-weight:bold;'>Đang chờ</span>";
            return "-";

        }
        protected void grvListArticle_DataBound(object sender, EventArgs e)
        {
            int type = int.Parse(Request.QueryString["Type"]);
            int userID = int.Parse(Session["UserID"].ToString());
            int UserType = int.Parse(Session["UserType"].ToString());

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

                if (UserType == 1)
                {
                    grvListArticle.Columns[10].Visible = false;
                    grvListArticle.Columns[11].Visible = true;
                    grvListArticle.Columns[9].Visible = true;
                }
                else  if (UserType == 2)
                {
                    grvListArticle.Columns[10].Visible = true;
                    grvListArticle.Columns[11].Visible = true;
                    grvListArticle.Columns[9].Visible = true;
                }
                else
                {
                    grvListArticle.Columns[9].Visible = false;
                }



            }
            else if (type == 2) // Bài viết chờ xuất bản
            {
                grvListArticle.Columns[4].Visible = false;
                grvListArticle.Columns[7].Visible = false;
                grvListArticle.Columns[8].Visible = false;
                // Quyền Thư ký -> có thể sửa
                if (UserType == 2)
                {
                    grvListArticle.Columns[9].Visible = true;
                    grvListArticle.Columns[10].Visible = true;
                    grvListArticle.Columns[11].Visible = true;

                }
                // Quyền khác -> ko thể
                else
                    grvListArticle.Columns[9].Visible = false;
            }
            else if (type == 3)
            {
                grvListArticle.Columns[4].Visible = false;
                // Quyền Thư ký -> có thể sửa
                if (UserType == 2)
                {
                    grvListArticle.Columns[5].Visible = false;
                    grvListArticle.Columns[6].Visible = false;
                    grvListArticle.Columns[9].Visible = true;
                    grvListArticle.Columns[11].Visible = true;
                }
                // Quyền khác -> ko thể
                // Quyền phóng viên
                else if (UserType == 0)
                {
                    grvListArticle.Columns[3].Visible = false;
                    grvListArticle.Columns[5].Visible = true;
                    grvListArticle.Columns[6].Visible = false;
                    grvListArticle.Columns[7].Visible = true;
                    grvListArticle.Columns[8].Visible = false;
                    grvListArticle.Columns[9].Visible = false;
                }
                else
                {
                    grvListArticle.Columns[5].Visible = false;
                    grvListArticle.Columns[9].Visible = false;
                }
            }
        }
        cmsArticleDO objArt = new cmsArticleDO();
        cmsArticleBL artBL = new cmsArticleBL();
        protected void grvListArticle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int type = int.Parse(Request.QueryString["Type"]);
            int UserType = int.Parse(Session["UserType"].ToString());
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
                        btnEdit.Visible = true;
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
                else if (type == 2)
                {
                    if (UserType == 2)
                    {
                        ImageButton btnDelete = e.Row.FindControl("btnDelete") as ImageButton;
                        btnDelete.Visible = false;
                    }
                }
                else if (type == 3)
                {
                    if (UserType == 2)
                    {
                        ImageButton btnDelete = e.Row.FindControl("btnDelete") as ImageButton;
                        btnDelete.Visible = false;
                    }
                }
            }
        }
        //search
        protected void rcbCat_Init(object sender, EventArgs e)
        {
            RadComboBox objCombo = ((RadComboBox)sender);
            RadTreeView treeView = (RadTreeView)objCombo.Items[0].FindControl("RadTreeView1");
            if (null != treeView)
            {
                treeView.DataTextField = "Title";
                treeView.DataFieldID = "CategoryID";
                treeView.DataValueField = "CategoryID";
                treeView.DataFieldParentID = "ParentCID";
                treeView.DataSource = new cmsCategoryBL().SelectAll();
                treeView.DataBind();
            }
        }

    }
}
