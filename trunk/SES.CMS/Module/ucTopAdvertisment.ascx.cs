using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SES.CMS.Module
{
    public partial class ucTopAdvertisment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((Request.QueryString["CategoryID"] == null) && (Request.QueryString["ArticleID"] == null))
            //    homeBanner.Visible = true;
            //else if ((Request.QueryString["CategoryID"] != null) && (Request.QueryString["ArticleID"] == null))
            //    catBanner.Visible = true;
            //else if ((Request.QueryString["ArticleID"] != null))
            //    artBanner.Visible = true;
            //else 0
            artBanner.Visible = true;
            if(Request.QueryString["CategoryID"] != null)
            {
                int id = int.Parse(Request.QueryString["CategoryID"]);
                if (id == 27 || id == 28 || id == 29)
                {
                    Image1.ImageUrl = "/Ads/AudiVN.gif";
                }
                else if (id == 3 || id == 6 || id == 7)
                {
                    Image1.ImageUrl = "/Ads/MEC-Andu-678x80.gif";
                }
                else if (id == 19 || id == 15 || id == 16 || id == 18)
                {
                    Image1.ImageUrl = "/Ads/Toyota-678X80.gif";
                }
                if (id == 11 || id == 13 || id == 14 || id == 5)
                {
                    artBanner.Visible = false;
                    catBanner.Visible = true;
                }
            }
            else
                Image1.ImageUrl = "/Ads/baner-news.jpg";

        }
    }
}