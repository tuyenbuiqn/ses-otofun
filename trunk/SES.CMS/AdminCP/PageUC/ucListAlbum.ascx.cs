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
    public partial class ucListAlbum : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvAlbum.DataSource = new cmsAlbumBL().SelectAll();
            gvAlbum.DataBind();
        }

        protected void gvAlbum_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int AlbumID = int.Parse(e.EditingKeyValue.ToString());
            Response.Redirect("Default.aspx?Page=Album&AlbumID=" + AlbumID.ToString());
        }



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?Page=Album");
        }

        protected void gvAlbum_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int PLID = int.Parse(e.Keys["AlbumID"].ToString());
            new cmsAlbumBL().Delete(new cmsAlbumDO { AlbumID = PLID });
     //       new cmsImagesBL().DeleteByalbum(PLID);
            Functions.Alert("Default.aspx?Page=ListAlbum", "Xóa thành công");
        }

        protected void gvAlbum_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AlbumID = int.Parse(gvAlbum.DataKeys[gvAlbum.SelectedIndex].Value.ToString());
            Response.Redirect("Default.aspx?Page=Album&AlbumID=" + AlbumID.ToString());
        }

        protected void gvAlbum_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int PLID = Convert.ToInt32(gvAlbum.DataKeys[e.RowIndex].Value);
            new cmsAlbumBL().Delete(new cmsAlbumDO { AlbumID = PLID });
        //    new cmsImagesBL().DeleteByalbum(PLID);
            Functions.Alert("Xóa thành công", "Default.aspx?Page=ListAlbum");
        }
    }
}