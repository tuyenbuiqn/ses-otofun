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
/// Summary description for cmsCategoryDAL
/// </summary>
namespace SES.CMS.DAL
{

    public class cmsCategoryDAL : BaseDAL
    {
        #region Private Variables

        #endregion

        #region Public Constructors
        public cmsCategoryDAL()
        {
            //
            // TODO: Add constructor logic here
            //

        }
        #endregion



        #region Public Methods
        public int Insert(cmsCategoryDO objcmsCategoryDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsCategory_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsCategoryDO.Title;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Description", SqlDbType.NText);
            Sqlparam.Value = objcmsCategoryDO.Description;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
            Sqlparam.Value = objcmsCategoryDO.OrderID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsPublish", SqlDbType.Bit);
            Sqlparam.Value = objcmsCategoryDO.IsPublish;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsHompage", SqlDbType.Bit);
            Sqlparam.Value = objcmsCategoryDO.IsHompage;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserCreate", SqlDbType.Int);
            Sqlparam.Value = objcmsCategoryDO.UserCreate;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            Sqlparam.Value = objcmsCategoryDO.CreateDate;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@CategoryTypeID", SqlDbType.Int);
            Sqlparam.Value = objcmsCategoryDO.CategoryTypeID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ParentID", SqlDbType.Int);
            Sqlparam.Value = objcmsCategoryDO.ParentID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsContent", SqlDbType.Bit);
            Sqlparam.Value = objcmsCategoryDO.IsContent;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsMenu", SqlDbType.Bit);
            Sqlparam.Value = objcmsCategoryDO.IsMenu;
            Sqlcomm.Parameters.Add(Sqlparam);



            Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);


            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsCategoryDO objcmsCategoryDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsCategory_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
            Sqlparam.Value = objcmsCategoryDO.CategoryID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsCategoryDO.Title;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Description", SqlDbType.NText);
            Sqlparam.Value = objcmsCategoryDO.Description;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@OrderID", SqlDbType.Int);
            Sqlparam.Value = objcmsCategoryDO.OrderID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsPublish", SqlDbType.Bit);
            Sqlparam.Value = objcmsCategoryDO.IsPublish;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsHompage", SqlDbType.Bit);
            Sqlparam.Value = objcmsCategoryDO.IsHompage;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserCreate", SqlDbType.Int);
            Sqlparam.Value = objcmsCategoryDO.UserCreate;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            Sqlparam.Value = objcmsCategoryDO.CreateDate;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@CategoryTypeID", SqlDbType.Int);
            Sqlparam.Value = objcmsCategoryDO.CategoryTypeID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ParentID", SqlDbType.Int);
            Sqlparam.Value = objcmsCategoryDO.ParentID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsContent", SqlDbType.Bit);
            Sqlparam.Value = objcmsCategoryDO.IsContent;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsMenu", SqlDbType.Bit);
            Sqlparam.Value = objcmsCategoryDO.IsMenu;
            Sqlcomm.Parameters.Add(Sqlparam);




            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);

            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);

            return result;


        }

        public int Delete(cmsCategoryDO objcmsCategoryDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsCategory_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
            Sqlparam.Value = objcmsCategoryDO.CategoryID;
            Sqlcomm.Parameters.Add(Sqlparam);



            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public int DeleteAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsCategory_DeleteAll";

            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsCategoryDO Select(cmsCategoryDO objcmsCategoryDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsCategory_GetByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
            Sqlparam.Value = objcmsCategoryDO.CategoryID;
            Sqlcomm.Parameters.Add(Sqlparam);



            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if (!Convert.IsDBNull(dr["CategoryID"]))
                    objcmsCategoryDO.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                if (!Convert.IsDBNull(dr["Title"]))
                    objcmsCategoryDO.Title = Convert.ToString(dr["Title"]);
                if (!Convert.IsDBNull(dr["Description"]))
                    objcmsCategoryDO.Description = Convert.ToString(dr["Description"]);
                if (!Convert.IsDBNull(dr["OrderID"]))
                    objcmsCategoryDO.OrderID = Convert.ToInt32(dr["OrderID"]);
                if (!Convert.IsDBNull(dr["IsPublish"]))
                    objcmsCategoryDO.IsPublish = Convert.ToBoolean(dr["IsPublish"]);
                if (!Convert.IsDBNull(dr["IsHompage"]))
                    objcmsCategoryDO.IsHompage = Convert.ToBoolean(dr["IsHompage"]);
                if (!Convert.IsDBNull(dr["UserCreate"]))
                    objcmsCategoryDO.UserCreate = Convert.ToInt32(dr["UserCreate"]);
                if (!Convert.IsDBNull(dr["CreateDate"]))
                    objcmsCategoryDO.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                if (!Convert.IsDBNull(dr["CategoryTypeID"]))
                    objcmsCategoryDO.CategoryTypeID = Convert.ToInt32(dr["CategoryTypeID"]);
                if (!Convert.IsDBNull(dr["IsContent"]))
                    objcmsCategoryDO.IsContent = Convert.ToBoolean(dr["IsContent"]);
                if (!Convert.IsDBNull(dr["IsMenu"]))
                    objcmsCategoryDO.IsMenu = Convert.ToBoolean(dr["IsMenu"]);

                if (!Convert.IsDBNull(dr["ParentID"]))
                    objcmsCategoryDO.ParentID = Convert.ToInt32(dr["ParentID"]);

            }
            return objcmsCategoryDO;
        }

        public ArrayList SelectAll1()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsCategory_GetAll";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsCategoryDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    cmsCategoryDO objcmsCategoryDO = new cmsCategoryDO();
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        objcmsCategoryDO.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                    if (!Convert.IsDBNull(dr["Title"]))
                        objcmsCategoryDO.Title = Convert.ToString(dr["Title"]);
                    if (!Convert.IsDBNull(dr["Description"]))
                        objcmsCategoryDO.Description = Convert.ToString(dr["Description"]);
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        objcmsCategoryDO.OrderID = Convert.ToInt32(dr["OrderID"]);
                    if (!Convert.IsDBNull(dr["IsPublish"]))
                        objcmsCategoryDO.IsPublish = Convert.ToBoolean(dr["IsPublish"]);
                    if (!Convert.IsDBNull(dr["IsHompage"]))
                        objcmsCategoryDO.IsHompage = Convert.ToBoolean(dr["IsHompage"]);
                    if (!Convert.IsDBNull(dr["UserCreate"]))
                        objcmsCategoryDO.UserCreate = Convert.ToInt32(dr["UserCreate"]);
                    if (!Convert.IsDBNull(dr["CreateDate"]))
                        objcmsCategoryDO.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                    if (!Convert.IsDBNull(dr["CategoryTypeID"]))
                        objcmsCategoryDO.CategoryTypeID = Convert.ToInt32(dr["CategoryTypeID"]);
                    if (!Convert.IsDBNull(dr["ParentID"]))
                        objcmsCategoryDO.ParentID = Convert.ToInt32(dr["ParentID"]);

                    if (!Convert.IsDBNull(dr["IsContent"]))
                        objcmsCategoryDO.IsContent = Convert.ToBoolean(dr["IsContent"]);
                    if (!Convert.IsDBNull(dr["IsMenu"]))
                        objcmsCategoryDO.IsMenu = Convert.ToBoolean(dr["IsMenu"]);

                    arrcmsCategoryDO.Add(objcmsCategoryDO);
                }
            }
            return arrcmsCategoryDO;
        }

        public DataTable SelectAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsCategory_GetAll";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }


        #endregion


        public DataTable SelectHomepage(int BlockNumber)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsCategory_GetByHompage";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@BlockNumber", SqlDbType.Int);
            Sqlparam.Value = BlockNumber;
            Sqlcomm.Parameters.Add(Sqlparam);


            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;

        }

        public DataTable SelectMenu(int BlockNumber)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsCategory_GetByMenu";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@BlockNumber", SqlDbType.Int);
            Sqlparam.Value = BlockNumber;
            Sqlcomm.Parameters.Add(Sqlparam);


            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;

        }

        public DataTable SelectByParent(int ParentID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsCategory_GetByParent";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@ParentID", SqlDbType.Int);
            Sqlparam.Value = ParentID;
            Sqlcomm.Parameters.Add(Sqlparam);


            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }

        public DataTable SelectOne(cmsCategoryDO objCat)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsCategory_GetByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
            Sqlparam.Value = objCat.CategoryID;
            Sqlcomm.Parameters.Add(Sqlparam);


            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }

        public DataTable SelectByType(int type)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsCategory_GetByType";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@Type", SqlDbType.Int);
            Sqlparam.Value = type;
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
