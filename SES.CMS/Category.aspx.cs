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
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadTime();
            if (!string.IsNullOrEmpty(Request.QueryString["CategoryID"]))
            {
                int categoryID = int.Parse(Request.QueryString["CategoryID"]);
                rptCategoryDataSoucre(categoryID);
                rptBuildChildMenu(categoryID);
                Page.Title = new cmsCategoryBL().Select(new cmsCategoryDO { CategoryID = categoryID }).Title + " - " + (new sysConfigBL().Select(new sysConfigDO { ConfigID = 1 }).ConfigValue);
                BuildEvent(categoryID);
                loadBreadcrumb(categoryID);
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
        protected void rptBuildChildMenu(int categoryID)
        {
            MasterPage master = this.Master as MasterPage;
            Control ucCateMenu = master.FindControl("ucCateMenu2") as Control;
            Repeater rptCateMenu = ucCateMenu.FindControl("rptChildMenu") as Repeater;

            cmsCategoryDO objCate = new cmsCategoryDO();
            objCate.CategoryID = categoryID;
            objCate = new cmsCategoryBL().Select(objCate);

            if (objCate.ParentID == 0)
            {
                rptCateMenu.DataSource = new cmsCategoryBL().SelectByParent(categoryID);
                rptCateMenu.DataBind();
            }
            else if (objCate.ParentID > 0)
            {
                rptCateMenu.DataSource = new cmsCategoryBL().SelectByParent(objCate.ParentID);
                rptCateMenu.DataBind();
            }
        }

        private Cache cache = HttpContext.Current.Cache;
        protected void rptCategoryDataSoucre(int categoryID)
        {
            int PageID = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["Page"]))
                PageID = int.Parse(Request.QueryString["Page"]);
           
            int PageSize = 15;
            
            hplNextPage.NavigateUrl = "/" + Ultility.Change_AVCate(new cmsCategoryBL().Select(new cmsCategoryDO { CategoryID = categoryID }).Title) + "-" + categoryID.ToString() + "-Trang-" + (PageID+1).ToString() + ".otofun";
            if (PageID > 0)
            {
                if (PageID > 1)
                    hplPrevPage.NavigateUrl = "/" + Ultility.Change_AVCate(new cmsCategoryBL().Select(new cmsCategoryDO { CategoryID = categoryID }).Title) + "-" + categoryID.ToString() + "-Trang-" + (PageID - 1).ToString() + ".otofun";
                else
                    hplPrevPage.NavigateUrl = "/" + Ultility.Change_AVCate(new cmsCategoryBL().Select(new cmsCategoryDO { CategoryID = categoryID }).Title) + "-" + categoryID.ToString() + ".otofun";
                
            }
            else
                hplPrevPage.Visible = false;
            int PageID2 = PageID;
            PageID = PageSize * PageID;


             string keycatpage = categoryID.ToString() + "-" + PageID.ToString();
            int SumcountCat = new cmsArticleBL().SelectSumCat(categoryID);
            
            if ((PageID + PageSize) >= SumcountCat) hplNextPage.Visible = false;
            if (SumcountCat == 0) return;
            string keycount = categoryID.ToString() + "-" + SumcountCat.ToString();
            if (cache[keycount] == null) //Nếu null thì thêm
            {
             
             cache.Insert(keycount, keycount, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
             
            }
           
                if(cache[keycount].ToString()!=keycount) //Nếu không null thì kiểm tra xem có trùng tổng không. nếu không trùng thì xóa + ghi bản ghi mới
                {
                    cache.Remove(keycount);
                    cache.Insert(keycount, keycount, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                    
                    cache.Remove(keycatpage);
                    DataTable dtPage = new cmsArticleBL().SelectPaging(categoryID,PageID,PageSize);
                    cache.Insert(keycatpage, dtPage, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                   
                }
                else
                {
                   
                   if(cache[keycatpage]==null)
                   {
                    DataTable dtPage = new cmsArticleBL().SelectPaging(categoryID,PageID,PageSize);
                    cache.Insert(keycatpage, dtPage, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                   }
                }
                //Nếu trùng tổng kiểm tra xem có cache trang chưa
            
            
            rptCategory.DataSource = (DataTable)cache[keycatpage];

            rptCategory.DataBind();
        }

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
                    divCategory.Attributes.Add("class", "category-wrap");
                }
                else
                {
                    divCategory.Attributes.Add("class", "category-wrap-first");
                }

                DataRowView drv = (DataRowView)item.DataItem;
                int articleID = 0;
                articleID = int.Parse(drv["ArticleID"].ToString());

                string keyTinLienQuan1 = "TinLienQuanCache1=" + articleID;
                if (cache[keyTinLienQuan1] == null)
                {
                    DataTable dtTinLienQuan1 = artBL.GetTinLienQuan1(articleID);
                    if (dtTinLienQuan1 != null)
                        if (dtTinLienQuan1 != null)
                            cache.Insert(keyTinLienQuan1, dtTinLienQuan1, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                }
                rptTinLienQuan1.DataSource = (DataTable)cache[keyTinLienQuan1];
                rptTinLienQuan1.DataBind();


            }
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        public string ReturnCateID()
        {
            string url = Request.Url.AbsolutePath;
            string rt = url.Substring(1, url.Length - 8);
            return rt;

        }
        public string WordCut(string text)
        {
            return Ultility.WordCut(text, 260, new char[] { ' ', '.', ',', ';' }) + "...";
        }
    }
}