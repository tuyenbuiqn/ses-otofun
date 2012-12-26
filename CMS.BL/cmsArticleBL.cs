/*
  Copyright 2009 Smart Enterprise Solution Corp.
  Email: contact@ses.vn - Website: http://www.ses.vn
  KimNgan Project.
*/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using SES.CMS.DAL;
using SES.CMS.DO;
using System.Collections.Generic;
using System.Reflection;
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

        public DataTable Article_Search(string lstCategoryID, DateTime ArticleSearchDateStart, DateTime ArticleSearchDateEnd, string Keyw)
        {
            return objcmsArticleDAL.Article_Search(lstCategoryID, ArticleSearchDateStart, ArticleSearchDateEnd, Keyw);
        }

        public DataTable GetMultiID(string StrArticleID)
        {
            return objcmsArticleDAL.GetMultiID(StrArticleID);
        }

        public List<cmsArticleDO> GetListMultiID(string StrArticleID)
        {
            return ConvertTo<cmsArticleDO>(GetMultiID(StrArticleID));
        }

        public List<T> ConvertTo<T>(DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }
        public T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }
        public DataTable SelectByTrangThaiAndUserCreate(int trangThai, int userCreate,int cate)
        {
            return objcmsArticleDAL.SelectByTrangThaiAndUserCreate(trangThai, userCreate,cate);
        }

    }

}
