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
/// Summary description for cmsConfigBL
/// </summary>
namespace SES.CMS.BL
{
    public class cmsConfigBL 
    {
    	#region Private Variables
		cmsConfigDAL objcmsConfigDAL;
		#endregion
		
        #region Public Constructors
        public cmsConfigBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsConfigDAL=new cmsConfigDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsConfigDO objcmsConfigDO)
        {
            return objcmsConfigDAL.Insert(objcmsConfigDO);
        }

        public int Update(cmsConfigDO objcmsConfigDO)
        {
             return objcmsConfigDAL.Update(objcmsConfigDO);

        }

        public int Delete(cmsConfigDO objcmsConfigDO)
        {
             return objcmsConfigDAL.Delete(objcmsConfigDO);

        }

         public int DeleteAll()
        {
             return objcmsConfigDAL.DeleteAll();
        }

        public cmsConfigDO Select(cmsConfigDO objcmsConfigDO)
        {
            return objcmsConfigDAL.Select(objcmsConfigDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsConfigDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsConfigDAL.SelectAll();
        }


     
#endregion          
    
    }

}
