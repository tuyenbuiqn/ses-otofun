using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.DO;
using SES.CMS.BL;
namespace SES.CMS.ofeditor
{
    public partial class Slide : System.Web.UI.Page
    {
        cmsSlideDO objSlide = new cmsSlideDO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] == null || Session["UserName"] == null)
            {
                Response.Redirect("/ofeditor/Login.aspx");
            }
            else
            {
                int userType = int.Parse(Session["UserType"].ToString());
                //if (userType == 2)
                //{ }
            }
            if (Request.QueryString["SlideID"] != null)
            {
                objSlide.SlideID = int.Parse(Request.QueryString["SlideID"].ToString());
                if (!IsPostBack)
                    initForm();
            }
        }

        private void initForm()
        {

            objSlide = new cmsSlideBL().Select(objSlide);
            txtTitle.Text = objSlide.Title;
            //txtDescription.Text = objSlide.Description;
            txtSlideURL.Text = objSlide.SlideUrl;
            if (!string.IsNullOrEmpty(objSlide.SlideImg))
            {
                imgSlide.Visible = true;
                imgSlide.ImageUrl = objSlide.SlideImg;
            }
            //txtOrder.Text = objSlide.OrderID.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            initObject();
            if (objSlide.SlideID <= 0)
            {
                new cmsSlideBL().Insert(objSlide);
            }
            else
            {
                new cmsSlideBL().Update(objSlide);
            }
            Functions.Alert("Cập nhật thành công!", "Slides.aspx");
        }

        private void initObject()
        {
            //if (objSlide.SlideID > 0)
            //{
            //    initForm();
            //}
            objSlide.Title = hdfTitle.Value;
            //objSlide.Description = txtDescription.Text;
            objSlide.SlideImg = hdfIMG.Value;
           
            objSlide.SlideUrl = hdfURL.Value;
            //objSlide.OrderID = int.Parse(txtOrder.Text);

        }
       

        

       
    }
}