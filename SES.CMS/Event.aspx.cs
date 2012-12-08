using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using System.Data;
namespace SES.CMS
{
    public partial class Event : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadTime();
            if (!string.IsNullOrEmpty(Request.QueryString["EventID"]))
            {
                divEvent.Visible = false;
                divDetail.Visible = true;
                int eventID = int.Parse(Request.QueryString["EventID"]);
                rptCategoryDataSoucre(eventID);
                Page.Title = new cmsEventBL().Select(new cmsEventDO { EventID = eventID }).Title + " - " + (new sysConfigBL().Select(new sysConfigDO { ConfigID = 1 }).ConfigValue);
                BuildEvent();
            }
            else
            {
                divDetail.Visible = false;
                divEvent.Visible = true;
                rptEventDataSource();
                Page.Title ="Dòng sự kiện - " + (new sysConfigBL().Select(new sysConfigDO { ConfigID = 1 }).ConfigValue);
                BuildEvent();
            }
        }
        protected void loadTime()
        {
            DateTime dateTime = DateTime.Now;
            ltrDatetime.Text = Ultility.vietNameseDay(dateTime.DayOfWeek) + ", ngày " + dateTime.Date.Day + " tháng " + dateTime.Month + " năm " + dateTime.Year;
        }
        protected void BuildEvent()
        {
            MasterPage master = this.Master as MasterPage;
            Control ucEvent = master.FindControl("ucEvent3") as Control;
            Repeater rptEvent = ucEvent.FindControl("rptEvent") as Repeater;

            rptEvent.DataSource = new cmsEventBL().GetTopEvent(5);
            rptEvent.DataBind();
        }

        protected void rptCategoryDataSoucre(int eventID)
        {
            CollectionPager1.MaxPages = 10000;

            CollectionPager1.PageSize = 30;

            DataTable dtCategory = new cmsArticleBL().SelectAllEventArticle(eventID);

            CollectionPager1.DataSource = new DataView(dtCategory, "", "", DataViewRowState.CurrentRows);

            CollectionPager1.BindToControl = rptCategory;

            rptCategory.DataSource = CollectionPager1.DataSourcePaged;

            rptCategory.DataBind();
        }

        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Panel divCategory = (Panel)e.Item.FindControl("divCategory");
                if (e.Item.ItemIndex == 0)
                {
                    divCategory.Attributes.Add("class", "category-wrap");
                }
                else
                {
                    divCategory.Attributes.Add("class", "category-wrap-first");
                }
            }
        }
        protected void rptEventDataSource()
        {
            CollectionPager1.MaxPages = 10000;

            CollectionPager1.PageSize = 30;

            DataTable dtCategory = new cmsEventBL().SelectAll();

            CollectionPager2.DataSource = new DataView(dtCategory, "", "", DataViewRowState.CurrentRows);

            CollectionPager2.BindToControl = rptEvent;

            rptEvent.DataSource = CollectionPager2.DataSourcePaged;

            rptEvent.DataBind();
        }
      
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        public string WordCut(string text)
        {
            return Ultility.WordCut(text, 260, new char[] { ' ', '.', ',', ';' }) + "...";
        }
    }
}