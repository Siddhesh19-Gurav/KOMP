using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.Services;
using System.Globalization;
using System.Threading;
using System.Resources;
using KitchenOnMyPlate;

namespace SwamiSamarthSeva
{
    public partial class Events : System.Web.UI.Page
    {
        protected string evetnName = string.Empty;
        ResourceManager rm;
        CultureInfo ci;

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


            //Filling event dropdown
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                // divCityDropDown = "<div style='width:auto;height:auto'>";
                var events = (from w in db.PhotoDirectories where w.Type == "E" orderby w.Id descending select w).ToList();
                int length = events.Count();
                for (int i = 0; i < length; i++)
                {
                    if (i == 0)
                    {
                        evetnName = events[i].FolderName;
                    }

                    if (i == length - 1)
                    {
                        SpnLatestEvent.InnerHtml = events[i].AlbumName;
                    }

                    //string cities = "SetDivisionPage(" + zones[i].Id + ",'aDID" + zones[i].Id + "')";
                    //divCities.InnerHtml = divCities.InnerHtml + "<a  id='aDRP" + events[i].Id + "' href='Event-" + events[i].AlbumName.Replace(" ", "_") + "'  >" + events[i].AlbumName + "</a></br>";
                    divCities.InnerHtml = divCities.InnerHtml + "<a  id='aDRP" + events[i].Id + "' href='Events.aspx?id=" + events[i].Id + "'  >" + events[i].AlbumName + "</a></br>";
                    divCities.InnerHtml = (i < (length - 1)) ? divCities.InnerHtml + "<hr style='border-top:1px;width: 75%'/>" : divCities.InnerHtml + "";
                }

            }

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                using (DBKOMPDataContext db = new DBKOMPDataContext())
                {
                    // divCityDropDown = "<div style='width:auto;height:auto'>";
                    evetnName = (from w in db.PhotoDirectories where w.Id == Convert.ToInt32(Request.QueryString["id"]) orderby w.Id descending select w).First().FolderName;
                }
            }

            if (Page.RouteData.Values["e"]!= null )
            {
                string actualName = string.Empty;
                evetnName = Page.RouteData.Values["e"] as string;
                evetnName = evetnName == null ? "" : evetnName.Replace("_","");

                if ( string.IsNullOrEmpty( evetnName))
                {
                    Page.Title = "Swami Samarth Seva-Events";
                    Page.MetaDescription = "Swami Samarth Seva-Events";
                    Page.MetaKeywords = "Swami Samarth Seva-Events";
                }
                else
                {
                    actualName = Page.RouteData.Values["e"].ToString().Replace("_"," ");
                    Page.Title = "Event-" + actualName;
                    Page.MetaDescription = "Event " + actualName;
                    Page.MetaKeywords = "Swami Samarth Seva-Events";
                   
                }



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
            lblH6.Text = rm.GetString("H13", ci);
            lblH7.Text = rm.GetString("H14", ci);

            lblDon1.Text = rm.GetString("dn1", ci);
            lblDon2.Text = rm.GetString("dn2", ci);
            lblDon3.Text = rm.GetString("dn3", ci);

            //lblH2.Text = rm.GetString("H5", ci);
            //lbh.Text = rm.GetString("H5", ci);
            //lblCowsText.InnerHtml = rm.GetString("H6", ci);
            //lblH4.Text = rm.GetString("H7", ci);

            //pHome.InnerHtml = rm.GetString("H8", ci);
        }

        
    }
}
