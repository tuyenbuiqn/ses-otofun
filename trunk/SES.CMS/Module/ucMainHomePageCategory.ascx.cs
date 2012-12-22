using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.DO;
using SES.CMS.BL;
using System.Data;

namespace SES.CMS.Module
{
    public partial class ucMainHomePageCategory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptCategoryParentDataSource();
        }

        protected void rptCategoryParentDataSource()
        {

            DataTable dtCateParent = new cmsCategoryBL().SelectAll();
            rptCategoryParent.DataSource = new DataView(dtCateParent, " IsHomPage = 1 and IsPublish = 1 and ParentID = 0", " OrderID ASC", DataViewRowState.CurrentRows);
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

                DataTable dtMenuChild = cateBL.SelectByParent(int.Parse(drv["CategoryID"].ToString()));
                DataTable dtTopHighLight = artBL.SelectHomeNews(int.Parse(drv["CategoryID"].ToString()));

                

                int topArtID = 0;
                if (dtTopHighLight.Rows.Count > 0)
                    topArtID = int.Parse(dtTopHighLight.Rows[0]["ArticleID"].ToString());
                Repeater rptChildCate = (Repeater)item.FindControl("rptChildCate");
                rptChildCate.DataSource = dtMenuChild;
                rptChildCate.DataBind();

                Repeater rptTopHighLight = (Repeater)item.FindControl("rptTopHighLight");
                rptTopHighLight.DataSource = new DataView(dtTopHighLight, "ArticleID=" + topArtID.ToString(), "", DataViewRowState.CurrentRows).ToTable();
                rptTopHighLight.DataBind();

                DataTable dtTopOtherHighLight = new DataView(dtTopHighLight, "ArticleID <> " + topArtID.ToString(), "", DataViewRowState.CurrentRows).ToTable();

                Repeater rptTopOtherHighLight = (Repeater)item.FindControl("rptTopOtherHighLight");
                rptTopOtherHighLight.DataSource = dtTopOtherHighLight;
                rptTopOtherHighLight.DataBind();
            }
        }

        public string WordCut(string text)
        {
            return Ultility.WordCut(text, 200, new char[] { ' ', '.', ',', ';' }) + "...";
        }
    }
}