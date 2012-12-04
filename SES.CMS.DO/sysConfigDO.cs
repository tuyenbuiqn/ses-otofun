/*
  Copyright 2009 Smart Enterprise Solution Corp.
  Email: contact@ses.vn - Website: http://www.ses.vn
  KimNgan Project.
*/
using System;
using System.Collections;

namespace SES.CMS.DO
{
    [Serializable]
    public class sysConfigDO
    {

        /// <summary>
        /// Summary description for sysConfigDO
        /// </summary>


        #region Public Constants (Fields name)
        public const string CONFIGID_FIELD = "ConfigID";
        public const string CONFIGNAME_FIELD = "ConfigName";
        public const string CONFIGVALUE_FIELD = "ConfigValue";
        public const string ISACTIVE_FIELD = "IsActive";

        #endregion

        #region Private Variables
        private Int32 _ConfigID;
        private String _ConfigName;
        private String _ConfigValue;
        private Boolean _IsActive;

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
        public String ConfigName
        {
            get
            {
                return _ConfigName;
            }
            set
            {
                _ConfigName = value;
            }
        }
        public String ConfigValue
        {
            get
            {
                return _ConfigValue;
            }
            set
            {
                _ConfigValue = value;
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

        #endregion

    }
}
