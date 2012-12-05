﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
namespace SES.CMS.Module
{
    public partial class ucTopRightAdv : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sysConfigBL configBL = new sysConfigBL();
            sysConfigDO objConfig = new sysConfigDO();
            objConfig.ConfigID = 3;
            ltrLienHeGuiBai.Text = configBL.Select(objConfig).ConfigValue;
            objConfig.ConfigID = 4;
            ltrLienHeQuangcao.Text = configBL.Select(objConfig).ConfigValue;
        }
    }
}