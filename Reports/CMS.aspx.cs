using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitchenOnMyPlate.Reports
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
    }
}