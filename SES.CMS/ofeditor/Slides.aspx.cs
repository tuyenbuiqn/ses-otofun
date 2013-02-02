using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using System.Data;


namespace SES.CMS.ofeditor
{
    public partial class Slides : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] == null || Session["UserName"] == null)
            {
                Response.Redirect("/ofeditor/Login.aspx");
            }
            else
            {
                int userType = int.Parse(Session["UserType"].ToString());
                if (userType == 2)
                {
                    if (!IsPostBack)
                    {
                        grvSlideDataSource();
                    }
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
            }
           
        }
        protected void grvSlide_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new cmsSlideBL().Delete(new cmsSlideDO { SlideID = Convert.ToInt32(grvSlide.DataKeys[e.RowIndex].Value) });
            Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
        }
        protected void grvSlide_SelectedIndexChanged(object sender, EventArgs e)
         {
             int slideID = int.Parse(grvSlide.DataKeys[grvSlide.SelectedIndex].Value.ToString());
             Response.Redirect("Slide.aspx?SlideID=" + slideID.ToString());
         }

        private void grvSlideDataSource()
        {
            CollectionPager1.MaxPages = 10000;

            CollectionPager1.PageSize = 20;
            DataTable dt = new cmsSlideBL().SelectAll();
            CollectionPager1.DataSource = new DataView(dt, "SlideID > 0", "", DataViewRowState.CurrentRows);

            CollectionPager1.BindToControl = grvSlide;
            grvSlide.DataSource = CollectionPager1.DataSourcePaged;

            grvSlide.DataBind();
        }


        //protected void dlListSlide_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int ImageID = int.Parse(dlListSlide.DataKeys[dlListSlide.SelectedIndex].ToString());
        //    Response.Redirect("Slide.aspx?SlideID=" + ImageID.ToString());
        //}

        //protected void dlListSlide_DeleteCommand(object source, DataListCommandEventArgs e)
        //{
        //    int ImageID = int.Parse(dlListSlide.DataKeys[e.Item.ItemIndex].ToString());
        //    new cmsSlideBL().Delete(new cmsSlideDO { SlideID = ImageID });

        //    Functions.Alert("Xóa thành công", "Slides.aspx");
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Slide.aspx");
        }
        protected void btnAddImages_Click(object sender, EventArgs e)
        {
          //  Response.Redirect("Default.aspx?Page=AddMultiImg");
        }
    }
}