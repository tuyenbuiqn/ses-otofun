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
   public class cmsAdvertisementDO
    {

        /// <summary>
        /// Summary description for cmsAdvertisementDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string ADVERTISEMENTID_FIELD ="AdvertisementID";
		public const string TITLE_FIELD ="Title";
		public const string ADVDETAIL_FIELD ="AdvDetail";
		public const string POSITION_FIELD ="Position";
		public const string MODULE_FIELD ="Module";
		public const string CREATEDATE_FIELD ="CreateDate";
		public const string CREATEUSER_FIELD ="CreateUser";
		public const string ADVINFO_FIELD ="AdvInfo";
		public const string OTHERINFO_FIELD ="OtherInfo";

		#endregion
		
		#region Private Variables
					private Int32 _AdvertisementID;
		private String _Title;
		private String _AdvDetail;
		private String _Position;
		private String _Module;
		private DateTime _CreateDate;
		private int _CreateUser;
		private String _AdvInfo;
		private String _OtherInfo;

		#endregion
        public bool IsPublish { get; set; }
        public int OrderID { get; set; }
		#region Public Properties
					public Int32 AdvertisementID
		{
			get
			{
				return _AdvertisementID;
			}
			set
			{
				_AdvertisementID = value;
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
		public String AdvDetail
		{
			get
			{
				return _AdvDetail;
			}
			set
			{
				_AdvDetail = value;
			}
		}
		public String Position
		{
			get
			{
				return _Position;
			}
			set
			{
				_Position = value;
			}
		}
		public String Module
		{
			get
			{
				return _Module;
			}
			set
			{
				_Module = value;
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
		public Int32 CreateUser
		{
			get
			{
				return _CreateUser;
			}
			set
			{
				_CreateUser = value;
			}
		}
		public String AdvInfo
		{
			get
			{
				return _AdvInfo;
			}
			set
			{
				_AdvInfo = value;
			}
		}
		public String OtherInfo
		{
			get
			{
				return _OtherInfo;
			}
			set
			{
				_OtherInfo = value;
			}
		}

        #endregion

	}
}
