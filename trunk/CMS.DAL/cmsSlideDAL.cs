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
/// Summary description for cmsSlideDAL
/// </summary>
namespace SES.CMS.DAL 
{
    
    public class cmsSlideDAL  : BaseDAL
    {
    	#region Private Variables
			
		#endregion
		
		#region Public Constructors
				public cmsSlideDAL()
				{
					//
					// TODO: Add constructor logic here
					//
					
				}
		#endregion       

	
		
		#region Public Methods
        public int Insert(cmsSlideDO objcmsSlideDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsSlide_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
Sqlparam.Value = objcmsSlideDO.Title;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Description", SqlDbType.NVarChar);
Sqlparam.Value = objcmsSlideDO.Description;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@SlideUrl", SqlDbType.NVarChar);
Sqlparam.Value = objcmsSlideDO.SlideUrl;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
Sqlparam.Value = objcmsSlideDO.CategoryID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
Sqlparam.Value = objcmsSlideDO.OrderID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@SlideImg", SqlDbType.NVarChar);
Sqlparam.Value = objcmsSlideDO.SlideImg;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
Sqlparam.Direction = ParameterDirection.ReturnValue;
Sqlcomm.Parameters.Add(Sqlparam);

           
            int result =base.ExecuteNoneQuery(Sqlcomm);
            
            if(!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
				result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsSlideDO objcmsSlideDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsSlide_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@SlideID", SqlDbType.Int);
Sqlparam.Value = objcmsSlideDO.SlideID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
Sqlparam.Value = objcmsSlideDO.Title;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Description", SqlDbType.NVarChar);
Sqlparam.Value = objcmsSlideDO.Description;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@SlideUrl", SqlDbType.NVarChar);
Sqlparam.Value = objcmsSlideDO.SlideUrl;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
Sqlparam.Value = objcmsSlideDO.CategoryID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
Sqlparam.Value = objcmsSlideDO.OrderID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@SlideImg", SqlDbType.NVarChar);
Sqlparam.Value = objcmsSlideDO.SlideImg;
Sqlcomm.Parameters.Add(Sqlparam);


            
            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);
            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            
             if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);
                
            return result;

           
        }

        public int Delete(cmsSlideDO objcmsSlideDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsSlide_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@SlideID", SqlDbType.Int);
Sqlparam.Value = objcmsSlideDO.SlideID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

         public int DeleteAll()
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsSlide_DeleteAll";

            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsSlideDO Select(cmsSlideDO objcmsSlideDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsSlide_GetByPK";
            SqlParameter Sqlparam;
  

            Sqlparam = new SqlParameter("@SlideID", SqlDbType.Int);
Sqlparam.Value = objcmsSlideDO.SlideID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if(!Convert.IsDBNull(dr["SlideID"]))
objcmsSlideDO.SlideID=Convert.ToInt32(dr["SlideID"]);
if(!Convert.IsDBNull(dr["Title"]))
objcmsSlideDO.Title=Convert.ToString(dr["Title"]);
if(!Convert.IsDBNull(dr["Description"]))
objcmsSlideDO.Description=Convert.ToString(dr["Description"]);
if(!Convert.IsDBNull(dr["SlideUrl"]))
objcmsSlideDO.SlideUrl=Convert.ToString(dr["SlideUrl"]);
if(!Convert.IsDBNull(dr["CategoryID"]))
objcmsSlideDO.CategoryID=Convert.ToInt32(dr["CategoryID"]);
if(!Convert.IsDBNull(dr["OrderID"]))
objcmsSlideDO.OrderID=Convert.ToInt32(dr["OrderID"]);
if(!Convert.IsDBNull(dr["SlideImg"]))
objcmsSlideDO.SlideImg=Convert.ToString(dr["SlideImg"]);

            }
             return objcmsSlideDO;
        }

        public ArrayList SelectAll1( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsSlide_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsSlideDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach(DataRow dr in dt.Rows)
{
cmsSlideDO objcmsSlideDO= new cmsSlideDO();
if(!Convert.IsDBNull(dr["SlideID"]))
objcmsSlideDO.SlideID=Convert.ToInt32(dr["SlideID"]);
if(!Convert.IsDBNull(dr["Title"]))
objcmsSlideDO.Title=Convert.ToString(dr["Title"]);
if(!Convert.IsDBNull(dr["Description"]))
objcmsSlideDO.Description=Convert.ToString(dr["Description"]);
if(!Convert.IsDBNull(dr["SlideUrl"]))
objcmsSlideDO.SlideUrl=Convert.ToString(dr["SlideUrl"]);
if(!Convert.IsDBNull(dr["CategoryID"]))
objcmsSlideDO.CategoryID=Convert.ToInt32(dr["CategoryID"]);
if(!Convert.IsDBNull(dr["OrderID"]))
objcmsSlideDO.OrderID=Convert.ToInt32(dr["OrderID"]);
if(!Convert.IsDBNull(dr["SlideImg"]))
objcmsSlideDO.SlideImg=Convert.ToString(dr["SlideImg"]);
arrcmsSlideDO.Add(objcmsSlideDO);
}
            }
               return arrcmsSlideDO;
        }
        
        public DataTable SelectAll( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsSlide_GetAll";
            
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
