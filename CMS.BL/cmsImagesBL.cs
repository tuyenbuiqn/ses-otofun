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
/// Summary description for cmsImagesBL
/// </summary>
namespace SES.CMS.BL
{
    public class cmsImagesBL 
    {
    	#region Private Variables
		cmsImagesDAL objcmsImagesDAL;
		#endregion
		
        #region Public Constructors
        public cmsImagesBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsImagesDAL=new cmsImagesDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsImagesDO objcmsImagesDO)
        {
            return objcmsImagesDAL.Insert(objcmsImagesDO);
        }

        public int Update(cmsImagesDO objcmsImagesDO)
        {
             return objcmsImagesDAL.Update(objcmsImagesDO);

        }

        public int Delete(cmsImagesDO objcmsImagesDO)
        {
             return objcmsImagesDAL.Delete(objcmsImagesDO);

        }

         public int DeleteAll()
        {
             return objcmsImagesDAL.DeleteAll();
        }

        public cmsImagesDO Select(cmsImagesDO objcmsImagesDO)
        {
            return objcmsImagesDAL.Select(objcmsImagesDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsImagesDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsImagesDAL.SelectAll();
        }


     
#endregion          
    
    
        public DataTable SelectByAlbumID(int p)
        {
            return objcmsImagesDAL.SelectByAlbumID(p);
        }

        public object SelectBySlideID(int p)
        {
            throw new NotImplementedException();
        }

        public object SelectByArticleID(int p)
        {
            throw new NotImplementedException();
        }

        public object SelectByCategoryID(int p)
        {
            throw new NotImplementedException();
        }
    }

}
