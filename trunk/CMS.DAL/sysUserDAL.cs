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
/// Summary description for sysUserDAL
/// </summary>
namespace SES.CMS.DAL 
{
    
    public class sysUserDAL  : BaseDAL
    {
    	#region Private Variables
			
		#endregion
		
		#region Public Constructors
				public sysUserDAL()
				{
					//
					// TODO: Add constructor logic here
					//
					
				}
		#endregion       

	
		
		#region Public Methods
        public int Insert(sysUserDO objsysUserDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spsysUser_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@Username", SqlDbType.NVarChar);
Sqlparam.Value = objsysUserDO.Username;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Password", SqlDbType.NVarChar);
Sqlparam.Value = objsysUserDO.Password;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Email", SqlDbType.NVarChar);
Sqlparam.Value = objsysUserDO.Email;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Address", SqlDbType.NText);
Sqlparam.Value = objsysUserDO.Address;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@UserType", SqlDbType.Int);
Sqlparam.Value = objsysUserDO.UserType;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@IsActive", SqlDbType.Bit);
Sqlparam.Value = objsysUserDO.IsActive;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@FullName", SqlDbType.NVarChar);
Sqlparam.Value = objsysUserDO.FullName;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@YahooIM", SqlDbType.NVarChar);
Sqlparam.Value = objsysUserDO.YahooIM;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ProfileID", SqlDbType.Int);
Sqlparam.Value = objsysUserDO.ProfileID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
Sqlparam.Direction = ParameterDirection.ReturnValue;
Sqlcomm.Parameters.Add(Sqlparam);

           
            int result =base.ExecuteNoneQuery(Sqlcomm);
            
            if(!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
				result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(sysUserDO objsysUserDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spsysUser_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@UserID", SqlDbType.Int);
Sqlparam.Value = objsysUserDO.UserID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Username", SqlDbType.NVarChar);
Sqlparam.Value = objsysUserDO.Username;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Password", SqlDbType.NVarChar);
Sqlparam.Value = objsysUserDO.Password;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Email", SqlDbType.NVarChar);
Sqlparam.Value = objsysUserDO.Email;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Address", SqlDbType.NText);
Sqlparam.Value = objsysUserDO.Address;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@UserType", SqlDbType.Int);
Sqlparam.Value = objsysUserDO.UserType;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@IsActive", SqlDbType.Bit);
Sqlparam.Value = objsysUserDO.IsActive;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@FullName", SqlDbType.NVarChar);
Sqlparam.Value = objsysUserDO.FullName;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@YahooIM", SqlDbType.NVarChar);
Sqlparam.Value = objsysUserDO.YahooIM;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ProfileID", SqlDbType.Int);
Sqlparam.Value = objsysUserDO.ProfileID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);
            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            
             if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);
                
            return result;

           
        }

        public int Delete(sysUserDO objsysUserDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spsysUser_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@UserID", SqlDbType.Int);
Sqlparam.Value = objsysUserDO.UserID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

         public int DeleteAll()
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spsysUser_DeleteAll";

            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public sysUserDO Select(sysUserDO objsysUserDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spsysUser_GetByPK";
            SqlParameter Sqlparam;
  

            Sqlparam = new SqlParameter("@UserID", SqlDbType.Int);
Sqlparam.Value = objsysUserDO.UserID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if(!Convert.IsDBNull(dr["UserID"]))
objsysUserDO.UserID=Convert.ToInt32(dr["UserID"]);
if(!Convert.IsDBNull(dr["Username"]))
objsysUserDO.Username=Convert.ToString(dr["Username"]);
if(!Convert.IsDBNull(dr["Password"]))
objsysUserDO.Password=Convert.ToString(dr["Password"]);
if(!Convert.IsDBNull(dr["Email"]))
objsysUserDO.Email=Convert.ToString(dr["Email"]);
if(!Convert.IsDBNull(dr["Address"]))
objsysUserDO.Address=Convert.ToString(dr["Address"]);
if(!Convert.IsDBNull(dr["UserType"]))
objsysUserDO.UserType=Convert.ToInt32(dr["UserType"]);
if(!Convert.IsDBNull(dr["IsActive"]))
objsysUserDO.IsActive=Convert.ToBoolean(dr["IsActive"]);
if(!Convert.IsDBNull(dr["FullName"]))
objsysUserDO.FullName=Convert.ToString(dr["FullName"]);
if(!Convert.IsDBNull(dr["YahooIM"]))
objsysUserDO.YahooIM=Convert.ToString(dr["YahooIM"]);
if(!Convert.IsDBNull(dr["ProfileID"]))
objsysUserDO.ProfileID=Convert.ToInt32(dr["ProfileID"]);

            }
             return objsysUserDO;
        }

        public ArrayList SelectAll1( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spsysUser_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrsysUserDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach(DataRow dr in dt.Rows)
{
sysUserDO objsysUserDO= new sysUserDO();
if(!Convert.IsDBNull(dr["UserID"]))
objsysUserDO.UserID=Convert.ToInt32(dr["UserID"]);
if(!Convert.IsDBNull(dr["Username"]))
objsysUserDO.Username=Convert.ToString(dr["Username"]);
if(!Convert.IsDBNull(dr["Password"]))
objsysUserDO.Password=Convert.ToString(dr["Password"]);
if(!Convert.IsDBNull(dr["Email"]))
objsysUserDO.Email=Convert.ToString(dr["Email"]);
if(!Convert.IsDBNull(dr["Address"]))
objsysUserDO.Address=Convert.ToString(dr["Address"]);
if(!Convert.IsDBNull(dr["UserType"]))
objsysUserDO.UserType=Convert.ToInt32(dr["UserType"]);
if(!Convert.IsDBNull(dr["IsActive"]))
objsysUserDO.IsActive=Convert.ToBoolean(dr["IsActive"]);
if(!Convert.IsDBNull(dr["FullName"]))
objsysUserDO.FullName=Convert.ToString(dr["FullName"]);
if(!Convert.IsDBNull(dr["YahooIM"]))
objsysUserDO.YahooIM=Convert.ToString(dr["YahooIM"]);
if(!Convert.IsDBNull(dr["ProfileID"]))
objsysUserDO.ProfileID=Convert.ToInt32(dr["ProfileID"]);
arrsysUserDO.Add(objsysUserDO);
}
            }
               return arrsysUserDO;
        }
        
        public DataTable SelectAll( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spsysUser_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
          
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                
            }
               return dt;
        }

     
		#endregion          
    
    
        public DataTable SelectLogin(string txtUsername, string txtPassword)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spsysUser_GetLogin";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@txtUsername", SqlDbType.NVarChar);
            Sqlparam.Value = txtUsername;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@txtPassword", SqlDbType.NVarChar);
            Sqlparam.Value = txtPassword;
            Sqlcomm.Parameters.Add(Sqlparam);


            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
    }

}
