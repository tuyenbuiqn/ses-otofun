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

namespace SES.CMS.WEB.AdminCP.PageUC
{
    public partial class ucListSlide : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dlListSlideDataSource();
        }

        private void dlListSlideDataSource()
        {
            CollectionPager1.MaxPages = 10000;

            CollectionPager1.PageSize = 20; 
            DataTable dt = new cmsSlideBL().SelectAll();
            CollectionPager1.DataSource = new DataView(dt, "SlideID > 0", "", DataViewRowState.CurrentRows);

            CollectionPager1.BindToControl = dlListSlide;
            dlListSlide.DataSource = CollectionPager1.DataSourcePaged;

            dlListSlide.DataBind();
        }


        protected void dlListSlide_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ImageID = int.Parse(dlListSlide.DataKeys[dlListSlide.SelectedIndex].ToString());
            Response.Redirect("Default.aspx?Page=Slide&SlideID=" + ImageID.ToString());
        }

        protected void dlListSlide_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int ImageID = int.Parse(dlListSlide.DataKeys[e.Item.ItemIndex].ToString());
            new cmsSlideBL().Delete(new cmsSlideDO { SlideID = ImageID });

            Functions.Alert("Xóa thành công", "Default.aspx?Page=ListSlide");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?Page=Slide");
        }
        protected void btnAddImages_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?Page=AddMultiImg");
        }

    }
}