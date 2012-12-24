/*
  Copyright 2009 Smart Enterprise Solution Corp.
  Email: contact@ses.vn - Website: http://www.ses.vn
  KimNgan Project.
*/
using System;
using System.Data;
using System.Configuration;
using System.Collections;

using SES.CMS.DAL;
using SES.CMS.DO;
/// <summary>
/// Summary description for cmsArticleBL
/// </summary>
namespace SES.CMS.BL
{
    public class cmsArticleBL
    {
        #region Private Variables
        cmsArticleDAL objcmsArticleDAL;
        #endregion

        #region Public Constructors
        public cmsArticleBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsArticleDAL = new cmsArticleDAL();
        }
        #endregion

        #region Public Methods
        public int Insert(cmsArticleDO objcmsArticleDO)
        {
            return objcmsArticleDAL.Insert(objcmsArticleDO);
        }

        public int Update(cmsArticleDO objcmsArticleDO)
        {
            return objcmsArticleDAL.Update(objcmsArticleDO);

        }

        public int Delete(cmsArticleDO objcmsArticleDO)
        {
            return objcmsArticleDAL.Delete(objcmsArticleDO);

        }

        public int DeleteAll()
        {
            return objcmsArticleDAL.DeleteAll();
        }

        public cmsArticleDO Select(cmsArticleDO objcmsArticleDO)
        {
            return objcmsArticleDAL.Select(objcmsArticleDO);
        }

        public ArrayList SelectAll1()
        {
            return objcmsArticleDAL.SelectAll1();
        }

        public DataTable SelectAll()
        {
            return objcmsArticleDAL.SelectAll();
        }



        #endregion


        public DataTable SelectByCategoryID(int CategoryID)
        {
            return objcmsArticleDAL.SelectByCategoryID(CategoryID);
        }
        public DataTable SelectByCategoryID1(int categoryID)
        {
            return objcmsArticleDAL.SelectByCategoryID1(categoryID);
        }
        public DataTable SelectByCategoryID2(int categoryID)
        {
            return objcmsArticleDAL.SelectByCategoryID2(categoryID);
        }
        public DataTable SelectByCatNum(int CategoryID, int Recordnumber)
        {
            return objcmsArticleDAL.SelectByCatNum(CategoryID, Recordnumber);
        }

        public DataTable SelectOne(cmsArticleDO objArt)
        {
            return objcmsArticleDAL.SelectOne(objArt);
        }
        public DataTable LastestNews()
        {
            return objcmsArticleDAL.LastestNews();
        }
        public DataTable MostRead()
        {
            return objcmsArticleDAL.MostRead();
        }
        public DataTable SelectToMainHomepageCate(int top, int categoryID, bool type)
        {
            return objcmsArticleDAL.SelectToMainHomepageCate(top, categoryID, type);
        }
        public DataTable SelectByPK(int articleID)
        {
            return objcmsArticleDAL.SelectByPK(articleID);
        }
        public DataTable SelectDanhMucNoiBat(int type)
        {
            return objcmsArticleDAL.SelectDanhMucNoiBat(type);
        }
        public DataTable HotEvents(int categoryID)
        {
            return objcmsArticleDAL.HotEvents(categoryID);
        }
        public DataTable Events()
        { return objcmsArticleDAL.Events(); }
        public DataTable NewArticles()
        { return objcmsArticleDAL.NewArticles(); }
        public DataTable SelectAllEventArticle(int eventID)
        {
            return objcmsArticleDAL.SelectAllEventArticle(eventID);
        }
        public void XetDuyetNhieuBaiViet(string articleIDList, bool isAccepted, int userXetDuyet)
        {
            objcmsArticleDAL.XetDuyetNhieuBaiViet(articleIDList, isAccepted, userXetDuyet);
        }
        public DataTable ArticleXetDuyet_Filter(int categoryID, int isAccepted, int userID)
        {
            return objcmsArticleDAL.ArticleXetDuyet_Filter(categoryID, isAccepted, userID);
        }
        public DataTable SelectByTag(string tag)
        {
            return objcmsArticleDAL.SelectByTag(tag);
        }
        public DataTable HotArticle_UnderSlideHomepage()
        {
            return objcmsArticleDAL.HotArticle_UnderSlideHomepage();
        }

        public DataTable SelectByCatType(int type)
        {
            return objcmsArticleDAL.SelectByCatType(type);
        }

        public DataTable SelectHomeNews(int CategoryID)
        {
            return objcmsArticleDAL.SelectHomeNews(CategoryID);
        }
        public DataTable GetTinLienQuan1(int articleID)
        {
            return objcmsArticleDAL.GetTinLienQuan1(articleID);

        }
        public DataTable GetTinLienQuan2(int articleID)
        {
            return objcmsArticleDAL.GetTinLienQuan2(articleID);
        }
    }

}
