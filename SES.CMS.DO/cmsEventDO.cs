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
   public class cmsEventDO
    {

        /// <summary>
        /// Summary description for cmsEventDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string EVENTID_FIELD ="EventID";
		public const string TITLE_FIELD ="Title";
		public const string ISPUBLISH_FIELD ="IsPublish";
		public const string DESCRIPTION_FIELD ="Description";
		public const string ORDERID_FIELD ="OrderID";
		public const string USERCREATE_FIELD ="UserCreate";
		public const string CREATEDATE_FIELD ="CreateDate";
		public const string GHICHU_FIELD ="GhiChu";
		public const string CATEGORYID_FIELD ="CategoryID";

		#endregion
		
		#region Private Variables
					private Int64 _EventID;
		private String _Title;
		private Boolean _IsPublish;
		private String _Description;
		private Int32 _OrderID;
		private Int32 _UserCreate;
		private DateTime _CreateDate;
		private String _GhiChu;
		private Int32 _CategoryID;

		#endregion

		#region Public Properties
					public Int64 EventID
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
		public String GhiChu
		{
			get
			{
				return _GhiChu;
			}
			set
			{
				_GhiChu = value;
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

        #endregion

	}
}
