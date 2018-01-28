using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mail;
using System.Net.Mail;

namespace KitchenOnMyPlate.DataAccess
{
    public class AutoServices
    {
      
        public static void SendeMailToUs(string subject, string body)
        {
            MailAddressCollection col1 = new MailAddressCollection();
            col1.Add(new MailAddress(ConfigurationManager.AppSettings["OwnerEmailID1"]));

            MailAddressCollection col= new MailAddressCollection();

            //if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["OwnerEmailID1"]))
            //{
            //    col.Add(new MailAddress(ConfigurationManager.AppSettings["OwnerEmailID1"].ToString()));
            //}

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["OwnerEmailID2"]))
            {
                col.Add(new MailAddress(ConfigurationManager.AppSettings["OwnerEmailID2"].ToString()));
            }

            //if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["OwnerEmailID3"]))
            //{
            //    col.Add(new MailAddress(ConfigurationManager.AppSettings["OwnerEmailID3"].ToString()));
            //}
            
            MailHelper.SendMailMessage("", col1, col, string.Empty, subject, body);

            //string ownerEmailId2 = ConfigurationManager.AppSettings["OwnerEmailID2"].ToString();
            //MailHelper.SendMailMessage("", ownerEmailId2, string.Empty, string.Empty, "Now total Hits:" + hits, "Hit From User:" + ipDetails);
        }

    }
    }
