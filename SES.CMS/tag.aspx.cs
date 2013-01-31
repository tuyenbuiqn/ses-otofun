using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.DO;
using SES.CMS.BL;
using System.Data;

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
            }
        }

        protected void loadTime()
        {
            DateTime dateTime = DateTime.Now;
            ltrDatetime.Text = Ultility.vietNameseDay(dateTime.DayOfWeek) + ", ngày " + dateTime.Date.Day + " tháng " + dateTime.Month + " năm " + dateTime.Year;
        }
        protected void loadBreadcrumb(int categoryID)
        {
            cmsCategoryDO objCate = new cmsCategoryDO();
            objCate.CategoryID = categoryID;
            objCate = new cmsCategoryBL().Select(objCate);
            string rootUrl = "<a href='/" + Ultility.Change_AV(objCate.Title) + "-" + objCate.CategoryID + ".otofun' title='" + objCate.Title + "'>" + objCate.Title + "</a>";
            if (objCate.ParentID == 0)
            {
                lblBreadcrumb.Text = rootUrl;
            }
            else
            {
                lblBreadcrumb.Text = rootUrl;
                objCate.CategoryID = objCate.ParentID;
                objCate = new cmsCategoryBL().Select(objCate);

                lblBreadcrumb.Text = "<a href='/" + Ultility.Change_AV(objCate.Title) + "-" + objCate.CategoryID + ".otofun' title='" + objCate.Title + "'>" + objCate.Title + "</a>" + " » " + rootUrl;
            }
        }
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
            hplNextPage.NavigateUrl = "/tag/otofun-" + tag + "-Trang-" + (PageID + 1).ToString() + ".otofun";
            if (PageID > 0)
            {
                if (PageID > 1)
                    hplPrevPage.NavigateUrl = "/tag/otofun-" + tag + "-Trang-" + (PageID - 1).ToString() + ".otofun";
                else
                    hplPrevPage.NavigateUrl = "/tag/otofun-" + tag + ".otofun";
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

        protected void rptTag_ItemDataBound(object sender, RepeaterItemEventArgs e)
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