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
/// Summary description for cmsHistoryBL
/// </summary>
namespace SES.CMS.BL 
{
    public class cmsHistoryBL 
    {
    	#region Private Variables
		cmsHistoryDAL objcmsHistoryDAL;
		#endregion
		
        #region Public Constructors
        public cmsHistoryBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsHistoryDAL=new cmsHistoryDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsHistoryDO objcmsHistoryDO)
        {
            return objcmsHistoryDAL.Insert(objcmsHistoryDO);
        }

        public int Update(cmsHistoryDO objcmsHistoryDO)
        {
             return objcmsHistoryDAL.Update(objcmsHistoryDO);

        }

        public int Delete(cmsHistoryDO objcmsHistoryDO)
        {
             return objcmsHistoryDAL.Delete(objcmsHistoryDO);

        }

         public int DeleteAll()
        {
             return objcmsHistoryDAL.DeleteAll();
        }

        public cmsHistoryDO Select(cmsHistoryDO objcmsHistoryDO)
        {
            return objcmsHistoryDAL.Select(objcmsHistoryDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsHistoryDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsHistoryDAL.SelectAll();
        }


     
#endregion          
    
    }

}
