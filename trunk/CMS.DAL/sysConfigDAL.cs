/*
  Copyright 2009 Smart Enterprise Solution Corp.
  Email: contact@ses.vn - Website: http://www.ses.vn
  KimNgan Project.
*/
using System;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using SES.CMS.DO;
/// <summary>
/// Summary description for sysConfigDAL
/// </summary>
namespace SES.CMS.DAL
{

    public class sysConfigDAL : BaseDAL
    {
        #region Private Variables

        #endregion

        #region Public Constructors
        public sysConfigDAL()
        {
            //
            // TODO: Add constructor logic here
            //

        }
        #endregion



        #region Public Methods
        public int Insert(sysConfigDO objsysConfigDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spsysConfig_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@ConfigName", SqlDbType.NVarChar);
            Sqlparam.Value = objsysConfigDO.ConfigName;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ConfigValue", SqlDbType.NText);
            Sqlparam.Value = objsysConfigDO.ConfigValue;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsActive", SqlDbType.Bit);
            Sqlparam.Value = objsysConfigDO.IsActive;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);


            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(sysConfigDO objsysConfigDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spsysConfig_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@ConfigID", SqlDbType.Int);
            Sqlparam.Value = objsysConfigDO.ConfigID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ConfigName", SqlDbType.NVarChar);
            Sqlparam.Value = objsysConfigDO.ConfigName;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ConfigValue", SqlDbType.NText);
            Sqlparam.Value = objsysConfigDO.ConfigValue;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsActive", SqlDbType.Bit);
            Sqlparam.Value = objsysConfigDO.IsActive;
            Sqlcomm.Parameters.Add(Sqlparam);



            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);

            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);

            return result;


        }

        public int Delete(sysConfigDO objsysConfigDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spsysConfig_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@ConfigID", SqlDbType.Int);
            Sqlparam.Value = objsysConfigDO.ConfigID;
            Sqlcomm.Parameters.Add(Sqlparam);



            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public int DeleteAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spsysConfig_DeleteAll";

            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public sysConfigDO Select(sysConfigDO objsysConfigDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spsysConfig_GetByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@ConfigID", SqlDbType.Int);
            Sqlparam.Value = objsysConfigDO.ConfigID;
            Sqlcomm.Parameters.Add(Sqlparam);



            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if (!Convert.IsDBNull(dr["ConfigID"]))
                    objsysConfigDO.ConfigID = Convert.ToInt32(dr["ConfigID"]);
                if (!Convert.IsDBNull(dr["ConfigName"]))
                    objsysConfigDO.ConfigName = Convert.ToString(dr["ConfigName"]);
                if (!Convert.IsDBNull(dr["ConfigValue"]))
                    objsysConfigDO.ConfigValue = Convert.ToString(dr["ConfigValue"]);
                if (!Convert.IsDBNull(dr["IsActive"]))
                    objsysConfigDO.IsActive = Convert.ToBoolean(dr["IsActive"]);

            }
            return objsysConfigDO;
        }

        public ArrayList SelectAll1()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spsysConfig_GetAll";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrsysConfigDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    sysConfigDO objsysConfigDO = new sysConfigDO();
                    if (!Convert.IsDBNull(dr["ConfigID"]))
                        objsysConfigDO.ConfigID = Convert.ToInt32(dr["ConfigID"]);
                    if (!Convert.IsDBNull(dr["ConfigName"]))
                        objsysConfigDO.ConfigName = Convert.ToString(dr["ConfigName"]);
                    if (!Convert.IsDBNull(dr["ConfigValue"]))
                        objsysConfigDO.ConfigValue = Convert.ToString(dr["ConfigValue"]);
                    if (!Convert.IsDBNull(dr["IsActive"]))
                        objsysConfigDO.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    arrsysConfigDO.Add(objsysConfigDO);
                }
            }
            return arrsysConfigDO;
        }

        public DataTable SelectAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spsysConfig_GetAll";

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
