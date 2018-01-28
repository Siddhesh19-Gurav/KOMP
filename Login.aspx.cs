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

using KitchenOnMyPlate.Classes;
using KitchenOnMyPlate.DataAccess;
using KitchenOnMyPlate;

namespace KotaCoachings
{
    public partial class Login : System.Web.UI.Page
    {
        protected string ISCityDisplayed = "0";
        protected string logo = string.Empty;
        protected string LID = string.Empty;
        protected string Location = string.Empty;        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {                
            }
        }

      
    }
}
