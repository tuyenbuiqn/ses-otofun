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
/// Summary description for cmsMostReadDAL
/// </summary>
namespace SES.CMS.DAL 
{
    
    public class cmsMostReadDAL  : BaseDAL
    {
    	#region Private Variables
			
		#endregion
		
		#region Public Constructors
				public cmsMostReadDAL()
				{
					//
					// TODO: Add constructor logic here
					//
					
				}
		#endregion       

	
		
		#region Public Methods
        public int Insert(cmsMostReadDO objcmsMostReadDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsMostRead_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
Sqlparam.Value = objcmsMostReadDO.ArticleID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
Sqlparam.Value = objcmsMostReadDO.CategoryID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
Sqlparam.Value = objcmsMostReadDO.OrderID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
Sqlparam.Direction = ParameterDirection.ReturnValue;
Sqlcomm.Parameters.Add(Sqlparam);

           
            int result =base.ExecuteNoneQuery(Sqlcomm);
            
            if(!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
				result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsMostReadDO objcmsMostReadDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsMostRead_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@MostReadID", SqlDbType.Int);
Sqlparam.Value = objcmsMostReadDO.MostReadID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
Sqlparam.Value = objcmsMostReadDO.ArticleID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
Sqlparam.Value = objcmsMostReadDO.CategoryID;
Sqlcomm.Parameters.Add(Sqlparam);

Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
Sqlparam.Value = objcmsMostReadDO.OrderID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);
            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            
             if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);
                
            return result;

           
        }

        public int Delete(cmsMostReadDO objcmsMostReadDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsMostRead_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@MostReadID", SqlDbType.Int);
Sqlparam.Value = objcmsMostReadDO.MostReadID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

         public int DeleteAll()
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsMostRead_DeleteAll";

            int result=base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsMostReadDO Select(cmsMostReadDO objcmsMostReadDO)
        {
            
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsMostRead_GetByPK";
            SqlParameter Sqlparam;
  

            Sqlparam = new SqlParameter("@MostReadID", SqlDbType.Int);
Sqlparam.Value = objcmsMostReadDO.MostReadID;
Sqlcomm.Parameters.Add(Sqlparam);


            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if(!Convert.IsDBNull(dr["MostReadID"]))
objcmsMostReadDO.MostReadID=Convert.ToInt32(dr["MostReadID"]);
if(!Convert.IsDBNull(dr["ArticleID"]))
objcmsMostReadDO.ArticleID=Convert.ToInt32(dr["ArticleID"]);
if(!Convert.IsDBNull(dr["CategoryID"]))
objcmsMostReadDO.CategoryID=Convert.ToInt32(dr["CategoryID"]);
if(!Convert.IsDBNull(dr["OrderID"]))
objcmsMostReadDO.OrderID=Convert.ToInt32(dr["OrderID"]);

            }
             return objcmsMostReadDO;
        }

        public ArrayList SelectAll1( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsMostRead_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsMostReadDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach(DataRow dr in dt.Rows)
{
cmsMostReadDO objcmsMostReadDO= new cmsMostReadDO();
if(!Convert.IsDBNull(dr["MostReadID"]))
objcmsMostReadDO.MostReadID=Convert.ToInt32(dr["MostReadID"]);
if(!Convert.IsDBNull(dr["ArticleID"]))
objcmsMostReadDO.ArticleID=Convert.ToInt32(dr["ArticleID"]);
if(!Convert.IsDBNull(dr["CategoryID"]))
objcmsMostReadDO.CategoryID=Convert.ToInt32(dr["CategoryID"]);
if(!Convert.IsDBNull(dr["OrderID"]))
objcmsMostReadDO.OrderID=Convert.ToInt32(dr["OrderID"]);
arrcmsMostReadDO.Add(objcmsMostReadDO);
}
            }
               return arrcmsMostReadDO;
        }
        
        public DataTable SelectAll( )
        {
			
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType =  CommandType.StoredProcedure;
            Sqlcomm.CommandText =  "spcmsMostRead_GetAll";
            
            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
          
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                
            }
               return dt;
        }

     
		#endregion          
        public DataTable SelectByCategoryID(int top, int categoryID)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            //Sqlcomm.CommandText = "spcmsLastestNews_GetAll";
            Sqlcomm.CommandText = "spcmsMostRead_GetByCategory";

            SqlParameter Sqlparam;
            Sqlparam = new SqlParameter("@top", SqlDbType.Int);
            Sqlparam.Value = top;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
            Sqlparam.Value = categoryID;
            Sqlcomm.Parameters.Add(Sqlparam);

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
        public DataTable SelectHomepageMostRead(int top)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            //Sqlcomm.CommandText = "spcmsLastestNews_GetAll";
            Sqlcomm.CommandText = "spcmsMostRead_GetByCategoryHome";

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
    }

}
