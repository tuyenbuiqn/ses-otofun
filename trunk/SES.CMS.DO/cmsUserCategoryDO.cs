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
   public class cmsUserCategoryDO
    {

        /// <summary>
        /// Summary description for sysUserDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
		public const string USERCATEGORYID_FIELD ="UserCategoryID";
        public const string USERID_FIELD = "UserID";
		public const string CATEGORYID_FIELD ="CategoryID";
        public const string NOTE_FIELD = "Note";

		#endregion

        public int UserCategoryID { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public string Note { get; set; }

	}
}
