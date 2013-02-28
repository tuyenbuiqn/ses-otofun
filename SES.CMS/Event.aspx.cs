using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using System.Data;
using System.Web.Caching;
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
                ltrKey.Text = new cmsEventBL().Select(new cmsEventDO { EventID = eventID }).Title;
                Page.Title = new cmsEventBL().Select(new cmsEventDO { EventID = eventID }).Title + " - " + (new sysConfigBL().Select(new sysConfigDO { ConfigID = 1 }).ConfigValue);
                BuildEvent();
            }
            else
            {
                ltrKey.Text = "DÒNG SỰ KIỆN";
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
           // ltrDatetime.Text = Ultility.vietNameseDay(dateTime.DayOfWeek) + ", ngày " + dateTime.Date.Day + " tháng " + dateTime.Month + " năm " + dateTime.Year;
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
        private Cache cache = HttpContext.Current.Cache;
        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            cmsCategoryBL cateBL = new cmsCategoryBL();
            cmsArticleBL artBL = new cmsArticleBL();
            RepeaterItem item = e.Item;
            Repeater rptTinLienQuan1 = (Repeater)e.Item.FindControl("rptTinLienQuan1");
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Panel divCategory = (Panel)e.Item.FindControl("divCategory");
                if (e.Item.ItemIndex == 0)
                {
                    divCategory.Attributes.Add("class", "category-wrap-first");
                }
                else
                {
                    divCategory.Attributes.Add("class", "category-wrap-first");
                }

                DataRowView drv = (DataRowView)item.DataItem;
                int articleID = 0;
                articleID = int.Parse(drv["ArticleID"].ToString());
                int tinLienQuanID = 0;
                string keyTinLienQuan1 = "TinLienQuanCache1=" + articleID;
                if (cache[keyTinLienQuan1] == null)
                {
                    DataTable dtTinLienQuan1 = artBL.GetTinLienQuan1(articleID);
                    if (dtTinLienQuan1.Rows.Count > 0)
                        tinLienQuanID = int.Parse(dtTinLienQuan1.Rows[0]["ArticleID"].ToString());
                    if (dtTinLienQuan1 != null)
                        if (dtTinLienQuan1 != null)
                            cache.Insert(keyTinLienQuan1, dtTinLienQuan1, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                }
                DataTable dtCateTinLienQuan = (DataTable)cache[keyTinLienQuan1];
                rptTinLienQuan1.DataSource = dtCateTinLienQuan;
                rptTinLienQuan1.DataBind();
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