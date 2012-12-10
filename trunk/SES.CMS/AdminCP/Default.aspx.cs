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
                Control MnuPage = LoadControl("MenuUC/ucMnuArticles.ascx");
                phSubNav.Controls.Add(MnuPage);
                hplDestination.CssClass = "active";
            }
            else
            {
                Control CtrlPage = LoadControl("PageUC/uc" + Request.QueryString["Page"] + ".ascx");
                Control MnuPage = null;
                phPageControl.Controls.Add(CtrlPage);
                switch(Request.QueryString["Page"].ToString())
                {
                    //Danh muc
                    case "Article":
                        hplDestination.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuArticles.ascx");
                        break;
                    case "ListArticle":
                        hplDestination.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuArticles.ascx");
                        break;
                    case "ListArticleCategory":
                        hplDestination.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuArticles.ascx");
                        break;
                    case "ArticleCategory":
                        hplDestination.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuArticles.ascx");
                        break;
                    case "ListEvent":
                        hplDestination.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuArticles.ascx");
                        break;
                    case "Event":
                        hplDestination.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuArticles.ascx");
                        break;
                    case "XetDuyetBaiViet":
                        hplDestination.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuArticles.ascx");
                        break;


                    //Video
                 
                        //Config
                    case "ListConfig":
                        hplConfig.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuConfig.ascx");
                        break;
                    case "Config":
                        hplConfig.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuConfig.ascx");
                        break;

                    case "ListUser":
                        hplConfig.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuConfig.ascx");
                        break;
                    case "User":
                        hplConfig.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuConfig.ascx");
                        break;


                    //Slide
                    case "ListSlide":
                        hplSlide.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuSlide.ascx");
                        break;
                    case "Slide":
                        hplSlide.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuSlide.ascx");
                        break;

                    case "ListAlbum":
                        hplImage.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
                        break;
                    case "ListImages":
                        hplImage.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
                        break;
                    case "Image":
                        hplImage.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
                        break;
                    case "Album":
                        hplImage.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
                        break;
                    case "AddMultiImg":
                        hplImage.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
                        break;

                    case "Video":
                        hplImage.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
                        break;
                    case "ListVideo":
                        hplImage.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
                        break;


                    //Video
                    case "ListAdvertisement":
                        hplAdvertisement.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuAdvertisement.ascx");
                        break;
                    case "Advertisement":
                        hplAdvertisement.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuAdvertisement.ascx");
                        break;

                    //Business Info
                    case "ListBusiness":
                        hplAdvertisement.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuBusinessInfo.ascx");
                        break;
                    case "BusinessInfo":
                        hplAdvertisement.CssClass = "active";
                        MnuPage = LoadControl("MenuUC/ucMnuBusinessInfo.ascx");
                        break;

            //        case "ListClientLogin":
            //            hplImage.CssClass = "active";
            //            MnuPage = LoadControl("MenuUC/ucMnuCustomer.ascx");
            //            break;

            //        case "ClientLogin":
            //            hplImage.CssClass = "active";
            //            MnuPage = LoadControl("MenuUC/ucMnuCustomer.ascx");
            //            break;

            //        case "ListSlide":
            //            hplImage.CssClass = "active";
            //            MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
            //            break;
            //        case "Slide":
            //            hplImage.CssClass = "active";
            //            MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
            //            break;

            //        case "ListImage":
            //            hplImage.CssClass = "active";
            //            MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
            //            break;

            //        case "ListImagealt":
            //            hplImage.CssClass = "active";
            //            MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
            //            break;

            //        case "Images":
            //            hplImage.CssClass = "active";
            //            MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
            //            break;
            //        case "AddMultiImg":
            //            hplImage.CssClass = "active";
            //            MnuPage = LoadControl("MenuUC/ucMnuImages.ascx");
            //            break;
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
