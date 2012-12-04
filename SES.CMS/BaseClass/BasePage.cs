using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System;

namespace SES.CMS
{
    public class BasePage : Page
    {
        protected override void InitializeCulture()
        {
            string culture = "";
            if (Session["lang"].ToString() == "VN") culture = "vi-VN";
            if (Session["lang"].ToString() == "EN") culture = "en-US";

            //check whether a culture is stored in the session
            if (culture.Length > 0) Culture = culture;

            //set culture to current thread
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            //call base class
            base.InitializeCulture();
        }

    }
}