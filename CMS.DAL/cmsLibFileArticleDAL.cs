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
/// Summary description for cmsLibFileArticleDAL
/// </summary>
namespace SES.CMS.DAL 
{
    
    public class cmsLibFileArticleDAL  : BaseDAL
    {
    	#region Private Variables
			
		#endregion
		
		#region Public Constructors
				public cmsLibFileArticleDAL()
				{
					//
					// TODO: Add constructor logic here
					//
					
				}
		#endregion       

	
		
		#region Public Methods
        public int Insert(cmsLibFileArticleDO objcmsLibFileArticleDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibFileArticle_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
Sqlparam.Value = objcmsLibFileArticleDO.ArticleID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@FileID", SqlDbType.Int);
Sqlparam.Value = objcmsLibFileArticleDO.FileID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
Sqlparam.Direction = ParameterDirection.ReturnValue;
Sqlcomm.Parameters.Add(Sqlparam);

           
            int result =base.ExecuteNoneQuery(Sqlcomm);
            
            if(!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
				result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsLibFileArticleDO objcmsLibFileArticleDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibFileArticle_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@LibFileArticleID", SqlDbType.Int);
Sqlparam.Value = objcmsLibFileArticleDO.LibFileArticleID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
Sqlparam.Value = objcmsLibFileArticleDO.ArticleID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@FileID", SqlDbType.Int);
Sqlparam.Value = objcmsLibFileArticleDO.FileID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);
            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            
             if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);
                
            return result;

           
        }

        public int Delete(cmsLibFileArticleDO objcmsLibFileArticleDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibFileArticle_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@LibFileArticleID", SqlDbType.Int);
Sqlparam.Value = objcmsLibFileArticleDO.LibFileArticleID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

         public int DeleteAll()
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibFileArticle_DeleteAll";

            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsLibFileArticleDO Select(cmsLibFileArticleDO objcmsLibFileArticleDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibFileArticle_GetByPK";
            SqlParameter Sqlparam;
  

            Sqlparam = new SqlParameter("@LibFileArticleID", SqlDbType.Int);
Sqlparam.Value = objcmsLibFileArticleDO.LibFileArticleID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if(!Convert.IsDBNull(dr["LibFileArticleID"]))
objcmsLibFileArticleDO.LibFileArticleID=Convert.ToInt32(dr["LibFileArticleID"]);
if(!Convert.IsDBNull(dr["ArticleID"]))
objcmsLibFileArticleDO.ArticleID=Convert.ToInt32(dr["ArticleID"]);
if(!Convert.IsDBNull(dr["FileID"]))
objcmsLibFileArticleDO.FileID=Convert.ToInt32(dr["FileID"]);

            }
             return objcmsLibFileArticleDO;
        }

        public ArrayList SelectAll1( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibFileArticle_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsLibFileArticleDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach(DataRow dr in dt.Rows)
{
cmsLibFileArticleDO objcmsLibFileArticleDO= new cmsLibFileArticleDO();
if(!Convert.IsDBNull(dr["LibFileArticleID"]))
objcmsLibFileArticleDO.LibFileArticleID=Convert.ToInt32(dr["LibFileArticleID"]);
if(!Convert.IsDBNull(dr["ArticleID"]))
objcmsLibFileArticleDO.ArticleID=Convert.ToInt32(dr["ArticleID"]);
if(!Convert.IsDBNull(dr["FileID"]))
objcmsLibFileArticleDO.FileID=Convert.ToInt32(dr["FileID"]);
arrcmsLibFileArticleDO.Add(objcmsLibFileArticleDO);
}
            }
               return arrcmsLibFileArticleDO;
        }
        
        public DataTable SelectAll( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsLibFileArticle_GetAll";
            
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
