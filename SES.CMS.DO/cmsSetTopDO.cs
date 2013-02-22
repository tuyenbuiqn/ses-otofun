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
   public class cmsSetTopDO
    {

        /// <summary>
        /// Summary description for cmsSetTopDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string SETTOPID_FIELD ="SetTopID";
		public const string ARTICLEID_FIELD ="ArticleID";
		public const string CATEGORYID_FIELD ="CategoryID";
		public const string ORDERID_FIELD ="OrderID";

		#endregion
		
		#region Private Variables
					private Int32 _SetTopID;
		private Int32 _ArticleID;
		private Int32 _CategoryID;
		private Int32 _OrderID;

		#endregion

		#region Public Properties
					public Int32 SetTopID
		{
			get
			{
				return _SetTopID;
			}
			set
			{
				_SetTopID = value;
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

        #endregion

	}
}
