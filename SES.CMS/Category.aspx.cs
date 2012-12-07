﻿using System;
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
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadTime();
            if (!string.IsNullOrEmpty(Request.QueryString["CategoryID"]))
            {
                int categoryID = int.Parse(Request.QueryString["CategoryID"]);
                rptCategoryDataSoucre(categoryID);
                rptBuildChildMenu(categoryID);
                Page.Title = new cmsCategoryBL().Select(new cmsCategoryDO { CategoryID = categoryID}).Title + " - " + (new sysConfigBL().Select(new sysConfigDO { ConfigID = 1 }).ConfigValue);
                BuildEvent(categoryID);
            }
        }

        protected void loadTime()
        {
            DateTime dateTime = DateTime.Now;
            ltrDatetime.Text =  Ultility.vietNameseDay(dateTime.DayOfWeek) + ", ngày " + dateTime.Date.Day + " tháng " + dateTime.Month + " năm " + dateTime.Year;
        }
        protected void loadBreadcrumb(int categoryID)
        {
            cmsCategoryDO objCate = new cmsCategoryDO();
            objCate.CategoryID = categoryID;
            string rootUrl = "";
            if (objCate.ParentID == 0)
            {
                rootUrl = hplBreadcrumb.NavigateUrl = "/" + Ultility.Change_AV(objCate.Title) + "-" + objCate.CategoryID;
                hplBreadcrumb.Text = objCate.Title;
                hplBreadcrumb.ToolTip = objCate.Title;
            }
            else
            {
                hplBreadcrumb.NavigateUrl = "/" + Ultility.Change_AV(objCate.Title) + "-" + objCate.CategoryID;
                hplBreadcrumb.Text = objCate.Title;
                hplBreadcrumb.ToolTip = objCate.Title;
            }
        }
        protected void BuildEvent(int categoryID)
        {
            MasterPage master = this.Master as MasterPage;
            Control ucEvent = master.FindControl("ucEvent3") as Control;
            Repeater rptEvent = ucEvent.FindControl("rptEvent") as Repeater;

            rptEvent.DataSource = new cmsEventBL().GetEventByCategoryID(categoryID, 5);
            rptEvent.DataBind();
        }
        protected void rptBuildChildMenu(int categoryID)
        {
            MasterPage master = this.Master as MasterPage;
            Control ucCateMenu = master.FindControl("ucCateMenu2") as Control;
            Repeater rptCateMenu = ucCateMenu.FindControl("rptChildMenu") as Repeater;

            cmsCategoryDO objCate = new cmsCategoryDO();
            objCate.CategoryID = categoryID;
            objCate = new cmsCategoryBL().Select(objCate);

            if (objCate.ParentID == 0)
            {
                rptCateMenu.DataSource = new cmsCategoryBL().SelectByParent(categoryID);
                rptCateMenu.DataBind();
            }
            else if (objCate.ParentID > 0)
            {
                rptCateMenu.DataSource = new cmsCategoryBL().SelectByParent(objCate.ParentID);
                rptCateMenu.DataBind();
            }
        }
        protected void rptCategoryDataSoucre(int categoryID)
        {
            CollectionPager1.MaxPages = 10000;

            CollectionPager1.PageSize = 30;

            DataTable dtCategory = new cmsArticleBL().SelectByCategoryID1(categoryID);

            CollectionPager1.DataSource = new DataView(dtCategory, "", "", DataViewRowState.CurrentRows);

            CollectionPager1.BindToControl = rptCategory;

            rptCategory.DataSource = CollectionPager1.DataSourcePaged;

            rptCategory.DataBind();
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        public string WordCut(string text)
        {
            return Ultility.WordCut(text, 260, new char[] { ' ', '.', ',', ';' }) + "...";
        }
    }
}