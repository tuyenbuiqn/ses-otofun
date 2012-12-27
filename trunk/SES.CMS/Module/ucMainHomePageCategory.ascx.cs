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

namespace SES.CMS.Module
{
    public partial class ucMainHomePageCategory : System.Web.UI.UserControl
    {
        private Cache cache = HttpContext.Current.Cache;
        protected void Page_Load(object sender, EventArgs e)
        {
            rptCategoryParentDataSource();
        }
        protected void rptCategoryParentDataSource()
        {
            //  DataTable dtCateParent = new cmsCategoryBL().SelectAll();

            if (cache["DataTables"] == null)
            {
                DataTable dtCache = new DataView(new cmsCategoryBL().SelectAll(), " IsHomPage = 1 and IsPublish = 1 and ParentID = 0", " OrderID ASC", DataViewRowState.CurrentRows).ToTable();
                cache.Insert("DataTables", dtCache, null,DateTime.Now.AddSeconds(150), TimeSpan.Zero);
            }
            rptCategoryParent.DataSource = (DataTable)cache["DataTables"];
            rptCategoryParent.DataBind();

        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        protected void rptCategoryParent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            cmsCategoryBL cateBL = new cmsCategoryBL();
            cmsArticleBL artBL = new cmsArticleBL();
            RepeaterItem item = e.Item;
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)item.DataItem;

                int categoryID = int.Parse(drv["CategoryID"].ToString());

                //Cache childmenu
                string keyCacheChildMenu = "ChildMenu=" + categoryID;
                if (cache[keyCacheChildMenu] == null)
                {
                    DataTable dtMenuChild = cateBL.SelectByParent(categoryID);
                    cache.Insert(keyCacheChildMenu, dtMenuChild, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                }
                Repeater rptChildCate = (Repeater)item.FindControl("rptChildCate");
                rptChildCate.DataSource = (DataTable)cache[keyCacheChildMenu];
                rptChildCate.DataBind();

                //cache top hightlight
                string keyCacheTopHightLight = "TopHightLight=" + categoryID;
                if (cache[keyCacheTopHightLight] == null)
                {
                    DataTable dtTopHighLight = artBL.SelectHomeNews(categoryID);
                    cache.Insert(keyCacheTopHightLight, dtTopHighLight, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                }
                DataTable dtCacheTopHight = (DataTable)cache[keyCacheTopHightLight];
                int topArtID = 0;
                if (dtCacheTopHight.Rows.Count > 0)
                    topArtID = int.Parse(dtCacheTopHight.Rows[0]["ArticleID"].ToString());
                Repeater rptTopHighLight = (Repeater)item.FindControl("rptTopHighLight");
                rptTopHighLight.DataSource = new DataView(dtCacheTopHight, "ArticleID=" + topArtID.ToString(), "", DataViewRowState.CurrentRows).ToTable();
                rptTopHighLight.DataBind();

                string keyCacheOther = "Other=" + categoryID;
                if (cache[keyCacheOther] == null)
                {
                    DataTable dtTopOtherHighLight = new DataView(dtCacheTopHight, "ArticleID <> " + topArtID.ToString(), "", DataViewRowState.CurrentRows).ToTable();
                    cache.Insert(keyCacheOther, dtTopOtherHighLight, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                }
                Repeater rptTopOtherHighLight = (Repeater)item.FindControl("rptTopOtherHighLight");
                rptTopOtherHighLight.DataSource = (DataTable)cache[keyCacheOther];
                rptTopOtherHighLight.DataBind();
            }
        }
        protected void rptTopHightLight_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            cmsCategoryBL cateBL = new cmsCategoryBL();
            cmsArticleBL artBL = new cmsArticleBL();
            RepeaterItem item = e.Item;
          //  Repeater rptTopHightLight = (Repeater)rptCategoryParent.FindControl("rptTopHighLight");
            
            //if (rptTopHightLight.Items.Count > 0)
            //{
                Repeater rptTinLienQuan1 = (Repeater)e.Item.FindControl("rptTinLienQuan1");
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    DataRowView drv = (DataRowView)item.DataItem;
                    int articleID = 0;
                    articleID = int.Parse(drv["ArticleID"].ToString());

                    string keyTinLienQuan1 = "TinLienQuan1=" + articleID;
                    if (cache[keyTinLienQuan1] == null)
                    {
                        DataTable dtTinLienQuan1 = artBL.GetTinLienQuan1(articleID);
                        if(dtTinLienQuan1!=null)
                        cache.Insert(keyTinLienQuan1, dtTinLienQuan1, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                    }
                    rptTinLienQuan1.DataSource = (DataTable)cache[keyTinLienQuan1];
                    rptTinLienQuan1.DataBind();
                }
            //}
        }
        protected DataTable dtTinLienQuan1(int articleID)
        {
            DataTable dtTinLienQuan1 = new DataTable();
            dtTinLienQuan1.Columns.Add("Tag", typeof(string));
            string sTinLienQuan1 = new cmsArticleBL().Select(new cmsArticleDO { ArticleID = articleID }).TinLienQuan1;
            if (string.IsNullOrEmpty(sTinLienQuan1))
            {
                dtTinLienQuan1 = null;
            }
            else
            {
                string[] tagArray = sTinLienQuan1.Split(',');
                for (int i = 1; i < tagArray.Length - 1; i++)
                {
                    dtTinLienQuan1.Rows.Add(tagArray[i]);
                }
            }
            return dtTinLienQuan1;
        }
        public string WordCut(string text)
        {
            return Ultility.WordCut(text, 100, new char[] { ' ', '.', ',', ';' }) + "...";

        }
        public string WordCutArticle(string text)
        {
            return Ultility.WordCut(text, 35, new char[] { ' ', '.', ',', ';' }) + "...";

        }
    }
}