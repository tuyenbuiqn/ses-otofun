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

    public class cmsArticleDAL : BaseDAL
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
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_Insert";
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

            Sqlparam = new SqlParameter("@IsMostRead", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsMostRead;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsHighLight", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsHighLight;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsHotEvent", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsHotEvent;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsEvent", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsEvent;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsNew", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsNew;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@EventID", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.EventID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsAccepted", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsAccepted;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserXetDuyet", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.UserXetDuyet;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsHot", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsHot;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ThoiGianGui", SqlDbType.DateTime);
            Sqlparam.Value = objcmsArticleDO.ThoiGianGui;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@BienTapVienID", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.BienTapVienID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ThoiGianGuiXuatBan", SqlDbType.DateTime);
            Sqlparam.Value = objcmsArticleDO.ThoiGianGuiXuatBan;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ThuKyID", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.ThuKyID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ThoiGianXuatBan", SqlDbType.DateTime);
            Sqlparam.Value = objcmsArticleDO.ThoiGianXuatBan;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@BTVEdit", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.BTVEdit;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ThuKyEdit", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.ThuKyEdit;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@DangBienTap", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.DangBienTap;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@SlideID", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.SlideID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@TrangThai", SqlDbType.SmallInt);
            Sqlparam.Value = objcmsArticleDO.TrangThai;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@LuotView", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.LuotView;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@TinLienQuan1", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsArticleDO.TinLienQuan1;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@TinLienQuan2", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsArticleDO.TinLienQuan2;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);


            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsArticleDO objcmsArticleDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_UpdateByPK";
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

            Sqlparam = new SqlParameter("@IsMostRead", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsMostRead;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsHighLight", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsHighLight;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsHotEvent", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsHotEvent;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsEvent", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsEvent;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsNew", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsNew;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@EventID", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.EventID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsAccepted", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsAccepted;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserXetDuyet", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.UserXetDuyet;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsHot", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.IsHot;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ThoiGianGui", SqlDbType.DateTime);
            Sqlparam.Value = objcmsArticleDO.ThoiGianGui;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@BienTapVienID", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.BienTapVienID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ThoiGianGuiXuatBan", SqlDbType.DateTime);
            Sqlparam.Value = objcmsArticleDO.ThoiGianGuiXuatBan;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ThuKyID", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.ThuKyID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ThoiGianXuatBan", SqlDbType.DateTime);
            Sqlparam.Value = objcmsArticleDO.ThoiGianXuatBan;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@BTVEdit", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.BTVEdit;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ThuKyEdit", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.ThuKyEdit;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@DangBienTap", SqlDbType.Bit);
            Sqlparam.Value = objcmsArticleDO.DangBienTap;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@SlideID", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.SlideID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@TrangThai", SqlDbType.SmallInt);
            Sqlparam.Value = objcmsArticleDO.TrangThai;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@LuotView", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.LuotView;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@TinLienQuan1", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsArticleDO.TinLienQuan1;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@TinLienQuan2", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsArticleDO.TinLienQuan2;
            Sqlcomm.Parameters.Add(Sqlparam);



            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);

            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);

            return result;


        }

        public int Delete(cmsArticleDO objcmsArticleDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.ArticleID;
            Sqlcomm.Parameters.Add(Sqlparam);



            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public int DeleteAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_DeleteAll";

            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsArticleDO Select(cmsArticleDO objcmsArticleDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
            Sqlparam.Value = objcmsArticleDO.ArticleID;
            Sqlcomm.Parameters.Add(Sqlparam);



            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if (!Convert.IsDBNull(dr["ArticleID"]))
                    objcmsArticleDO.ArticleID = Convert.ToInt32(dr["ArticleID"]);
                if (!Convert.IsDBNull(dr["Title"]))
                    objcmsArticleDO.Title = Convert.ToString(dr["Title"]);
                if (!Convert.IsDBNull(dr["CategoryID"]))
                    objcmsArticleDO.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                if (!Convert.IsDBNull(dr["ImageUrl"]))
                    objcmsArticleDO.ImageUrl = Convert.ToString(dr["ImageUrl"]);
                if (!Convert.IsDBNull(dr["Description"]))
                    objcmsArticleDO.Description = Convert.ToString(dr["Description"]);
                if (!Convert.IsDBNull(dr["ArticleDetail"]))
                    objcmsArticleDO.ArticleDetail = Convert.ToString(dr["ArticleDetail"]);
                if (!Convert.IsDBNull(dr["Tags"]))
                    objcmsArticleDO.Tags = Convert.ToString(dr["Tags"]);
                if (!Convert.IsDBNull(dr["IsPublish"]))
                    objcmsArticleDO.IsPublish = Convert.ToBoolean(dr["IsPublish"]);
                if (!Convert.IsDBNull(dr["OrderID"]))
                    objcmsArticleDO.OrderID = Convert.ToInt32(dr["OrderID"]);
                if (!Convert.IsDBNull(dr["IsHompage"]))
                    objcmsArticleDO.IsHompage = Convert.ToBoolean(dr["IsHompage"]);
                if (!Convert.IsDBNull(dr["UserCreate"]))
                    objcmsArticleDO.UserCreate = Convert.ToInt32(dr["UserCreate"]);
                if (!Convert.IsDBNull(dr["CreateDate"]))
                    objcmsArticleDO.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                if (!Convert.IsDBNull(dr["IsMostRead"]))
                    objcmsArticleDO.IsMostRead = Convert.ToBoolean(dr["IsMostRead"]);
                if (!Convert.IsDBNull(dr["IsHighLight"]))
                    objcmsArticleDO.IsHighLight = Convert.ToBoolean(dr["IsHighLight"]);
                if (!Convert.IsDBNull(dr["IsHotEvent"]))
                    objcmsArticleDO.IsHotEvent = Convert.ToBoolean(dr["IsHotEvent"]);
                if (!Convert.IsDBNull(dr["IsEvent"]))
                    objcmsArticleDO.IsEvent = Convert.ToBoolean(dr["IsEvent"]);
                if (!Convert.IsDBNull(dr["IsNew"]))
                    objcmsArticleDO.IsNew = Convert.ToBoolean(dr["IsNew"]);
                if (!Convert.IsDBNull(dr["EventID"]))
                    objcmsArticleDO.EventID = Convert.ToInt32(dr["EventID"]);
                if (!Convert.IsDBNull(dr["IsAccepted"]))
                    objcmsArticleDO.IsAccepted = Convert.ToBoolean(dr["IsAccepted"]);
                if (!Convert.IsDBNull(dr["UserXetDuyet"]))
                    objcmsArticleDO.UserXetDuyet = Convert.ToInt32(dr["UserXetDuyet"]);
                if (!Convert.IsDBNull(dr["IsHot"]))
                    objcmsArticleDO.IsHot = Convert.ToBoolean(dr["IsHot"]);


            }
            return objcmsArticleDO;
        }

        public ArrayList SelectAll1()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetAll";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsArticleDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    cmsArticleDO objcmsArticleDO = new cmsArticleDO();
                    if (!Convert.IsDBNull(dr["ArticleID"]))
                        objcmsArticleDO.ArticleID = Convert.ToInt32(dr["ArticleID"]);
                    if (!Convert.IsDBNull(dr["Title"]))
                        objcmsArticleDO.Title = Convert.ToString(dr["Title"]);
                    if (!Convert.IsDBNull(dr["CategoryID"]))
                        objcmsArticleDO.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                    if (!Convert.IsDBNull(dr["ImageUrl"]))
                        objcmsArticleDO.ImageUrl = Convert.ToString(dr["ImageUrl"]);
                    if (!Convert.IsDBNull(dr["Description"]))
                        objcmsArticleDO.Description = Convert.ToString(dr["Description"]);
                    if (!Convert.IsDBNull(dr["ArticleDetail"]))
                        objcmsArticleDO.ArticleDetail = Convert.ToString(dr["ArticleDetail"]);
                    if (!Convert.IsDBNull(dr["Tags"]))
                        objcmsArticleDO.Tags = Convert.ToString(dr["Tags"]);
                    if (!Convert.IsDBNull(dr["IsPublish"]))
                        objcmsArticleDO.IsPublish = Convert.ToBoolean(dr["IsPublish"]);
                    if (!Convert.IsDBNull(dr["OrderID"]))
                        objcmsArticleDO.OrderID = Convert.ToInt32(dr["OrderID"]);
                    if (!Convert.IsDBNull(dr["IsHompage"]))
                        objcmsArticleDO.IsHompage = Convert.ToBoolean(dr["IsHompage"]);
                    if (!Convert.IsDBNull(dr["UserCreate"]))
                        objcmsArticleDO.UserCreate = Convert.ToInt32(dr["UserCreate"]);
                    if (!Convert.IsDBNull(dr["CreateDate"]))
                        objcmsArticleDO.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                    if (!Convert.IsDBNull(dr["IsMostRead"]))
                        objcmsArticleDO.IsMostRead = Convert.ToBoolean(dr["IsMostRead"]);
                    if (!Convert.IsDBNull(dr["IsHighLight"]))
                        objcmsArticleDO.IsHighLight = Convert.ToBoolean(dr["IsHighLight"]);
                    if (!Convert.IsDBNull(dr["IsHotEvent"]))
                        objcmsArticleDO.IsHotEvent = Convert.ToBoolean(dr["IsHotEvent"]);
                    if (!Convert.IsDBNull(dr["IsEvent"]))
                        objcmsArticleDO.IsEvent = Convert.ToBoolean(dr["IsEvent"]);
                    if (!Convert.IsDBNull(dr["IsNew"]))
                        objcmsArticleDO.IsNew = Convert.ToBoolean(dr["IsNew"]);
                    if (!Convert.IsDBNull(dr["EventID"]))
                        objcmsArticleDO.EventID = Convert.ToInt32(dr["EventID"]);
                    if (!Convert.IsDBNull(dr["IsAccepted"]))
                        objcmsArticleDO.IsAccepted = Convert.ToBoolean(dr["IsAccepted"]);
                    if (!Convert.IsDBNull(dr["UserXetDuyet"]))
                        objcmsArticleDO.UserXetDuyet = Convert.ToInt32(dr["UserXetDuyet"]);
                    if (!Convert.IsDBNull(dr["IsHot"]))
                        objcmsArticleDO.IsHot = Convert.ToBoolean(dr["IsHot"]);
                    arrcmsArticleDO.Add(objcmsArticleDO);
                }
            }
            return arrcmsArticleDO;
        }

        public DataTable SelectAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetAll";

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
        public void XetDuyetNhieuBaiViet(string articleIDList, bool isAccepted, int userXetDuyet)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_DuyetBaiViet";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@ArticleIDList", SqlDbType.NVarChar);
            Sqlparam.Value = articleIDList;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsAccepted", SqlDbType.Bit);
            Sqlparam.Value = isAccepted;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserXetDuyet", SqlDbType.Int);
            Sqlparam.Value = userXetDuyet;
            Sqlcomm.Parameters.Add(Sqlparam);

            base.ExecuteNoneQuery(Sqlcomm);
        }
        public DataTable SelectDanhMucNoiBat(int type)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByCategoryType";
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
        public DataTable SelectByPK(int articleID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByPK";
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
        public DataTable SelectByCategoryID1(int categoryID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByCategoryID1";
            SqlParameter Sqlparam;


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
        public DataTable SelectByCategoryID2(int categoryID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByCategory2";
            SqlParameter Sqlparam;


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
        public DataTable LastestNews()
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetLastestNews";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
        public DataTable HotArticle_UnderSlideHomepage()
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByIsHot";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
        public DataTable MostRead()
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByMostRead";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
        public DataTable HotEvents(int categoryID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByIsHotEvent";

            SqlParameter Sqlparam;
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
        public DataTable SelectAllEventArticle(int eventID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByEvent";

            SqlParameter Sqlparam;
            Sqlparam = new SqlParameter("@EventID", SqlDbType.Int);
            Sqlparam.Value = eventID;
            Sqlcomm.Parameters.Add(Sqlparam);

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
        public DataTable Events()
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByIsEvent";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
        public DataTable NewArticles()
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByIsNew";

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
        public DataTable SelectByTag(string tag)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByTag";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@tag", SqlDbType.NVarChar);
            Sqlparam.Value = tag;
            Sqlcomm.Parameters.Add(Sqlparam);

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
        public DataTable GetTinLienQuan1(int articleID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetTinLienQuan1";
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

        public DataTable GetTinLienQuan2(int articleID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetTinLienQuan2";
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
        public DataTable SelectToMainHomepageCate(int top, int categoryID, bool type)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetHighLight";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@Top", SqlDbType.Int);
            Sqlparam.Value = top;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@CategoryID", SqlDbType.Int);
            Sqlparam.Value = categoryID;
            Sqlcomm.Parameters.Add(Sqlparam);

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
        public DataTable ArticleXetDuyet_Filter(int categoryID, int isAccepted, int userID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_XetDuyetFilter";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@categoryID", SqlDbType.Int);
            Sqlparam.Value = categoryID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@isAccepted", SqlDbType.Int);
            Sqlparam.Value = isAccepted;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@userID", SqlDbType.Int);
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
        public DataTable SelectByCatType(int type)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetByCatType";
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
        public DataTable SelectHomeNews(int CategoryID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsArticle_GetHomeNews";
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
    }

}
