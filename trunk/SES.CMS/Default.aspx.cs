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
            ltrNgay.Text = vietNameseDay(dateTime.DayOfWeek) + ", ngày " + dateTime.Date.Day + " tháng " + dateTime.Month + " năm " + dateTime.Year;

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
        public string vietNameseDay(DayOfWeek dow)
        {
            string vietNameseDay = "";
            switch (dow)
            {
                case DayOfWeek.Sunday:
                    vietNameseDay = "Chủ nhật";
                    break;
                case DayOfWeek.Monday:
                    vietNameseDay = "Thứ hai";
                    break;
                case DayOfWeek.Tuesday:
                    vietNameseDay = "Thứ ba";
                    break;
                case DayOfWeek.Wednesday:
                    vietNameseDay = "Thứ tư";
                    break;
                case DayOfWeek.Thursday:
                    vietNameseDay = "Thứ năm";
                    break;
                case DayOfWeek.Friday:
                    vietNameseDay = "Thứ sáu";
                    break;
                case DayOfWeek.Saturday:
                    vietNameseDay = "Thứ bảy";
                    break;
            }
            return vietNameseDay;
        }
    }
}