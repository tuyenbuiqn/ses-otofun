using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.DO;
using SES.CMS.BL;
using System.Data;
using System.Web.Caching;
namespace SES.CMS
{
    public partial class tag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadTime();
            if (!string.IsNullOrEmpty(Request.QueryString["tag"]))
            {
                string tag = Request.QueryString["tag"];

                Page.Title = "Tag - " + tag + " - " + new sysConfigBL().Select(new sysConfigDO { ConfigID = 1 }).ConfigValue;

                rptTagDataSoucre(tag);
                ltrKey.Text = tag;
            }
        }

        protected void loadTime()
        {
            DateTime dateTime = DateTime.Now;
            //ltrDatetime.Text = Ultility.vietNameseDay(dateTime.DayOfWeek) + ", ngày " + dateTime.Date.Day + " tháng " + dateTime.Month + " năm " + dateTime.Year;
        }
        //protected void loadBreadcrumb(int categoryID)
        //{
        //    cmsCategoryDO objCate = new cmsCategoryDO();
        //    objCate.CategoryID = categoryID;
        //    objCate = new cmsCategoryBL().Select(objCate);
        //    string rootUrl = "<a href='/" + Ultility.Change_AV(objCate.Title) + "-" + objCate.CategoryID + ".ofn' title='" + objCate.Title + "'>" + objCate.Title + "</a>";
        //    if (objCate.ParentID == 0)
        //    {
        //        lblBreadcrumb.Text = rootUrl;
        //    }
        //    else
        //    {
        //        lblBreadcrumb.Text = rootUrl;
        //        objCate.CategoryID = objCate.ParentID;
        //        objCate = new cmsCategoryBL().Select(objCate);

        //        lblBreadcrumb.Text = "<a href='/" + Ultility.Change_AV(objCate.Title) + "-" + objCate.CategoryID + ".ofn' title='" + objCate.Title + "'>" + objCate.Title + "</a>" + " » " + rootUrl;
        //    }
        //}
        protected void BuildEvent(int categoryID)
        {
            MasterPage master = this.Master as MasterPage;
            Control ucEvent = master.FindControl("ucEvent3") as Control;
            Repeater rptEvent = ucEvent.FindControl("rptEvent") as Repeater;

            rptEvent.DataSource = new cmsEventBL().GetEventByCategoryID(categoryID, 5);
            rptEvent.DataBind();
        }

        protected void rptTagDataSoucre(string tag)
        {
            int PageID = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["Page"]))
                PageID = int.Parse(Request.QueryString["Page"]);

            int PageSize = 15;
            hplNextPage.NavigateUrl = "/tag/otofun-" + tag + "-Trang-" + (PageID + 1).ToString() + ".ofn";
            if (PageID > 0)
            {
                if (PageID > 1)
                    hplPrevPage.NavigateUrl = "/tag/otofun-" + tag + "-Trang-" + (PageID - 1).ToString() + ".ofn";
                else
                    hplPrevPage.NavigateUrl = "/tag/otofun-" + tag + ".ofn";
            }
            else
                hplPrevPage.Visible = false;
            int PageID2 = PageID;
            PageID = PageSize * PageID;
            int SumcountTag = new cmsArticleBL().SelectSumTag(tag);

            if ((PageID + PageSize) >= SumcountTag) hplNextPage.Visible = false;
            if (SumcountTag == 0) return;
            DataTable dtPage = new cmsArticleBL().SelectPagingTagOrSearch(tag, PageID, PageSize);
            rptTag.DataSource = dtPage;
            rptTag.DataBind();

            //CollectionPager1.MaxPages = 10000;

            //CollectionPager1.PageSize = 30;

            //DataTable dtTag = new cmsArticleBL().SelectByTag(tag);

            //CollectionPager1.DataSource = new DataView(dtTag, "", "", DataViewRowState.CurrentRows);

            //CollectionPager1.BindToControl = rptTag;

            //rptTag.DataSource = CollectionPager1.DataSourcePaged;

            //rptTag.DataBind();
        }
        private Cache cache = HttpContext.Current.Cache;
        protected void rptTag_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
        public string CheckAuth(string s)
        {
            if (string.IsNullOrEmpty(s)) return "Otofun";
            else return s;
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