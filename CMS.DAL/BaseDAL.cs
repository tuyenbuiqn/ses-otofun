/*
  Copyright 2009 Smart Enterprise Solution Corp.
  Email: contact@ses.vn - Website: http://www.ses.vn
  KimNgan Project.
*/
using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BaseDAL
/// </summary>
namespace SES.CMS.DAL 
{
    public class BaseDAL
    {
        #region PrivateVariables
        private SqlConnection SqlConn;
        #endregion

        #region Constructor
        public BaseDAL()
        {
            //
            // TODO: Add constructor logic here
            //
            if (SqlConn == null)
            {
                SqlConn = new SqlConnection();
                SqlConn.ConnectionString =ConfigurationManager.ConnectionStrings["SqlProvider"].ConnectionString;
            }

        }
        #endregion

        #region PrivateMethods

        private void OpenSqlConnection()
        {
            if (SqlConn.State != ConnectionState.Open)
            {
                SqlConn.Open();
            }
        }


        private void CloseSqlConnection()
        {
            if (SqlConn.State == ConnectionState.Open)
            {
               SqlConn.Close();
            }
        }

        #endregion

        #region PublicMethods
        public DataSet GetDataSet(SqlCommand SqlComm)
        {
            SqlDataAdapter SqlDataAdp;
            DataSet dsData;
            try
            {
                SqlComm.Connection = SqlConn;
                SqlDataAdp = new SqlDataAdapter(SqlComm);
                dsData = new DataSet();
                SqlDataAdp.Fill(dsData);
                return dsData;



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlDataAdp = null;
                dsData = null;
            }
        }


        public int ExecuteNoneQuery(SqlCommand SqlComm)
        {
            try
            {
                OpenSqlConnection();
                SqlComm.Connection = SqlConn;
                int i = SqlComm.ExecuteNonQuery();
                return i;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseSqlConnection();
            }
        }


        public Object ExecuteScalar(SqlCommand SqlComm)
        {
            try
            {
                OpenSqlConnection();
                SqlComm.Connection = SqlConn;
                return SqlComm.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseSqlConnection();
            }
        }

        #endregion
    }
}

