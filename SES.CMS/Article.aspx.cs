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
using System.Web.UI.HtmlControls;

namespace SES.CMS
{
    public partial class Article : System.Web.UI.Page
    {
        private Cache cache = HttpContext.Current.Cache;
        cmsCommentDO objcomment = new cmsCommentDO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["CategoryID"]))
            {
                int categoryID = int.Parse(Request.QueryString["CategoryID"]);
                if (categoryID == 5 || categoryID == 15 || categoryID == 3)
                    divad.Visible = true;

                //if (categoryID == 27 || categoryID == 28 || categoryID == 29 || categoryID == 11 || categoryID == 13 || categoryID == 14 || categoryID == 19)
                //    ltAds.Text = "<script type=\"text/javascript\" src=\"http://ads.otv.vn:81/ads_box_63.ads\"></script>";
                //else if (categoryID == 15 || categoryID == 16 || categoryID == 18 || categoryID == 33 || categoryID == 34 || categoryID == 35 || categoryID == 36 || categoryID == 3 || categoryID == 6 || categoryID == 7)
                //    ltAds.Text = "<script type=\"text/javascript\" src=\"http://ads.otv.vn:81/ads_box_62.ads\"></script>";
                //else if (categoryID == 5 || categoryID == 37 || categoryID == 39 || categoryID == 38)
                //    ltAds.Text = "<script type=\"text/javascript\" src=\"http://ads.otv.vn:81/ads_box_64.ads\"></script>";

            }
            if (!string.IsNullOrEmpty(Request.QueryString["ArticleID"]))
            {
                int articleID = int.Parse(Request.QueryString["ArticleID"]);

                if (!IsPostBack)
                {
                    string CurrentUrl = "http://" + Request.Url.Host + Request.RawUrl;
                    hplFacebook.NavigateUrl = hplFacebook.NavigateUrl + CurrentUrl;
                    hplGoogle.NavigateUrl = hplGoogle.NavigateUrl + CurrentUrl;
                    hplTwitter.NavigateUrl = hplTwitter.NavigateUrl + CurrentUrl;
                    


                    //abc.Attributes.Add("src", "//www.facebook.com/plugins/like.php?href=" + CurrentUrl + "&send=false&layout=button_count&width=450&show_faces=false&action=like&colorscheme=light&font&height=21&appId=379138395463852");
                    abc.Attributes.Add("src", "//www.facebook.com/plugins/like.php?href=" + CurrentUrl + "&send=false&layout=button_count&width=450&show_faces=false&action=like&colorscheme=light&font&height=21&appId=379138395463852");
                    if (Session["artIpAddress"] == null)
                    {
                        UpdateLuotView(articleID);
                    }
                    else if (Session["artIpAddress"] != null)
                    {
                        if (Session["readedArticle"] == null)
                        {
                            UpdateLuotView(articleID);
                        }
                        else
                        {
                            int readedArticle = int.Parse(Session["readedArticle"].ToString());
                            if (articleID != readedArticle)
                            {
                                UpdateLuotView(articleID);
                            }
                        }
                    }
                    Session["artIpAddress"] = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                    Session["readedArticle"] = articleID;

                    rptArticeDataSource(articleID);
                    //Load Cate, Breadcrumb
                    loadOtherInfo();

                    DataTable dtArticle = new cmsArticleBL().SelectByPK(articleID);
                    if (dtArticle.Rows.Count > 0)
                    {
                        Page.Title = dtArticle.Rows[0]["Title"].ToString() + " - " + (new sysConfigBL().Select(new sysConfigDO { ConfigID = 1 }).ConfigValue);
                        Page.Header.Controls.Add(Ultility.AddDescription(dtArticle.Rows[0]["Description"].ToString()));
                    }
                    else
                    {
                        Page.Title = "Tin tức - " + (new sysConfigBL().Select(new sysConfigDO { ConfigID = 1 }).ConfigValue);
                    }
                    

                    HtmlMeta myLinkIMG = new HtmlMeta();
                    
                    myLinkIMG.Attributes.Add("property", "og:site_name");
                    myLinkIMG.Content = "Otofun News";
                    Page.Header.Controls.Add(myLinkIMG);

                    myLinkIMG = new HtmlMeta();
                    myLinkIMG.Attributes.Add("property", "og:title");
                    myLinkIMG.Content = dtArticle.Rows[0]["Title"].ToString();
                    Page.Header.Controls.Add(myLinkIMG);

                    myLinkIMG = new HtmlMeta();
                    myLinkIMG.Attributes.Add("property", "og:image");
                    myLinkIMG.Content = "http://news.otofun.net/Media/" + dtArticle.Rows[0][cmsArticleDO.IMAGEURL_FIELD].ToString();
                    //myLinkIMG.Content = "http://news.otofun.net/test.jpg";
                    Page.Header.Controls.Add(myLinkIMG);

                    myLinkIMG = new HtmlMeta();
                    myLinkIMG.Attributes.Add("property", "og:image");
                    myLinkIMG.Content = "http://news.otofun.net/Media/" + dtArticle.Rows[0][cmsArticleDO.IMAGEURL_FIELD].ToString();
                    //myLinkIMG.Content = "http://news.otofun.net/test.jpg";
                    Page.Header.Controls.Add(myLinkIMG);

                    myLinkIMG = new HtmlMeta();
                    myLinkIMG.Attributes.Add("property", "og:image");
                    myLinkIMG.Content = "http://news.otofun.net/Media/" + dtArticle.Rows[0][cmsArticleDO.IMAGEURL_FIELD].ToString();
                    //myLinkIMG.Content = "http://news.otofun.net/test.jpg";
                    Page.Header.Controls.Add(myLinkIMG);

                  

                

                    myLinkIMG = new HtmlMeta();
                    myLinkIMG.Attributes.Add("property", "og:description");
                    myLinkIMG.Content = dtArticle.Rows[0]["Description"].ToString();
                    Page.Header.Controls.Add(myLinkIMG);

                    myLinkIMG = new HtmlMeta();
                    myLinkIMG.Attributes.Add("property", "og:url");
                    myLinkIMG.Content = CurrentUrl;
                    Page.Header.Controls.Add(myLinkIMG);

              

                    


                }
            }
        }

        protected void loadOtherInfo()
        {
            int categoryID = -1;
            string url = Request.Url.AbsolutePath;
            url = url.Substring(1, url.Length - 1);
            string url1 = url.Replace(".", "/");
            string Module = url1.Substring(0, url1.IndexOf("/"));
            try
            {
               // string s = Module.Substring(Module.LastIndexOf('-') + 1, Module.Length - (Module.LastIndexOf('-') + 1));
                categoryID = int.Parse(Module.Substring(Module.LastIndexOf('-') + 1, Module.Length - (Module.LastIndexOf('-') + 1)));
            }
            catch{}
            loadBreadcrumb(categoryID);
            rptBuildChildMenu(categoryID);
            BuildEvent(categoryID);
        }
        protected void UpdateLuotView(int articleID)
        {
            cmsArticleDO objArt = new cmsArticleDO();
            objArt.ArticleID = articleID;

            objArt = new cmsArticleBL().Select(objArt);

            if (objArt != null)
            {
                objArt.LuotView = objArt.LuotView + 1;
                new cmsArticleBL().Update(objArt);
            }
        }
        protected void loadBreadcrumb(int categoryID)
        {
            cmsCategoryDO objCate = new cmsCategoryDO();
            objCate.CategoryID = categoryID;
            objCate = new cmsCategoryBL().Select(objCate);

            string rootUrl = "<a href='/" + Ultility.Change_AVCate(objCate.Title) + "-" + objCate.CategoryID + ".ofn' title='" + objCate.Title + "'>" + objCate.Title + "</a>";
            if (objCate.ParentID == 0)
            {
                lblBreadcrumb.Text = rootUrl;
            }
            else
            {
                lblBreadcrumb.Text = rootUrl;
                objCate.CategoryID = objCate.ParentID;
                objCate = new cmsCategoryBL().Select(objCate);

                lblBreadcrumb.Text = "<a class='rootcat' href='/" + Ultility.Change_AVCate(objCate.Title) + "-" + objCate.CategoryID + ".ofn' title='" + objCate.Title + "'>" + objCate.Title + "</a>" + " » " + rootUrl;
            }
        }

        protected void rptArticeDataSource(int articleID)
        {
            string cateArticleDetail = "ArticleDetailCache=" + articleID;
            if (cache[cateArticleDetail] == null)
            {
                DataTable dtArticleCache = new cmsArticleBL().SelectByPK(articleID);
                if (dtArticleCache != null)
                    cache.Insert(cateArticleDetail, dtArticleCache, null, DateTime.Now.AddSeconds(650), TimeSpan.Zero);
            }
            rptArticleDetail.DataSource = (DataTable)cache[cateArticleDetail];
            rptArticleDetail.DataBind();
        }
        protected void rptArticleDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            cmsArticleBL artBL = new cmsArticleBL();
            RepeaterItem item = e.Item;

            Repeater rptTinLienQuan2 = (Repeater)e.Item.FindControl("rptTinLienQuan2");
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)item.DataItem;
                int articleID = 0;
                articleID = int.Parse(drv["ArticleID"].ToString());

                string keyTinLienQuan2 = "TinLienQuan2=" + articleID;
                if (cache[keyTinLienQuan2] == null)
                {
                    DataTable dtTinLienQuan2 = artBL.GetTinLienQuan2(articleID);
                    if (dtTinLienQuan2 != null)
                        cache.Insert(keyTinLienQuan2, dtTinLienQuan2, null, DateTime.Now.AddSeconds(150), TimeSpan.Zero);
                    
                }
                if (((DataTable)cache[keyTinLienQuan2]).Rows.Count > 0)
                {
                    rptTinLienQuan2.DataSource = (DataTable)cache[keyTinLienQuan2];
                    rptTinLienQuan2.DataBind();
                }
                else rptTinLienQuan2.Visible = false;
            }
        }

        protected void BuildEvent(int categoryID)
        {
            MasterPage master = this.Master as MasterPage;
            Control ucEvent = master.FindControl("ucEvent3") as Control;
            Repeater rptEvent = ucEvent.FindControl("rptEvent") as Repeater;

            cmsCategoryDO objCategory = new cmsCategoryDO();
            objCategory.CategoryID = categoryID;
            objCategory = new cmsCategoryBL().Select(objCategory);

            if (objCategory.ParentID == 0)
                rptEvent.DataSource = new cmsEventBL().GetEventByCategoryID(objCategory.CategoryID, 5);
            else
                rptEvent.DataSource = new cmsEventBL().GetEventByCategoryID(objCategory.ParentID, 5);
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
                DataTable dtCate = new cmsCategoryBL().SelectByParent(objCate.CategoryID);
                if (dtCate.Rows.Count > 0)
                {
                    rptCateMenu.DataSource = dtCate;
                    rptCateMenu.DataBind();
                }
            }
            else if (objCate.ParentID > 0)
            {
                rptCateMenu.DataSource = new cmsCategoryBL().SelectByParent(objCate.ParentID);
                rptCateMenu.DataBind();
            }
        }

        public string WordCutArticle(string text)
        {
            return Ultility.WordCut(text, 50, new char[] { ' ', '.', ',', ';' }) + "...";

        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        public string CheckAuth(string s)
        {
            if (string.IsNullOrEmpty(s)) return "Otofun";
            else return s;
        }
    }
}