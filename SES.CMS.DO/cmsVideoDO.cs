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
   public class cmsVideoDO
    {

        /// <summary>
        /// Summary description for cmsVideoDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string VIDEOID_FIELD ="VideoID";
		public const string TITLE_FIELD ="Title";
		public const string VIDEOURL_FIELD ="VideoUrl";
		public const string DESCRIPTION_FIELD ="Description";
		public const string ALBUMID_FIELD ="AlbumID";
		public const string CATEGORYID_FIELD ="CategoryID";
		public const string ISMOSTVIEW_FIELD ="IsMostView";
		public const string ISNEW_FIELD ="IsNew";
		public const string ORDERID_FIELD ="OrderID";
		public const string ISPUBLISH_FIELD ="IsPublish";
		public const string CREATEDATE_FIELD ="CreateDate";
		public const string ISHOMEPAGE_FIELD ="IsHomepage";
		public const string ARTICLEID_FIELD ="ArticleID";
        public const string ISACCEPTED_FIELD = "IsAccepted";
        public const string USERXETDUYET_FIELD = "UserXetDuyet";

		#endregion
		
		#region Private Variables
					private Int64 _VideoID;
		private String _Title;
		private String _VideoUrl;
		private String _Description;
		private Int32 _AlbumID;
		private Int32 _CategoryID;
		private Boolean _IsMostView;
		private Boolean _IsNew;
		private Int32 _OrderID;
		private Boolean _IsPublish;
		private DateTime _CreateDate;
		private Boolean _IsHomepage;
		private Int32 _ArticleID;
        private Boolean _IsAccepted;
        private Int32 _UserXetDuyet;

		#endregion

		#region Public Properties
					public Int64 VideoID
		{
			get
			{
				return _VideoID;
			}
			set
			{
				_VideoID = value;
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
		public String VideoUrl
		{
			get
			{
				return _VideoUrl;
			}
			set
			{
				_VideoUrl = value;
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
		public Int32 AlbumID
		{
			get
			{
				return _AlbumID;
			}
			set
			{
				_AlbumID = value;
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
		public Boolean IsMostView
		{
			get
			{
				return _IsMostView;
			}
			set
			{
				_IsMostView = value;
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
		public Boolean IsHomepage
		{
			get
			{
				return _IsHomepage;
			}
			set
			{
				_IsHomepage = value;
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
