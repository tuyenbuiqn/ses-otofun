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
/// Summary description for cmsTopNewsDAL
/// </summary>
namespace SES.CMS.DAL 
{
    
    public class cmsTopNewsDAL  : BaseDAL
    {
    	#region Private Variables
			
		#endregion
		
		#region Public Constructors
				public cmsTopNewsDAL()
				{
					//
					// TODO: Add constructor logic here
					//
					
				}
		#endregion       

	
		
		#region Public Methods
        public int Insert(cmsTopNewsDO objcmsTopNewsDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsTopNews_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
Sqlparam.Value = objcmsTopNewsDO.ArticleID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
Sqlparam.Value = objcmsTopNewsDO.OrderID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@DateCreate", SqlDbType.DateTime);
Sqlparam.Value = objcmsTopNewsDO.DateCreate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@UserCreate", SqlDbType.Int);
Sqlparam.Value = objcmsTopNewsDO.UserCreate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
Sqlparam.Direction = ParameterDirection.ReturnValue;
Sqlcomm.Parameters.Add(Sqlparam);

           
            int result =base.ExecuteNoneQuery(Sqlcomm);
            
            if(!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
				result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsTopNewsDO objcmsTopNewsDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsTopNews_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@TopNews", SqlDbType.Int);
Sqlparam.Value = objcmsTopNewsDO.TopNews;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
Sqlparam.Value = objcmsTopNewsDO.ArticleID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
Sqlparam.Value = objcmsTopNewsDO.OrderID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@DateCreate", SqlDbType.DateTime);
Sqlparam.Value = objcmsTopNewsDO.DateCreate;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@UserCreate", SqlDbType.Int);
Sqlparam.Value = objcmsTopNewsDO.UserCreate;
Sqlcomm.Parameters.Add(Sqlparam);


            
            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);
            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            
             if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);
                
            return result;

           
        }

        public int Delete(cmsTopNewsDO objcmsTopNewsDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsTopNews_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@TopNews", SqlDbType.Int);
Sqlparam.Value = objcmsTopNewsDO.TopNews;
Sqlcomm.Parameters.Add(Sqlparam);


            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

         public int DeleteAll()
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsTopNews_DeleteAll";

            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsTopNewsDO Select(cmsTopNewsDO objcmsTopNewsDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsTopNews_GetByPK";
            SqlParameter Sqlparam;
  

            Sqlparam = new SqlParameter("@TopNews", SqlDbType.Int);
Sqlparam.Value = objcmsTopNewsDO.TopNews;
Sqlcomm.Parameters.Add(Sqlparam);


            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if(!Convert.IsDBNull(dr["TopNews"]))
objcmsTopNewsDO.TopNews=Convert.ToInt32(dr["TopNews"]);
if(!Convert.IsDBNull(dr["ArticleID"]))
objcmsTopNewsDO.ArticleID=Convert.ToInt32(dr["ArticleID"]);
if(!Convert.IsDBNull(dr["OrderID"]))
objcmsTopNewsDO.OrderID=Convert.ToInt32(dr["OrderID"]);
if(!Convert.IsDBNull(dr["DateCreate"]))
objcmsTopNewsDO.DateCreate=Convert.ToDateTime(dr["DateCreate"]);
if(!Convert.IsDBNull(dr["UserCreate"]))
objcmsTopNewsDO.UserCreate=Convert.ToInt32(dr["UserCreate"]);

            }
             return objcmsTopNewsDO;
        }

        public ArrayList SelectAll1( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsTopNews_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsTopNewsDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach(DataRow dr in dt.Rows)
{
cmsTopNewsDO objcmsTopNewsDO= new cmsTopNewsDO();
if(!Convert.IsDBNull(dr["TopNews"]))
objcmsTopNewsDO.TopNews=Convert.ToInt32(dr["TopNews"]);
if(!Convert.IsDBNull(dr["ArticleID"]))
objcmsTopNewsDO.ArticleID=Convert.ToInt32(dr["ArticleID"]);
if(!Convert.IsDBNull(dr["OrderID"]))
objcmsTopNewsDO.OrderID=Convert.ToInt32(dr["OrderID"]);
if(!Convert.IsDBNull(dr["DateCreate"]))
objcmsTopNewsDO.DateCreate=Convert.ToDateTime(dr["DateCreate"]);
if(!Convert.IsDBNull(dr["UserCreate"]))
objcmsTopNewsDO.UserCreate=Convert.ToInt32(dr["UserCreate"]);
arrcmsTopNewsDO.Add(objcmsTopNewsDO);
}
            }
               return arrcmsTopNewsDO;
        }

        public DataTable SelectAll(int top)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            //Sqlcomm.CommandText = "spcmsLastestNews_GetAll";
            Sqlcomm.CommandText = "spcmsTopNews_GetAll";

            SqlParameter Sqlparam;
            Sqlparam = new SqlParameter("@top", SqlDbType.Int);
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
