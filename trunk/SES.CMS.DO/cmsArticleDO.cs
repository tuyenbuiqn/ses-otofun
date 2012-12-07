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
   public class cmsArticleDO
    {

        /// <summary>
        /// Summary description for cmsArticleDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string ARTICLEID_FIELD ="ArticleID";
		public const string TITLE_FIELD ="Title";
		public const string CATEGORYID_FIELD ="CategoryID";
		public const string IMAGEURL_FIELD ="ImageUrl";
		public const string DESCRIPTION_FIELD ="Description";
		public const string ARTICLEDETAIL_FIELD ="ArticleDetail";
		public const string TAGS_FIELD ="Tags";
		public const string ISPUBLISH_FIELD ="IsPublish";
		public const string ORDERID_FIELD ="OrderID";
		public const string ISHOMPAGE_FIELD ="IsHompage";
		public const string USERCREATE_FIELD ="UserCreate";
		public const string CREATEDATE_FIELD ="CreateDate";
		public const string ISMOSTREAD_FIELD ="IsMostRead";
		public const string ISHIGHLIGHT_FIELD ="IsHighLight";
		public const string ISHOTEVENT_FIELD ="IsHotEvent";
		public const string ISEVENT_FIELD ="IsEvent";
		public const string ISNEW_FIELD ="IsNew";
		public const string EVENTID_FIELD ="EventID";
		public const string ISACCEPTED_FIELD ="IsAccepted";
		public const string USERXETDUYET_FIELD ="UserXetDuyet";

		#endregion
		
		#region Private Variables
					private Int32 _ArticleID;
		private String _Title;
		private Int32 _CategoryID;
		private String _ImageUrl;
		private String _Description;
		private String _ArticleDetail;
		private String _Tags;
		private Boolean _IsPublish;
		private Int32 _OrderID;
		private Boolean _IsHompage;
		private Int32 _UserCreate;
		private DateTime _CreateDate;
		private Boolean _IsMostRead;
		private Boolean _IsHighLight;
		private Boolean _IsHotEvent;
		private Boolean _IsEvent;
		private Boolean _IsNew;
		private Int32 _EventID;
		private Boolean _IsAccepted;
		private Int32 _UserXetDuyet;

		#endregion

		#region Public Properties
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
		public String Title
		{
			get
			{
				return _Title;
			}
			set
			{
				_Title = value;
			}
		}
		public Int32 CategoryID
		{
			get
			{
				return _CategoryID;
			}
			set
			{
				_CategoryID = value;
			}
		}
		public String ImageUrl
		{
			get
			{
				return _ImageUrl;
			}
			set
			{
				_ImageUrl = value;
			}
		}
		public String Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description = value;
			}
		}
		public String ArticleDetail
		{
			get
			{
				return _ArticleDetail;
			}
			set
			{
				_ArticleDetail = value;
			}
		}
		public String Tags
		{
			get
			{
				return _Tags;
			}
			set
			{
				_Tags = value;
			}
		}
		public Boolean IsPublish
		{
			get
			{
				return _IsPublish;
			}
			set
			{
				_IsPublish = value;
			}
		}
		public Int32 OrderID
		{
			get
			{
				return _OrderID;
			}
			set
			{
				_OrderID = value;
			}
		}
		public Boolean IsHompage
		{
			get
			{
				return _IsHompage;
			}
			set
			{
				_IsHompage = value;
			}
		}
		public Int32 UserCreate
		{
			get
			{
				return _UserCreate;
			}
			set
			{
				_UserCreate = value;
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
		public Boolean IsMostRead
		{
			get
			{
				return _IsMostRead;
			}
			set
			{
				_IsMostRead = value;
			}
		}
		public Boolean IsHighLight
		{
			get
			{
				return _IsHighLight;
			}
			set
			{
				_IsHighLight = value;
			}
		}
		public Boolean IsHotEvent
		{
			get
			{
				return _IsHotEvent;
			}
			set
			{
				_IsHotEvent = value;
			}
		}
		public Boolean IsEvent
		{
			get
			{
				return _IsEvent;
			}
			set
			{
				_IsEvent = value;
			}
		}
		public Boolean IsNew
		{
			get
			{
				return _IsNew;
			}
			set
			{
				_IsNew = value;
			}
		}
		public Int32 EventID
		{
			get
			{
				return _EventID;
			}
			set
			{
				_EventID = value;
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

        #endregion

	}
}
