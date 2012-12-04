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
   public class cmsAlbumDO
    {

        /// <summary>
        /// Summary description for cmsAlbumDO
        /// </summary>
		
		
		#region Public Constants (Fields name)
					public const string ALBUMID_FIELD ="AlbumID";
		public const string TITLE_FIELD ="Title";
		public const string DESCRIPTION_FIELD ="Description";
		public const string ORDERID_FIELD ="OrderID";
        public const string ALBUMIMG_FIELD = "AlbumImg";
        //public const bool TYPE_FIELD = "Type";

		#endregion
		
		#region Private Variables
					private Int32 _AlbumID;
		private String _Title;
        private String _Description;
		private Int32 _OrderID;
        private String _AlbumImg;
        private Boolean _Type;

		#endregion

		#region Public Properties
					public Int32 AlbumID
		{
			get
			{
				return _AlbumID;
			}
			set
			{
				_AlbumID = value;
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
        public String AlbumImg
        {
            get
            {
                return _AlbumImg;
            }
            set
            {
                _AlbumImg = value;
            }
        }
        public Boolean Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        #endregion

	}
}
