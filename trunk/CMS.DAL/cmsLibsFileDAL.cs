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
/// Summary description for cmsLibsFileDAL
/// </summary>
namespace SES.CMS.DAL 
{
    
    public class cmsLibsFileDAL  : BaseDAL
    {
    	#region Private Variables
			
		#endregion
		
		#region Public Constructors
				public cmsLibsFileDAL()
				{
					//
					// TODO: Add constructor logic here
					//
					
				}
		#endregion       

	
		
		#region Public Methods
        public int Insert(cmsLibsFileDO objcmsLibsFileDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibsFile_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@FileUrl", SqlDbType.NVarChar);
Sqlparam.Value = objcmsLibsFileDO.FileUrl;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
Sqlparam.Value = objcmsLibsFileDO.Title;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Description", SqlDbType.NVarChar);
Sqlparam.Value = objcmsLibsFileDO.Description;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@FileExtension", SqlDbType.NVarChar);
Sqlparam.Value = objcmsLibsFileDO.FileExtension;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@UserCreate", SqlDbType.Int);
Sqlparam.Value = objcmsLibsFileDO.UserCreate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
Sqlparam.Value = objcmsLibsFileDO.CategoryID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
Sqlparam.Direction = ParameterDirection.ReturnValue;
Sqlcomm.Parameters.Add(Sqlparam);

           
            int result =base.ExecuteNoneQuery(Sqlcomm);
            
            if(!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
				result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsLibsFileDO objcmsLibsFileDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibsFile_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@FileID", SqlDbType.Int);
Sqlparam.Value = objcmsLibsFileDO.FileID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@FileUrl", SqlDbType.NVarChar);
Sqlparam.Value = objcmsLibsFileDO.FileUrl;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
Sqlparam.Value = objcmsLibsFileDO.Title;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Description", SqlDbType.NVarChar);
Sqlparam.Value = objcmsLibsFileDO.Description;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@FileExtension", SqlDbType.NVarChar);
Sqlparam.Value = objcmsLibsFileDO.FileExtension;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@UserCreate", SqlDbType.Int);
Sqlparam.Value = objcmsLibsFileDO.UserCreate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
Sqlparam.Value = objcmsLibsFileDO.CategoryID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);
            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            
             if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);
                
            return result;

           
        }

        public int Delete(cmsLibsFileDO objcmsLibsFileDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibsFile_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@FileID", SqlDbType.Int);
Sqlparam.Value = objcmsLibsFileDO.FileID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

         public int DeleteAll()
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibsFile_DeleteAll";

            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsLibsFileDO Select(cmsLibsFileDO objcmsLibsFileDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibsFile_GetByPK";
            SqlParameter Sqlparam;
  

            Sqlparam = new SqlParameter("@FileID", SqlDbType.Int);
Sqlparam.Value = objcmsLibsFileDO.FileID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if(!Convert.IsDBNull(dr["FileID"]))
objcmsLibsFileDO.FileID=Convert.ToInt32(dr["FileID"]);
if(!Convert.IsDBNull(dr["FileUrl"]))
objcmsLibsFileDO.FileUrl=Convert.ToString(dr["FileUrl"]);
if(!Convert.IsDBNull(dr["Title"]))
objcmsLibsFileDO.Title=Convert.ToString(dr["Title"]);
if(!Convert.IsDBNull(dr["Description"]))
objcmsLibsFileDO.Description=Convert.ToString(dr["Description"]);
if(!Convert.IsDBNull(dr["FileExtension"]))
objcmsLibsFileDO.FileExtension=Convert.ToString(dr["FileExtension"]);
if(!Convert.IsDBNull(dr["UserCreate"]))
objcmsLibsFileDO.UserCreate=Convert.ToInt32(dr["UserCreate"]);
if(!Convert.IsDBNull(dr["CategoryID"]))
objcmsLibsFileDO.CategoryID=Convert.ToInt32(dr["CategoryID"]);

            }
             return objcmsLibsFileDO;
        }

        public ArrayList SelectAll1( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibsFile_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsLibsFileDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach(DataRow dr in dt.Rows)
{
cmsLibsFileDO objcmsLibsFileDO= new cmsLibsFileDO();
if(!Convert.IsDBNull(dr["FileID"]))
objcmsLibsFileDO.FileID=Convert.ToInt32(dr["FileID"]);
if(!Convert.IsDBNull(dr["FileUrl"]))
objcmsLibsFileDO.FileUrl=Convert.ToString(dr["FileUrl"]);
if(!Convert.IsDBNull(dr["Title"]))
objcmsLibsFileDO.Title=Convert.ToString(dr["Title"]);
if(!Convert.IsDBNull(dr["Description"]))
objcmsLibsFileDO.Description=Convert.ToString(dr["Description"]);
if(!Convert.IsDBNull(dr["FileExtension"]))
objcmsLibsFileDO.FileExtension=Convert.ToString(dr["FileExtension"]);
if(!Convert.IsDBNull(dr["UserCreate"]))
objcmsLibsFileDO.UserCreate=Convert.ToInt32(dr["UserCreate"]);
if(!Convert.IsDBNull(dr["CategoryID"]))
objcmsLibsFileDO.CategoryID=Convert.ToInt32(dr["CategoryID"]);
arrcmsLibsFileDO.Add(objcmsLibsFileDO);
}
            }
               return arrcmsLibsFileDO;
        }
        
        public DataTable SelectAll( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibsFile_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
          
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                
            }
               return dt;
        }

     
		#endregion          
    
    
        public DataTable SelectByCategoryID(int CategoryID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsLibsFile_GetByCategoryID";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
            Sqlparam.Value = CategoryID;
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
