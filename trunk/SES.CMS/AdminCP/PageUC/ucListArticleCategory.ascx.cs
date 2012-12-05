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

namespace SES.CMS.AdminCP.PageUC
{
    public partial class ucListArticleCategory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tlCategory.DataSource = new cmsCategoryBL().SelectAll();
            tlCategory.DataBind();
            tlCategory.ExpandToLevel(3);
        }

        protected void tlCategory_StartNodeEditing(object sender, DevExpress.Web.ASPxTreeList.TreeListNodeEditingEventArgs e)
        {
            int id = 0;
            if (int.TryParse(tlCategory.EditingNodeKey, out id))
            {
                Response.Redirect("Default.aspx?Page=ArticleCategory&CategoryID=" + id.ToString());
            }
        }

        protected void tlCategory_NodeDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
            new cmsCategoryBL().Delete(new cmsCategoryDO() { CategoryID = int.Parse(tlCategory.FocusedNode.Key) });
            Response.Redirect("Default.aspx?Page=ListArticleCategory");
        }
    }
}