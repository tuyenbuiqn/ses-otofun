﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace SES.CMS
{
    public partial class Otofun : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           

            new SES.CMS.BL.cmsArticleBL().AutoPublish();
        }
    }
}