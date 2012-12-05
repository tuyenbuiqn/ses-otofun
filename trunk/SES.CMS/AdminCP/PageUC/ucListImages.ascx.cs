using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SES.CMS.BL;
using SES.CMS.DO;
using SES.CMS.AdminCP;

namespace SES.CMS.AdminCP.PageUC
{
    public partial class ucListImages : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Functions.ddlDatabinder(ddlCate, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectAll());
            //    Functions.ddlDatabinder(ddlSlide, SlideDO.SLIDEID_FIELD, SlideDO.TITLE_FIELD, new SlideBL().SelectAll());
                Functions.ddlDatabinder(ddlArticle, cmsArticleDO.ARTICLEID_FIELD, cmsArticleDO.TITLE_FIELD, new cmsArticleBL().SelectAll());
                dlImagesDataSource();
            }
           
        }

        protected void dlImagesDataSource()
        {

            CollectionPager1.MaxPages = 10000;

            CollectionPager1.PageSize = 50; // số items hiển thị trên một trang

            CollectionPager1.DataSource = new cmsImagesBL().SelectAll().DefaultView;

            CollectionPager1.BindToControl = dlImages;
            dlImages.DataSource = CollectionPager1.DataSourcePaged;
            dlImages.DataBind();
        }
        protected void dlImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ImageID = int.Parse(dlImages.DataKeys[dlImages.SelectedIndex].ToString());
            Response.Redirect("Default.aspx?Page=Image&ImageID=" + ImageID.ToString());
        }

        protected void dlImages_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int PLID = int.Parse(dlImages.DataKeys[e.Item.ItemIndex].ToString());
            new cmsImagesBL().Delete(new cmsImagesDO { ImageID = PLID });

            Functions.Alert("Xóa thành công", "Default.aspx?Page=ListImages");
        }

        protected void ddlCate_SelectedIndexChanged(object sender, EventArgs e)
        {


            CollectionPager1.MaxPages = 10000;

            CollectionPager1.PageSize = 50; // số items hiển thị trên một trang

            CollectionPager1.DataSource = null;// new cmsImagesBL().SelectByCategoryID(int.Parse(ddlCate.SelectedValue)).DefaultView;

            CollectionPager1.BindToControl = dlImages;
            dlImages.DataSource = CollectionPager1.DataSourcePaged;
            dlImages.DataBind();
        }

        protected void ddlArticle_SelectedIndexChanged(object sender, EventArgs e)
        {


            CollectionPager1.MaxPages = 10000;

            CollectionPager1.PageSize = 50; // số items hiển thị trên một trang

            CollectionPager1.DataSource = null;// new cmsImagesBL().SelectByArticleID(int.Parse(ddlArticle.SelectedValue)).DefaultView;

            CollectionPager1.BindToControl = dlImages;
            dlImages.DataSource = CollectionPager1.DataSourcePaged;
            dlImages.DataBind();
        }

        protected void ddlSlide_SelectedIndexChanged(object sender, EventArgs e)
        {


            CollectionPager1.MaxPages = 10000;

            CollectionPager1.PageSize = 50; // số items hiển thị trên một trang

            CollectionPager1.DataSource = null;// new cmsImagesBL().SelectBySlideID(int.Parse(ddlSlide.SelectedValue)).DefaultView;

            CollectionPager1.BindToControl = dlImages;
            dlImages.DataSource = CollectionPager1.DataSourcePaged;
            dlImages.DataBind();
        }
    }
}