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
   public class cmsCommentDO
    {

        /// <summary>
        /// Summary description for cmsCommentDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string COMMENTID_FIELD ="CommentID";
		public const string CONTENTS_FIELD ="Contents";
		public const string CREATEDATE_FIELD ="CreateDate";
		public const string NAME_FIELD ="Name";
		public const string EMAIL_FIELD ="Email";
		public const string VOTEUP_FIELD ="VoteUp";
		public const string VOTEDOWN_FIELD ="VoteDown";
		public const string ISACCEPTED_FIELD ="IsAccepted";
		public const string USERXETDUYET_FIELD ="UserXetDuyet";
		public const string ARTICLEID_FIELD ="ArticleID";

		#endregion
		
		#region Private Variables
					private Int32 _CommentID;
		private String _Contents;
		private DateTime _CreateDate;
		private String _Name;
		private String _Email;
		private Int32 _VoteUp;
		private Int32 _VoteDown;
		private Boolean _IsAccepted;
		private Int32 _UserXetDuyet;
		private Int32 _ArticleID;

		#endregion

		#region Public Properties
					public Int32 CommentID
		{
			get
			{
				return _CommentID;
			}
			set
			{
				_CommentID = value;
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
		public DateTime CreateDate
		{
			get
			{
				return _CreateDate;
			}
			set
			{
				_CreateDate = value;
			}
		}
		public String Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}
		public String Email
		{
			get
			{
				return _Email;
			}
			set
			{
				_Email = value;
			}
		}
		public Int32 VoteUp
		{
			get
			{
				return _VoteUp;
			}
			set
			{
				_VoteUp = value;
			}
		}
		public Int32 VoteDown
		{
			get
			{
				return _VoteDown;
			}
			set
			{
				_VoteDown = value;
			}
		}
		public Boolean IsAccepted
		{
			get
			{
				return _IsAccepted;
			}
			set
			{
				_IsAccepted = value;
			}
		}
		public Int32 UserXetDuyet
		{
			get
			{
				return _UserXetDuyet;
			}
			set
			{
				_UserXetDuyet = value;
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
