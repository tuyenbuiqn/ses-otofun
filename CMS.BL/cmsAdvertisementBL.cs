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
/// Summary description for cmsAdvertisementBL
/// </summary>
namespace SES.CMS.BL 
{
    public class cmsAdvertisementBL 
    {
    	#region Private Variables
		cmsAdvertisementDAL objcmsAdvertisementDAL;
		#endregion
		
        #region Public Constructors
        public cmsAdvertisementBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsAdvertisementDAL=new cmsAdvertisementDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsAdvertisementDO objcmsAdvertisementDO)
        {
            return objcmsAdvertisementDAL.Insert(objcmsAdvertisementDO);
        }

        public int Update(cmsAdvertisementDO objcmsAdvertisementDO)
        {
             return objcmsAdvertisementDAL.Update(objcmsAdvertisementDO);

        }

        public int Delete(cmsAdvertisementDO objcmsAdvertisementDO)
        {
             return objcmsAdvertisementDAL.Delete(objcmsAdvertisementDO);

        }

         public int DeleteAll()
        {
             return objcmsAdvertisementDAL.DeleteAll();
        }

        public cmsAdvertisementDO Select(cmsAdvertisementDO objcmsAdvertisementDO)
        {
            return objcmsAdvertisementDAL.Select(objcmsAdvertisementDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsAdvertisementDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsAdvertisementDAL.SelectAll();
        }

        public DataTable Advertisement_Filter(string position, string module, int isPublish)
        {
            return objcmsAdvertisementDAL.Advertisement_Filter(position, module, isPublish);
        }
     
#endregion          
    
    }

}
