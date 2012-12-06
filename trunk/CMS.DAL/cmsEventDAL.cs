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
/// Summary description for cmsEventDAL
/// </summary>
namespace SES.CMS.DAL 
{
    
    public class cmsEventDAL  : BaseDAL
    {
    	#region Private Variables
			
		#endregion
		
		#region Public Constructors
				public cmsEventDAL()
				{
					//
					// TODO: Add constructor logic here
					//
					
				}
		#endregion       

	
		
		#region Public Methods
        public int Insert(cmsEventDO objcmsEventDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsEvent_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
Sqlparam.Value = objcmsEventDO.Title;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@IsPublish", SqlDbType.Bit);
Sqlparam.Value = objcmsEventDO.IsPublish;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Description", SqlDbType.NVarChar);
Sqlparam.Value = objcmsEventDO.Description;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
Sqlparam.Value = objcmsEventDO.OrderID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@UserCreate", SqlDbType.Int);
Sqlparam.Value = objcmsEventDO.UserCreate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CreateDate", SqlDbType.DateTime);
Sqlparam.Value = objcmsEventDO.CreateDate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@GhiChu", SqlDbType.NVarChar);
Sqlparam.Value = objcmsEventDO.GhiChu;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
Sqlparam.Value = objcmsEventDO.CategoryID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
Sqlparam.Direction = ParameterDirection.ReturnValue;
Sqlcomm.Parameters.Add(Sqlparam);

           
            int result =base.ExecuteNoneQuery(Sqlcomm);
            
            if(!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
				result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsEventDO objcmsEventDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsEvent_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@EventID", SqlDbType.BigInt);
Sqlparam.Value = objcmsEventDO.EventID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
Sqlparam.Value = objcmsEventDO.Title;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@IsPublish", SqlDbType.Bit);
Sqlparam.Value = objcmsEventDO.IsPublish;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Description", SqlDbType.NVarChar);
Sqlparam.Value = objcmsEventDO.Description;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
Sqlparam.Value = objcmsEventDO.OrderID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@UserCreate", SqlDbType.Int);
Sqlparam.Value = objcmsEventDO.UserCreate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CreateDate", SqlDbType.DateTime);
Sqlparam.Value = objcmsEventDO.CreateDate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@GhiChu", SqlDbType.NVarChar);
Sqlparam.Value = objcmsEventDO.GhiChu;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
Sqlparam.Value = objcmsEventDO.CategoryID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);
            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            
             if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);
                
            return result;

           
        }

        public int Delete(cmsEventDO objcmsEventDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsEvent_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@EventID", SqlDbType.BigInt);
Sqlparam.Value = objcmsEventDO.EventID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

         public int DeleteAll()
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsEvent_DeleteAll";

            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsEventDO Select(cmsEventDO objcmsEventDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsEvent_GetByPK";
            SqlParameter Sqlparam;
  

            Sqlparam = new SqlParameter("@EventID", SqlDbType.BigInt);
Sqlparam.Value = objcmsEventDO.EventID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if(!Convert.IsDBNull(dr["EventID"]))
objcmsEventDO.EventID=Convert.ToInt64(dr["EventID"]);
if(!Convert.IsDBNull(dr["Title"]))
objcmsEventDO.Title=Convert.ToString(dr["Title"]);
if(!Convert.IsDBNull(dr["IsPublish"]))
objcmsEventDO.IsPublish=Convert.ToBoolean(dr["IsPublish"]);
if(!Convert.IsDBNull(dr["Description"]))
objcmsEventDO.Description=Convert.ToString(dr["Description"]);
if(!Convert.IsDBNull(dr["OrderID"]))
objcmsEventDO.OrderID=Convert.ToInt32(dr["OrderID"]);
if(!Convert.IsDBNull(dr["UserCreate"]))
objcmsEventDO.UserCreate=Convert.ToInt32(dr["UserCreate"]);
if(!Convert.IsDBNull(dr["CreateDate"]))
objcmsEventDO.CreateDate=Convert.ToDateTime(dr["CreateDate"]);
if(!Convert.IsDBNull(dr["GhiChu"]))
objcmsEventDO.GhiChu=Convert.ToString(dr["GhiChu"]);
if(!Convert.IsDBNull(dr["CategoryID"]))
objcmsEventDO.CategoryID=Convert.ToInt32(dr["CategoryID"]);

            }
             return objcmsEventDO;
        }

        public ArrayList SelectAll1( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsEvent_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsEventDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach(DataRow dr in dt.Rows)
{
cmsEventDO objcmsEventDO= new cmsEventDO();
if(!Convert.IsDBNull(dr["EventID"]))
objcmsEventDO.EventID=Convert.ToInt64(dr["EventID"]);
if(!Convert.IsDBNull(dr["Title"]))
objcmsEventDO.Title=Convert.ToString(dr["Title"]);
if(!Convert.IsDBNull(dr["IsPublish"]))
objcmsEventDO.IsPublish=Convert.ToBoolean(dr["IsPublish"]);
if(!Convert.IsDBNull(dr["Description"]))
objcmsEventDO.Description=Convert.ToString(dr["Description"]);
if(!Convert.IsDBNull(dr["OrderID"]))
objcmsEventDO.OrderID=Convert.ToInt32(dr["OrderID"]);
if(!Convert.IsDBNull(dr["UserCreate"]))
objcmsEventDO.UserCreate=Convert.ToInt32(dr["UserCreate"]);
if(!Convert.IsDBNull(dr["CreateDate"]))
objcmsEventDO.CreateDate=Convert.ToDateTime(dr["CreateDate"]);
if(!Convert.IsDBNull(dr["GhiChu"]))
objcmsEventDO.GhiChu=Convert.ToString(dr["GhiChu"]);
if(!Convert.IsDBNull(dr["CategoryID"]))
objcmsEventDO.CategoryID=Convert.ToInt32(dr["CategoryID"]);
arrcmsEventDO.Add(objcmsEventDO);
}
            }
               return arrcmsEventDO;
        }
        
        public DataTable SelectAll( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsEvent_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
          
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                
            }
               return dt;
        }

        public DataTable GetEventByCategoryID(int categoryID,int top)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsEvent_GetByCategory";

            SqlParameter Sqlparam;
            Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
            Sqlparam.Value = categoryID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Top", SqlDbType.Int);
            Sqlparam.Value = top;
            Sqlcomm.Parameters.Add(Sqlparam);


            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
        public DataTable GetTopEvent(int top)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsEvent_GetTop";

            SqlParameter Sqlparam;
         
            Sqlparam = new SqlParameter("@Top", SqlDbType.Int);
            Sqlparam.Value = top;
            Sqlcomm.Parameters.Add(Sqlparam);


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
