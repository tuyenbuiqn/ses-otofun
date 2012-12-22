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
    public partial class Article : System.Web.UI.Page
    {
        cmsCommentDO objcomment = new cmsCommentDO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ArticleID"]))
            {
                int articleID = int.Parse(Request.QueryString["ArticleID"].ToString());
                rptArticeDataSource(articleID);
                rptBuildChildMenu(articleID);
                loadBreadcrumb(articleID);
                DataTable dtArticle = new cmsArticleBL().SelectByPK(articleID);
                if (dtArticle.Rows.Count > 0)
                {
                    Page.Title = dtArticle.Rows[0]["Title"].ToString() + " - " + (new sysConfigBL().Select(new sysConfigDO { ConfigID = 1 }).ConfigValue);
                }
                else
                {
                    Page.Title = "Tin tức - " + (new sysConfigBL().Select(new sysConfigDO { ConfigID = 1 }).ConfigValue);
                }
                Page.Header.Controls.Add(Ultility.AddDescription(dtArticle.Rows[0]["Description"].ToString()));
                BuildEvent(articleID);
            }
        }
        protected void loadBreadcrumb(int articleID)
        {
            cmsArticleDO objArt = new cmsArticleDO();
            objArt.ArticleID = articleID;
            objArt = new cmsArticleBL().Select(objArt);

            cmsCategoryDO objCate = new cmsCategoryDO();
            objCate.CategoryID = objArt.CategoryID;
            objCate = new cmsCategoryBL().Select(objCate);

            string rootUrl = "<a href='/" + Ultility.Change_AVCate(objCate.Title) + "-" + objCate.CategoryID + ".aspx' title='" + objCate.Title + "'>" + objCate.Title + "</a>";
            if (objCate.ParentID == 0)
            {
                lblBreadcrumb.Text = rootUrl;
            }
            else
            {
                lblBreadcrumb.Text = rootUrl;
                objCate.CategoryID = objCate.ParentID;
                objCate = new cmsCategoryBL().Select(objCate);

                lblBreadcrumb.Text = "<a href='/" + Ultility.Change_AVCate(objCate.Title) + "-" + objCate.CategoryID + ".aspx' title='" + objCate.Title + "'>" + objCate.Title + "</a>" + " » " + rootUrl;
            }
        }

        protected void rptArticeDataSource(int articleID)
        {
            rptArticleDetail.DataSource = new cmsArticleBL().SelectByPK(articleID);
            rptArticleDetail.DataBind();
        }

        protected void BuildEvent(int articleID)
        {
            MasterPage master = this.Master as MasterPage;
            Control ucEvent = master.FindControl("ucEvent3") as Control;
            Repeater rptEvent = ucEvent.FindControl("rptEvent") as Repeater;

            cmsArticleDO objArt = new cmsArticleDO();
            objArt.ArticleID = articleID;
            objArt = new cmsArticleBL().Select(objArt);

            rptEvent.DataSource = new cmsEventBL().GetEventByCategoryID(objArt.CategoryID, 5);
            rptEvent.DataBind();
        }
        protected void rptBuildChildMenu(int articleID)
        {
            MasterPage master = this.Master as MasterPage;
            Control ucCateMenu = master.FindControl("ucCateMenu2") as Control;
            Repeater rptCateMenu = ucCateMenu.FindControl("rptChildMenu") as Repeater;

            cmsArticleDO objArt = new cmsArticleDO();
            objArt.ArticleID = articleID;
            objArt = new cmsArticleBL().Select(objArt);

            cmsCategoryDO objCate = new cmsCategoryDO();
            objCate.CategoryID = objArt.CategoryID;
            objCate = new cmsCategoryBL().Select(objCate);

            if (objCate.ParentID == 0)
            {
                DataTable dtCate = new cmsCategoryBL().SelectByParent(objArt.CategoryID);
                if (dtCate.Rows.Count > 0)
                {
                    rptCateMenu.DataSource = dtCate;
                    rptCateMenu.DataBind();
                }
            }
            else if (objCate.ParentID > 0)
            {
                rptCateMenu.DataSource = new cmsCategoryBL().SelectByParent(objCate.ParentID);
                rptCateMenu.DataBind();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            initObject();
            objcomment.IsAccepted = false;
            new cmsCommentBL().Insert(objcomment);

            Ultility.Alert("Cám ơn đã đóng góp ý kiến về bài viết. Chúng tôi đã nhận được đóng góp của quý vị", Request.Url.AbsolutePath);
        }

        private void initObject()
        {
            objcomment.ArticleID = int.Parse(Request.QueryString["ArticleID"].ToString());
            objcomment.Contents = txtContent.Text;
            objcomment.CreateDate = DateTime.Now;
            objcomment.Email = txtEmail.Text;
            objcomment.Name = txtHoTen.Text;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtContent.Text = "";
        }
    }
}