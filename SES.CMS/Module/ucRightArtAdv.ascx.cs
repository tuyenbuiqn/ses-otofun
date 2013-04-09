using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SES.CMS.Module
{
    public partial class ucRightArtAdv : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["CategoryID"] != null))
            {
                int id = int.Parse(Request.QueryString["CategoryID"]);
                if (id == 11 || id == 13 || id == 14||id == 5)
                    divMazda.Visible = true;
                else if (id == 27 || id == 28 || id == 29)
                    divKia.Visible = divNissan.Visible = true;
                else if (id == 15 || id == 16 || id == 18 || id == 19 || id == 3 || id == 6 || id == 7 || id == 33 || id == 34 || id == 35 || id == 36 || id == 37 || id == 38 || id == 39)
                {
                    divIMG.Visible = true;
                    if (id == 33 || id == 34 || id == 35 || id == 36 || id == 37 || id == 38 || id == 39 || id == 15 || id == 16 || id == 18)
                        imgBanner.ImageUrl = "/Ads/Your-ADS300x450.jpg";
                }
            }
            
        }
    }
}