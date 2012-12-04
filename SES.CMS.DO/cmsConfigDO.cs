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
   public class cmsConfigDO
    {

        /// <summary>
        /// Summary description for cmsConfigDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string CONFIGID_FIELD ="ConfigID";
		public const string SITENAME_FIELD ="SiteName";
		public const string SITEDESCRIPTION_FIELD ="SiteDescription";
		public const string SITEKEYWORD_FIELD ="SiteKeyWord";
		public const string ADMINEMAIL_FIELD ="AdminEmail";
		public const string FIELD1_FIELD ="Field1";
		public const string FIELD2_FIELD ="Field2";
		public const string FIELD3_FIELD ="Field3";
		public const string FIELD4_FIELD ="Field4";
		public const string FIELD5_FIELD ="Field5";

		#endregion
		
		#region Private Variables
					private Int32 _ConfigID;
		private String _SiteName;
		private String _SiteDescription;
		private String _SiteKeyWord;
		private String _AdminEmail;
		private String _Field1;
		private String _Field2;
		private String _Field3;
		private String _Field4;
		private String _Field5;

		#endregion

		#region Public Properties
					public Int32 ConfigID
		{
			get
			{
				return _ConfigID;
			}
			set
			{
				_ConfigID = value;
			}
		}
		public String SiteName
		{
			get
			{
				return _SiteName;
			}
			set
			{
				_SiteName = value;
			}
		}
		public String SiteDescription
		{
			get
			{
				return _SiteDescription;
			}
			set
			{
				_SiteDescription = value;
			}
		}
		public String SiteKeyWord
		{
			get
			{
				return _SiteKeyWord;
			}
			set
			{
				_SiteKeyWord = value;
			}
		}
		public String AdminEmail
		{
			get
			{
				return _AdminEmail;
			}
			set
			{
				_AdminEmail = value;
			}
		}
		public String Field1
		{
			get
			{
				return _Field1;
			}
			set
			{
				_Field1 = value;
			}
		}
		public String Field2
		{
			get
			{
				return _Field2;
			}
			set
			{
				_Field2 = value;
			}
		}
		public String Field3
		{
			get
			{
				return _Field3;
			}
			set
			{
				_Field3 = value;
			}
		}
		public String Field4
		{
			get
			{
				return _Field4;
			}
			set
			{
				_Field4 = value;
			}
		}
		public String Field5
		{
			get
			{
				return _Field5;
			}
			set
			{
				_Field5 = value;
			}
		}

        #endregion

	}
}
