using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Configuration;
using KitchenOnMyPlate.DataAccess;

namespace KitchenOnMyPlate.Masters
{
    public partial class CMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER"] != null)
            {
                divNoLogin.Visible = false;
                divLoggedLogin.Visible = true;
                if (((User)Session["USER"]).UserType != "N") // If not admin
                {
                    Session.Remove("USER");
                    divNoLogin.Visible = true;
                    divLoggedLogin.Visible = false;
                }
            }
            else
            {
                divNoLogin.Visible = true;
                divLoggedLogin.Visible = false;
            }


            
        }

        protected void logOut_Click(object sender, EventArgs e)
        {
            Session.Remove("USER");
            //Komp
            //divLogin.Visible = true;
            //divLogout.Visible = false;

            if (Request.Cookies["USERMART"] != null)
            {
                HttpCookie myCookie = new HttpCookie("USERMART");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }


            Response.Redirect("CMS.aspx");
        }

        protected void btnAdvance_Click(object sender, EventArgs e)
        {
            DateTime serverTime = DateTime.Now;
            DateTime utcTime = serverTime.ToUniversalTime();
            // convert it to Utc using timezone setting of server computer
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

            string date = localTime.ToString("ddMMyy");
            string dd = (Convert.ToInt32(date.ToString().Substring(0, 2)) * 2).ToString().PadLeft(2,'0');
            string mm = (Convert.ToInt32(date.ToString().Substring(2, 2)) * 2).ToString().PadLeft(2,'0');
            string yy = (Convert.ToInt32(date.ToString().Substring(4, 2)) * 2).ToString().PadLeft(2,'0');

            string paymentLink = "http://www.kitchenonmyplate.com/Default.aspx?OFT=" + dd+mm+yy;

            #region Send Mail

            string content = string.Empty;

            string filepath = "~/Email/Post.htm";
            //New user
            StringBuilder sbContent = new StringBuilder();
            StreamReader rdr = new StreamReader(HttpContext.Current.Server.MapPath(filepath));
            string strLine = "";
            while (strLine != null)
            {
                strLine = rdr.ReadLine();
                if ((strLine != null) && (strLine != ""))
                {
                    sbContent.Append("\n" + strLine);
                }
            }
            rdr.Close();

            string site = ConfigurationManager.AppSettings["SiteName"].ToString();
            content = sbContent.ToString();
            //content = content.Replace("$REQ$", PostType);
            //content = content.Replace("$ID$", ID);
            var sbOff = new StringBuilder();
            //divOff.RenderControl(new HtmlTextWriter(new StringWriter(sbOff)));
            content = content.Replace("$ORDERSUMMARY$", "Click on below link to place your order!");


            var sb = new StringBuilder();
            //divFinal.RenderControl(new HtmlTextWriter(new StringWriter(sb)));
            content = content.Replace("$REQ$", "<a href='" + paymentLink + "' >Order Now</a><br/><br/>Link will work only for today");
            content = content.Replace("$NAME$", "Dear Sir/Madam");
            content = content.Replace("$SITE$", site);
            content = content.Replace("RobotoBlack", "Arial");
            content = content.Replace("Roboto", "Arial");
            content = content.Replace("RobotoBold", "Arial");
            content = content.Replace("images/rs3.png", "http://www.kitchenonmyplate.com/images/rs3.png");
            content = content.Replace("class", "style");
            content = content.Replace("page-titleSmallCust", "color:#4b220c; text-transform:uppercase; font-family:'Arial'; font-weight:bold;border-bottom:1px solid #c8c6c6; padding:10px 0 10px 25px ; font-size:25px; margin-top:0px;background:#EEEEEE !important;");
            content = content.Replace("OrderBox", "display:none");
            content = content.Replace("ProcessBox", "width:100%;height:auto;border:1px solid #c8c6c6;padding-bottom:10px;");
            content = content.Replace("ProcesBoxInner", "height:auto; padding:0px 25px 10px 10px;text-align: justify; text-justify: inter-word;");
            content = content.Replace("tbl", "width:100%;height:auto;border:1px solid #c8c6c6;");
            content = content.Replace("divRowHeader", "font-weight:bold; color:Black; font-size:0.85em;");
            content = content.Replace("<table", "<table style='border-collapse:collapse; border-spacing:0;' ");
            content = content.Replace("price", "font-weight:700; font-size:1.2em; color: #006400;");
            content = content.Replace("priceTotaltxt", "font-weight:700; font-size:24px; color: #006400;");
            content = content.Replace("priceTotal", "font-size:30px; color: #006400; padding-right:25px;");
            content = content.Replace("CUSTBOX", "");
            content = content.Replace("emailH5", "font-size:14px;");
            content = content.Replace("<i style='fa fa-inr'></i>", "Rs. ");

            content = content.Replace(">01<", "");
            content = content.Replace(">03<", "");

            if (!string.IsNullOrEmpty(txtEmailAdv.Value)) //Note : last name is as emailid
            {
                MailHelper.SendMailMessage("", txtEmailAdv.Value, string.Empty, string.Empty, "KOMP : Confirm your order", content);
                AutoServices.SendeMailToUs("Copy:KOMP : KOMP : Confirm your order", content);

            }

            txtEmailAdv.Value = "";
            #endregion
        }
    }
}