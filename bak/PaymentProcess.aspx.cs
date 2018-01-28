using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using KitchenOnMyPlate.Classes;
using KitchenOnMyPlate.DataAccess;
using CCA.Util;
using System.Text;
using System.IO;
using System.Threading;

namespace KitchenOnMyPlate
{
    public partial class PaymentProcess : System.Web.UI.Page
    {
        protected int loggiedIn = 0;
        protected int IsPaymentEnabled = 0;
        protected int requestId = 0;
        protected int CountProducts = 0;
        
        protected string method = "0";
        protected int FromTopCart = 0;
        protected string FinalOrder = string.Empty; //it is for final box

        CCACrypto ccaCrypto = new CCACrypto();
        string workingKey = "450273C40E328E5C121E04A20281F3E7";//put in the 32bit alpha numeric key in the quotes provided here 	
        string ccaRequest = "";
        public string strEncRequest = "";
        public string strAccessCode = "AVXH05CE12AQ55HXQA";// put the access key in the quotes provided here.
        public int pincode = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            loggiedIn = CommanAction.GetSession().UserId;
            IsPaymentEnabled = Convert.ToInt32(ConfigurationManager.AppSettings["GoToPaymentGateway"]);
            requestId = Convert.ToInt32(Request.QueryString["requestId"]);

            method = string.IsNullOrEmpty(Request.QueryString["method"])?method:Request.QueryString["method"].ToString();

            if (!IsPostBack)
            {
                if (Request.QueryString["method"] != "11" && Request.QueryString["method"] != "12" && Request.QueryString["method"] != "13" && Request.QueryString["method"] != "14")
                {
                    if (((KitchenOnMyPlate.User)CommanAction.GetSession()).UserType == "N")
                    {
                    btnProcC.Visible = true; 
                    }
                }


                if (CommanAction.GetSession() == null)
                {
                    Response.Redirect("/");
                }
                else
                {
                    
                    if(!string.IsNullOrEmpty( Request.QueryString["LT"]))
                    {
                    FromTopCart = 1;
                    }

                    if (Session["OrderList"] != null)
                    {
                        var orders = ((OrderList)Session["OrderList"]).orders;

                        CountProducts = orders.Count;


                        if (orders.Count > 0)
                        {
                            delivery_zip.Value = orders[0].Order.pincode.ToString();

                            txtLocation.DataSource  = DBAccess.GetDeliveryAreaForZip(Convert.ToInt32(delivery_zip.Value));
                            txtLocation.DataTextField = "Location";
                            txtLocation.DataValueField = "Id";
                            txtLocation.DataBind();
                            //txtLocation.Items.Add(new ListItem { Selected = true, Value = "0", Text = "--Select Area--" });
                            txtLocation.Items.Insert(0, new ListItem { Selected = true, Value = "999", Text = "" });
                            txtLocation.SelectedIndex = 0;
                            //txtLocation.Disabled 
                        }

                        //CHANGES on 22/01/16-
                        //if (("400601,400602,400603,400703,400703").Contains(orders[0].Order.pincode.ToString()))
                        //{
                        //txtLocation.DataSource = DBAccess.GetDeliveryAreaForZip(Convert.ToInt32(delivery_zip.Value));
                        //txtLocation.DataTextField = "Location";
                        //txtLocation.DataValueField = "Id";
                        //txtLocation.DataBind();
                        //txtLocation.Items.Add(new ListItem { Selected = true, Value = "0", Text = "--Select Area--" });
                        //}
                        //else
                        //{
                        //    txtLocation.Items.Add(new ListItem { Selected = true, Value = "999", Text = "Mumbai"});
                        //    txtLocation.Disabled = true;
                        //}

                        foreach (var ord in orders)
                        {                           

                            pincode = ord.Order.pincode??0;
                            order_id.Text = ord.Order.RequestId.ToString();
                            if (amount.Text == "")
                            {
                                amount.Text = "0";
                            }
                            amount.Text = (Convert.ToDecimal(amount.Text) + ord.payment.Amount + ord.payment.DeliveryChrg + ord.payment.TrnChrg).ToString();
                        }
                    }

                    string utype = ((KitchenOnMyPlate.User)CommanAction.GetSession()).UserType;
                    if (utype != "N")//Not setting for admin
                    {
                    
                    
                    var shpbill = DBAccess.GetShippingBillingByUserId(loggiedIn, pincode);

                    if (shpbill.Id != 0)
                    {
                        delivery_name.Value = shpbill.FirstName;

                        if (shpbill.LastName.Trim() == "") //Note last name is using as emailid
                        {
                            txtLastName.Value = CommanAction.GetSession().email;
                        }
                        else
                        {
                            txtLastName.Value = shpbill.LastName;
                        }

                        if (Session["USER"] != null && shpbill.LastNameB.Trim() == "") //Note last name is using as emailid
                        {
                            txtLastNameB.Value = CommanAction.GetSession().email;
                        }
                        else
                        {
                            txtLastName.Value = shpbill.LastName;
                        }

                        delivery_tel.Value = shpbill.mobile;
                        txtCompanyName.Value = shpbill.CompanyName;
                        delivery_address.Value = shpbill.Address.Replace("$",", ");
                        var address = shpbill.Address.Split('$');

                        if (address.Length > 2)
                        {
                            txtFlat.Value = address[0];
                            txtBuilding.Value = address[1];
                            txtStreet.Value = address[2];

                            txtFlat.Value = address[0];
                            txtBuilding.Value = address[1];
                            txtStreet.Value = address[2];
                        }

                        if (address.Length > 3)
                        {
                            txtLocation.Value = address[3];
                        }
                        

                        txtLandMark.Value = shpbill.LandMark;
                        delivery_city.Value = shpbill.City;
                        //delivery_state.Value = shpbill.;
                        delivery_zip.Value = shpbill.Pincode;

                        billing_name.Value = delivery_name.Value;
                        txtLastNameB.Value = shpbill.LastName;
                        billing_tel.Value = shpbill.mobile;
                        txtCompanyNameB.Value = shpbill.CompanyName;
                        billing_address.Value = shpbill.Address.Replace("$", ", ");
                        
                     

                        txtLandMarkB.Value = shpbill.LandMark;
                        billing_city.Value = shpbill.City;
                        //delivery_state.Value = shpbill.;
                        billing_zip.Value = shpbill.Pincode;
                        txtLocation.Value = DBAccess.CheckDeliveryArea( Convert.ToInt32(shpbill.Pincode)).Location;
                    }
                    else 
                    {//First time withoud shipping address

                        if (CommanAction.GetSession().email != "") 
                        {
                            delivery_name.Value = CommanAction.GetSession().FirstName;

                            txtLastName.Value = CommanAction.GetSession().email;
                            txtLastNameB.Value = CommanAction.GetSession().email;
                             delivery_tel.Value = CommanAction.GetSession().mobile;

                            txtLastName.Disabled = true;
                            txtLastNameB.Disabled = true;
                        }
                        
                    }
                   }
                }

                ShowOrderDetails();

                FinalOrder = OrderManagement.GetPlacedOrderFinalHTML();
            }
         }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);

            if (InsertAddress() == 0)
            {
                return;
            }
            
            if (!string.IsNullOrEmpty(Request.QueryString["method"]) && Request.QueryString["method"] != "11" && Request.QueryString["method"] != "12" && Request.QueryString["method"] != "13" && Request.QueryString["method"] != "14")  //It is for online only - should not be called in offline. 11 means offf line
            {

                //It is for online only - should not be called in offline.
                foreach (var name in Request.Form.AllKeys)
                {
                    if (name != null)
                    {
                        if (!name.Contains("btnProcC") && !name.Contains("bll") && !name.Contains("txtLandMark") && !name.Contains("txtCompanyName"))
                        {
                            if (!name.Replace("ctl00$ContentPlaceHolder1$", "").StartsWith("_"))
                            {
                                ccaRequest = ccaRequest + name.Replace("ctl00$ContentPlaceHolder1$", "") + "=" + Request.Form[name] + "&";
                                /* Response.Write(name + "=" + Request.Form[name]);
                                  Response.Write("</br>");*/
                            }
                        }
                    }
                }


                //if ( Request.QueryString["method"] == "11")//Off line
                //{                    
                //    Response.Redirect("ConfirmationPage.aspx?method=" + Request.QueryString["method"]+"&requestId"+Request.QueryString["requestId"]);
                //}
                //else
                //{
                //Online
                if (CommanAction.GetSession() != null)
                {
                    ccaRequest = ccaRequest + "billing_email=" + txtLastName.Value + "&"; //Note : last name is using like email id //((User)Session["USER"]).email + "&";
                }


                ccaRequest = ccaRequest + "billing_country=India&";
                ccaRequest = ccaRequest + "delivery_country=India&";

                strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);


                DBAccess.setPaymentAsFailed(requestId); //Online payment Mark it as failed

                if(Convert.ToInt32(ConfigurationManager.AppSettings["GoToPaymentGateway"])==1)
                {
                    Response.Redirect("ccavRequestHandler.aspx?ED=" + strEncRequest);
                }
                else
                {
                    Response.Redirect("Stub.aspx?requestId=" + requestId);
            //window.location.href = "Stub.aspx?requestId=" + requestId;
                }
                    
               // Response.Redirect("ccavRequestHandler.aspx?ED=" + strEncRequest);
                //window.location.href = "Stub.aspx?requestId=" + requestId;
                //}

            }
            else
            {
                Response.Redirect("ConfirmationPage.aspx?method=" + method + "&referanceNo=123&PaymentDone=0&requestId=" + requestId);
                  
                        //window.location = "ConfirmationPage.aspx?method=" + method + "&referanceNo=123&PaymentDone=0&requestId=" + requestId;
                        
                //
            }
        }


        private int InsertAddress()
        {
            //Start Insert Address
            //Note use last name as emaiid
            var shippingBilling = new ShippingBilling();

            shippingBilling.Id = 0;

            shippingBilling.UserId = loggiedIn;

            shippingBilling.RequestId = requestId;

            shippingBilling.FirstName = delivery_name.Value.Trim(); //Trim(document.getElementById("delivery_name").value);

            shippingBilling.LastName = txtLastName.Value;// Trim(document.getElementById("txtLastName").value);
            shippingBilling.mobile = delivery_tel.Value;// Trim(document.getElementById("delivery_tel").value);
            shippingBilling.CompanyName = txtCompanyName.Value;//Trim(document.getElementById("txtCompanyName").value);

            //Create address     

           // delivery_address.Value = txtFlat.Value + ", " + txtBuilding.Value + ", " + txtStreet.Value + ", ";// +txtLocation.Items[txtLocation.SelectedIndex].Text;



            shippingBilling.Address = txtFlat.Value + "$" + txtBuilding.Value + ", " + txtStreet.Value + "$";// +txtLocation.Items[txtLocation.SelectedIndex].Text;
            //shippingBilling.Address = Trim($("#txtFlat").val()) + "$" + Trim($("#txtBuilding").val()) + "$" + Trim($("#txtStreet").val() + "$" + $("#txtLocation option:selected").html()); // Trim(document.getElementById("delivery_address").value);
            shippingBilling.City = delivery_city.Value.Trim();
            shippingBilling.State = delivery_state.Value.Trim();
            shippingBilling.LandMark = txtLandMark.Value.Trim();
            shippingBilling.Pincode = delivery_zip.Value;

            if (chkSamAsShipping.Checked)// $("#chkSamAsShipping").is(':checked')) 
            {


                //Need to set control value too for ccavenu posting -start
                //billing_name.Value = delivery_name.Value;
                //txtLastNameB.Value = txtLastName.Value;
                //billing_tel.Value = delivery_tel.Value;
                //txtCompanyNameB.Value = txtCompanyName.Value;
                //billing_address.Value = delivery_address.Value;
                //txtFlat.Value = txtFlatB.Value;
                //txtBuilding.Value = txtBuildingB.Value;
                //txtStreet.Value = txtStreetB.Value;
                //billing_city.Value = delivery_city.Value;
                //billing_state.Value = delivery_state.Value;
                //txtLandMarkB.Value = txtLandMark.Value;
                //billing_zip.Value = delivery_zip.Value;
                //Need to set control value too for ccavenu posting -end


                shippingBilling.FirstNameB = delivery_name.Value;
                shippingBilling.LastNameB = txtLastName.Value;
                shippingBilling.mobileB = delivery_tel.Value;
                shippingBilling.CompanyNameB = txtCompanyName.Value;
                //shippingBilling.AddressB = Trim($("#txtFlat").val()) + "$" + Trim($("#txtBuilding").val()) + "$" + $("#txtLocation option:selected").html(); // Trim(document.getElementById("delivery_address").value);
                shippingBilling.AddressB = txtFlat.Value + "$" + txtBuilding.Value + "$";// +txtLocation.Items[txtLocation.SelectedIndex].Text; // Trim(document.getElementById("delivery_address").value);
                shippingBilling.CityB = delivery_city.Value;
                shippingBilling.StateB = delivery_state.Value;
                shippingBilling.LandMarkB = txtLandMark.Value;
                shippingBilling.PincodeB = delivery_zip.Value;

                shippingBilling.CreatedDate = DateTime.Now;
            }
            else
            {
                shippingBilling.FirstNameB = billing_name.Value;
                shippingBilling.LastNameB = txtLastNameB.Value;
                shippingBilling.mobileB = billing_tel.Value;
                shippingBilling.CompanyNameB = txtCompanyNameB.Value;

                //document.getElementById("billing_address").value = Trim($("#txtFlatB").val()) + ", " + Trim($("#txtBuildingB").val()) + ", " + Trim($("#txtStreetB").val());
               // billing_address.Value = txtFlatB.Value.Trim() + ", " + txtBuildingB.Value.Trim() + ", " + txtStreetB.Value.Trim();

                shippingBilling.AddressB = txtFlatB.Value.Trim() + "$" + txtBuildingB.Value.Trim() + "$" + txtStreetB.Value.Trim();
                //shippingBilling.AddressB = Trim($("#txtFlatB").val()) + "$" + Trim($("#txtBuildingB").val()) + "$" + Trim($("#txtStreetB").val()+"$"+$("#txtLocationB").val()); // Trim(document.getElementById("billing_address").value);
                shippingBilling.CityB = billing_city.Value;
                shippingBilling.StateB = billing_state.Value;
                shippingBilling.LandMarkB = txtLandMarkB.Value.Trim();
                shippingBilling.PincodeB = billing_zip.Value.Trim();
                shippingBilling.CreatedDate = DateTime.Now;
            }

            int shipinid = DataAccess.DBAccess.SaveShippingBilling(shippingBilling);

            return shipinid;
            //end Insert Address
        }
        //Event is for Admin who will plac order on customer behalf
        protected void btnProcC_Click(object sender, EventArgs e)
        {
            string paymentLink = string.Empty;
            if (!string.IsNullOrEmpty(Request.QueryString["method"]) && Request.QueryString["method"] != "11" && Request.QueryString["method"] != "12" && Request.QueryString["method"] != "13" && Request.QueryString["method"] != "14")  //It is for online only - should not be called in offline. 11 means offf line
            {
                
                DBAccess.SetUserByAdminOnBehalf(requestId,billing_name.Value, txtLastName.Value); 

                //It is for online only - should not be called in offline.
                foreach (var name in Request.Form.AllKeys)
                {
                    if (name != null)
                    {
                        if (!name.Contains("btnProcC"))
                        {
                            if (!name.Replace("ctl00$ContentPlaceHolder1$", "").StartsWith("_"))
                            {
                                ccaRequest = ccaRequest + name.Replace("ctl00$ContentPlaceHolder1$", "") + "=" + Request.Form[name] + "&";
                                /* Response.Write(name + "=" + Request.Form[name]);
                                  Response.Write("</br>");*/
                            }
                        }
                    }
                }


                //if ( Request.QueryString["method"] == "11")//Off line
                //{                    
                //    Response.Redirect("ConfirmationPage.aspx?method=" + Request.QueryString["method"]+"&requestId"+Request.QueryString["requestId"]);
                //}
                //else
                //{
                //Online
                //if (Session["USER"] != null)
                //{
                ccaRequest = ccaRequest + "billing_email=" + txtLastName.Value + "&"; //Note : last name is using like email id //((User)Session["USER"]).email + "&";
                //}


                ccaRequest = ccaRequest + "billing_country=India&";
                ccaRequest = ccaRequest + "delivery_country=India&";

                strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);



                if (Convert.ToInt32(ConfigurationManager.AppSettings["GoToPaymentGateway"]) == 1)
                {
                    paymentLink = "http://www.kitchenonmyplate.com/ccavRequestHandler.aspx?ED=" + strEncRequest;
                }
                else
                {
                   // Response.Redirect("Stub.aspx?requestId=" + requestId);
                    paymentLink = "http://www.kitchenonmyplate.com/ccavRequestHandler.aspx?ED=" + strEncRequest;
                    //window.location.href = "Stub.aspx?requestId=" + requestId;
                }

                // Response.Redirect("ccavRequestHandler.aspx?ED=" + strEncRequest);
                //window.location.href = "Stub.aspx?requestId=" + requestId;
                //}


                //else
                //{
                //   // Response.Redirect("ConfirmationPage.aspx?method=" + method + "&referanceNo=123&PaymentDone=0&requestId=" + requestId);
                //}

                //ShippingBilling objSB = DBAccess.GetShippingBilling(rqst);

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
                //divOff.RenderControl(new HtmlTextWriter(new StringWriter(sbOff)));
                content = content.Replace("$ORDERSUMMARY$", "Click on below link to complete your order!");


                var sb = new StringBuilder();
                //divFinal.RenderControl(new HtmlTextWriter(new StringWriter(sb)));
                content = content.Replace("$REQ$", "<a href='" + paymentLink + "' >Make Payment</a><br/><br/>Only single transaction is permitted with above link");
                content = content.Replace("$NAME$", billing_name.Value);
                content = content.Replace("$SITE$", site);
                content = content.Replace("RobotoBlack", "Arial");
                content = content.Replace("Roboto", "Arial");
                content = content.Replace("RobotoBold", "Arial");
                content = content.Replace("images/rs3.png", "http://www.kitchenonmyplate.com/images/rs3.png");
                content = content.Replace("class", "style");
                content = content.Replace("page-titleSmallCust", "color:#4b220c; text-transform:uppercase; font-family:'Arial'; font-weight:bold;border-bottom:1px solid #c8c6c6; padding:10px 0 10px 25px ; font-size:25px; margin-top:0px;background:#EEEEEE !important;");
                content = content.Replace("OrderBox", "display:none");
                content = content.Replace("ProcessBox", "width:100%;height:auto;border:1px solid #c8c6c6;padding-bottom:10px;");
                content = content.Replace("ProcesBoxInner", "height:auto; padding:0px 25px 10px 10px;text-align: justify; text-justify: inter-word;");
                content = content.Replace("tbl", "width:100%;height:auto;border:1px solid #c8c6c6;");
                content = content.Replace("divRowHeader", "font-weight:bold; color:Black; font-size:0.85em;");
                content = content.Replace("<table", "<table style='border-collapse:collapse; border-spacing:0;' ");
                content = content.Replace("price", "font-weight:700; font-size:1.2em; color: #006400;");
                content = content.Replace("priceTotaltxt", "font-weight:700; font-size:24px; color: #006400;");
                content = content.Replace("priceTotal", "font-size:30px; color: #006400; padding-right:25px;");
                content = content.Replace("CUSTBOX", "");
                content = content.Replace("emailH5", "font-size:14px;");
                content = content.Replace("<i style='fa fa-inr'></i>", "Rs. ");

                content = content.Replace(">01<", "");
                content = content.Replace(">03<", "");   

                if (!string.IsNullOrEmpty(txtLastName.Value)) //Note : last name is as emailid
                {
                    MailHelper.SendMailMessage("", txtLastName.Value, string.Empty, string.Empty, "KOMP : Confirm your order", content);
                    AutoServices.SendeMailToUs("Copy:KOMP : KOMP : Confirm your order", content);

                }
                #endregion

                Session.Remove("OrderList");
                Response.Redirect("/");

            }
        }

        //Final
        public void ShowOrderDetails()
        {
            Decimal subTotal = 0;
            Decimal tranChrg = 0;
            Decimal deliveryChrg = 0;
            string colspan = "0";
            string startdate = string.Empty;
            string productName = "Customized Meals";
            string Quantity = string.Empty;
            string mealstartdate = string.Empty;
            
            var requesedItems = DBAccess.GetRequestedItems(Convert.ToInt32(Request.QueryString["requestId"]));

            int indx = 0;
            foreach (var item in requesedItems)
            {
                var LunchDinner = item.IsTiffin == 1 ? "LUNCH" : "DINNER";
                string mealType = string.Empty;
                mealType = (item.nonCustomized == 0) ? "CUSTOMIZED MEALS" : item.orderedItems[0].ProductName;
                //if (item.nonCustomized == 0)//Customized
                //{
                //    mealType = "CUSTOMIZED MEALS";
                ////    tbOrders.Text = tbOrders.Text + "<tr class='divRow dataHeader'><td><b>MEAL NAME</b></td><td><b>PRICE</b></td><td><b>QUANTITY</b></td><td><b>TOTAL</b></td></tr>";
                ////    colspan = "3";                    
                //}
                //else
                //{
                //    if (item.IsTiffin == 1)
                //    {
                //        mealType = (item.nonCustomized == 0) ? "CUSTOMIZED MEALS" : ((item.IsTiffin == 1) ? "LUNCH" : "Dinner");
                //    }

                //    //tbOrders.Text = tbOrders.Text + "<tr class='divRow dataHeader'><td><b>MEAL DETAILS</b></td><td><b>AMOUNT DETAILS</b></td></tr>";
                //    //colspan = "0";
                //}

                tbOrders.Text = tbOrders.Text + "<tr class='divRow cstItem' id='Ord" + item.orderId.ToString() + "' align='center'></td><td  style='width:10%;'>" + (indx + 1) + ".</td><td  style='width:60%;'  align='left'> <span>" + mealType + "</span><br/><span class='startDate'>MEAL START DATE : " + Convert.ToDateTime(item.orderedItems[0].DeliverDate).ToString("dd/MM/yyyy") + "<br/>MEAL TYPE : " + LunchDinner + "</span></td><td><span> " + item.orderedItems.Count + "</span></td><td style='width:30%;' align='right'><span class='RSBig'></span><span id='spCharge' class='priceTotal'><i class='fa fa-inr'></i>" + item.subTotal + "</span></td></tr>";

                //"$("#divFinal .tableCart tbody").append(
                
                //int indx = 0;
                //foreach (var odr in item.orderedItems)
                //{
                //    indx++;

                //    if (indx == 1)
                //    {
                //        startdate = odr.DeliverDate.ToString();
                //        mealstartdate = odr.DeliverDate.ToString();
                //    }
                //    if (item.nonCustomized == 0)
                //    {//Customized
                //        tbOrders.Text = tbOrders.Text + "<tr class='divRow divRowData'><td>" + odr.ProductName + ".</td><td>" + odr.Price + "</td><td>1</td><td>" + odr.Price + "</td></tr>";
                //    }
                //    else
                //    {//Tiffin
                //        if (indx == 1)
                //        {
                //            tbOrders.Text = tbOrders.Text + "<tr class='divRow'><td style='width:70%;' id='divPNAME'> <span class='price'>" + odr.ProductName + "</span></td><td style='width:30%;' align='center'><strong>" + odr.Price ?? 0 * item.orderedItems.Count + "</strong></td></tr>";
                //            productName = odr.ProductName;
                //        }
                //    }
                //}

                //Quantity = item.orderedItems.Count.ToString();
                subTotal = subTotal+item.subTotal;
                deliveryChrg = deliveryChrg + item.deliveryCharges;
                tranChrg = tranChrg + item.transCharges;

                //tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'><td colspan='" + colspan + "'><b>Sub Total &nbsp;&nbsp; </b> </td><td align='center'><b>" + item.subTotal + "</b></td></tr>";
                //tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'><td colspan='" + colspan + "'><b>Delivery Charges&nbsp;&nbsp;</b>  </td><td align='center'><b>" + item.deliveryCharges + "</b></td></tr>";

                //if (item.transCharges > 0)
                //{
                //    tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'><td colspan='" + colspan + "'><b>Online Transaction Charges&nbsp;&nbsp;</b>  </td><td align='center'><b>" + item.transCharges + "</b></td></tr>";
                //}

                //tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'  ><td colspan='" + colspan + "'><span style='font-family:RobotoBlack' >Amount&nbsp;&nbsp;</span>  </td><td align='center' ><span style='font-family:RobotoBlack' >" + item.grandTotal + "</span></td></tr>";
                indx++;
            }

            trTran.Visible = tranChrg > 0;

            string transactionStr = tranChrg.ToString();
            if (method == "14") //Cash check pickup
            {
                spOT.InnerHtml = "CASH PICK UP CHARGE";
                 var config = DBAccess.GetConfig();
                tranChrg = Convert.ToInt32(tranChrg + config.CashPickUp??0);
                transactionStr = tranChrg + ".00";
            }

            spnShip.InnerHtml = "<i class='fa fa-inr'></i>" + deliveryChrg.ToString();
            spnTrns.InnerHtml = "<i class='fa fa-inr'></i>" + transactionStr;
            spnOnlineGrandTotal.InnerHtml = "<i class='fa fa-inr'></i>" + (subTotal + deliveryChrg + tranChrg).ToString(); ;

            ////spnSubTotal.InnerText = subTotal.ToString();
            ////// spnDelivery.InnerText = deliveryChrg.ToString();
            ////spnTrns.InnerText = deliveryChrg.ToString();
            ////spnOnlineGrandTotal.InnerText = (subTotal + deliveryChrg + tranChrg).ToString();


            ////var shippingBilling = DBAccess.GetShippingBilling(Convert.ToInt32(objPaymentResponse.RequestId));
            ////strongBilling.InnerText = shippingBilling.Address;
            ////strongDelivery.InnerText = shippingBilling.AddressB;
        }


        //public void ShowOrderDetails()
        //{
        //    int subTotal = 0;
        //    int tranChrg = 0;
        //    int deliveryChrg = 0;
        //    string colspan = "0";
        //    string startdate = string.Empty;
        //    string productName = "Customized Meals";
        //    string Quantity = string.Empty;
        //    string mealstartdate = string.Empty;
        //    var requesedItems = DBAccess.GetRequestedItems(Convert.ToInt32(Request.QueryString["requestId"]));
        //    foreach (var item in requesedItems)
        //    {


        //        if (item.nonCustomized == 0)
        //        {
        //            tbOrders.Text = tbOrders.Text + "<tr class='divRow dataHeader'><td><b>MEAL NAME</b></td><td><b>PRICE</b></td><td><b>QUANTITY</b></td><td><b>TOTAL</b></td></tr>";
        //            colspan = "3";
        //        }
        //        else
        //        {
        //            tbOrders.Text = tbOrders.Text + "<tr class='divRow dataHeader'><td><b>MEAL DETAILS</b></td><td><b>AMOUNT DETAILS</b></td></tr>";
        //            colspan = "0";
        //        }


        //        int indx = 0;
        //        foreach (var odr in item.orderedItems)
        //        {
        //            indx++;

        //            if (indx == 1)
        //            {
        //                startdate = odr.DeliverDate.ToString();
        //                mealstartdate = odr.DeliverDate.ToString();
        //            }
        //            if (item.nonCustomized == 0)
        //            {//Customized
        //                tbOrders.Text = tbOrders.Text + "<tr class='divRow divRowData'><td>" + odr.ProductName + ".</td><td>" + odr.Price + "</td><td>1</td><td>" + odr.Price + "</td></tr>";
        //            }
        //            else
        //            {//Tiffin
        //                if (indx == 1)
        //                {
        //                    tbOrders.Text = tbOrders.Text + "<tr class='divRow'><td style='width:70%;' id='divPNAME'> <span class='price'>" + odr.ProductName + "</span></td><td style='width:30%;' align='center'><strong>" + odr.Price ?? 0 * item.orderedItems.Count + "</strong></td></tr>";
        //                    productName = odr.ProductName;
        //                }
        //            }
        //        }

        //        Quantity = item.orderedItems.Count.ToString();
        //        subTotal = item.subTotal;
        //        deliveryChrg = item.deliveryCharges;
        //        tranChrg = item.transCharges;

        //        tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'><td colspan='" + colspan + "'><b>Sub Total &nbsp;&nbsp; </b> </td><td align='center'><b>" + item.subTotal + "</b></td></tr>";
        //        tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'><td colspan='" + colspan + "'><b>Delivery Charges&nbsp;&nbsp;</b>  </td><td align='center'><b>" + item.deliveryCharges + "</b></td></tr>";

        //        if (item.transCharges > 0)
        //        {
        //            tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'><td colspan='" + colspan + "'><b>Online Transaction Charges&nbsp;&nbsp;</b>  </td><td align='center'><b>" + item.transCharges + "</b></td></tr>";
        //        }

        //        tbOrders.Text = tbOrders.Text + "<tr class='divRow' align='right'  ><td colspan='" + colspan + "'><span style='font-family:RobotoBlack' >Amount&nbsp;&nbsp;</span>  </td><td align='center' ><span style='font-family:RobotoBlack' >" + item.grandTotal + "</span></td></tr>";
        //    }

        //    ////spnSubTotal.InnerText = subTotal.ToString();
        //    ////// spnDelivery.InnerText = deliveryChrg.ToString();
        //    ////spnTrns.InnerText = deliveryChrg.ToString();
        //    ////spnOnlineGrandTotal.InnerText = (subTotal + deliveryChrg + tranChrg).ToString();


        //    ////var shippingBilling = DBAccess.GetShippingBilling(Convert.ToInt32(objPaymentResponse.RequestId));
        //    ////strongBilling.InnerText = shippingBilling.Address;
        //    ////strongDelivery.InnerText = shippingBilling.AddressB;
        //}


    }
}