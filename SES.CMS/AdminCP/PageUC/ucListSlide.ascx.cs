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
            
            gvSlide.DataSource = new cmsSlideBL().SelectAll();
            gvSlide.DataBind();
        }

        protected void gvSlide_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SlideID = int.Parse(gvSlide.DataKeys[gvSlide.SelectedIndex].Value.ToString());
            Response.Redirect("Default.aspx?Page=Slide&SlideID=" + SlideID.ToString());
        }

       

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?Page=Slide");
        }
        protected void btnAddImages_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?Page=AddMultiImg");
        }

        protected void gvSlide_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
       //     new SlideBL().Delete(new SlideDO { SlideID = Convert.ToInt32(gvSlide.DataKeys[e.RowIndex].Value) });
            Functions.Alert("Xóa thành công", "Default.aspx?Page=ListSlide");
        }
    }
}