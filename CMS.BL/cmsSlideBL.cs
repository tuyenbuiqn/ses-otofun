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
/// Summary description for cmsSlideBL
/// </summary>
namespace SES.CMS.BL
{
    public class cmsSlideBL 
    {
    	#region Private Variables
		cmsSlideDAL objcmsSlideDAL;
		#endregion
		
        #region Public Constructors
        public cmsSlideBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsSlideDAL=new cmsSlideDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsSlideDO objcmsSlideDO)
        {
            return objcmsSlideDAL.Insert(objcmsSlideDO);
        }

        public int Update(cmsSlideDO objcmsSlideDO)
        {
             return objcmsSlideDAL.Update(objcmsSlideDO);

        }

        public int Delete(cmsSlideDO objcmsSlideDO)
        {
             return objcmsSlideDAL.Delete(objcmsSlideDO);

        }

         public int DeleteAll()
        {
             return objcmsSlideDAL.DeleteAll();
        }

        public cmsSlideDO Select(cmsSlideDO objcmsSlideDO)
        {
            return objcmsSlideDAL.Select(objcmsSlideDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsSlideDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsSlideDAL.SelectAll();
        }


     
#endregion          
    
    }

}
