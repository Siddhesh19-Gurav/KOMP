﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCA.Util;


public partial class yourguyRequestHandler : System.Web.UI.Page
    {
        CCACrypto ccaCrypto = new CCACrypto();
        string workingKey = "OTMyMzYyMDAzMTp2ZW5kb3I=";//put in the 32bit alpha numeric key in the quotes provided here 	
        string ccaRequest = "";
        public string strEncRequest="";
        public string strAccessCode = "AVXH05CE12AQ55HXQA";// put the access key in the quotes provided here.
         protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ED"]))
                {
                    strEncRequest = Request.QueryString["ED"];
                }

               //foreach (string name in Request.Form)
               // {
               //     if (name != null)
               //     {
               //         if (!name.StartsWith("_"))
               //         {
               //             ccaRequest = ccaRequest + name + "=" + Request.Form[name] + "&";
               //           /* Response.Write(name + "=" + Request.Form[name]);
               //             Response.Write("</br>");*/
               //         }
               //     }
               // }
               // strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);
            }
        }
    }

