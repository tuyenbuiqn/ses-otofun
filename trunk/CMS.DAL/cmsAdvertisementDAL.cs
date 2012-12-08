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
/// Summary description for cmsAdvertisementDAL
/// </summary>
namespace SES.CMS.DAL 
{
    
    public class cmsAdvertisementDAL  : BaseDAL
    {
    	#region Private Variables
			
		#endregion
		
		#region Public Constructors
				public cmsAdvertisementDAL()
				{
					//
					// TODO: Add constructor logic here
					//
					
				}
		#endregion       

	
		
		#region Public Methods
        public int Insert(cmsAdvertisementDO objcmsAdvertisementDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsAdvertisement_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
Sqlparam.Value = objcmsAdvertisementDO.Title;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@AdvDetail", SqlDbType.NText);
Sqlparam.Value = objcmsAdvertisementDO.AdvDetail;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Position", SqlDbType.NVarChar);
Sqlparam.Value = objcmsAdvertisementDO.Position;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Module", SqlDbType.NVarChar);
Sqlparam.Value = objcmsAdvertisementDO.Module;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CreateDate", SqlDbType.DateTime);
Sqlparam.Value = objcmsAdvertisementDO.CreateDate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CreateUser", SqlDbType.Int);
Sqlparam.Value = objcmsAdvertisementDO.CreateUser;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@AdvInfo", SqlDbType.NText);
Sqlparam.Value = objcmsAdvertisementDO.AdvInfo;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OtherInfo", SqlDbType.NText);
Sqlparam.Value = objcmsAdvertisementDO.OtherInfo;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@IsPublish", SqlDbType.Bit);
Sqlparam.Value = objcmsAdvertisementDO.IsPublish;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
Sqlparam.Value = objcmsAdvertisementDO.OrderID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
Sqlparam.Direction = ParameterDirection.ReturnValue;
Sqlcomm.Parameters.Add(Sqlparam);

           
            int result =base.ExecuteNoneQuery(Sqlcomm);
            
            if(!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
				result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsAdvertisementDO objcmsAdvertisementDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsAdvertisement_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@AdvertisementID", SqlDbType.Int);
Sqlparam.Value = objcmsAdvertisementDO.AdvertisementID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
Sqlparam.Value = objcmsAdvertisementDO.Title;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@AdvDetail", SqlDbType.NText);
Sqlparam.Value = objcmsAdvertisementDO.AdvDetail;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Position", SqlDbType.NVarChar);
Sqlparam.Value = objcmsAdvertisementDO.Position;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Module", SqlDbType.NVarChar);
Sqlparam.Value = objcmsAdvertisementDO.Module;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CreateDate", SqlDbType.DateTime);
Sqlparam.Value = objcmsAdvertisementDO.CreateDate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CreateUser", SqlDbType.Int);
Sqlparam.Value = objcmsAdvertisementDO.CreateUser;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@AdvInfo", SqlDbType.NText);
Sqlparam.Value = objcmsAdvertisementDO.AdvInfo;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OtherInfo", SqlDbType.NText);
Sqlparam.Value = objcmsAdvertisementDO.OtherInfo;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@IsPublish", SqlDbType.Bit);
Sqlparam.Value = objcmsAdvertisementDO.IsPublish;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
Sqlparam.Value = objcmsAdvertisementDO.OrderID;
Sqlcomm.Parameters.Add(Sqlparam);
            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);
            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            
             if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);
                
            return result;

           
        }

        public int Delete(cmsAdvertisementDO objcmsAdvertisementDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsAdvertisement_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@AdvertisementID", SqlDbType.Int);
Sqlparam.Value = objcmsAdvertisementDO.AdvertisementID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

         public int DeleteAll()
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsAdvertisement_DeleteAll";

            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsAdvertisementDO Select(cmsAdvertisementDO objcmsAdvertisementDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsAdvertisement_GetByPK";
            SqlParameter Sqlparam;
  

            Sqlparam = new SqlParameter("@AdvertisementID", SqlDbType.Int);
Sqlparam.Value = objcmsAdvertisementDO.AdvertisementID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if(!Convert.IsDBNull(dr["AdvertisementID"]))
objcmsAdvertisementDO.AdvertisementID=Convert.ToInt32(dr["AdvertisementID"]);
if(!Convert.IsDBNull(dr["Title"]))
objcmsAdvertisementDO.Title=Convert.ToString(dr["Title"]);
if(!Convert.IsDBNull(dr["AdvDetail"]))
objcmsAdvertisementDO.AdvDetail=Convert.ToString(dr["AdvDetail"]);
if(!Convert.IsDBNull(dr["Position"]))
objcmsAdvertisementDO.Position=Convert.ToString(dr["Position"]);
if(!Convert.IsDBNull(dr["Module"]))
objcmsAdvertisementDO.Module=Convert.ToString(dr["Module"]);
if(!Convert.IsDBNull(dr["CreateDate"]))
objcmsAdvertisementDO.CreateDate=Convert.ToDateTime(dr["CreateDate"]);
if(!Convert.IsDBNull(dr["CreateUser"]))
objcmsAdvertisementDO.CreateUser=Convert.ToInt32(dr["CreateUser"]);
if(!Convert.IsDBNull(dr["AdvInfo"]))
objcmsAdvertisementDO.AdvInfo=Convert.ToString(dr["AdvInfo"]);
if(!Convert.IsDBNull(dr["OtherInfo"]))
objcmsAdvertisementDO.OtherInfo=Convert.ToString(dr["OtherInfo"]);
if (!Convert.IsDBNull(dr["IsPublish"]))
    objcmsAdvertisementDO.IsPublish = Convert.ToBoolean(dr["IsPublish"]);
if (!Convert.IsDBNull(dr["OrderID"]))
    objcmsAdvertisementDO.OrderID = Convert.ToInt32(dr["OrderID"]);

            }
             return objcmsAdvertisementDO;
        }

        public ArrayList SelectAll1( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsAdvertisement_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsAdvertisementDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach(DataRow dr in dt.Rows)
{
cmsAdvertisementDO objcmsAdvertisementDO= new cmsAdvertisementDO();
if(!Convert.IsDBNull(dr["AdvertisementID"]))
objcmsAdvertisementDO.AdvertisementID=Convert.ToInt32(dr["AdvertisementID"]);
if(!Convert.IsDBNull(dr["Title"]))
objcmsAdvertisementDO.Title=Convert.ToString(dr["Title"]);
if(!Convert.IsDBNull(dr["AdvDetail"]))
objcmsAdvertisementDO.AdvDetail=Convert.ToString(dr["AdvDetail"]);
if(!Convert.IsDBNull(dr["Position"]))
objcmsAdvertisementDO.Position=Convert.ToString(dr["Position"]);
if(!Convert.IsDBNull(dr["Module"]))
objcmsAdvertisementDO.Module=Convert.ToString(dr["Module"]);
if(!Convert.IsDBNull(dr["CreateDate"]))
objcmsAdvertisementDO.CreateDate=Convert.ToDateTime(dr["CreateDate"]);
if(!Convert.IsDBNull(dr["CreateUser"]))
objcmsAdvertisementDO.CreateUser=Convert.ToInt32(dr["CreateUser"]);
if(!Convert.IsDBNull(dr["AdvInfo"]))
objcmsAdvertisementDO.AdvInfo=Convert.ToString(dr["AdvInfo"]);
if(!Convert.IsDBNull(dr["OtherInfo"]))
objcmsAdvertisementDO.OtherInfo=Convert.ToString(dr["OtherInfo"]);
if (!Convert.IsDBNull(dr["IsPublish"]))
    objcmsAdvertisementDO.IsPublish = Convert.ToBoolean(dr["IsPublish"]);
if (!Convert.IsDBNull(dr["OrderID"]))
    objcmsAdvertisementDO.OrderID = Convert.ToInt32(dr["OrderID"]);
arrcmsAdvertisementDO.Add(objcmsAdvertisementDO);
}
            }
               return arrcmsAdvertisementDO;
        }
        
        public DataTable SelectAll( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsAdvertisement_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
          
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                
            }
               return dt;
        }
        public DataTable Advertisement_Filter(string position, string module, int isPublish)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsAdvertisement_Filter";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@Position", SqlDbType.NVarChar);
            Sqlparam.Value = position;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Module", SqlDbType.NVarChar);
            Sqlparam.Value = module;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsPublish", SqlDbType.Bit);
            Sqlparam.Value = isPublish;
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
