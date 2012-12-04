using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SES.CMS.BL;

namespace SES.CMS.AdminCP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(new DateTime(1900, 01, 01, 00, 00, 00, 00));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblUsername.Text = Session["Username"].ToString();
            }
        //    Session["UserID"] = 1;
            if (Request.QueryString.Count == 0)
            {
                Control MnuPage = LoadControl("MenuUC/ucMnuMoPhan.ascx");
                phSubNav.Controls.Add(MnuPage);
                hplListMoPhan.CssClass = "active";
                MnuPage = LoadControl("MenuUC/ucMnuMoPhan.ascx");
            }
            else
            {
                Control CtrlPage = LoadControl("PageUC/uc" + Request.QueryString["Page"] + ".ascx");
                Control MnuPage = null;
                phPageControl.Controls.Add(CtrlPage);
                switch (Request.QueryString["Page"].ToString())
                {
                    //Menu danh mục
                    case "ListArticleCategory":
                        hplCategory.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuCategory.ascx");
                        break;
                    case "ArticleCategory":
                        hplCategory.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuCategory.ascx");
                        break;
                    case "ListArticle":
                        hplCategory.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuCategory.ascx");
                        break;
                    case "Article":
                        hplCategory.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuCategory.ascx");
                        break;
                    case "ListAboutUs":
                        hplCategory.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuCategory.ascx");
                        break;
                  
                    // Menu Mộ Phần
                    case "ListMoPhan":
                        hplListMoPhan.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuMoPhan.ascx");
                        break;
                    case "MoPhan":
                        hplListMoPhan.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuMoPhan.ascx");
                        break;
                    case "ListNghiaTrang":
                        hplListMoPhan.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuMoPhan.ascx");
                        break;
                    case "NghiaTrang":
                        hplListMoPhan.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuMoPhan.ascx");
                        break;
                    case "ListKhuVuc":
                        hplListMoPhan.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuMoPhan.ascx");
                        break;
                    case "KhuVuc":
                        hplListMoPhan.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuMoPhan.ascx");
                        break;
                    case "ListCaNhan":
                        hplListMoPhan.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuMoPhan.ascx");
                        break;
                    case "CaNhan":
                        hplListMoPhan.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuMoPhan.ascx");
                        break;
                    case "ChiTietGiaoDichMoPhan":
                        hplListMoPhan.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuMoPhan.ascx");
                        break;

                    // Menu dịch vụ
                    case "ListDichVu":
                        hplDichVu.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuDichVu.ascx");
                        break;
                    case "DichVu":
                        hplDichVu.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuDichVu.ascx");
                        break;
                    case "Cart":
                        hplDichVu.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuDichVu.ascx");
                        break;
                    case "CartDetail":
                        hplDichVu.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuDichVu.ascx");
                        break;

                    // Menu nhân  viên
                    case "ListNhanVien":
                        hplNhanVien.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNhanVien.ascx");
                        break;
                    case "NhanVien":
                        hplNhanVien.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNhanVien.ascx");
                        break;
                    case "ListPhanCong":
                        hplNhanVien.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNhanVien.ascx");
                        break;
                    case "PhanCong":
                        hplNhanVien.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNhanVien.ascx");
                        break;

                    // Menu Hệ thống
                    case "ListUser":
                        hplConfig.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuConfig.ascx");
                        break;
                    case "User":
                        hplConfig.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuConfig.ascx");
                        break;
                    case "ListConfig":
                        hplConfig.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuConfig.ascx");
                        break;
                    case "Config":
                        hplConfig.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuConfig.ascx");
                        break;
                   

                        // Menu khách hàng
                    case "ListCustomer":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;
                    case "Customer":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;
                    case "ListBinhLuan":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;
                    case "ListTaiKhoan":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;
                    case "ListNhacNho":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;
                    case "NhacNho":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;
                    case "ChiTietGiaoDichKhachHang":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;
                    case "TaiKhoan":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;
                    case "LogAccount":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;
                    case "CreateAccount":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;
                    case "ListHoanTra":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;

                    case "ListCamNhan":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;

                    case "CamNhan":
                        hplQLNguoiDung.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuQlNguoiDung.ascx");
                        break;
                        // Menu album
                    case "Album":
                        hplAlbum.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuAlbum.ascx");
                        break;
                    case "ListAlbum":
                        hplAlbum.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuAlbum.ascx");
                        break;
                    case "AnhDichVu":
                        hplAlbum.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuAlbum.ascx");
                        break;
                    case "ListAnhDichVu":
                        hplAlbum.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuAlbum.ascx");
                        break;
                    case "AddMultiImg":
                        hplAlbum.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuAlbum.ascx");
                        break;
                    case "ListSlide":
                        hplAlbum.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuAlbum.ascx");
                        break;
                    case "Slide":
                        hplAlbum.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuAlbum.ascx");
                        break;

                   


                }
                phSubNav.Controls.Add(MnuPage);
            }
        }

        //public string checkNonCustomer()
        //{
        //    string s = " ";
        //    DataTable dt = new cmsThongTinKHBL().SelectNonAll();
        //    if (dt.Rows.Count == 0)
        //    {
        //        return s;
        //    }
        //    else
        //    {
        //        string s1 = "Co " + dt.Rows.Count + " Ban chua dang ky!";
        //        s = "<a href=\"Default.aspx?Page=nonCustomer\">" + s1 + "</a>";
        //        return s;
        //    }
        //}
        //public string checkNonServices()
        //{
        //    string s = " ";
        //    DataTable dt = new cmsThongTinKHBL().getNonServ();
        //    if (dt.Rows.Count == 0)
        //    {
        //        return s;
        //    }
        //    else
        //    {
        //        string s1 = "Co " + dt.Rows.Count + " Ban chua chuan bi!";
        //        s = "<a href=\"Default.aspx?Page=Queue\">" + s1 + "</a>";
        //        return s;
        //    }
        //}
    }
}
