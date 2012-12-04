/*
  Copyright 2009 Smart Enterprise Solution Corp.
  Email: contact@ses.vn - Website: http://www.ses.vn
  KimNgan Project.
*/
using System;
using System.Data; using System.Linq;
using System.Configuration;
using System.Collections;

using SES.CMS.DAL;
using SES.CMS.DO;
/// <summary>
/// Summary description for sysConfigBL
/// </summary>
namespace SES.CMS.BL
{
    public class sysConfigBL 
    {
    	#region Private Variables
		sysConfigDAL objsysConfigDAL;
		#endregion
		
        #region Public Constructors
        public sysConfigBL()
        {
            //
            // TODO: Add constructor logic here
            //
            objsysConfigDAL=new sysConfigDAL();
        }
        #endregion       

        #region Public Methods
        public int Insert(sysConfigDO objsysConfigDO)
        {
            return objsysConfigDAL.Insert(objsysConfigDO);
        }

        public int Update(sysConfigDO objsysConfigDO)
        {
             return objsysConfigDAL.Update(objsysConfigDO);

        }

        public int Delete(sysConfigDO objsysConfigDO)
        {
             return objsysConfigDAL.Delete(objsysConfigDO);

        }

         public int DeleteAll()
        {
             return objsysConfigDAL.DeleteAll();
        }

        public sysConfigDO Select(sysConfigDO objsysConfigDO)
        {
            return objsysConfigDAL.Select(objsysConfigDO);
        }

        public ArrayList SelectAll1( )
        {
         return objsysConfigDAL.SelectAll1();
        }
        
        public DataTable SelectAll( )
        {
         return objsysConfigDAL.SelectAll();
        }


     
#endregion          
    
    }

}
