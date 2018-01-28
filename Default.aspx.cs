using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KitchenOnMyPlate.DataAccess;

namespace KitchenOnMyPlate
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               ltrProduct.Text = HTMLGenerator.GetProductOnHomeHTML();
               
                //If requst order from tomorrow start
               if (!string.IsNullOrEmpty(Request.QueryString["OFT"]))
               {
                   Session["ORDERFROMTOMORROW"] = Request.QueryString["OFT"];
               }
            }

        }
    }
}