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
/// Summary description for cmsMostReadBL
/// </summary>
namespace SES.CMS.BL 
{
    public class cmsMostReadBL 
    {
    	#region Private Variables
		cmsMostReadDAL objcmsMostReadDAL;
		#endregion
		
        #region Public Constructors
        public cmsMostReadBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsMostReadDAL=new cmsMostReadDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsMostReadDO objcmsMostReadDO)
        {
            return objcmsMostReadDAL.Insert(objcmsMostReadDO);
        }

        public int Update(cmsMostReadDO objcmsMostReadDO)
        {
             return objcmsMostReadDAL.Update(objcmsMostReadDO);

        }

        public int Delete(cmsMostReadDO objcmsMostReadDO)
        {
             return objcmsMostReadDAL.Delete(objcmsMostReadDO);

        }

         public int DeleteAll()
        {
             return objcmsMostReadDAL.DeleteAll();
        }

        public cmsMostReadDO Select(cmsMostReadDO objcmsMostReadDO)
        {
            return objcmsMostReadDAL.Select(objcmsMostReadDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsMostReadDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsMostReadDAL.SelectAll();
        }


     
#endregion          
        public DataTable SelectByCategoryID(int top, int categoryID)
        {
            return objcmsMostReadDAL.SelectByCategoryID(top, categoryID);
        }
        public DataTable SelectHomepageMostRead(int top)
        {
            return objcmsMostReadDAL.SelectHomepageMostRead(top);
        }
    }

}
