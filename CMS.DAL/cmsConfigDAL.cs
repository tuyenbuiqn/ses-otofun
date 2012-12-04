/*
  Copyright 2009 Smart Enterprise Solution Corp.
  Email: contact@ses.vn - Website: http://www.ses.vn
  KimNgan Project.
*/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using SES.CMS.DO;
/// <summary>
/// Summary description for cmsConfigDAL
/// </summary>
namespace SES.CMS.DAL 
{
    
    public class cmsConfigDAL  : BaseDAL
    {
    	#region Private Variables
			
		#endregion
		
		#region Public Constructors
				public cmsConfigDAL()
				{
					//
					// TODO: Add constructor logic here
					//
					
				}
		#endregion       

	
		
		#region Public Methods
        public int Insert(cmsConfigDO objcmsConfigDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsConfig_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@SiteName", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.SiteName;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@SiteDescription", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.SiteDescription;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@SiteKeyWord", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.SiteKeyWord;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@AdminEmail", SqlDbType.NVarChar);
Sqlparam.Value = objcmsConfigDO.AdminEmail;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Field1", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.Field1;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Field2", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.Field2;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Field3", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.Field3;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Field4", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.Field4;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Field5", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.Field5;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
Sqlparam.Direction = ParameterDirection.ReturnValue;
Sqlcomm.Parameters.Add(Sqlparam);

           
            int result =base.ExecuteNoneQuery(Sqlcomm);
            
            if(!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
				result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsConfigDO objcmsConfigDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsConfig_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@ConfigID", SqlDbType.Int);
Sqlparam.Value = objcmsConfigDO.ConfigID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@SiteName", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.SiteName;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@SiteDescription", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.SiteDescription;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@SiteKeyWord", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.SiteKeyWord;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@AdminEmail", SqlDbType.NVarChar);
Sqlparam.Value = objcmsConfigDO.AdminEmail;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Field1", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.Field1;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Field2", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.Field2;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Field3", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.Field3;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Field4", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.Field4;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Field5", SqlDbType.NText);
Sqlparam.Value = objcmsConfigDO.Field5;
Sqlcomm.Parameters.Add(Sqlparam);


            
            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);
            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            
             if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);
                
            return result;

           
        }

        public int Delete(cmsConfigDO objcmsConfigDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsConfig_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@ConfigID", SqlDbType.Int);
Sqlparam.Value = objcmsConfigDO.ConfigID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

         public int DeleteAll()
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsConfig_DeleteAll";

            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsConfigDO Select(cmsConfigDO objcmsConfigDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsConfig_GetByPK";
            SqlParameter Sqlparam;
  

            Sqlparam = new SqlParameter("@ConfigID", SqlDbType.Int);
Sqlparam.Value = objcmsConfigDO.ConfigID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if(!Convert.IsDBNull(dr["ConfigID"]))
objcmsConfigDO.ConfigID=Convert.ToInt32(dr["ConfigID"]);
if(!Convert.IsDBNull(dr["SiteName"]))
objcmsConfigDO.SiteName=Convert.ToString(dr["SiteName"]);
if(!Convert.IsDBNull(dr["SiteDescription"]))
objcmsConfigDO.SiteDescription=Convert.ToString(dr["SiteDescription"]);
if(!Convert.IsDBNull(dr["SiteKeyWord"]))
objcmsConfigDO.SiteKeyWord=Convert.ToString(dr["SiteKeyWord"]);
if(!Convert.IsDBNull(dr["AdminEmail"]))
objcmsConfigDO.AdminEmail=Convert.ToString(dr["AdminEmail"]);
if(!Convert.IsDBNull(dr["Field1"]))
objcmsConfigDO.Field1=Convert.ToString(dr["Field1"]);
if(!Convert.IsDBNull(dr["Field2"]))
objcmsConfigDO.Field2=Convert.ToString(dr["Field2"]);
if(!Convert.IsDBNull(dr["Field3"]))
objcmsConfigDO.Field3=Convert.ToString(dr["Field3"]);
if(!Convert.IsDBNull(dr["Field4"]))
objcmsConfigDO.Field4=Convert.ToString(dr["Field4"]);
if(!Convert.IsDBNull(dr["Field5"]))
objcmsConfigDO.Field5=Convert.ToString(dr["Field5"]);

            }
             return objcmsConfigDO;
        }

        public ArrayList SelectAll1( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsConfig_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsConfigDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach(DataRow dr in dt.Rows)
{
cmsConfigDO objcmsConfigDO= new cmsConfigDO();
if(!Convert.IsDBNull(dr["ConfigID"]))
objcmsConfigDO.ConfigID=Convert.ToInt32(dr["ConfigID"]);
if(!Convert.IsDBNull(dr["SiteName"]))
objcmsConfigDO.SiteName=Convert.ToString(dr["SiteName"]);
if(!Convert.IsDBNull(dr["SiteDescription"]))
objcmsConfigDO.SiteDescription=Convert.ToString(dr["SiteDescription"]);
if(!Convert.IsDBNull(dr["SiteKeyWord"]))
objcmsConfigDO.SiteKeyWord=Convert.ToString(dr["SiteKeyWord"]);
if(!Convert.IsDBNull(dr["AdminEmail"]))
objcmsConfigDO.AdminEmail=Convert.ToString(dr["AdminEmail"]);
if(!Convert.IsDBNull(dr["Field1"]))
objcmsConfigDO.Field1=Convert.ToString(dr["Field1"]);
if(!Convert.IsDBNull(dr["Field2"]))
objcmsConfigDO.Field2=Convert.ToString(dr["Field2"]);
if(!Convert.IsDBNull(dr["Field3"]))
objcmsConfigDO.Field3=Convert.ToString(dr["Field3"]);
if(!Convert.IsDBNull(dr["Field4"]))
objcmsConfigDO.Field4=Convert.ToString(dr["Field4"]);
if(!Convert.IsDBNull(dr["Field5"]))
objcmsConfigDO.Field5=Convert.ToString(dr["Field5"]);
arrcmsConfigDO.Add(objcmsConfigDO);
}
            }
               return arrcmsConfigDO;
        }
        
        public DataTable SelectAll( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsConfig_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
          
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                
            }
               return dt;
        }

     
		#endregion          
    
    }

}
