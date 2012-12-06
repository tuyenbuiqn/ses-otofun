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
    public partial class Article : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ArticleID"]))
            {
                int articleID = int.Parse(Request.QueryString["ArticleID"].ToString());
                rptArticeDataSource(articleID);
                rptBuildChildMenu(articleID);
                Page.Title = new cmsArticleBL().SelectByPK(articleID).Rows[0]["Title"].ToString() + " - " + (new sysConfigBL().Select(new sysConfigDO { ConfigID = 1}).ConfigValue);
            }
        }

        protected void rptArticeDataSource(int articleID)
        {
            rptArticleDetail.DataSource = new cmsArticleBL().SelectByPK(articleID);
            rptArticleDetail.DataBind();
        }
        protected void rptBuildChildMenu(int articleID)
        {
            MasterPage master = this.Master as MasterPage;
            Control ucCateMenu = master.FindControl("ucCateMenu2") as Control;
            Repeater rptCateMenu = ucCateMenu.FindControl("rptChildMenu") as Repeater;

            cmsArticleDO objArt = new cmsArticleDO();
            objArt.ArticleID = articleID;
            objArt = new cmsArticleBL().Select(objArt);

            cmsCategoryDO objCate = new cmsCategoryDO();
            objCate.CategoryID = objArt.CategoryID;
            objCate = new cmsCategoryBL().Select(objCate);

            if (objCate.ParentID == 0)
            {
                DataTable dtCate = new cmsCategoryBL().SelectByParent(objArt.CategoryID);
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
    }
}