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
/// Summary description for cmsVideoBL
/// </summary>
namespace SES.CMS.BL 
{
    public class cmsVideoBL 
    {
    	#region Private Variables
		cmsVideoDAL objcmsVideoDAL;
		#endregion
		
        #region Public Constructors
        public cmsVideoBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsVideoDAL=new cmsVideoDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsVideoDO objcmsVideoDO)
        {
            return objcmsVideoDAL.Insert(objcmsVideoDO);
        }

        public int Update(cmsVideoDO objcmsVideoDO)
        {
             return objcmsVideoDAL.Update(objcmsVideoDO);

        }

        public int Delete(cmsVideoDO objcmsVideoDO)
        {
             return objcmsVideoDAL.Delete(objcmsVideoDO);

        }

         public int DeleteAll()
        {
             return objcmsVideoDAL.DeleteAll();
        }

        public cmsVideoDO Select(cmsVideoDO objcmsVideoDO)
        {
            return objcmsVideoDAL.Select(objcmsVideoDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsVideoDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsVideoDAL.SelectAll();
        }

        public DataTable SelectVideoHomepage()
        {
            return objcmsVideoDAL.SelectVideoHomepage();
        }
     
#endregion          
    
    }

}
