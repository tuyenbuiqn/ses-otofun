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
/// Summary description for cmsHistoryDAL
/// </summary>
namespace SES.CMS.DAL
{

    public class cmsHistoryDAL : BaseDAL
    {
        #region Private Variables

        #endregion

        #region Public Constructors
        public cmsHistoryDAL()
        {
            //
            // TODO: Add constructor logic here
            //

        }
        #endregion



        #region Public Methods
        public int Insert(cmsHistoryDO objcmsHistoryDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsHistory_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@Action", SqlDbType.Int);
            Sqlparam.Value = objcmsHistoryDO.Action;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Contents", SqlDbType.NText);
            Sqlparam.Value = objcmsHistoryDO.Contents;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@HistoryTime", SqlDbType.DateTime);
            Sqlparam.Value = objcmsHistoryDO.HistoryTime;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Comment", SqlDbType.NText);
            Sqlparam.Value = objcmsHistoryDO.Comment;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IP", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsHistoryDO.IP;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserID", SqlDbType.Int);
            Sqlparam.Value = objcmsHistoryDO.UserID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
            Sqlparam.Value = objcmsHistoryDO.ArticleID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);


            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsHistoryDO objcmsHistoryDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsHistory_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@HistoryID", SqlDbType.Int);
            Sqlparam.Value = objcmsHistoryDO.HistoryID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Action", SqlDbType.Int);
            Sqlparam.Value = objcmsHistoryDO.Action;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Contents", SqlDbType.NText);
            Sqlparam.Value = objcmsHistoryDO.Contents;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@HistoryTime", SqlDbType.DateTime);
            Sqlparam.Value = objcmsHistoryDO.HistoryTime;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Comment", SqlDbType.NText);
            Sqlparam.Value = objcmsHistoryDO.Comment;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IP", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsHistoryDO.IP;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserID", SqlDbType.Int);
            Sqlparam.Value = objcmsHistoryDO.UserID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
            Sqlparam.Value = objcmsHistoryDO.ArticleID;
            Sqlcomm.Parameters.Add(Sqlparam);



            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);

            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);

            return result;


        }

        public int Delete(cmsHistoryDO objcmsHistoryDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsHistory_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@HistoryID", SqlDbType.Int);
            Sqlparam.Value = objcmsHistoryDO.HistoryID;
            Sqlcomm.Parameters.Add(Sqlparam);



            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public int DeleteAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsHistory_DeleteAll";

            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsHistoryDO Select(cmsHistoryDO objcmsHistoryDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsHistory_GetByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@HistoryID", SqlDbType.Int);
            Sqlparam.Value = objcmsHistoryDO.HistoryID;
            Sqlcomm.Parameters.Add(Sqlparam);



            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if (!Convert.IsDBNull(dr["HistoryID"]))
                    objcmsHistoryDO.HistoryID = Convert.ToInt32(dr["HistoryID"]);
                if (!Convert.IsDBNull(dr["Action"]))
                    objcmsHistoryDO.Action = Convert.ToInt32(dr["Action"]);
                if (!Convert.IsDBNull(dr["Contents"]))
                    objcmsHistoryDO.Contents = Convert.ToString(dr["Contents"]);
                if (!Convert.IsDBNull(dr["HistoryTime"]))
                    objcmsHistoryDO.HistoryTime = Convert.ToDateTime(dr["HistoryTime"]);
                if (!Convert.IsDBNull(dr["Comment"]))
                    objcmsHistoryDO.Comment = Convert.ToString(dr["Comment"]);
                if (!Convert.IsDBNull(dr["IP"]))
                    objcmsHistoryDO.IP = Convert.ToString(dr["IP"]);
                if (!Convert.IsDBNull(dr["UserID"]))
                    objcmsHistoryDO.UserID = Convert.ToInt32(dr["UserID"]);
                if (!Convert.IsDBNull(dr["ArticleID"]))
                    objcmsHistoryDO.ArticleID = Convert.ToInt32(dr["ArticleID"]);

            }
            return objcmsHistoryDO;
        }

        public ArrayList SelectAll1()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsHistory_GetAll";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsHistoryDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    cmsHistoryDO objcmsHistoryDO = new cmsHistoryDO();
                    if (!Convert.IsDBNull(dr["HistoryID"]))
                        objcmsHistoryDO.HistoryID = Convert.ToInt32(dr["HistoryID"]);
                    if (!Convert.IsDBNull(dr["Action"]))
                        objcmsHistoryDO.Action = Convert.ToInt32(dr["Action"]);
                    if (!Convert.IsDBNull(dr["Contents"]))
                        objcmsHistoryDO.Contents = Convert.ToString(dr["Contents"]);
                    if (!Convert.IsDBNull(dr["HistoryTime"]))
                        objcmsHistoryDO.HistoryTime = Convert.ToDateTime(dr["HistoryTime"]);
                    if (!Convert.IsDBNull(dr["Comment"]))
                        objcmsHistoryDO.Comment = Convert.ToString(dr["Comment"]);
                    if (!Convert.IsDBNull(dr["IP"]))
                        objcmsHistoryDO.IP = Convert.ToString(dr["IP"]);
                    if (!Convert.IsDBNull(dr["UserID"]))
                        objcmsHistoryDO.UserID = Convert.ToInt32(dr["UserID"]);
                    if (!Convert.IsDBNull(dr["ArticleID"]))
                        objcmsHistoryDO.ArticleID = Convert.ToInt32(dr["ArticleID"]);
                    arrcmsHistoryDO.Add(objcmsHistoryDO);
                }
            }
            return arrcmsHistoryDO;
        }

        public DataTable SelectAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsHistory_GetAll";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
        public DataTable SelectByArticeID(int articleID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsHistory_SelectByArticleID";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
            Sqlparam.Value = articleID;
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
