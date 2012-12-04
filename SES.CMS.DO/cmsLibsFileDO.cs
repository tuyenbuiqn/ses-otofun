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
   public class cmsLibsFileDO
    {

        /// <summary>
        /// Summary description for cmsLibsFileDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string FILEID_FIELD ="FileID";
		public const string FILEURL_FIELD ="FileUrl";
		public const string TITLE_FIELD ="Title";
		public const string DESCRIPTION_FIELD ="Description";
		public const string FILEEXTENSION_FIELD ="FileExtension";
		public const string USERCREATE_FIELD ="UserCreate";
		public const string CATEGORYID_FIELD ="CategoryID";

		#endregion
		
		#region Private Variables
					private Int32 _FileID;
		private String _FileUrl;
		private String _Title;
		private String _Description;
		private String _FileExtension;
		private Int32 _UserCreate;
		private Int32 _CategoryID;

		#endregion

		#region Public Properties
					public Int32 FileID
		{
			get
			{
				return _FileID;
			}
			set
			{
				_FileID = value;
			}
		}
		public String FileUrl
		{
			get
			{
				return _FileUrl;
			}
			set
			{
				_FileUrl = value;
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
		public String FileExtension
		{
			get
			{
				return _FileExtension;
			}
			set
			{
				_FileExtension = value;
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
