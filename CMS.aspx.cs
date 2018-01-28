using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnantaInterior
{
    public partial class CMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER"] != null)
            {
                divNoLogin.Visible = false;
                divLoggedLogin.Visible = true;
            }
            else
            {
                divNoLogin.Visible = true;
                divLoggedLogin.Visible = false;
            }
        }
    }
}