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
/// Summary description for cmsCommentBL
/// </summary>
namespace SES.CMS.BL 
{
    public class cmsCommentBL 
    {
    	#region Private Variables
		cmsCommentDAL objcmsCommentDAL;
		#endregion
		
        #region Public Constructors
        public cmsCommentBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objcmsCommentDAL=new cmsCommentDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(cmsCommentDO objcmsCommentDO)
        {
            return objcmsCommentDAL.Insert(objcmsCommentDO);
        }

        public int Update(cmsCommentDO objcmsCommentDO)
        {
             return objcmsCommentDAL.Update(objcmsCommentDO);

        }

        public int Delete(cmsCommentDO objcmsCommentDO)
        {
             return objcmsCommentDAL.Delete(objcmsCommentDO);

        }

         public int DeleteAll()
        {
             return objcmsCommentDAL.DeleteAll();
        }

        public cmsCommentDO Select(cmsCommentDO objcmsCommentDO)
        {
            return objcmsCommentDAL.Select(objcmsCommentDO);
        }

        public ArrayList SelectAll1( )
        {
         return objcmsCommentDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objcmsCommentDAL.SelectAll();
        }


     
#endregion          
    
    }

}