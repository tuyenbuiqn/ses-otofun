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
            if(!IsPostBack)
            rptCategoryParentDataSource();
        }

        protected void rptCategoryParentDataSource()
        {
            //  DataTable dtCateParent = new cmsCategoryBL().SelectAll();

            if (cache["DataTables"] == null)
            {
                DataTable dtCache = new DataView(new cmsCategoryBL().SelectAll(), " IsHomPage = 1 and IsPublish = 1 and ParentID = 0", " OrderID ASC", DataViewRowState.CurrentRows).ToTable();
                if (dtCache != null)
                    cache.Insert("DataTables", dtCache, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
            }
            rptCategoryParent.DataSource = (DataTable)cache["DataTables"];
            rptCategoryParent.DataBind();

        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }

        protected void rptTopArticle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                 Panel posTop = (Panel)e.Item.FindControl("posTop");
                if (e.Item.ItemIndex == 0)
                {
                    posTop.Attributes.Add("class", "hmp-cate-topart-left");
                }
                else if (e.Item.ItemIndex == 1)
                {
                    posTop.Attributes.Add("class", "hmp-cate-topart-right");
                }
            }

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
                string keyCacheTopArticle = "TopArticle=" + categoryID;
                if (cache[keyCacheTopArticle] == null)
                {
                    DataTable dtTopHomepageArticle = artBL.SelectTopHomeNews(categoryID,8);
                    if (dtTopHomepageArticle != null)
                        cache.Insert(keyCacheTopArticle, dtTopHomepageArticle, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                }
                string keyCacheTopArticle_New = "TopArticle_new=" + categoryID;
                if (cache[keyCacheTopArticle_New] == null)
                {
                    DataTable dtTopHomepageArticle_New = new cmsSetTopBL().SelectByCategoryID(2, categoryID);
                    if (dtTopHomepageArticle_New != null)
                        cache.Insert(keyCacheTopArticle_New, dtTopHomepageArticle_New, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                }
                Repeater rptTopArticle = (Repeater)item.FindControl("rptTopArticle");
                rptTopArticle.DataSource = (DataTable)cache[keyCacheTopArticle_New];// new DataView(dtCateTopHomepageArticle, " STT>=1 and STT<=2", "", DataViewRowState.CurrentRows).ToTable();
                rptTopArticle.DataBind();

                DataTable dtCateTopHomepageArticle = (DataTable)cache[keyCacheTopArticle];

                Repeater rptOtherTopArticleLeft = (Repeater)item.FindControl("rptOtherTopArticleLeft");
                rptOtherTopArticleLeft.DataSource = new DataView(dtCateTopHomepageArticle, " STT>=1 and STT<=3", "", DataViewRowState.CurrentRows).ToTable();
                rptOtherTopArticleLeft.DataBind();

                Repeater rptOtherTopArticleRight = (Repeater)item.FindControl("rptOtherTopArticleRight");
                rptOtherTopArticleRight.DataSource = new DataView(dtCateTopHomepageArticle, " STT>=4 and STT<=6", "", DataViewRowState.CurrentRows).ToTable();
                rptOtherTopArticleRight.DataBind();
                               
                /*
                string keyCacheTopHightLight = "TopHightLight=" + categoryID;
                if (cache[keyCacheTopHightLight] == null)
                {
                    DataTable dtTopHighLight = artBL.SelectHomeNews(categoryID);
                    if (dtTopHighLight != null)
                        cache.Insert(keyCacheTopHightLight, dtTopHighLight, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                }
                DataTable dtCacheTopHight = (DataTable)cache[keyCacheTopHightLight];
                int topArtID1 = 0;
                int topArtID2 = 0;
                if (dtCacheTopHight.Rows.Count > 0)
                    topArtID1 = int.Parse(dtCacheTopHight.Rows[0]["ArticleID"].ToString());
                if (dtCacheTopHight.Rows.Count > 1)
                    topArtID2 = int.Parse(dtCacheTopHight.Rows[1]["ArticleID"].ToString());
                Repeater rptTopArticle = (Repeater)item.FindControl("rptTopArticle");
                rptTopArticle.DataSource = new DataView(dtCacheTopHight, "ArticleID=" + topArtID1.ToString() + " AND  ", "", DataViewRowState.CurrentRows).ToTable();
                rptTopArticle.DataBind();
                 */

                /*       //Cache childmenu
                       string keyCacheChildMenu = "ChildMenu=" + categoryID;
                       if (cache[keyCacheChildMenu] == null)
                       {
                           DataTable dtMenuChild = cateBL.SelectByParent(categoryID);
                           if (dtMenuChild != null)
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
                           if (dtTopHighLight != null)
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
                           if (dtTopOtherHighLight != null)
                               cache.Insert(keyCacheOther, dtTopOtherHighLight, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                       }
                       Repeater rptTopOtherHighLight = (Repeater)item.FindControl("rptTopOtherHighLight");
                       rptTopOtherHighLight.DataSource = (DataTable)cache[keyCacheOther];
                       rptTopOtherHighLight.DataBind();
                   }
                 */
            }
        }

        /*
      
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
           return Ultility.WordCut(text, 100, new char[] { ' ', '.', ',', ';' }) + ".";

       }
       public string WordCutArticle(string text)
       {
           return Ultility.WordCut(text, 35, new char[] { ' ', '.', ',', ';' }) + ".";

       }
        */
    }
}