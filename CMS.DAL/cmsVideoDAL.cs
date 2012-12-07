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
/// Summary description for cmsVideoDAL
/// </summary>
namespace SES.CMS.DAL 
{
    
    public class cmsVideoDAL  : BaseDAL
    {
    	#region Private Variables
			
		#endregion
		
		#region Public Constructors
				public cmsVideoDAL()
				{
					//
					// TODO: Add constructor logic here
					//
					
				}
		#endregion       

	
		
		#region Public Methods
                public int Insert(cmsVideoDO objcmsVideoDO)
                {

                    SqlCommand Sqlcomm = new SqlCommand();
                    Sqlcomm.CommandType = CommandType.StoredProcedure;
                    Sqlcomm.CommandText = "spcmsVideo_Insert";
                    SqlParameter Sqlparam;

                    Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
                    Sqlparam.Value = objcmsVideoDO.Title;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@VideoUrl", SqlDbType.NVarChar);
                    Sqlparam.Value = objcmsVideoDO.VideoUrl;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@Description", SqlDbType.NVarChar);
                    Sqlparam.Value = objcmsVideoDO.Description;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@AlbumID", SqlDbType.Int);
                    Sqlparam.Value = objcmsVideoDO.AlbumID;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
                    Sqlparam.Value = objcmsVideoDO.CategoryID;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@IsMostView", SqlDbType.Bit);
                    Sqlparam.Value = objcmsVideoDO.IsMostView;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@IsNew", SqlDbType.Bit);
                    Sqlparam.Value = objcmsVideoDO.IsNew;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
                    Sqlparam.Value = objcmsVideoDO.OrderID;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@IsPublish", SqlDbType.Bit);
                    Sqlparam.Value = objcmsVideoDO.IsPublish;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@CreateDate", SqlDbType.DateTime);
                    Sqlparam.Value = objcmsVideoDO.CreateDate;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@IsHomepage", SqlDbType.Bit);
                    Sqlparam.Value = objcmsVideoDO.IsHomepage;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
                    Sqlparam.Value = objcmsVideoDO.ArticleID;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
                    Sqlparam.Direction = ParameterDirection.ReturnValue;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@IsAccepted", SqlDbType.Bit);
                    Sqlparam.Value = objcmsVideoDO.IsAccepted;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@UserXetDuyet", SqlDbType.Int);
                    Sqlparam.Value = objcmsVideoDO.UserXetDuyet;
                    Sqlcomm.Parameters.Add(Sqlparam);


                    int result = base.ExecuteNoneQuery(Sqlcomm);

                    if (!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
                        result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

                    return result;
                }

                public int Update(cmsVideoDO objcmsVideoDO)
                {

                    SqlCommand Sqlcomm = new SqlCommand();
                    Sqlcomm.CommandType = CommandType.StoredProcedure;
                    Sqlcomm.CommandText = "spcmsVideo_UpdateByPK";
                    SqlParameter Sqlparam;

                    Sqlparam = new SqlParameter("@VideoID", SqlDbType.BigInt);
                    Sqlparam.Value = objcmsVideoDO.VideoID;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
                    Sqlparam.Value = objcmsVideoDO.Title;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@VideoUrl", SqlDbType.NVarChar);
                    Sqlparam.Value = objcmsVideoDO.VideoUrl;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@Description", SqlDbType.NVarChar);
                    Sqlparam.Value = objcmsVideoDO.Description;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@AlbumID", SqlDbType.Int);
                    Sqlparam.Value = objcmsVideoDO.AlbumID;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
                    Sqlparam.Value = objcmsVideoDO.CategoryID;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@IsMostView", SqlDbType.Bit);
                    Sqlparam.Value = objcmsVideoDO.IsMostView;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@IsNew", SqlDbType.Bit);
                    Sqlparam.Value = objcmsVideoDO.IsNew;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
                    Sqlparam.Value = objcmsVideoDO.OrderID;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@IsPublish", SqlDbType.Bit);
                    Sqlparam.Value = objcmsVideoDO.IsPublish;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@CreateDate", SqlDbType.DateTime);
                    Sqlparam.Value = objcmsVideoDO.CreateDate;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@IsHomepage", SqlDbType.Bit);
                    Sqlparam.Value = objcmsVideoDO.IsHomepage;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
                    Sqlparam.Value = objcmsVideoDO.ArticleID;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@IsAccepted", SqlDbType.Bit);
                    Sqlparam.Value = objcmsVideoDO.IsAccepted;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    Sqlparam = new SqlParameter("@UserXetDuyet", SqlDbType.Int);
                    Sqlparam.Value = objcmsVideoDO.UserXetDuyet;
                    Sqlcomm.Parameters.Add(Sqlparam);


                    Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
                    Sqlparam.Direction = ParameterDirection.ReturnValue;
                    Sqlcomm.Parameters.Add(Sqlparam);

                    int result = base.ExecuteNoneQuery(Sqlcomm);

                    if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                        result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);

                    return result;


                }

        public int Delete(cmsVideoDO objcmsVideoDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsVideo_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@VideoID", SqlDbType.BigInt);
Sqlparam.Value = objcmsVideoDO.VideoID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

         public int DeleteAll()
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsVideo_DeleteAll";

            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsVideoDO Select(cmsVideoDO objcmsVideoDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsVideo_GetByPK";
            SqlParameter Sqlparam;
  

            Sqlparam = new SqlParameter("@VideoID", SqlDbType.BigInt);
Sqlparam.Value = objcmsVideoDO.VideoID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if(!Convert.IsDBNull(dr["VideoID"]))
objcmsVideoDO.VideoID=Convert.ToInt64(dr["VideoID"]);
if(!Convert.IsDBNull(dr["Title"]))
objcmsVideoDO.Title=Convert.ToString(dr["Title"]);
if(!Convert.IsDBNull(dr["VideoUrl"]))
objcmsVideoDO.VideoUrl=Convert.ToString(dr["VideoUrl"]);
if(!Convert.IsDBNull(dr["Description"]))
objcmsVideoDO.Description=Convert.ToString(dr["Description"]);
if(!Convert.IsDBNull(dr["AlbumID"]))
objcmsVideoDO.AlbumID=Convert.ToInt32(dr["AlbumID"]);
if(!Convert.IsDBNull(dr["CategoryID"]))
objcmsVideoDO.CategoryID=Convert.ToInt32(dr["CategoryID"]);
if(!Convert.IsDBNull(dr["IsMostView"]))
objcmsVideoDO.IsMostView=Convert.ToBoolean(dr["IsMostView"]);
if(!Convert.IsDBNull(dr["IsNew"]))
objcmsVideoDO.IsNew=Convert.ToBoolean(dr["IsNew"]);
if(!Convert.IsDBNull(dr["OrderID"]))
objcmsVideoDO.OrderID=Convert.ToInt32(dr["OrderID"]);
if(!Convert.IsDBNull(dr["IsPublish"]))
objcmsVideoDO.IsPublish=Convert.ToBoolean(dr["IsPublish"]);
if(!Convert.IsDBNull(dr["CreateDate"]))
objcmsVideoDO.CreateDate=Convert.ToDateTime(dr["CreateDate"]);
if(!Convert.IsDBNull(dr["IsHomepage"]))
objcmsVideoDO.IsHomepage=Convert.ToBoolean(dr["IsHomepage"]);
if (!Convert.IsDBNull(dr["IsAccepted"]))
    objcmsVideoDO.IsAccepted = Convert.ToBoolean(dr["IsAccepted"]);
if (!Convert.IsDBNull(dr["UserXetDuyet"]))
    objcmsVideoDO.UserXetDuyet = Convert.ToInt32(dr["UserXetDuyet"]);

            }
             return objcmsVideoDO;
        }

        public ArrayList SelectAll1( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsVideo_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsVideoDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach(DataRow dr in dt.Rows)
{
cmsVideoDO objcmsVideoDO= new cmsVideoDO();
if(!Convert.IsDBNull(dr["VideoID"]))
objcmsVideoDO.VideoID=Convert.ToInt64(dr["VideoID"]);
if(!Convert.IsDBNull(dr["Title"]))
objcmsVideoDO.Title=Convert.ToString(dr["Title"]);
if(!Convert.IsDBNull(dr["VideoUrl"]))
objcmsVideoDO.VideoUrl=Convert.ToString(dr["VideoUrl"]);
if(!Convert.IsDBNull(dr["Description"]))
objcmsVideoDO.Description=Convert.ToString(dr["Description"]);
if(!Convert.IsDBNull(dr["AlbumID"]))
objcmsVideoDO.AlbumID=Convert.ToInt32(dr["AlbumID"]);
if(!Convert.IsDBNull(dr["CategoryID"]))
objcmsVideoDO.CategoryID=Convert.ToInt32(dr["CategoryID"]);
if(!Convert.IsDBNull(dr["IsMostView"]))
objcmsVideoDO.IsMostView=Convert.ToBoolean(dr["IsMostView"]);
if(!Convert.IsDBNull(dr["IsNew"]))
objcmsVideoDO.IsNew=Convert.ToBoolean(dr["IsNew"]);
if(!Convert.IsDBNull(dr["OrderID"]))
objcmsVideoDO.OrderID=Convert.ToInt32(dr["OrderID"]);
if(!Convert.IsDBNull(dr["IsPublish"]))
objcmsVideoDO.IsPublish=Convert.ToBoolean(dr["IsPublish"]);
if(!Convert.IsDBNull(dr["CreateDate"]))
objcmsVideoDO.CreateDate=Convert.ToDateTime(dr["CreateDate"]);
if(!Convert.IsDBNull(dr["IsHomepage"]))
objcmsVideoDO.IsHomepage=Convert.ToBoolean(dr["IsHomepage"]);
if (!Convert.IsDBNull(dr["IsAccepted"]))
objcmsVideoDO.IsAccepted = Convert.ToBoolean(dr["IsAccepted"]);
if (!Convert.IsDBNull(dr["UserXetDuyet"]))
objcmsVideoDO.UserXetDuyet = Convert.ToInt32(dr["UserXetDuyet"]);
arrcmsVideoDO.Add(objcmsVideoDO);
}
            }
               return arrcmsVideoDO;
        }
        
        public DataTable SelectAll( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsVideo_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
          
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                
            }
               return dt;
        }
        public DataTable SelectVideoHomepage()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsVideo_Homepage";

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
