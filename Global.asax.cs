using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace KitchenOnMyPlate
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
            RegisterRoutes(RouteTable.Routes);
        }

          void RegisterRoutes(RouteCollection routes)
          {

              // Register a route for Categories/All
           
        
//              routes.MapPageRoute(
//"aboutM",      // Route name
//"AboutUs",      // Route URL
//"~/AboutUs.aspx" // Web page to handle route
//);

              // Register a route for Categories/All
              routes.MapPageRoute(
                 "Contact",      // Route name
                 "Contact",      // Route URL
                 "~/ContactUs.aspx" // Web page to handle route
              );
              routes.MapPageRoute("AboutUs-ouritem", "AboutUs-{tt}-{id}", "~/AboutUs.aspx");
              routes.MapPageRoute("SchoolCatering", "School-Catering", "~/School.aspx");
              routes.MapPageRoute("EventCatering", "Event-Catering", "~/Event.aspx");
              routes.MapPageRoute("CorporateCatering", "Corporate-Catering", "~/Corporate.aspx");

              routes.MapPageRoute("FAQ", "FAQ", "~/FAQ.aspx");
              routes.MapPageRoute("PaymentAndDelivery", "PaymentAndDelivery", "~/PaymentAndDelivery.aspx");
              routes.MapPageRoute("MyOrders", "MyOrders", "~/MyOrders.aspx");
              routes.MapPageRoute("HowItWorks", "HowItWorks", "~/HowItWorks.aspx");
              routes.MapPageRoute("Customised", "CustomisedLunch-{itm}", "~/YourOrder.aspx");
              routes.MapPageRoute("concept", "concept", "~/concept.aspx");
              routes.MapPageRoute("WhyChooseUs", "WhyChooseUs", "~/WhyChooseUs.aspx");
              routes.MapPageRoute("Careers", "Careers", "~/Careers.aspx");
              routes.MapPageRoute("Client", "Client", "~/Client.aspx");
              routes.MapPageRoute("Media", "Media", "~/Media.aspx");
              routes.MapPageRoute("Gallery", "Gallery", "~/Gallery.aspx");
              routes.MapPageRoute("PrivacyPolicy", "PrivacyPolicy", "~/PrivacyPolicy.aspx");
              routes.MapPageRoute("TermsNConditions", "TermsNConditions", "~/TermsNConditions.aspx");

              routes.MapPageRoute("SiteMap", "SiteMap", "~/SiteMap.aspx");
              routes.MapPageRoute("Feedback", "Feedback", "~/Feedback.aspx");
              //routes.MapPageRoute("Gallery", "Gallery", "~/Gallery.aspx");
              //routes.MapPageRoute("Gallery", "Gallery", "~/Gallery.aspx");

              routes.MapPageRoute("TraditionalNt-LunchDinner", "{itm}-{il}", "~/Service.aspx?il=1&itm=1");
              //routes.MapPageRoute("Traditional-Dinner", "Traditional-Dinner", "~/Service.aspx?il=0&itm=1");
              //routes.MapPageRoute("Nutrimeal-Lunch", "Nutrimeal-Lunch", "~/Service.aspx?il=1&itm=6");
              //routes.MapPageRoute("Nutrimeal-Dinner", "Nutrimeal-Dinner", "~/Service.aspx?il=0&itm=6");
              
              //routes.MapPageRoute("AboutUs-ourvision", "AboutUs-ourvision", "~/AboutUs.aspx");
              //routes.MapPageRoute("AboutUs-ourvalues", "AboutUs-ourvalues", "~/AboutUs.aspx");
              //routes.MapPageRoute("AboutUs-ourlogo", "AboutUs-ourlogo", "~/AboutUs.aspx");

              
          }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (HttpContext.Current != null)
            {
                Exception err = Server.GetLastError();
                Response.Clear();
               // Response.Write("<h1>" + err.InnerException.Message + "</h1>");
                Response.Write("<p>" + err.ToString() + "</p>");

                Server.ClearError();

            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}