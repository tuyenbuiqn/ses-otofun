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
   public class sysUserDO
    {

        /// <summary>
        /// Summary description for sysUserDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string USERID_FIELD ="UserID";
		public const string USERNAME_FIELD ="Username";
		public const string PASSWORD_FIELD ="Password";
		public const string EMAIL_FIELD ="Email";
		public const string ADDRESS_FIELD ="Address";
		public const string USERTYPE_FIELD ="UserType";
		public const string ISACTIVE_FIELD ="IsActive";
		public const string FULLNAME_FIELD ="FullName";
		public const string YAHOOIM_FIELD ="YahooIM";
		public const string PROFILEID_FIELD ="ProfileID";

		#endregion
		
		#region Private Variables
					private Int32 _UserID;
		private String _Username;
		private String _Password;
		private String _Email;
		private String _Address;
		private Int32 _UserType;
		private Boolean _IsActive;
		private String _FullName;
		private String _YahooIM;
		private Int32 _ProfileID;

		#endregion

		#region Public Properties
					public Int32 UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				_UserID = value;
			}
		}
		public String Username
		{
			get
			{
				return _Username;
			}
			set
			{
				_Username = value;
			}
		}
		public String Password
		{
			get
			{
				return _Password;
			}
			set
			{
				_Password = value;
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
		public String Address
		{
			get
			{
				return _Address;
			}
			set
			{
				_Address = value;
			}
		}
		public Int32 UserType
		{
			get
			{
				return _UserType;
			}
			set
			{
				_UserType = value;
			}
		}
		public Boolean IsActive
		{
			get
			{
				return _IsActive;
			}
			set
			{
				_IsActive = value;
			}
		}
		public String FullName
		{
			get
			{
				return _FullName;
			}
			set
			{
				_FullName = value;
			}
		}
		public String YahooIM
		{
			get
			{
				return _YahooIM;
			}
			set
			{
				_YahooIM = value;
			}
		}
		public Int32 ProfileID
		{
			get
			{
				return _ProfileID;
			}
			set
			{
				_ProfileID = value;
			}
		}

        #endregion

	}
}
