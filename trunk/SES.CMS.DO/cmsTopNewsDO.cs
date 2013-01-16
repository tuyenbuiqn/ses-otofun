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
   public class cmsTopNewsDO
    {

        /// <summary>
        /// Summary description for cmsTopNewsDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string TOPNEWS_FIELD ="TopNews";
		public const string ARTICLEID_FIELD ="ArticleID";
		public const string ORDERID_FIELD ="OrderID";
		public const string DATECREATE_FIELD ="DateCreate";
		public const string USERCREATE_FIELD ="UserCreate";

		#endregion
		
		#region Private Variables
					private Int32 _TopNews;
		private Int32 _ArticleID;
		private Int32 _OrderID;
		private DateTime _DateCreate;
		private Int32 _UserCreate;

		#endregion

		#region Public Properties
					public Int32 TopNews
		{
			get
			{
				return _TopNews;
			}
			set
			{
				_TopNews = value;
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
		public DateTime DateCreate
		{
			get
			{
				return _DateCreate;
			}
			set
			{
				_DateCreate = value;
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

        #endregion

	}
}
