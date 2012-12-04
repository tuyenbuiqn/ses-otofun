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
   public class cmsLibFileArticleDO
    {

        /// <summary>
        /// Summary description for cmsLibFileArticleDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string LIBFILEARTICLEID_FIELD ="LibFileArticleID";
		public const string ARTICLEID_FIELD ="ArticleID";
		public const string FILEID_FIELD ="FileID";

		#endregion
		
		#region Private Variables
					private Int32 _LibFileArticleID;
		private Int32 _ArticleID;
		private Int32 _FileID;

		#endregion

		#region Public Properties
					public Int32 LibFileArticleID
		{
			get
			{
				return _LibFileArticleID;
			}
			set
			{
				_LibFileArticleID = value;
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

        #endregion

	}
}
