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
   public class cmsMostReadDO
    {

        /// <summary>
        /// Summary description for cmsMostReadDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string MOSTREADID_FIELD ="MostReadID";
		public const string ARTICLEID_FIELD ="ArticleID";
		public const string CATEGORYID_FIELD ="CategoryID";
		public const string ORDERID_FIELD ="OrderID";

		#endregion
		
		#region Private Variables
					private Int32 _MostReadID;
		private Int32 _ArticleID;
		private Int32 _CategoryID;
		private Int32 _OrderID;

		#endregion

		#region Public Properties
					public Int32 MostReadID
		{
			get
			{
				return _MostReadID;
			}
			set
			{
				_MostReadID = value;
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
