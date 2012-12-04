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
/// Summary description for cmsLibFileArticleBL
/// </summary>
namespace SES.CMS.BL
{
    public class cmsLibFileArticleBL 
    {
    	#region Private Variables
		cmsLibFileArticleDAL objcmsLibFileArticleDAL;
		#endregion
		
        #region Public Constructors
        public cmsLibFileArticleBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsLibFileArticleDAL=new cmsLibFileArticleDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsLibFileArticleDO objcmsLibFileArticleDO)
        {
            return objcmsLibFileArticleDAL.Insert(objcmsLibFileArticleDO);
        }

        public int Update(cmsLibFileArticleDO objcmsLibFileArticleDO)
        {
             return objcmsLibFileArticleDAL.Update(objcmsLibFileArticleDO);

        }

        public int Delete(cmsLibFileArticleDO objcmsLibFileArticleDO)
        {
             return objcmsLibFileArticleDAL.Delete(objcmsLibFileArticleDO);

        }

         public int DeleteAll()
        {
             return objcmsLibFileArticleDAL.DeleteAll();
        }

        public cmsLibFileArticleDO Select(cmsLibFileArticleDO objcmsLibFileArticleDO)
        {
            return objcmsLibFileArticleDAL.Select(objcmsLibFileArticleDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsLibFileArticleDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsLibFileArticleDAL.SelectAll();
        }


     
#endregion          
    
    }

}
