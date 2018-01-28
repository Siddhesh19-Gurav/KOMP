using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KitchenOnMyPlate.Classes;
using KitchenOnMyPlate.DataAccess;
using System.Text;
using System.IO;
using System.Configuration;

namespace KitchenOnMyPlate
{
    public partial class ConfirmationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            PaymentResponse objPaymentResponse = new PaymentResponse();
            if (Session["PaymentResponse"] != null)
            {
                objPaymentResponse = (PaymentResponse)Session["PaymentResponse"];
                Session.Remove("PaymentResponse");
            }
            else if (Request.QueryString["method"] == "11" || Request.QueryString["method"] == "12" || Request.QueryString["method"] == "13" || Request.QueryString["method"] == "14")//Offline
            {
                objPaymentResponse.PaymentMethod = Request.QueryString["method"];
                objPaymentResponse.PaymentDone = "0";
                objPaymentResponse.RequestId = Request.QueryString["requestId"];
            }

            OfflineOnly(objPaymentResponse);

            if (objPaymentResponse.PaymentDone == "1" || (objPaymentResponse.PaymentDone == "0" && objPaymentResponse.PaymentMethod == "11" || objPaymentResponse.PaymentMethod == "12" || objPaymentResponse.PaymentMethod == "13" || objPaymentResponse.PaymentMethod == "14"))
            {
                //var orderDTO = (OrderList)HttpContext.Current.Session["OrderList"];
                var requesedItems = DBAccess.GetRequestedItems(Convert.ToInt32(objPaymentResponse.RequestId));
                 //gridProduct.DataBind();
                 //lblOrderCode.Text = Request.QueryString["orderId"];                
                lblPMethod.Text = GetPaymentMethod(objPaymentResponse.PaymentMethod);


                if (objPaymentResponse.PaymentMethod == "11" || objPaymentResponse.PaymentMethod == "12" || objPaymentResponse.PaymentMethod == "13" || objPaymentResponse.PaymentMethod == "14") //Offline message
                {
                    lblPaymentMessage.Text = " Thank you for placing your order with Kitchen On My Plate. Here are your Order details";
                    offlineBankDtl.Visible = true;
                }
                
                 //lblTotal.Text = orderDTO.payment.Amount.ToString();


                //New
                
                // SavePayment(Convert.ToInt32(Request.QueryString["requestId"]));
                 Decimal subTotal = 0;
                Decimal tranChrg = 0;
                Decimal deliveryChrg = 0;
                string colspan = "0";
                string startdate = string.Empty;
                string productName = "Customized Meals";
                string Quantity  = string.Empty;
                string mealstartdate = string.Empty;
                string LunchDinner = string.Empty;
                string OrderNumbers = string.Empty;
                decimal TotalDiscount = 0;
                foreach (var item in requesedItems)
                {
                    productName = "Customized Meals";
                    OrderNumbers = (string.IsNullOrEmpty(OrderNumbers))? item.orderId.ToString():(OrderNumbers +","+ item.orderId.ToString());

                     LunchDinner= item.IsTiffin == 1 ? "Lunch" : "Dinner";
                    
                    if (item.nonCustomized == 0)
                    {
                        tbOrders.Text = tbOrders.Text + "<tr class='divRow dataHeader'><td><b>MEAL NAME</b></td><td><b>PRICE</b></td><td><b>QUANTITY</b></td><td><b>TOTAL</b></td></tr>";
                        colspan = "3";
                    }
                    else
                    {
                        tbOrders.Text = tbOrders.Text + "<tr class='divRow dataHeader'><td><b>MEAL DETAILS</b></td><td><b>AMOUNT DETAILS</b></td></tr>";
                        colspan = "0";
                    }

                    
                    int indx=0;
                        foreach (var odr in item.orderedItems)
                        {
                            indx++;

                            if(indx==1)
                            {
                            startdate = odr.DeliverDate.ToString();
                                mealstartdate=odr.DeliverDate.ToString();
                            }
                            if (item.nonCustomized == 0)
                            {//Customized
                                tbOrders.Text = tbOrders.Text + "<tr class='divRow divRowData'><td>" + odr.ProductName + ".</td><td>" + odr.Price + "</td><td>1</td><td>" + odr.Price + "</td></tr>";                                
                            }
                            else
                            {//Tiffin
                                if (indx == 1)
                                {
                                    tbOrders.Text = tbOrders.Text + "<tr class='divRow'><td style='width:70%;' id='divPNAME'> <span class='price'>" + odr.ProductName + "</span></td><td style='width:30%;' align='center'><strong>" + item.orderedItems.Count * Convert.ToDecimal(odr.Price)  +"</strong></td></tr>";
                                    productName =odr.ProductName;
                                }
                            }

                            
                        }

                    var PlanDiscount = DBAccess.GetDiscount(Convert.ToInt32(item.orderedItems.Count()));

                    var payment = DBAccess.GetPayment(item.orderId);

                    var discount = (item.subTotal + payment.Discount) * PlanDiscount.Discount / 100;
                    TotalDiscount = TotalDiscount + discount ?? 0;

                    subTotal = subTotal + (item.subTotal);
                    deliveryChrg = deliveryChrg + item.deliveryCharges;
                    tranChrg = tranChrg + item.transCharges;

                    //It is with top details                    
                    tbOrders1.Text = tbOrders1.Text + "<tr class='divRow cstItem' id='Ord11" + item.orderId.ToString() + "' align='center'></td><td align='center'  style=''>" + item.orderId.ToString() + "</td><td  style='width:40%;'  align='center'> <span>" + productName + "</span></td><td align='center'><span>" + item.orderedItems.Count + "</span></td><td style='' align='center'><span class=''>" + Convert.ToDateTime(mealstartdate).ToString("dd/MM/yy") + "</span></td><td style='' align='center'><span id='' class=''>" + LunchDinner + "</span></td></tr>";
                    
                   // tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'><td colspan='" + colspan + "'><b>Sub Total &nbsp;&nbsp; </b> </td><td align='center'><b>" + item.subTotal + "</b></td></tr>";
                   // tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'><td colspan='" + colspan + "'><b>Delivery Charges&nbsp;&nbsp;</b>  </td><td align='center'><b>" + item.deliveryCharges + "</b></td></tr>";

                 if (item.transCharges > 0)
                 {

                     //if (objPaymentResponse.PaymentMethod == "14") //Cash pickup option of off line
                     //{
                     //    tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'><td colspan='" + colspan + "'><b>Cash Pick up Charges&nbsp;&nbsp;</b>  </td><td align='center'><b>" + item.transCharges + "</b></td></tr>";
                     //}
                     //else
                     //{
                     //    tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'><td colspan='" + colspan + "'><b>Online Processing Charges&nbsp;&nbsp;</b>  </td><td align='center'><b>" + item.transCharges + "</b></td></tr>";
                     //}
                 }

                 //tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'  ><td colspan='" + colspan + "'><span style='font-family:RobotoBlack' >Amount&nbsp;&nbsp;</span>  </td><td align='center' ><span style='font-family:RobotoBlack' >" + item.grandTotal + "</span></td></tr>";
                 tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'  ><td colspan='" + colspan + "'><span style='font-family:RobotoBlack' >Amount&nbsp;&nbsp;</span>  </td><td align='center' ><i class='fa fa-inr'></i><span style='font-family:RobotoBlack' >" + (item.subTotal + payment.Discount) + "</span></td></tr>";

                 spnRqst.InnerText = spnRqst.InnerText == "" ? item.orderId.ToString() : (spnRqst.InnerText + ", " + item.orderId.ToString());
                }

                
                spnSubTotal.InnerHtml = "<i class='fa fa-inr'></i>" + subTotal.ToString("0.00");
                spnDelivery.InnerHtml = "<i class='fa fa-inr'></i>" + deliveryChrg.ToString();
                
                trTran.Visible = tranChrg > 0;

                //string transactionStr = "";
                string transactionStr = tranChrg.ToString();
                if (objPaymentResponse.PaymentMethod == "14") //Cash pickup option of off line
                {
                    strOnln.InnerHtml = "Cash Pick up Charges&nbsp;&nbsp;&nbsp;";
                     //Cash check pickup
                        //var config = DBAccess.GetConfig();
                        //tranChrg = Convert.ToInt32(tranChrg + config.CashPickUp ?? 0);
                    tranChrg = Convert.ToInt32(tranChrg);
                    transactionStr = tranChrg + ".00"; ;
                    
                }

                var config = DBAccess.GetConfig();
                decimal GSTRates = config.Tax ?? 0;

                decimal GstCharge = (subTotal + deliveryChrg + tranChrg) * GSTRates / 100;

                decimal GrandTotal = subTotal + deliveryChrg + tranChrg + GstCharge;
                if (TotalDiscount > 0)
                {
                    spnDiscount.InnerHtml = "<i class='fa fa-inr'></i>" + (TotalDiscount).ToString("0.00");
                    trdiscount.Attributes.Remove("style");
                }
                else
                {
                    trdiscount.Attributes.Add("style", "display:none");
                }
                spnGST.InnerHtml = "<i class='fa fa-inr'></i>" + (GstCharge).ToString("0.00");
                Strong1.InnerHtml = "GST("+ GSTRates + "%)";

                spnTrns.InnerHtml = "<i class='fa fa-inr'></i>" + transactionStr.ToString();

                spnOnlineGrandTotal.InnerHtml = "<i class='fa fa-inr'></i>" + (GrandTotal).ToString("0.00");

                if (!(objPaymentResponse.PaymentMethod == "11" || objPaymentResponse.PaymentMethod == "12" || objPaymentResponse.PaymentMethod == "13" || objPaymentResponse.PaymentMethod == "14")) //online message
                {
                    lblPaymentMessage.Text = "Thank you for placing your order with Kitchen On My Plate.  We have received the payment for the amount " + spnOnlineGrandTotal.InnerText + "    on " + DateTime.Today.ToString("dd/MM/yy") + " for the Order No. " + OrderNumbers + ". Here are your Order details";
                }


                var shippingBilling = DBAccess.GetShippingBilling(Convert.ToInt32(objPaymentResponse.RequestId));

                string strlocation = DBAccess.CheckDeliveryArea(Convert.ToInt32(shippingBilling.Pincode)).Location;

                strongBilling.InnerText = shippingBilling.Address.Replace("$", ", ") + ", "+strlocation;

                strlocation = DBAccess.CheckDeliveryArea(Convert.ToInt32(shippingBilling.PincodeB)).Location;

                strongDelivery.InnerText = shippingBilling.AddressB.Replace("$", ", ") + ", " + strlocation;



                if (CommanAction.GetSession() != null)
                {
                    var objtblUser = CommanAction.GetSession();

                    //Order Summary start 
                    //if (Request.QueryString["method"] == "5")
                    //{
                        divOff.Visible = true;
                        spnName.InnerText = objtblUser.FirstName;
                        //spnRqst.InnerText = objPaymentResponse.RequestId;// Request.QueryString["requestId"];
                        spnSA.InnerText = shippingBilling.Address.Replace("$", ", ") + shippingBilling.LandMark + " " + shippingBilling.Pincode;//+shippingBilling.City;
                        spnBA.InnerText = shippingBilling.Address.Replace("$",", ")+shippingBilling.LandMark+" "+shippingBilling.Pincode;
                        spnRQSTDATE.InnerText = DateTime.Today.ToString("dd/MM/yy");
                        spnPName.InnerText = productName;
                        spnQuantity.InnerText= Quantity;
                        spnMealPP.InnerText = Quantity + " days";
                        spnPaymentMode.InnerText = GetPaymentMethod(objPaymentResponse.PaymentMethod);
                        decimal ds = spnPaymentAmount.InnerHtml == "" ? 0 : Convert.ToDecimal(spnPaymentAmount.InnerHtml);
                        spnPaymentAmount.InnerHtml = (ds + subTotal + deliveryChrg + tranChrg).ToString(); ;
                                spnPaymentStatus.InnerText = GetStatusById(objPaymentResponse.PaymentDone);
                                spnaMealSDate.InnerText = Convert.ToDateTime(mealstartdate).ToString("dd/MM/yy");
                                spnaMealType.InnerText = LunchDinner;
                   //}
                   //Order Summary end

                    #region Send Mail

                    string content = string.Empty;

                    string filepath = "~/Email/Post.htm";
                    //New user
                    StringBuilder sbContent = new StringBuilder();
                    StreamReader rdr = new StreamReader(HttpContext.Current.Server.MapPath(filepath));
                    string strLine = "";
                    while (strLine != null)
                    {
                        strLine = rdr.ReadLine();
                        if ((strLine != null) && (strLine != ""))
                        {
                            sbContent.Append("\n" + strLine);
                        }
                    }
                    rdr.Close();

                    string site = ConfigurationManager.AppSettings["SiteName"].ToString();
                    content = sbContent.ToString();
                    //content = content.Replace("$REQ$", PostType);
                    //content = content.Replace("$ID$", ID);
                    var sbOff = new StringBuilder();
                    divOff.RenderControl(new HtmlTextWriter(new StringWriter(sbOff)));
                    //sbOff.Replace("hideonemail", "display:none");


                    content = content.Replace("$ORDERSUMMARY$", sbOff.ToString());

                    //All Orders Start
                    var sbOff1 = "<br/><br/><table class='tableCart tbl' cellspacing='1' width='100%' align='center' cellpadding='5' ><thead>" +
                    "<tr class='divRow dataHeader' style='background:#F16822;color:#fff;font-family:RobotoBold;font-size:1em; ' ><td>ORDER#</td><td>PRODUCT</td><td>QUANTITY</td><td>START DATE</td><td>MEAL TYPE</td></tr>"+
                    "</thead><tbody>"+tbOrders1.Text+"</tbody></table>";
                    content = content.Replace("$ALLORDERS$", sbOff1);
                    //All Orders End

                    
                    
                    
                    var sb = new StringBuilder();
                    divFinal.RenderControl(new HtmlTextWriter(new StringWriter(sb)));
                    content = content.Replace("$REQ$", sb.ToString());
                    content = content.Replace("$NAME$", objtblUser.FirstName + " " + objtblUser.LastName);
                    content = content.Replace("$SITE$", site);

                    content = content.Replace("RobotoBlack", "Arial");
                    content = content.Replace("RobotoBold", "Arial");
                    content = content.Replace("Roboto", "Arial");
                    
                    content = content.Replace("images/rs3.png", "http://www.kitchenonmyplate.com/images/rs3.png");
                    content = content.Replace("hideonemail", "display:none;max-height: 0px; font-size: 0px; overflow: hidden; mso-hide: all");
                    content = content.Replace("<strong>", "<span>");
                    content = content.Replace("</strong>", "</span>");
                    content = content.Replace("h1>", "h2>");
                    content = content.Replace("<h1", "<h2");

                    
                    content = content.Replace("<i class='fa fa-inr'></i>", "Rs. ");
                    
                    

                    //content = content.Replace("class", "style");
                    //content = content.Replace("page-titleSmallCust", "color:#4b220c; text-transform:uppercase; font-family:'Arial'; font-weight:bold;border-bottom:1px solid #c8c6c6; padding:10px 0 10px 25px ; font-size:25px; margin-top:0px;background:#EEEEEE !important;");
                    //content = content.Replace("OrderBox", "display:none");
                    //content = content.Replace("ProcesBoxInner", "height:auto; padding:0px 25px 10px 10px;text-align: justify; text-justify: inter-word;");
                    //content = content.Replace("ProcessBox", "width:100%;height:auto;border:1px solid #c8c6c6;padding-bottom:10px;");                    
                    //content = content.Replace("tbl", "width:100%;height:auto;border:1px solid #c8c6c6;");                    
                    //content = content.Replace("divRowHeader", "font-weight:bold; color:Black; font-size:0.85em;");
                    //content = content.Replace("<table", "<table style='border-collapse:collapse; border-spacing:0;' border='1' ");
                    //content = content.Replace("priceTotaltxt", "font-weight:700; font-size:24px; color: #006400;");
                    //content = content.Replace("priceTotal", "font-size:30px; color: #006400; padding-right:25px;");
                    //content = content.Replace("price", "font-weight:700; font-size:1.2em; color: #006400;");
                    
                    //content = content.Replace("CUSTBOX", "");
                    //content = content.Replace("emailH5", "font-size:14px;color:#f37624;font-family:Arial;");
                    
                    content = content.Replace(">01<", "><");
                    content = content.Replace(">03<", "><");   


                    if (!string.IsNullOrEmpty(objtblUser.email))
                    {
                        MailHelper.SendMailMessage("", objtblUser.email, string.Empty, string.Empty, "Thanks For Placing Order", content);
                        AutoServices.SendeMailToUs("Copy:Thanks For Placing Order", content);

                    }

                    trlist.Visible = true;
                #endregion
                }

                //Deleting cookies
                //if (Request.Cookies["ORDERLIST"] != null)
                //{
                //    HttpCookie myCookie = new HttpCookie("ORDERLIST");
                //    myCookie.Expires = DateTime.Now.AddDays(-1d);
                //    Response.Cookies.Add(myCookie);
                //}
             
            }

            Session.Remove("OrderList");
            //Deleting cookies
            if (Request.Cookies["ORDERLIST"] != null)
            {
                HttpCookie myCookie = new HttpCookie("ORDERLIST");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
        }

        string GetStatusById(string id)
        {
            if (id == "0")
            {
                return "Pending";
            }
            else if (id == "1")
            {
                return "Success";
            }
            else if (id == "2")
            {
                return "Failure";
            }
            else if (id == "3")
            {
                return "Invalid";
            }
            else if (id == "4")
            {
                return "ABORTED";
            }

            return "Pending";
        }

        private string GetPaymentMethod(string id)
        {
            string strMethod = string.Empty;

            switch (id)
            {
                case "1":
                    strMethod = "Net Banking";
                    break;
                case "2":
                    strMethod = "Credit Card";
                    break;
                case "3":
                    strMethod = "Debit Card";
                    break;
                case "4":
                    strMethod = "Cash Card";
                    break;
                case "5":
                    strMethod = "Mobile Payment";
                    break;
                case "11":
                    strMethod = "Offline - Cash Deposit";
                    break;
                case "12":
                    strMethod = "Offline - Cheque";
                    break;
                case "13":
                    strMethod = "Offline - NEFT";
                    break;
                case "14":
                    strMethod = "Offline - Cash Pick Up";
                    break;
            }
            return strMethod;
        }

        
        //private void SavePayment(int requestId)
        //{             
        //      //Request.QueryString["referanceNo"];
        //        Payment paymentObj = new Payment();
        //        paymentObj.OrderId = Convert.ToInt32(Request.QueryString["orderId"]);
        //        paymentObj.Amount = 200;
        //        paymentObj.CardNumber = "123";

        //        paymentObj.Mode = 1;
        //        paymentObj.NameOnCard = "Rekha";
        //        paymentObj.TransactionNo = Request.QueryString["referanceNo"];
        //        paymentObj.IsActive = 1;
        //        paymentObj.PaymentDate = DateTime.Now;

        //        //Saving Payment
        //        //.DBAccess.KitchenOnMyPlate.Classes.OrderManagement.SavePayemt(paymentObj, requestId,);
        //}
        void OfflineOnly(PaymentResponse paymentResponse)
        {
            if (paymentResponse.PaymentDone == "0" && (paymentResponse.PaymentMethod == "11" || paymentResponse.PaymentMethod == "12" || paymentResponse.PaymentMethod == "13" || paymentResponse.PaymentMethod == "14"))//Off line only
            {
                if (CommanAction.GetSession() != null)
                {
                    var objtblUser = CommanAction.GetSession();
                    OrderManagement.SavePayemt(Convert.ToInt32(Request.QueryString["requestId"]), 0, Convert.ToInt32(paymentResponse.PaymentMethod), "", "", objtblUser.FirstName);
                }
                Session.Remove("OrderList");
                //Deleting cookies
                if (Request.Cookies["ORDERLIST"] != null)
                {
                    HttpCookie myCookie = new HttpCookie("ORDERLIST");
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                }
            }
    }
    }
}