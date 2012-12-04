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
/// Summary description for cmsLibsFileBL
/// </summary>
namespace SES.CMS.BL
{
    public class cmsLibsFileBL 
    {
    	#region Private Variables
		cmsLibsFileDAL objcmsLibsFileDAL;
		#endregion
		
        #region Public Constructors
        public cmsLibsFileBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsLibsFileDAL=new cmsLibsFileDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsLibsFileDO objcmsLibsFileDO)
        {
            return objcmsLibsFileDAL.Insert(objcmsLibsFileDO);
        }

        public int Update(cmsLibsFileDO objcmsLibsFileDO)
        {
             return objcmsLibsFileDAL.Update(objcmsLibsFileDO);

        }

        public int Delete(cmsLibsFileDO objcmsLibsFileDO)
        {
             return objcmsLibsFileDAL.Delete(objcmsLibsFileDO);

        }

         public int DeleteAll()
        {
             return objcmsLibsFileDAL.DeleteAll();
        }

        public cmsLibsFileDO Select(cmsLibsFileDO objcmsLibsFileDO)
        {
            return objcmsLibsFileDAL.Select(objcmsLibsFileDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsLibsFileDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsLibsFileDAL.SelectAll();
        }


     
#endregion          
    
    
        public DataTable SelectByCategoryID(int CategoryID)
        {
            return objcmsLibsFileDAL.SelectByCategoryID(CategoryID);
        }
    }

}
