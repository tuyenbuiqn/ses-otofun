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
   public class cmsSlideDO
    {

        /// <summary>
        /// Summary description for cmsSlideDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string SLIDEID_FIELD ="SlideID";
		public const string TITLE_FIELD ="Title";
		public const string DESCRIPTION_FIELD ="Description";
		public const string SLIDEURL_FIELD ="SlideUrl";
		public const string CATEGORYID_FIELD ="CategoryID";
		public const string ORDERID_FIELD ="OrderID";
		public const string SLIDEIMG_FIELD ="SlideImg";

		#endregion
		
		#region Private Variables
					private Int32 _SlideID;
		private String _Title;
		private String _Description;
		private String _SlideUrl;
		private Int32 _CategoryID;
		private Int32 _OrderID;
		private String _SlideImg;

		#endregion

		#region Public Properties
					public Int32 SlideID
		{
			get
			{
				return _SlideID;
			}
			set
			{
				_SlideID = value;
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
		public String SlideUrl
		{
			get
			{
				return _SlideUrl;
			}
			set
			{
				_SlideUrl = value;
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
		public String SlideImg
		{
			get
			{
				return _SlideImg;
			}
			set
			{
				_SlideImg = value;
			}
		}

        #endregion

	}
}
