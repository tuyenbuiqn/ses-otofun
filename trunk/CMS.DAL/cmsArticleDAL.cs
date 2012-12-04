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
/// Summary description for cmsArticleDAL
/// </summary>
namespace SES.CMS.DAL 
{
    
    public class cmsArticleDAL  : BaseDAL
    {
    	#region Private Variables
			
		#endregion
		
		#region Public Constructors
				public cmsArticleDAL()
				{
					//
					// TODO: Add constructor logic here
					//
					
				}
		#endregion       

	
		
		#region Public Methods
        public int Insert(cmsArticleDO objcmsArticleDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsArticle_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
Sqlparam.Value = objcmsArticleDO.Title;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
Sqlparam.Value = objcmsArticleDO.CategoryID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ImageUrl", SqlDbType.NVarChar);
Sqlparam.Value = objcmsArticleDO.ImageUrl;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Description", SqlDbType.NText);
Sqlparam.Value = objcmsArticleDO.Description;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ArticleDetail", SqlDbType.NText);
Sqlparam.Value = objcmsArticleDO.ArticleDetail;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Tags", SqlDbType.NText);
Sqlparam.Value = objcmsArticleDO.Tags;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@IsPublish", SqlDbType.Bit);
Sqlparam.Value = objcmsArticleDO.IsPublish;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
Sqlparam.Value = objcmsArticleDO.OrderID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@IsHompage", SqlDbType.Bit);
Sqlparam.Value = objcmsArticleDO.IsHompage;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@UserCreate", SqlDbType.Int);
Sqlparam.Value = objcmsArticleDO.UserCreate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CreateDate", SqlDbType.DateTime);
Sqlparam.Value = objcmsArticleDO.CreateDate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
Sqlparam.Direction = ParameterDirection.ReturnValue;
Sqlcomm.Parameters.Add(Sqlparam);

           
            int result =base.ExecuteNoneQuery(Sqlcomm);
            
            if(!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
				result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsArticleDO objcmsArticleDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsArticle_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
Sqlparam.Value = objcmsArticleDO.ArticleID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
Sqlparam.Value = objcmsArticleDO.Title;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
Sqlparam.Value = objcmsArticleDO.CategoryID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ImageUrl", SqlDbType.NVarChar);
Sqlparam.Value = objcmsArticleDO.ImageUrl;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Description", SqlDbType.NText);
Sqlparam.Value = objcmsArticleDO.Description;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ArticleDetail", SqlDbType.NText);
Sqlparam.Value = objcmsArticleDO.ArticleDetail;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@Tags", SqlDbType.NText);
Sqlparam.Value = objcmsArticleDO.Tags;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@IsPublish", SqlDbType.Bit);
Sqlparam.Value = objcmsArticleDO.IsPublish;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
Sqlparam.Value = objcmsArticleDO.OrderID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@IsHompage", SqlDbType.Bit);
Sqlparam.Value = objcmsArticleDO.IsHompage;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@UserCreate", SqlDbType.Int);
Sqlparam.Value = objcmsArticleDO.UserCreate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CreateDate", SqlDbType.DateTime);
Sqlparam.Value = objcmsArticleDO.CreateDate;
Sqlcomm.Parameters.Add(Sqlparam);


            
            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);
            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            
             if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);
                
            return result;

           
        }

        public int Delete(cmsArticleDO objcmsArticleDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsArticle_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
Sqlparam.Value = objcmsArticleDO.ArticleID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

         public int DeleteAll()
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsArticle_DeleteAll";

            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsArticleDO Select(cmsArticleDO objcmsArticleDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsArticle_GetByPK";
            SqlParameter Sqlparam;
  

            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
Sqlparam.Value = objcmsArticleDO.ArticleID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if(!Convert.IsDBNull(dr["ArticleID"]))
objcmsArticleDO.ArticleID=Convert.ToInt32(dr["ArticleID"]);
if(!Convert.IsDBNull(dr["Title"]))
objcmsArticleDO.Title=Convert.ToString(dr["Title"]);
if(!Convert.IsDBNull(dr["CategoryID"]))
objcmsArticleDO.CategoryID=Convert.ToInt32(dr["CategoryID"]);
if(!Convert.IsDBNull(dr["ImageUrl"]))
objcmsArticleDO.ImageUrl=Convert.ToString(dr["ImageUrl"]);
if(!Convert.IsDBNull(dr["Description"]))
objcmsArticleDO.Description=Convert.ToString(dr["Description"]);
if(!Convert.IsDBNull(dr["ArticleDetail"]))
objcmsArticleDO.ArticleDetail=Convert.ToString(dr["ArticleDetail"]);
if(!Convert.IsDBNull(dr["Tags"]))
objcmsArticleDO.Tags=Convert.ToString(dr["Tags"]);
if(!Convert.IsDBNull(dr["IsPublish"]))
objcmsArticleDO.IsPublish=Convert.ToBoolean(dr["IsPublish"]);
if(!Convert.IsDBNull(dr["OrderID"]))
objcmsArticleDO.OrderID=Convert.ToInt32(dr["OrderID"]);
if(!Convert.IsDBNull(dr["IsHompage"]))
objcmsArticleDO.IsHompage=Convert.ToBoolean(dr["IsHompage"]);
if(!Convert.IsDBNull(dr["UserCreate"]))
objcmsArticleDO.UserCreate=Convert.ToInt32(dr["UserCreate"]);
if(!Convert.IsDBNull(dr["CreateDate"]))
objcmsArticleDO.CreateDate=Convert.ToDateTime(dr["CreateDate"]);

            }
             return objcmsArticleDO;
        }

        public ArrayList SelectAll1( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsArticle_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsArticleDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach(DataRow dr in dt.Rows)
{
cmsArticleDO objcmsArticleDO= new cmsArticleDO();
if(!Convert.IsDBNull(dr["ArticleID"]))
objcmsArticleDO.ArticleID=Convert.ToInt32(dr["ArticleID"]);
if(!Convert.IsDBNull(dr["Title"]))
objcmsArticleDO.Title=Convert.ToString(dr["Title"]);
if(!Convert.IsDBNull(dr["CategoryID"]))
objcmsArticleDO.CategoryID=Convert.ToInt32(dr["CategoryID"]);
if(!Convert.IsDBNull(dr["ImageUrl"]))
objcmsArticleDO.ImageUrl=Convert.ToString(dr["ImageUrl"]);
if(!Convert.IsDBNull(dr["Description"]))
objcmsArticleDO.Description=Convert.ToString(dr["Description"]);
if(!Convert.IsDBNull(dr["ArticleDetail"]))
objcmsArticleDO.ArticleDetail=Convert.ToString(dr["ArticleDetail"]);
if(!Convert.IsDBNull(dr["Tags"]))
objcmsArticleDO.Tags=Convert.ToString(dr["Tags"]);
if(!Convert.IsDBNull(dr["IsPublish"]))
objcmsArticleDO.IsPublish=Convert.ToBoolean(dr["IsPublish"]);
if(!Convert.IsDBNull(dr["OrderID"]))
objcmsArticleDO.OrderID=Convert.ToInt32(dr["OrderID"]);
if(!Convert.IsDBNull(dr["IsHompage"]))
objcmsArticleDO.IsHompage=Convert.ToBoolean(dr["IsHompage"]);
if(!Convert.IsDBNull(dr["UserCreate"]))
objcmsArticleDO.UserCreate=Convert.ToInt32(dr["UserCreate"]);
if(!Convert.IsDBNull(dr["CreateDate"]))
objcmsArticleDO.CreateDate=Convert.ToDateTime(dr["CreateDate"]);
arrcmsArticleDO.Add(objcmsArticleDO);
}
            }
               return arrcmsArticleDO;
        }
        
        public DataTable SelectAll( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsArticle_GetAll";
            
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
            Sqlcomm.CommandText = "spcmsArticle_GetByCategoryID";
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

        public DataTable SelectByCatNum(int CategoryID, int Recordnumber)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByCategoryRecordNumber";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
            Sqlparam.Value = CategoryID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Recordnumber", SqlDbType.Int);
            Sqlparam.Value = Recordnumber;
            Sqlcomm.Parameters.Add(Sqlparam);

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }

        public DataTable SelectOne(cmsArticleDO objArt)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
            Sqlparam.Value = objArt.ArticleID;
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
