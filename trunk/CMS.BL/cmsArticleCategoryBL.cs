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
/// Summary description for cmsArticleCategoryBL
/// </summary>
namespace SES.CMS.BL 
{
    public class cmsArticleCategoryBL 
    {
    	#region Private Variables
		cmsArticleCategoryDAL objcmsArticleCategoryDAL;
		#endregion
		
        #region Public Constructors
        public cmsArticleCategoryBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsArticleCategoryDAL=new cmsArticleCategoryDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsArticleCategoryDO objcmsArticleCategoryDO)
        {
            return objcmsArticleCategoryDAL.Insert(objcmsArticleCategoryDO);
        }

        public int Update(cmsArticleCategoryDO objcmsArticleCategoryDO)
        {
             return objcmsArticleCategoryDAL.Update(objcmsArticleCategoryDO);

        }

      

         public int DeleteAll()
        {
             return objcmsArticleCategoryDAL.DeleteAll();
        }

        public cmsArticleCategoryDO Select(cmsArticleCategoryDO objcmsArticleCategoryDO)
        {
            return objcmsArticleCategoryDAL.Select(objcmsArticleCategoryDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsArticleCategoryDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsArticleCategoryDAL.SelectAll();
        }


     
#endregion          
        public int DeleteByArticleID(int articleID)
        {
            return objcmsArticleCategoryDAL.DeleteByArticleID(articleID);
        }

      

        public DataTable SelectByArticleID(int articleID)
        {
            return objcmsArticleCategoryDAL.SelectByArticleID(articleID);
        }
        public DataTable SelectDistinctCategoryByArticleID(int articleID)
        {
            return objcmsArticleCategoryDAL.SelectDistinctCategoryByArticleID(articleID);
        }
    }

}
