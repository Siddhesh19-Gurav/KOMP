using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using KitchenOnMyPlate.Classes;
using KitchenOnMyPlate.DataAccess;

namespace KitchenOnMyPlate
{
    public partial class Stub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            string referanceNo = string.Empty;
            //string referanceNo = string.Empty;
            var requestId = Request.QueryString["requestId"];

            var paymentResponse = new PaymentResponse { RequestId = requestId, PaymentDone = "1", PaymentMethod = slPaymentMode.SelectedValue};
            Session["PaymentResponse"] = paymentResponse;
            //DBAccess.CreateSession(Params["billing_email"]);
            //Response.Redirect("ConfirmationPage.aspx");

            Response.Redirect("ccavResponseHandler.aspx?method=" + slPaymentMode.SelectedValue + "&referanceNo=12312&PaymentDone=1&requestId=" + requestId);
            
        }
    }
}