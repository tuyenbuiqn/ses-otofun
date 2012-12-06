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
/// Summary description for cmsEventBL
/// </summary>
namespace SES.CMS.BL 
{
    public class cmsEventBL 
    {
    	#region Private Variables
		cmsEventDAL objcmsEventDAL;
		#endregion
		
        #region Public Constructors
        public cmsEventBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsEventDAL=new cmsEventDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsEventDO objcmsEventDO)
        {
            return objcmsEventDAL.Insert(objcmsEventDO);
        }

        public int Update(cmsEventDO objcmsEventDO)
        {
             return objcmsEventDAL.Update(objcmsEventDO);

        }

        public int Delete(cmsEventDO objcmsEventDO)
        {
             return objcmsEventDAL.Delete(objcmsEventDO);

        }

         public int DeleteAll()
        {
             return objcmsEventDAL.DeleteAll();
        }

        public cmsEventDO Select(cmsEventDO objcmsEventDO)
        {
            return objcmsEventDAL.Select(objcmsEventDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsEventDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsEventDAL.SelectAll();
        }

        public DataTable GetTopEvent(int top)
        {
            return objcmsEventDAL.GetTopEvent(top);
        }
     
#endregion          
        public DataTable GetEventByCategoryID(int categoryID,int top)
        {
            return objcmsEventDAL.GetEventByCategoryID(categoryID,top);
        }
    }

}
