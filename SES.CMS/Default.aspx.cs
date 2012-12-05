using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.DO;
using SES.CMS.BL;

namespace SES.CMS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            ltrNgay.Text = "Thứ 2, " + " ngày " + dateTime.Date.Day + " tháng " + dateTime.Month + " năm " + dateTime.Year;

            Page.Title = new sysConfigBL().Select(new sysConfigDO { ConfigID = 1}).ConfigValue;
        }
    }
}