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
/// Summary description for cmsTinNoiBatDAL
/// </summary>
namespace SES.CMS.DAL
{

    public class cmsTinNoiBatDAL : BaseDAL
    {
        #region Private Variables

        #endregion

        #region Public Constructors
        public cmsTinNoiBatDAL()
        {
            //
            // TODO: Add constructor logic here
            //

        }
        #endregion



        #region Public Methods
        public int Insert(cmsTinNoiBatDO objcmsTinNoiBatDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsTinNoiBat_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
            Sqlparam.Value = objcmsTinNoiBatDO.ArticleID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
            Sqlparam.Value = objcmsTinNoiBatDO.OrderID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@DateCreate", SqlDbType.DateTime);
            Sqlparam.Value = objcmsTinNoiBatDO.DateCreate;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserCreate", SqlDbType.Int);
            Sqlparam.Value = objcmsTinNoiBatDO.UserCreate;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);


            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsTinNoiBatDO objcmsTinNoiBatDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsTinNoiBat_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@TinNoiBatID", SqlDbType.Int);
            Sqlparam.Value = objcmsTinNoiBatDO.TinNoiBatID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
            Sqlparam.Value = objcmsTinNoiBatDO.ArticleID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
            Sqlparam.Value = objcmsTinNoiBatDO.OrderID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@DateCreate", SqlDbType.DateTime);
            Sqlparam.Value = objcmsTinNoiBatDO.DateCreate;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserCreate", SqlDbType.Int);
            Sqlparam.Value = objcmsTinNoiBatDO.UserCreate;
            Sqlcomm.Parameters.Add(Sqlparam);



            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);

            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);

            return result;


        }

        public int Delete(cmsTinNoiBatDO objcmsTinNoiBatDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsTinNoiBat_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@TinNoiBatID", SqlDbType.Int);
            Sqlparam.Value = objcmsTinNoiBatDO.TinNoiBatID;
            Sqlcomm.Parameters.Add(Sqlparam);



            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public int DeleteAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsTinNoiBat_DeleteAll";

            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsTinNoiBatDO Select(cmsTinNoiBatDO objcmsTinNoiBatDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsTinNoiBat_GetByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@TinNoiBatID", SqlDbType.Int);
            Sqlparam.Value = objcmsTinNoiBatDO.TinNoiBatID;
            Sqlcomm.Parameters.Add(Sqlparam);



            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if (!Convert.IsDBNull(dr["TinNoiBatID"]))
                    objcmsTinNoiBatDO.TinNoiBatID = Convert.ToInt32(dr["TinNoiBatID"]);
                if (!Convert.IsDBNull(dr["ArticleID"]))
                    objcmsTinNoiBatDO.ArticleID = Convert.ToInt32(dr["ArticleID"]);
                if (!Convert.IsDBNull(dr["OrderID"]))
                    objcmsTinNoiBatDO.OrderID = Convert.ToInt32(dr["OrderID"]);
                if (!Convert.IsDBNull(dr["DateCreate"]))
                    objcmsTinNoiBatDO.DateCreate = Convert.ToDateTime(dr["DateCreate"]);
                if (!Convert.IsDBNull(dr["UserCreate"]))
                    objcmsTinNoiBatDO.UserCreate = Convert.ToInt32(dr["UserCreate"]);

            }
            return objcmsTinNoiBatDO;
        }

        public ArrayList SelectAll1()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsTinNoiBat_GetAll";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsTinNoiBatDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    cmsTinNoiBatDO objcmsTinNoiBatDO = new cmsTinNoiBatDO();
                    if (!Convert.IsDBNull(dr["TinNoiBatID"]))
                        objcmsTinNoiBatDO.TinNoiBatID = Convert.ToInt32(dr["TinNoiBatID"]);
                    if (!Convert.IsDBNull(dr["ArticleID"]))
                        objcmsTinNoiBatDO.ArticleID = Convert.ToInt32(dr["ArticleID"]);
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        objcmsTinNoiBatDO.OrderID = Convert.ToInt32(dr["OrderID"]);
                    if (!Convert.IsDBNull(dr["DateCreate"]))
                        objcmsTinNoiBatDO.DateCreate = Convert.ToDateTime(dr["DateCreate"]);
                    if (!Convert.IsDBNull(dr["UserCreate"]))
                        objcmsTinNoiBatDO.UserCreate = Convert.ToInt32(dr["UserCreate"]);
                    arrcmsTinNoiBatDO.Add(objcmsTinNoiBatDO);
                }
            }
            return arrcmsTinNoiBatDO;
        }

        public DataTable SelectAll(int top)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsTinNoiBat_GetAll";

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
