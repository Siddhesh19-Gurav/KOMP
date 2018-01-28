using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitchenOnMyPlate
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected string selectedItem = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var item = Page.RouteData.Values["id"] as string;

                if (!string.IsNullOrEmpty(item))
                {
                    selectedItem = "our"+item;
                }
            }

        }
    }
}