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
/// Summary description for cmsTopNewsBL
/// </summary>
namespace SES.CMS.BL 
{
    public class cmsTopNewsBL 
    {
    	#region Private Variables
		cmsTopNewsDAL objcmsTopNewsDAL;
		#endregion
		
        #region Public Constructors
        public cmsTopNewsBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsTopNewsDAL=new cmsTopNewsDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsTopNewsDO objcmsTopNewsDO)
        {
            return objcmsTopNewsDAL.Insert(objcmsTopNewsDO);
        }

        public int Update(cmsTopNewsDO objcmsTopNewsDO)
        {
             return objcmsTopNewsDAL.Update(objcmsTopNewsDO);

        }

        public int Delete(cmsTopNewsDO objcmsTopNewsDO)
        {
             return objcmsTopNewsDAL.Delete(objcmsTopNewsDO);

        }

         public int DeleteAll()
        {
             return objcmsTopNewsDAL.DeleteAll();
        }

        public cmsTopNewsDO Select(cmsTopNewsDO objcmsTopNewsDO)
        {
            return objcmsTopNewsDAL.Select(objcmsTopNewsDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsTopNewsDAL.SelectAll1();
        }
        
        public DataTable SelectAll(int top )
        {
         return objcmsTopNewsDAL.SelectAll(top);
        }


     
#endregion          
    
    }

}
