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
/// Summary description for cmsTinNoiBatBL
/// </summary>
namespace SES.CMS.BL 
{
    public class cmsTinNoiBatBL 
    {
    	#region Private Variables
		cmsTinNoiBatDAL objcmsTinNoiBatDAL;
		#endregion
		
        #region Public Constructors
        public cmsTinNoiBatBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsTinNoiBatDAL=new cmsTinNoiBatDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsTinNoiBatDO objcmsTinNoiBatDO)
        {
            return objcmsTinNoiBatDAL.Insert(objcmsTinNoiBatDO);
        }

        public int Update(cmsTinNoiBatDO objcmsTinNoiBatDO)
        {
             return objcmsTinNoiBatDAL.Update(objcmsTinNoiBatDO);

        }

        public int Delete(cmsTinNoiBatDO objcmsTinNoiBatDO)
        {
             return objcmsTinNoiBatDAL.Delete(objcmsTinNoiBatDO);

        }

         public int DeleteAll()
        {
             return objcmsTinNoiBatDAL.DeleteAll();
        }

        public cmsTinNoiBatDO Select(cmsTinNoiBatDO objcmsTinNoiBatDO)
        {
            return objcmsTinNoiBatDAL.Select(objcmsTinNoiBatDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsTinNoiBatDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsTinNoiBatDAL.SelectAll();
        }


     
#endregion          
    
    }

}
