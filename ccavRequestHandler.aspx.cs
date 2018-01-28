﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCA.Util;
using KitchenOnMyPlate.Classes;


    public partial class SubmitData : System.Web.UI.Page
    {
        CCACrypto ccaCrypto = new CCACrypto();
        string workingKey = "450273C40E328E5C121E04A20281F3E7";//put in the 32bit alpha numeric key in the quotes provided here 	
        string ccaRequest = "";
        public string strEncRequest="";
        public string strAccessCode = "AVXH05CE12AQ55HXQA";// put the access key in the quotes provided here.
         protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                 //querystring requestId is calling using Make payment link
                 if (!string.IsNullOrEmpty(Request.QueryString["requestId"]))
                 {
                     //if any order having start date is equal or less than current date then now allowing to payment
                     if (!OrderManagement.AllowPayemntOnRequesteOrder(Convert.ToInt32(Request.QueryString["requestId"])))
                     {
                         Response.Write("Order is expired, Please place a new order");
                         Response.End();
                     }
                 }

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

