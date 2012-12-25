using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using Telerik.Web.UI;

namespace SES.CMS.ofeditor
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                RadGrid1.DataSource = new cmsArticleBL().GetListMultiID("0");
                RadGrid1.DataBind();

                RadGrid2.DataSource = new cmsArticleBL().GetListMultiID("0");
                RadGrid2.DataBind();
            }
        }

        protected void RadComboBox1_Init(object sender, EventArgs e)
        {
            RadComboBox objCombo = ((RadComboBox)sender);
            RadTreeView treeView = (RadTreeView)objCombo.Items[0].FindControl("RadTreeView1");
            if (null != treeView)
            {
                treeView.DataTextField = "Title";
                treeView.DataFieldID = "CategoryID";
                treeView.DataFieldParentID = "ParentCID";
                treeView.DataSource = new cmsCategoryBL().SelectAll();
                treeView.DataBind();
            }
        }
       
    }
}