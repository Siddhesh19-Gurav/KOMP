using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KitchenOnMyPlate.DataAccess;
using System.Text.RegularExpressions;
using KitchenOnMyPlate.Classes;
using System.Configuration;

namespace KitchenOnMyPlate
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected int loggiedIn = 0;
        protected string LoggedInUserType = string.Empty;
        protected int pageId = -1;
        protected string subpageId = "";
        protected string VarName = string.Empty;
        protected string VarMobile = string.Empty;
        protected string VarEmail = string.Empty;
        protected string ShowProperty = string.Empty;
        protected string AllowDefaultFooterCityChange = string.Empty;
        protected string fbapiId = string.Empty;


        protected string SiteCity = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            //HttpContext.Current.Response.ClearHeaders();
            //("Location",
            //if (!Request.Url.ToString().ToLower().Contains("www") && !Request.Url.ToString().ToLower().Contains("localhost"))
            //{
            //    HttpContext.Current.Response.Status = "301 Moved Permanently";
            //    //HttpContext.Current.Response.AddHeader("Location","http://www." + ConfigurationManager.AppSettings["SiteName"].ToString());
            //    HttpContext.Current.Response.AddHeader("Location",
            //        Request.Url.ToString().ToLower().Replace("http://" + ConfigurationManager.AppSettings["SiteName"].ToString(), "http://www." + ConfigurationManager.AppSettings["SiteName"].ToString()));

            //    Response.RedirectPermanent("http://www." + ConfigurationManager.AppSettings["SiteName"].ToString());
            //}

            if (!IsPostBack)
            {

                if (Request != null)
                {

                    if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                    {
                        txtExistingUserName.Value = Request.Cookies["UserName"].Value;

                    }
                }

                //if (!HttpContext.Current.Request.Url.Host.ToUpper().Contains("WWW") && HttpContext.Current.Request.Url.Host.ToUpper() !="LOCALHOST" )
                //{
                //    Response.Redirect("http://www.kitchenonmyplate.com/");
                //}
                //Read the cookie from Request.
                HttpCookie myCookie = HttpContext.Current.Request.Cookies["USERMART"];
                if (myCookie != null)
                {
                    if (!string.IsNullOrEmpty(myCookie.Values["EMAIL"]))
                    {
                        if (Session["USER"] == null)
                        {
                            DataAccess.DBAccess.CreateSession(myCookie.Values["EMAIL"]);
                        }
                    }
                }





                if (Session["USER"] != null)
                {
                    var userObj = ((User)Session["USER"]);
                    loggiedIn = userObj.UserId;

                    login.Style.Add("display", "none");
                    aRegister.Style.Add("display", "none");
                    //lnkForgotPassword.Style.Add("display", "none");
                    //lblhindResh.Style.Add("display", "none"); 
                    //login.Visible = false;
                    //aRegister.Visible = false;
                    loggendUser.Style.Remove("display");
                    logOut.Style.Remove("display");
                    aMyOrders.Style.Remove("display");

                    //logOut.Visible = true;                    
                    //aMyOrders.Visible = true;

                    loggendUser.Text = "Hi, "+userObj.FirstName; 

                    VarName = userObj.FirstName + " " + userObj.LastName;
                    VarMobile = userObj.mobile;
                    VarEmail = userObj.email;

                    //KOMP

                    //loggendUser.Text = "Welcome " + ((User)Session["USER"]).FirstName + " !!";
                    //loggendUser.Visible = true;

                    //divLogout.Visible = true;
                    //divLogout.Style.Remove("display");

                    //divLogin.Visible = false;
                    //loggendUser.Visible = true;
                    //Page.ClientScript.RegisterStartupScript(typeof(Page), "dfSite", " $('#ctl00_divLogin').hide();$('#ctl00_divLogout,#ctl00_loggendUser').show();", false);

                    if (CommanAction.GetSession().UserType == "N") // If admin
                    {
                        LoggedInUserType = "A";
                    }

                    LoggedInUserType = CommanAction.GetSession().UserType;
                    //divLogin.Visible = false;
                    //divLogout.Visible = true;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "dfSite1", " $('#ctl00_loggendUser').hide();", true);
                    //loggendUser.Visible = false;
                }


                //Placed Orders only , not saved in db
                string PlacedOrders1 = OrderManagement.GetPlacedOrders().Split('$')[0];
                CartSaved.Text = !string.IsNullOrEmpty(PlacedOrders1) ? PlacedOrders1 : "";

                if (HttpContext.Current.Session["OrderList"] != null)
                {
                    OrderList orders = (OrderList)HttpContext.Current.Session["OrderList"];
                    if (orders.orders.Count > 3)
                    {
                        PlacedOrders.Style.Add("height", "550px");
                        PlacedOrders.Style.Add("overflow-y", "auto"); 
                    }
                }

                string pType = string.IsNullOrEmpty(Request.QueryString["il"]) ? string.Empty : Request.QueryString["il"];
                if (!((System.Web.UI.Control)(ContentPlaceHolder1)).Page.ToString().Contains("default"))
                {
                    divSlider.Visible = false;
                }

                if (((System.Web.UI.Control)(ContentPlaceHolder1)).Page.ToString().Contains("default"))
                {
                    pageId = 0;
                }
                else if (((System.Web.UI.Control)(ContentPlaceHolder1)).Page.ToString().Contains("about"))
                {
                    pageId = 1;
                    if (Request.QueryString["id"] == "ourmission")
                    {
                        subpageId = "abt1";
                    }
                    else if (Request.QueryString["id"] == "ourvision")
                    {
                        subpageId = "abt2";
                    }
                    else if (Request.QueryString["id"] == "ourvalues")
                    {
                        subpageId = "abt3";
                    }
                    else if (Request.QueryString["id"] == "ourlogo")
                    {
                        subpageId = "abt3";
                    }


                }
                else if (((System.Web.UI.Control)(ContentPlaceHolder1)).Page.ToString().Contains("service") && pType == "1")
                {
                    pageId = 2;
                }
                else if (((System.Web.UI.Control)(ContentPlaceHolder1)).Page.ToString().Contains("yourorder"))
                {
                    pageId = 3;
                }
                else if (((System.Web.UI.Control)(ContentPlaceHolder1)).Page.ToString().Contains("service") && pType == "0")
                {
                    pageId = 4;
                }
                else if (((System.Web.UI.Control)(ContentPlaceHolder1)).Page.ToString().Contains("corporate"))
                {
                    pageId = 5;
                    subpageId="asub1";
                }
                else if (((System.Web.UI.Control)(ContentPlaceHolder1)).Page.ToString().Contains("school"))
                {
                    pageId = 5;
                    subpageId = "asub2";
                }
                else if (((System.Web.UI.Control)(ContentPlaceHolder1)).Page.ToString().Contains("event"))
                {
                    pageId = 5;
                    subpageId = "asub3";
                }
                else if (((System.Web.UI.Control)(ContentPlaceHolder1)).Page.ToString().Contains("contactus"))
                {
                    subpageId = "acont";
                }
                else if (((System.Web.UI.Control)(ContentPlaceHolder1)).Page.ToString().Contains("myorders"))
                {
                    subpageId = "aMyOrders";                    
                }
                else if (((System.Web.UI.Control)(ContentPlaceHolder1)).Page.ToString().Contains("howitworks"))
                {
                    subpageId = "achow";
                }
                


                SetMenu();
            }

        }

        protected void imgLogin_Click(object sender, EventArgs e)
        {
           // DBAccess.CreateSession(userName.Value);
            Response.Redirect("/");
            //hypSign.Visible = false;
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


            Response.Redirect("/");
        }

        private void SetMenu()

        {
            //custDivInner.InnerHtml = "<span>&nbsp;</span><br />";
            tifDivInner.InnerHtml = "<span>&nbsp;</span><br />";
            //dinDivInner.InnerHtml = "<span>&nbsp;</span><br />";

            var products = DBAccess.GetProducts();
            string str= string.Empty;
            foreach(var item in products )
            {
                string itemSubMenu = string.Empty;
                if (item.Header.Contains("("))
                {
                    itemSubMenu = item.Header.Split('(')[0].Trim(); //Regex.Match(item.Header, @"^(\w+\b.*?){3}").ToString();
                }
                else
                {
                    itemSubMenu = item.Header;
                }

                if (item.ShowInBoth == "B")
                {
                    //custDivInner.InnerHtml = custDivInner.InnerHtml + "<span> <a href='YourOrder.aspx?itm=" + item.Id + "'>" + itemSubMenu + "</a></span><hr />";
                    //custDivInner.InnerHtml = custDivInner.InnerHtml + "<span> <a href='CustomisedLunch-" + item.Id + "'>" + itemSubMenu + "</a></span><hr />";

                    //    tifDivInner.InnerHtml = tifDivInner.InnerHtml + "<span> <a href='Service.aspx?il=1&itm=" + item.Id + "'>" + itemSubMenu + "</a></span><hr />";
                    //dinDivInner.InnerHtml = dinDivInner.InnerHtml + "<span> <a href='Service.aspx?il=0&itm=" + item.Id + "'>" + itemSubMenu + "</a></span><hr />";
                    tifDivInner.InnerHtml = tifDivInner.InnerHtml + "<span> <a href='Traditional-Lunch'>" + itemSubMenu + "</a></span><hr />";
                    //dinDivInner.InnerHtml = dinDivInner.InnerHtml + "<span> <a href='Traditional-Dinner'>" + itemSubMenu + "</a></span><hr />";
                }
                else if (item.ShowInBoth == "C")
                {
                    //custDivInner.InnerHtml = custDivInner.InnerHtml + "<span> <a href='YourOrder.aspx?itm=" + item.Id + "'>" + itemSubMenu + "</a></span><hr />";                    
                   // custDivInner.InnerHtml = custDivInner.InnerHtml + "<span> <a href='CustomisedLunch-" + item.Id + "'>" + itemSubMenu + "</a></span><hr />";
                }
                else if (item.ShowInBoth == "N")
                {
                    tifDivInner.InnerHtml = tifDivInner.InnerHtml + "<span> <a href='Nutrimeal-Lunch'>" + itemSubMenu + "</a></span><hr />";
                    //dinDivInner.InnerHtml = dinDivInner.InnerHtml + "<span> <a href='Nutrimeal-Dinner'>" + itemSubMenu + "</a></span><hr />";
                    //tifDivInner.InnerHtml = tifDivInner.InnerHtml + "<span> <a href='Service.aspx?il=1&itm=" + item.Id + "'>" + itemSubMenu + "</a></span><hr />";
                    //dinDivInner.InnerHtml = dinDivInner.InnerHtml + "<span> <a href='Service.aspx?il=0&itm=" + item.Id + "'>" + itemSubMenu + "</a></span><hr />";
                }
            }
                        
        }
    }
}