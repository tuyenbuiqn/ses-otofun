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
/// Summary description for cmsCommentDAL
/// </summary>
namespace SES.CMS.DAL
{

    public class cmsCommentDAL : BaseDAL
    {
        #region Private Variables

        #endregion

        #region Public Constructors
        public cmsCommentDAL()
        {
            //
            // TODO: Add constructor logic here
            //

        }
        #endregion



        #region Public Methods
        public int Insert(cmsCommentDO objcmsCommentDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsComment_Insert";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@Contents", SqlDbType.NText);
            Sqlparam.Value = objcmsCommentDO.Contents;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            Sqlparam.Value = objcmsCommentDO.CreateDate;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Name", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsCommentDO.Name;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Email", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsCommentDO.Email;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@VoteUp", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.VoteUp;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@VoteDown", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.VoteDown;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsAccepted", SqlDbType.Bit);
            Sqlparam.Value = objcmsCommentDO.IsAccepted;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserXetDuyet", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.UserXetDuyet;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.ArticleID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IP", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsCommentDO.IP;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsCommentDO.Title;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ReplyCommentID", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.ReplyCommentID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);


            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ID"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ID"].Value);

            return result;
        }

        public int Update(cmsCommentDO objcmsCommentDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsComment_UpdateByPK";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@CommentID", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.CommentID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Contents", SqlDbType.NText);
            Sqlparam.Value = objcmsCommentDO.Contents;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            Sqlparam.Value = objcmsCommentDO.CreateDate;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Name", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsCommentDO.Name;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Email", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsCommentDO.Email;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@VoteUp", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.VoteUp;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@VoteDown", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.VoteDown;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsAccepted", SqlDbType.Bit);
            Sqlparam.Value = objcmsCommentDO.IsAccepted;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserXetDuyet", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.UserXetDuyet;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.ArticleID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IP", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsCommentDO.IP;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@Title", SqlDbType.NVarChar);
            Sqlparam.Value = objcmsCommentDO.Title;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ReplyCommentID", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.ReplyCommentID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ErrorCode", SqlDbType.Int);
            Sqlparam.Direction = ParameterDirection.ReturnValue;
            Sqlcomm.Parameters.Add(Sqlparam);

            int result = base.ExecuteNoneQuery(Sqlcomm);

            if (!Convert.IsDBNull(Sqlcomm.Parameters["@ErrorCode"]))
                result = Convert.ToInt32(Sqlcomm.Parameters["@ErrorCode"].Value);

            return result;


        }

        public int Delete(cmsCommentDO objcmsCommentDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsComment_DeleteByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@CommentID", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.CommentID;
            Sqlcomm.Parameters.Add(Sqlparam);



            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public int DeleteAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsComment_DeleteAll";

            int result = base.ExecuteNoneQuery(Sqlcomm);
            return result;
        }

        public cmsCommentDO Select(cmsCommentDO objcmsCommentDO)
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsComment_GetByPK";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@CommentID", SqlDbType.Int);
            Sqlparam.Value = objcmsCommentDO.CommentID;
            Sqlcomm.Parameters.Add(Sqlparam);



            DataSet ds = base.GetDataSet(Sqlcomm);
            DataRow dr = null;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if (!Convert.IsDBNull(dr["CommentID"]))
                    objcmsCommentDO.CommentID = Convert.ToInt32(dr["CommentID"]);
                if (!Convert.IsDBNull(dr["Contents"]))
                    objcmsCommentDO.Contents = Convert.ToString(dr["Contents"]);
                if (!Convert.IsDBNull(dr["CreateDate"]))
                    objcmsCommentDO.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                if (!Convert.IsDBNull(dr["Name"]))
                    objcmsCommentDO.Name = Convert.ToString(dr["Name"]);
                if (!Convert.IsDBNull(dr["Email"]))
                    objcmsCommentDO.Email = Convert.ToString(dr["Email"]);
                if (!Convert.IsDBNull(dr["VoteUp"]))
                    objcmsCommentDO.VoteUp = Convert.ToInt32(dr["VoteUp"]);
                if (!Convert.IsDBNull(dr["VoteDown"]))
                    objcmsCommentDO.VoteDown = Convert.ToInt32(dr["VoteDown"]);
                if (!Convert.IsDBNull(dr["IsAccepted"]))
                    objcmsCommentDO.IsAccepted = Convert.ToBoolean(dr["IsAccepted"]);
                if (!Convert.IsDBNull(dr["UserXetDuyet"]))
                    objcmsCommentDO.UserXetDuyet = Convert.ToInt32(dr["UserXetDuyet"]);
                if (!Convert.IsDBNull(dr["ArticleID"]))
                    objcmsCommentDO.ArticleID = Convert.ToInt32(dr["ArticleID"]);
                if (!Convert.IsDBNull(dr["IP"]))
                    objcmsCommentDO.IP = Convert.ToString(dr["IP"]);
                if (!Convert.IsDBNull(dr["Title"]))
                    objcmsCommentDO.Title = Convert.ToString(dr["Title"]);
                if (!Convert.IsDBNull(dr["ReplyCommentID"]))
                    objcmsCommentDO.ReplyCommentID = Convert.ToInt32(dr["ReplyCommentID"]);

            }
            return objcmsCommentDO;
        }

        public ArrayList SelectAll1()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsComment_GetAll";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;
            ArrayList arrcmsCommentDO = new ArrayList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    cmsCommentDO objcmsCommentDO = new cmsCommentDO();
                    if (!Convert.IsDBNull(dr["CommentID"]))
                        objcmsCommentDO.CommentID = Convert.ToInt32(dr["CommentID"]);
                    if (!Convert.IsDBNull(dr["Contents"]))
                        objcmsCommentDO.Contents = Convert.ToString(dr["Contents"]);
                    if (!Convert.IsDBNull(dr["CreateDate"]))
                        objcmsCommentDO.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                    if (!Convert.IsDBNull(dr["Name"]))
                        objcmsCommentDO.Name = Convert.ToString(dr["Name"]);
                    if (!Convert.IsDBNull(dr["Email"]))
                        objcmsCommentDO.Email = Convert.ToString(dr["Email"]);
                    if (!Convert.IsDBNull(dr["VoteUp"]))
                        objcmsCommentDO.VoteUp = Convert.ToInt32(dr["VoteUp"]);
                    if (!Convert.IsDBNull(dr["VoteDown"]))
                        objcmsCommentDO.VoteDown = Convert.ToInt32(dr["VoteDown"]);
                    if (!Convert.IsDBNull(dr["IsAccepted"]))
                        objcmsCommentDO.IsAccepted = Convert.ToBoolean(dr["IsAccepted"]);
                    if (!Convert.IsDBNull(dr["UserXetDuyet"]))
                        objcmsCommentDO.UserXetDuyet = Convert.ToInt32(dr["UserXetDuyet"]);
                    if (!Convert.IsDBNull(dr["ArticleID"]))
                        objcmsCommentDO.ArticleID = Convert.ToInt32(dr["ArticleID"]);
                    if (!Convert.IsDBNull(dr["IP"]))
                        objcmsCommentDO.IP = Convert.ToString(dr["IP"]);
                    if (!Convert.IsDBNull(dr["Title"]))
                        objcmsCommentDO.Title = Convert.ToString(dr["Title"]);
                    if (!Convert.IsDBNull(dr["ReplyCommentID"]))
                        objcmsCommentDO.ReplyCommentID = Convert.ToInt32(dr["ReplyCommentID"]);
                    arrcmsCommentDO.Add(objcmsCommentDO);
                }
            }
            return arrcmsCommentDO;
        }

        public DataTable SelectAll()
        {

            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsComment_GetAll";

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }


        #endregion

        public DataTable SelectByArt(int ArtID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsComment_GetByArtID";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@ID", SqlDbType.Int);
            Sqlparam.Value = ArtID;
            Sqlcomm.Parameters.Add(Sqlparam);

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
        public DataTable SelectByArticle(int articleID, int replyCommentID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsComment_GetByArticleID";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@ArticleID", SqlDbType.Int);
            Sqlparam.Value = articleID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@ReplyCommentID", SqlDbType.Int);
            Sqlparam.Value = replyCommentID;
            Sqlcomm.Parameters.Add(Sqlparam);

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }
        public DataTable SelectByPermission(int userType, int bienTapVienID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsComment_GetByPermisson";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@UserType", SqlDbType.Int);
            Sqlparam.Value = userType;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@BienTapVienID", SqlDbType.Int);
            Sqlparam.Value = bienTapVienID;
            Sqlcomm.Parameters.Add(Sqlparam);

            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }

        public DataTable CommentXetDuyet_Filter(int articleID, int isAccepted, int userID, int userType, int bienTapVienID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsComment_XetDuyetFilter";
            SqlParameter Sqlparam;

            Sqlparam = new SqlParameter("@articleID", SqlDbType.Int);
            Sqlparam.Value = articleID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@isAccepted", SqlDbType.Int);
            Sqlparam.Value = isAccepted;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@userID", SqlDbType.Int);
            Sqlparam.Value = userID;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@UserType", SqlDbType.Int);
            Sqlparam.Value = userType;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@BienTapVienID", SqlDbType.Int);
            Sqlparam.Value = bienTapVienID;
            Sqlcomm.Parameters.Add(Sqlparam);


            DataSet ds = base.GetDataSet(Sqlcomm);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }

        public void XetDuyetNhieuBinhLuan(string commentIDList, bool isAccepted, int userID)
        {
            SqlCommand Sqlcomm = new SqlCommand();
            Sqlcomm.CommandType = CommandType.StoredProcedure;
            Sqlcomm.CommandText = "spcmsComment_DuyetBaiViet";
            SqlParameter Sqlparam;


            Sqlparam = new SqlParameter("@CommentIDList", SqlDbType.NVarChar);
            Sqlparam.Value = commentIDList;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@IsAccepted", SqlDbType.Bit);
            Sqlparam.Value = isAccepted;
            Sqlcomm.Parameters.Add(Sqlparam);

            Sqlparam = new SqlParameter("@userID", SqlDbType.Int);
            Sqlparam.Value = userID;
            Sqlcomm.Parameters.Add(Sqlparam);

            base.ExecuteNoneQuery(Sqlcomm);
        }
    }

}
