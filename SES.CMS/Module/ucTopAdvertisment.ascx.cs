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
           
            if (Request.QueryString["CategoryID"] != null)
            {
                int CategoryID = int.Parse(Request.QueryString["CategoryID"]);
                if (CategoryID == 27 || CategoryID == 28 || CategoryID == 29 || CategoryID == 11 || CategoryID == 13 || CategoryID == 14 || CategoryID == 19)
                { 
                    topBanner.Text = "<script type=\"text/javascript\" src=\"http://ads.otv.vn:81/ads_box_34.ads\"></script>";
                }
                else if (CategoryID == 15 || CategoryID == 16 || CategoryID == 18 || CategoryID == 3 || CategoryID == 6 || CategoryID == 7 || CategoryID == 33 || CategoryID == 34 || CategoryID == 35 || CategoryID == 36)
                {
                    topBanner.Text = "<script type=\"text/javascript\" src=\"http://ads.otv.vn:81/ads_box_38.ads\"></script>";
                }
                else if (CategoryID == 5 || CategoryID == 37 || CategoryID == 38 || CategoryID == 39)
                {
                    topBanner.Text = "<script type=\"text/javascript\" src=\"http://ads.otv.vn:81/ads_box_39.ads\"></script>";
                }
                else

                    topBanner.Text = "<a href=\"http://otofun.net/sendmessage.php\" target=\"_blank\"><img src=\"http://news.otofun.net/Ads/YourAds.jpg\" width=\"670\" height=\"80\"/></a>";
            }
            else //Home
            {
                topBanner.Text = "<script type=\"text/javascript\" src=\"http://ads.otv.vn:81/ads_box_37.ads\"></script>";
            }  

        }
    }
}