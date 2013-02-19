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
            //ltrNgay.Text = Ultility.vietNameseDay(dateTime.DayOfWeek) + ", ngày " + dateTime.Date.Day + "/" + dateTime.Month + "/" + dateTime.Year;

            Page.Title = new sysConfigBL().Select(new sysConfigDO { ConfigID = 1}).ConfigValue;
            BuildEvent();
        }
        protected void BuildEvent()
        {
            MasterPage master = this.Master as MasterPage;
            Control ucEvent = master.FindControl("ucEvent3") as Control;
            Repeater rptEvent = ucEvent.FindControl("rptEvent") as Repeater;

            rptEvent.DataSource = new cmsEventBL().GetTopEvent(5);
            rptEvent.DataBind();
        }
       
    }
}