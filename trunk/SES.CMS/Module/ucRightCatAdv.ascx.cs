﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SES.CMS.Module
{
    public partial class ucRightCatAdv : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["CategoryID"] != null))
            {
                int CategoryID = int.Parse(Request.QueryString["CategoryID"]);
                if (CategoryID == 27 || CategoryID == 28 || CategoryID == 29 || CategoryID == 11 || CategoryID == 13 || CategoryID == 14 || CategoryID == 19)
                {
                    right300x600.Text = "<script type=\"text/javascript\" src=\"http://ads.otv.vn:81/ads_box_47.ads\"></script>";
                }
                else if (CategoryID == 15 || CategoryID == 16 || CategoryID == 18 || CategoryID == 3 || CategoryID == 6 || CategoryID == 7 || CategoryID == 33 || CategoryID == 34 || CategoryID == 35 || CategoryID == 36)
                {
                    right300x600.Text = "<script type=\"text/javascript\" src=\"http://ads.otv.vn:81/ads_box_49.ads\"></script>";
                }
                else if (CategoryID == 5 || CategoryID == 37 || CategoryID == 38 || CategoryID == 39)
                {
                    right300x600.Text = "<script type=\"text/javascript\" src=\"http://ads.otv.vn:81/ads_box_51.ads\"></script>";
                }
            }
        }
    }
}