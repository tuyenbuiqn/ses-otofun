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
            objcmsArticleDAL=new cmsArticleDAL();
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

        public ArrayList SelectAll1( )
        {
         return objcmsArticleDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsArticleDAL.SelectAll();
        }


     
#endregion          
    
    
        public DataTable SelectByCategoryID(int CategoryID)
        {
            return objcmsArticleDAL.SelectByCategoryID(CategoryID);
        }

        public DataTable SelectByCatNum(int CategoryID, int Recordnumber)
        {
            return objcmsArticleDAL.SelectByCatNum(CategoryID, Recordnumber);
        }

        public DataTable SelectOne(cmsArticleDO objArt)
        {
            return objcmsArticleDAL.SelectOne(objArt);
        }
    }

}
