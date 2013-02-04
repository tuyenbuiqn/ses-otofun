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
/// Summary description for sysUserBL
/// </summary>
namespace SES.CMS.BL 
{
    public class cmsUserCategoryBL
    {
    	#region Private Variables
		cmsUserCategory objcmsUserCategory;
		#endregion
		
        #region Public Constructors
        public cmsUserCategoryBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsUserCategory=new cmsUserCategory();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsUserCategoryDO objcmsUserCategoryDO)
        {
            return objcmsUserCategory.Insert(objcmsUserCategoryDO);
        }

        public int Update(cmsUserCategoryDO objcmsUserCategoryDO)
        {
             return objcmsUserCategory.Update(objcmsUserCategoryDO);

        }

        public int Delete(cmsUserCategoryDO objcmsUserCategoryDO)
        {
             return objcmsUserCategory.Delete(objcmsUserCategoryDO);

        }

         public int DeleteAll()
        {
             return objcmsUserCategory.DeleteAll();
        }

        public cmsUserCategoryDO Select(cmsUserCategoryDO objcmsUserCategoryDO)
        {
            return objcmsUserCategory.Select(objcmsUserCategoryDO);
        }
        public int DeleteByUserID(int userID)
        {
            return objcmsUserCategory.DeleteByUserID(userID);
        }
        public ArrayList SelectAll1( )
        {
         return objcmsUserCategory.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsUserCategory.SelectAll();
        }

        public DataTable SelectByUserID(int userID)
        {
            return objcmsUserCategory.SelectByUserID(userID);
        }
     
#endregion          
    
    }

}
