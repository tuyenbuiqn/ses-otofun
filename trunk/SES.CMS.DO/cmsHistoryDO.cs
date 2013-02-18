/*
  Copyright 2009 Smart Enterprise Solution Corp.
  Email: contact@ses.vn - Website: http://www.ses.vn
  KimNgan Project.
*/
using System;
using System.Collections;

namespace SES.CMS.DO
{
   [Serializable ]
   public class cmsHistoryDO
    {

        /// <summary>
        /// Summary description for cmsHistoryDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string HISTORYID_FIELD ="HistoryID";
		public const string ACTION_FIELD ="Action";
		public const string CONTENTS_FIELD ="Contents";
		public const string HISTORYTIME_FIELD ="HistoryTime";
		public const string COMMENT_FIELD ="Comment";
		public const string IP_FIELD ="IP";
		public const string USERID_FIELD ="UserID";
		public const string ARTICLEID_FIELD ="ArticleID";

		#endregion
		
		#region Private Variables
					private Int32 _HistoryID;
		private Int32 _Action;
		private String _Contents;
		private DateTime _HistoryTime;
		private String _Comment;
		private String _IP;
		private Int32 _UserID;
		private Int32 _ArticleID;

		#endregion

		#region Public Properties
					public Int32 HistoryID
		{
			get
			{
				return _HistoryID;
			}
			set
			{
				_HistoryID = value;
			}
		}
		public Int32 Action
		{
			get
			{
				return _Action;
			}
			set
			{
				_Action = value;
			}
		}
		public String Contents
		{
			get
			{
				return _Contents;
			}
			set
			{
				_Contents = value;
			}
		}
		public DateTime HistoryTime
		{
			get
			{
				return _HistoryTime;
			}
			set
			{
				_HistoryTime = value;
			}
		}
		public String Comment
		{
			get
			{
				return _Comment;
			}
			set
			{
				_Comment = value;
			}
		}
		public String IP
		{
			get
			{
				return _IP;
			}
			set
			{
				_IP = value;
			}
		}
		public Int32 UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				_UserID = value;
			}
		}
		public Int32 ArticleID
		{
			get
			{
				return _ArticleID;
			}
			set
			{
				_ArticleID = value;
			}
		}

        #endregion

	}
}
