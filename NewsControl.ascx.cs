using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace PeraFin
{
    public partial class NewsControl : System.Web.UI.UserControl
    {
        ResourceManager rm;
        CultureInfo ci;

        NewsControl ctrl;
        protected int pageId = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

                if (Session["lang"] != null)
                {
                    SetCulture(Session["lang"].ToString());
                }
                else
                {
                    SetCulture("en-US");
                }


            

        }

        void SetCulture(string cul)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cul);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cul);
            rm = new ResourceManager("Resources.RS1.language", System.Reflection.Assembly.Load("App_GlobalResources"));
            LoadString(Thread.CurrentThread.CurrentCulture);
        }

        private void LoadString(CultureInfo ci)
        {

            lbh.Text = rm.GetString("H3", ci);          

        }

        public string Date 
        {
            set {
                //todaysDate.ToString("dd-MMM-yyyy");
                string dateTime = Convert.ToDateTime(value).ToString("dd-MMM-yyyy") + " " + Convert.ToDateTime(value).ToShortTimeString();
                lblDate.Text = dateTime;
               //' lblDate1.Text = dateTime;
            }
        }

        public string Header
        {
            set
            {
                lblHeader.InnerHtml = value;
                //'lblHeader1.InnerHtml = value;
            }
        }

 

        public string Description
        {
            set
            {
                string newsText = value;
                if (newsText.Contains("."))
                {
                    newsText = newsText.Substring(0, newsText.IndexOf("."));
                    string AppliedText = newsText;
                    lblDescription.InnerHtml = AppliedText;
                    //'lblDescription1.InnerHtml =value;
                }
                else
                {
                    lblDescription.InnerHtml = value;
                   // 'lblDescription1.InnerHtml = value;
                }
            }
        }
    }
}