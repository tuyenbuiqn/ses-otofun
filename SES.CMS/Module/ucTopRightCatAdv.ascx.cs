using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SES.CMS.Module
{
    public partial class ucTopRightCatAdv : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["CategoryID"] != null))
            {
                int id = int.Parse(Request.QueryString["CategoryID"]);
                if (id == 11 || id == 13 || id == 14)
                    divBMW.Visible = true;
                else if (id == 40 || id == 19 || id == 6 || id == 7)
                {
                    catTTDN.Visible = true;
                    if (id == 40) imgBanner.ImageUrl = "/Ads/pico.jpg";
                    if (id == 19) imgBanner.ImageUrl = "/Ads/RNAULT-300X250.gif";
                    if (id == 6 || id == 7) imgBanner.ImageUrl = "/Ads/ferrari.jpg";

                }
                else if (id == 27 || id == 28 || id == 29)
                    catImg.Visible = true;
                else if (id == 15 || id == 16 || id == 18 || id == 38 || id == 39)
                    divTopcare.Visible = true;
                else if (id == 33 || id == 34 || id == 35 || id == 36)
                    divGW.Visible = true;
                else if (id == 37) divHuongsen.Visible = true;
                else if (id == 5) divCuuHo116.Visible = true;
                else if (id == 3) divHoangGia.Visible = true;


            }


        }
    }
}