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
/// Summary description for cmsSetTopBL
/// </summary>
namespace SES.CMS.BL 
{
    public class cmsSetTopBL 
    {
    	#region Private Variables
		cmsSetTopDAL objcmsSetTopDAL;
		#endregion
		
        #region Public Constructors
        public cmsSetTopBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsSetTopDAL=new cmsSetTopDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsSetTopDO objcmsSetTopDO)
        {
            return objcmsSetTopDAL.Insert(objcmsSetTopDO);
        }

        public int Update(cmsSetTopDO objcmsSetTopDO)
        {
             return objcmsSetTopDAL.Update(objcmsSetTopDO);

        }

        public int Delete(cmsSetTopDO objcmsSetTopDO)
        {
             return objcmsSetTopDAL.Delete(objcmsSetTopDO);

        }

         public int DeleteAll()
        {
             return objcmsSetTopDAL.DeleteAll();
        }

        public cmsSetTopDO Select(cmsSetTopDO objcmsSetTopDO)
        {
            return objcmsSetTopDAL.Select(objcmsSetTopDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsSetTopDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsSetTopDAL.SelectAll();
        }


     
#endregion          
        public DataTable SelectAll(int top)
        {
            return objcmsSetTopDAL.SelectAll(top);
        }
        public DataTable SelectByCategoryID(int top, int categoryID)
        {
            return objcmsSetTopDAL.SelectByCategoryID(top, categoryID);
        }
    }

}
