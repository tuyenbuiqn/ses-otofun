/*
  Copyright 2009 Smart Enterprise Solution Corp.
  CategoryID: contact@ses.vn - Website: http://www.ses.vn
  KimNgan Project.
*/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using SES.CMS.DO;
/// <summary>
/// Summary description for sysUserDAL
/// </summary>
namespace SES.CMS.DAL
{
    public class cmsUserCategory : BaseDAL
    {
        #region Private Variables

        #endregion

        #region Public Constructors
        public cmsUserCategory()
        {
            //
            // TODO: Add constructor logic here
            //

        }
        #endregion



        #region Public Methods
        public int Insert(cmsUserCategoryDO objcmsUserCategoryDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsUserCategory_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@UserID", SqlDbType.Int);
            Sqlparam.Value = objcmsUserCategoryDO.UserID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
            Sqlparam.Value = objcmsUserCategoryDO.CategoryID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Note", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsUserCategoryDO.Note;
            Sqlcomm.Parameters.Add(Sqlparam);


            Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);


            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsUserCategoryDO objcmsUserCategoryDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsUserCategory_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@UserCategoryID", SqlDbType.Int);
            Sqlparam.Value = objcmsUserCategoryDO.UserCategoryID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserID", SqlDbType.Int);
            Sqlparam.Value = objcmsUserCategoryDO.UserID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
            Sqlparam.Value = objcmsUserCategoryDO.CategoryID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Note", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsUserCategoryDO.Note;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);

            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);

            return result;


        }

        public int Delete(cmsUserCategoryDO objcmsUserCategoryDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsUserCategory_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@UserCategoryID", SqlDbType.Int);
            Sqlparam.Value = objcmsUserCategoryDO.UserCategoryID;
            Sqlcomm.Parameters.Add(Sqlparam);



            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }
        public int DeleteByUserID(int userID)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsUserCategory_DeleteByFK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@UserID", SqlDbType.Int);
            Sqlparam.Value = userID;
            Sqlcomm.Parameters.Add(Sqlparam);



            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }
        public int DeleteAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsUserCategory_DeleteAll";

            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsUserCategoryDO Select(cmsUserCategoryDO objcmsUserCategoryDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsUserCategory_GetByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@UserCategoryID", SqlDbType.Int);
            Sqlparam.Value = objcmsUserCategoryDO.UserCategoryID;
            Sqlcomm.Parameters.Add(Sqlparam);

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if (!Convert.IsDBNull(dr["UserCategoryID"]))
                    objcmsUserCategoryDO.UserCategoryID = Convert.ToInt32(dr["UserCategoryID"]);
                if (!Convert.IsDBNull(dr["UserID"]))
                    objcmsUserCategoryDO.UserID = Convert.ToInt32(dr["UserID"]);
                if (!Convert.IsDBNull(dr["CategoryID"]))
                    objcmsUserCategoryDO.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                if (!Convert.IsDBNull(dr["Note"]))
                    objcmsUserCategoryDO.Note = Convert.ToString(dr["Note"]);
            }
            return objcmsUserCategoryDO;
        }

        public ArrayList SelectAll1()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsUserCategory_GetAll";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsUserCategoryDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    cmsUserCategoryDO objcmsUserCategoryDO = new cmsUserCategoryDO();
                    if (!Convert.IsDBNull(dr["UserCategoryID"]))
                        objcmsUserCategoryDO.UserCategoryID = Convert.ToInt32(dr["UserCategoryID"]);
                    if (!Convert.IsDBNull(dr["UserID"]))
                        objcmsUserCategoryDO.UserID = Convert.ToInt32(dr["UserID"]);
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        objcmsUserCategoryDO.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                    if (!Convert.IsDBNull(dr["Note"]))
                        objcmsUserCategoryDO.Note = Convert.ToString(dr["Note"]);
                    arrcmsUserCategoryDO.Add(objcmsUserCategoryDO);
                }
            }
            return arrcmsUserCategoryDO;
        }

        public DataTable SelectAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsUserCategory_GetAll";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
        public DataTable SelectByUserID(int userID)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsUserCategory_GetByFK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@UserID", SqlDbType.Int);
            Sqlparam.Value = userID;
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
