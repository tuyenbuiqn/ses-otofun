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
/// Summary description for sysUserBL
/// </summary>
namespace SES.CMS.BL
{
    public class sysUserBL 
    {
    	#region Private Variables
		sysUserDAL objsysUserDAL;
		#endregion
		
        #region Public Constructors
        public sysUserBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objsysUserDAL=new sysUserDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(sysUserDO objsysUserDO)
        {
            return objsysUserDAL.Insert(objsysUserDO);
        }

        public int Update(sysUserDO objsysUserDO)
        {
             return objsysUserDAL.Update(objsysUserDO);

        }

        public int Delete(sysUserDO objsysUserDO)
        {
             return objsysUserDAL.Delete(objsysUserDO);

        }

         public int DeleteAll()
        {
             return objsysUserDAL.DeleteAll();
        }

        public sysUserDO Select(sysUserDO objsysUserDO)
        {
            return objsysUserDAL.Select(objsysUserDO);
        }

        public ArrayList SelectAll1( )
        {
         return objsysUserDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objsysUserDAL.SelectAll();
        }


     
#endregion          
    
    
        public DataTable SelectLogin(string txtUsername, string txtPassword)
        {
            return objsysUserDAL.SelectLogin(txtUsername, txtPassword);
        }
    }

}
