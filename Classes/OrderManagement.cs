using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Configuration;
using System.Net;
using KitchenOnMyPlate.DataAccess;
using System.Web.Script.Serialization;
using System.Collections;

namespace KitchenOnMyPlate.Classes
{
    public class OrderManagement
    {
        public static string CreateOrdersSession(OrderList orders)
        {

            //if (HttpContext.Current.Session["OrderList"] != null)
            //{             
            //    var ordersOld = (OrderList)HttpContext.Current.Session["OrderList"];
            //    ordersOld.orders.AddRange(orders.orders);
            //    HttpContext.Current.Session["OrderList"] = ordersOld;
            //    orders = ordersOld;
            //}
            //else
            //{
           
            
                HttpContext.Current.Session["OrderList"] = orders;
            //}

            return CreatePlacedOrderHTML(orders);// orderDTO.Order.Id;
            
        }

        public static string CreateOrdersSessionOnHome(int indx)
        {
            OrderList orders = new OrderList();
            if (HttpContext.Current.Session["OrderList"] != null)
            {
                orders = (OrderList)HttpContext.Current.Session["OrderList"];
                orders.orders.RemoveAt(indx);                 
            }

            HttpContext.Current.Session["OrderList"] = orders;
            //}

            return CreatePlacedOrderHTML(orders);// orderDTO.Order.Id;

        }


        public static string GetPlacedOrders()
        {
            string strOrders = string.Empty;
            if (HttpContext.Current.Session["OrderList"]!=null)
            {
            OrderList orders =(OrderList) HttpContext.Current.Session["OrderList"];
            strOrders = CreatePlacedOrderHTML(orders);            
            }
            return strOrders;// orderDTO.Order.Id;

        }

        public static bool AllowPayemntOnRequesteOrder(int requestId)
        {
            bool allowtopayment = true;
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var orders = (from w in db.Orders where w.RequestId == requestId select w).ToList();

                //if any order having start date is equal or less than current date then now allowing to payment
                foreach (var ord in orders)
                {
                    if (ord.OrderStartDate.Value <= DateTime.Today.Date)
                    {
                        allowtopayment = false;
                    }
                }
            }

            return allowtopayment;
           
        }

        /// <summary>
        /// IT is the method where user placed checkout button of cart (top right)
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public static string GetPlacedOrderFinalHTML()
        {
            string strOrders = string.Empty;
            string TotalDetails = string.Empty;
            Decimal subTotal = 0;
            Decimal tranChrg = 0;
            Decimal deliveryChrg = 0;
            string colspan = "0";
            string startdate = string.Empty;
            string productName = "Customized Meals";
            string Quantity = string.Empty;
            string mealstartdate = string.Empty;

            int indx = 0;

            OrderList orders = new OrderList();
            if (HttpContext.Current.Session["OrderList"] != null)
            {
                orders = (OrderList)HttpContext.Current.Session["OrderList"];                
            }            

            foreach (var item in orders.orders)
            {

                string mealType = string.Empty;
                //mealType = (item.Order.NonCustomized == 0) ? "CUSTOMIZED MEALS" : ((item.Order.IsLunch == 1) ? "LUNCH" : "Dinner");
                mealType = (item.Order.NonCustomized == 0) ? "CUSTOMIZED MEALS" : GetSubProductNameById(item.OrderDetailList[0].SubProductId);
                var LunchDinner = item.Order.IsLunch == 0 ? "LUNCH" : "DINNER";
                //strOrders = strOrders + "<tr class='divRow cstItem' id='Ord" + item.Order.Id.ToString() + "' align='center'></td><td  style='width:10%;'>" + (orders.orders.Count - indx) + ".</td><td  style='width:60%;'  align='left'> <span>" + mealType + "</span><br/><span class='startDate'>MEAL START DATE : " + item.OrderDetailList[0].DeliverDate + "</span></td><td><span> " + item.OrderDetailList.Count + "</span></td><td style='width:30%;' align='center'><span id='spCharge' class='price'><img alt='rs' src='images/rs3.png' style='margin-top: -10px;'/>" + item.payment.Amount + "</span></td></tr>";
                //strOrders = strOrders + "<tr class='divRow cstItem' id='OrdHome" + indx + "' align='center'><td  style='width:10%;' align='center' ><span class='deleteProduct' onclick='DeleteOrderOnHome(" + indx + ");' title='Delete Order' >x</span>&nbsp;</td><td  style='width:10%;'>" + (indx + 1) + ".</td><td  style='width:60%;'  align='left'> <span>" + mealType + "</span><br/><h2 class='startDate'>MEAL START DATE : " + item.OrderDetailList[0].DeliverDate.Value.ToString("dd/MM/yyyy") + "<br/>MEAL TYPE : " + LunchDinner + "</h2></td><td><span> " + item.OrderDetailList.Count + "</span></td><td style='width:30%;' align='center'><span id='spCharge' class='price'><i class='fa fa-inr'></i>" + item.payment.Amount + "</span></td></tr>";
                strOrders = strOrders + "<tr class='divRow cstItem Ord" + (indx + 1) + "' align='center'><td  style='width:10%;'><span class='deleteProduct' onclick='DeleteOrderOnHome(" + indx + ");' title='Delete Order' >x</span></td><td  style='width:10%;'>" + (indx + 1) + ".</td><td  style='width:60%;'  align='left'> <span>" + mealType + "</span><br/><span class='startDate'>MEAL START DATE : " + item.OrderDetailList[0].DeliverDate.Value.ToString("dd/MM/yyyy") + "<br/>MEAL TYPE : " + LunchDinner + "</span></td><td><span> " + item.OrderDetailList.Count + "</span></td><td style='width:30%;' align='right'><span id='spCharge' class='priceTotal'><i class='fa fa-inr'></i>" + String.Format("{0:.00}", item.payment.Amount) + "</span></td></tr>";
                subTotal = subTotal + item.payment.Amount ?? 0;
                deliveryChrg = deliveryChrg + item.payment.DeliveryChrg ?? 0;
                tranChrg = tranChrg + item.payment.TrnChrg ?? 0;

                indx++;
            }

            Decimal TransactionCharge = (subTotal + deliveryChrg) * 4 / 100;
            Decimal gtotal =  (subTotal + deliveryChrg + TransactionCharge);

            strOrders = strOrders + "<tr class='divRow'><td colspan='4' style='width:70%;' align='right'><span class='priceTotaltxt'>DELIVERY CHARGE &nbsp;&nbsp;&nbsp;</span></td><td style='width:30%;' align='center' ><span id='spCharge' class='priceTotal'><i class='fa fa-inr'></i>" + String.Format("{0:.00}", deliveryChrg) + "</span></td></tr>";
            strOrders = strOrders + "<tr class='divRow'><td colspan='4' style='width:70%;' align='right'><span class='priceTotaltxt'>ONLINE PROCESSING CHARGE &nbsp;&nbsp;&nbsp;</span></td><td style='width:30%;' align='center' ><span id='spnTrns' class='priceTotal onChrges'><i class='fa fa-inr'></i>" + String.Format("{0:.00}", TransactionCharge) + "</span></td></tr>";
            strOrders = strOrders + "<tr class='divRow'><td colspan='4' style='width:70%;' align='right'><span class='priceTotaltxt'>TOTAL AMOUNT&nbsp;&nbsp;&nbsp;</span></td><td style='width:30%;' align='center' ><span class='priceTotal'><i class='fa fa-inr'></i>" + String.Format("{0:.00}", gtotal) + "</span></td></tr>";

            TotalDetails = orders.orders.Count + "^" + (subTotal + deliveryChrg + tranChrg).ToString();

            return strOrders + "$" + TotalDetails;
        }

        private static string CreatePlacedOrderHTML(OrderList orders)
        {
            string strOrders = string.Empty;
            string TotalDetails = string.Empty;
            Decimal subTotal = 0;
            Decimal tranChrg = 0;
            Decimal deliveryChrg = 0;
            string colspan = "0";
            string startdate = string.Empty;
            string productName = "Customized Meals";
            string Quantity = string.Empty;
            string mealstartdate = string.Empty;

            int indx = 0;

            foreach (var item in orders.orders)
            {

                string mealType = string.Empty;
                //mealType = (item.Order.NonCustomized == 0) ? "CUSTOMIZED MEALS" : ((item.Order.IsLunch == 1) ? "LUNCH" : "Dinner");
                mealType = (item.Order.NonCustomized == 0) ? "CUSTOMIZED MEALS" : GetSubProductNameById(item.OrderDetailList[0].SubProductId);
                var LunchDinner = item.Order.IsLunch == 0 ? "LUNCH" : "DINNER";
                //strOrders = strOrders + "<tr class='divRow cstItem' id='Ord" + item.Order.Id.ToString() + "' align='center'></td><td  style='width:10%;'>" + (orders.orders.Count - indx) + ".</td><td  style='width:60%;'  align='left'> <span>" + mealType + "</span><br/><span class='startDate'>MEAL START DATE : " + item.OrderDetailList[0].DeliverDate + "</span></td><td><span> " + item.OrderDetailList.Count + "</span></td><td style='width:30%;' align='center'><span id='spCharge' class='price'><img alt='rs' src='images/rs3.png' style='margin-top: -10px;'/>" + item.payment.Amount + "</span></td></tr>";
                strOrders = strOrders + "<tr class='divRow cstItem' id='OrdHome" + indx + "' align='center'><td  style='width:10%;' align='center' ><span class='deleteProduct' onclick='DeleteOrderOnHome(" + indx + ");' title='Delete Order' >x</span>&nbsp;</td><td  style='width:10%;'><span>" + (indx + 1) + ".</span></td><td  style='width:60%;'  align='left'> <span>" + mealType + "</span><br/><h2 class='startDate'>MEAL START DATE : " + item.OrderDetailList[0].DeliverDate.Value.ToString("dd/MM/yyyy") + "<br/>MEAL TYPE : " + LunchDinner + "</h2></td><td><span> " + item.OrderDetailList.Count + "</span></td><td style='width:30%;' align='center'><span id='spCharge' class='price'><i class='fa fa-inr'></i>" + item.payment.Amount + "</span></td></tr>";

                subTotal = subTotal + item.payment.Amount ?? 0;
                deliveryChrg = deliveryChrg + item.payment.DeliveryChrg ?? 0;
                tranChrg = tranChrg + item.payment.TrnChrg ?? 0;

                indx++;
            }

            strOrders = strOrders + "<tr class='divRow'><td colspan='4' style='width:70%;' align='right'><span class='priceTotaltxt'>DELIVERY CHARGE &nbsp;&nbsp;&nbsp;</span></td><td style='width:30%;' align='center' ><span id='spCharge' class='priceTotal'><i class='fa fa-inr'></i>" + deliveryChrg.ToString() + "</span></td></tr>";
            strOrders = strOrders + "<tr class='divRow'><td colspan='4' style='width:70%;' align='right'><span class='priceTotaltxt'>TOTAL AMOUNT&nbsp;&nbsp;&nbsp;</span></td><td style='width:30%;' align='center' ><span class='priceTotal'><i class='fa fa-inr'></i>" + (subTotal + deliveryChrg).ToString() + "</span></td></tr>";

            //TotalDetails = orders.orders.Count + "^" + (subTotal + deliveryChrg + tranChrg).ToString();
            TotalDetails = orders.orders.Count + "^" + (subTotal + deliveryChrg).ToString();

            return strOrders +"$"+ TotalDetails;
        }

        public static string GetSubProductNameById(int subProId)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
             return (from w in db.MenuItems where w.IsActive == 1 where w.Id == subProId select w).First().Header;
            }
        }

        public static void CreateOrderListSession(string requestid)
        {
            OrderList orders = new OrderList();

            //Now taking it from session. instead of perameter.
            if (HttpContext.Current.Session["OrderList"] != null)
            {
                orders = (OrderList)HttpContext.Current.Session["OrderList"];
            }
            else
            {
                orders.orders = new List<OrderDTO>(); 
            }
           
            //Below condition : already ordered
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var orders1 = (from w in db.Orders where w.RequestId.ToString() == requestid.ToString() select w).ToList();
                if (orders1.Count > 0)
                {
                    foreach (var order in orders1)
                    {
                            var orderdetails = (from w in db.OrderDetails where w.OrderId == order.Id select w).ToList();
                            var payment1 = (from w in db.Payments where w.OrderId == order.Id select w).First();
                            orders.orders.Add(new OrderDTO { Order = order,  OrderDetailList = orderdetails, payment  = payment1 }); 
                    }                    
                }
                
                HttpContext.Current.Session["OrderList"] = orders;              
            }
        }
        public static OrderList GetOrderListSession()
        {
            //Read the cookie from Request.
            HttpCookie myCookie = HttpContext.Current.Request.Cookies["ORDERLIST"];
            if (myCookie != null)
            {
                if (!string.IsNullOrEmpty(myCookie.Values["ORDERS1"]))
                {
                    if (HttpContext.Current.Session["OrderList"] == null)
                    {
                        CreateOrderListSession(myCookie.Values["ORDERS1"]);
                    }
                }
            }

            if (HttpContext.Current.Session["OrderList"] == null)
            {
                return (new OrderList());
            }
            return ((OrderList)HttpContext.Current.Session["OrderList"]);
        }
        public static void CreateCookieOrderList()
        {

            ////Deleting cookies
            //if (Request.Cookies["ORDERLIST"] != null)
            //{
            //    HttpCookie myCookie = new HttpCookie("ORDERLIST");
            //    myCookie.Expires = DateTime.Now.AddDays(-1d);
            //    Response.Cookies.Add(myCookie);
            //}

          //  if (HttpContext.Current.Request.Cookies["ORDERLIST"] == null)
          //  {
                //create a cookie
                HttpCookie myCookie = new HttpCookie("ORDERLIST");


                //Add key-values in the cookie
                myCookie.Values.Add("ORDERS1", ((OrderList)(HttpContext.Current.Session["OrderList"])).orders[0].Order.RequestId.ToString());
                // myCookie.Values.Add("USERNAME", ((User)(HttpContext.Current.Session["USER"])).FirstName);
                //set cookie expiry date-time. Made it to last for next 12 hours.
                myCookie.Expires = DateTime.Now.AddDays(1d);
                //Most important, write the cookie to client.
                HttpContext.Current.Response.Cookies.Add(myCookie);
           // }
        }

        public static int SaveOrder(string method)
        {
            OrderList orders = new OrderList();

            //Now taking it from session. instead of perameter.
            if (HttpContext.Current.Session["OrderList"] != null)
            {
                orders = (OrderList)HttpContext.Current.Session["OrderList"];
            }
            else
            {
                //It create the orders from the cookies
                if (OrderManagement.GetOrderListSession().orders.Count == 0)
                {
                    return -1;
                }
            }

            //Below condition : already ordered
            

            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                int customerId = 0;
                //if (CommanAction.GetSession() != null)
                //{
                    customerId = CommanAction.GetSession().UserId;
                //}

                //Delete if already in cart
                if (orders.orders.Count > 0 && orders.orders[0].Order.RequestId > 0)
                {

                    foreach (var order in orders.orders)
                    {
                        if (orders.orders.Count > 0 && orders.orders[0].Order.RequestId > 0)
                        {
                            db.OrderDetails.DeleteAllOnSubmit((from w in db.OrderDetails where w.OrderId == order.Order.Id select w));
                            db.Payments.DeleteAllOnSubmit((from w in db.Payments where w.OrderId == order.Order.Id select w));
                        }
                    }
                    db.Requests.DeleteAllOnSubmit((from w in db.Requests where w.Id == orders.orders[0].Order.RequestId select w));
                    db.Orders.DeleteAllOnSubmit((from w in db.Orders where w.RequestId == orders.orders[0].Order.RequestId select w));
                    db.SubmitChanges();
                }


                decimal tranCharge = 0;
                decimal tranChargeConfig = (from w in db.Configs select w).First().TrnChrg ?? 0;

                var config = (from w in db.Configs select w).First();
                decimal Caspikup = config.CashPickUp ?? 0;
                decimal CaspikupPer = config.CashPickUpPercent ?? 0; 



                //////////////////REQUEST START
                Request objRequest = new Request();
                objRequest.CreatedDate = DateTime.Now;
                objRequest.UserId = customerId;
                objRequest.CreatedBy = customerId;

                if (method == "14") //Cash pikup delivery charges by yourguy
                {
                    objRequest.YourGuyChkPickUP = Convert.ToInt32(Caspikup);
                }
                //create a request id
                db.Requests.InsertOnSubmit(objRequest);
                db.SubmitChanges();
                //////////////////REQUEST END

                
                TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime indianTime =  TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                foreach (var order in orders.orders)
                {
                    Caspikup = 0;// resetting 0 becuasue unable to divide charges in n order so making o, actial charges are in Request table
                    order.Order.RequestId = objRequest.Id;
                    order.Order.CustomerId = customerId;
                    order.Order.OrderDate = indianTime;// DateTime.Now;
                    order.Order.OrderStartDate = order.OrderDetailList[0].DeliverDate;

                    tranCharge = ((order.payment.Amount + order.payment.DeliveryChrg) * tranChargeConfig / 100) ?? 0;
                    

                    order.Order.TotalPayment = (method == "11" || method == "12" || method == "13")?0:(order.payment.Amount + tranCharge + order.payment.DeliveryChrg);

                    if (method == "14")//Cas pikup
                    {
                        order.Order.TotalPayment = (method == "11" || method == "12" || method == "13") ? 0 : (order.payment.Amount + Caspikup + order.payment.DeliveryChrg);
                    }

                    
                    db.Orders.InsertOnSubmit(order.Order);
                    db.SubmitChanges();

                    

                    if (method == "14") //Cash pikup delivery
                    {
                        order.payment.TrnChrg = Convert.ToDecimal(Caspikup + CaspikupPer * (order.payment.Amount + order.payment.DeliveryChrg) / 100);
                        //Round off for cash pickup
                    }
                    else if (method == "11" || method == "12" || method == "13")
                    {
                        order.payment.TrnChrg = 0; //Add 0 if offline else calculate trans charge
                    }
                    else
                    {
                        order.payment.TrnChrg = tranCharge; //for online calculate trans charge
                    }


                    order.payment.OrderId = order.Order.Id;
                    db.Payments.InsertOnSubmit(order.payment);

                    foreach (var apt in order.OrderDetailList)
                    {
                        apt.OrderId = order.Order.Id;
                    }

                    db.OrderDetails.InsertAllOnSubmit(order.OrderDetailList);
                }

                db.SubmitChanges();

                //#region Send Mail
                //if (HttpContext.Current.Session["USER"] != null)
                //{                  
                //    var objtblUser = (User)HttpContext.Current.Session["USER"];

                //    string content = string.Empty;

                //    string filepath = "~/Email/Post.htm";
                //    //New user
                //    StringBuilder sbContent = new StringBuilder();
                //    StreamReader rdr = new StreamReader(HttpContext.Current.Server.MapPath(filepath));
                //    string strLine = "";
                //    while (strLine != null)
                //    {
                //        strLine = rdr.ReadLine();
                //        if ((strLine != null) && (strLine != ""))
                //        {
                //            sbContent.Append("\n" + strLine);
                //        }
                //    }
                //    rdr.Close();

                //    string site = ConfigurationManager.AppSettings["SiteName"].ToString();
                //    content = sbContent.ToString();
                //    //content = content.Replace("$REQ$", PostType);
                //    //content = content.Replace("$ID$", ID);
                //    content = content.Replace("$NAME$", objtblUser.FirstName + " " + objtblUser.LastName);
                //    content = content.Replace("$SITE$", site);

                //    if (!string.IsNullOrEmpty(objtblUser.email))
                //    {
                //        MailHelper.SendMailMessage("", objtblUser.email, string.Empty, string.Empty, "Thanks for Posting", content);
                //       // AutoServices.SendeMailToUs("Copy:Thanks for Posting", content);

                //    }
                //}
                //#endregion

                // HttpContext.Current.Session["OrderList"] = orders;
                   
                HttpContext.Current.Session["OrderList"] = orders;

                CreateCookieOrderList();
                return objRequest.Id;// orderDTO.Order.Id;
            }
        }
        //public static int SaveOrder(OrderList orders)
        //{
        //    //Now taking it from session. instead of perameter.
        //    if (HttpContext.Current.Session["OrderList"] != null)
        //    {
        //        orders = (OrderList)HttpContext.Current.Session["OrderList"];                
        //    }

        //    using (DBKOMPDataContext db = new DBKOMPDataContext())
        //    {
        //        int customerId = 0;
        //        if (HttpContext.Current.Session["USER"] != null)
        //        {
        //            customerId = ((User)HttpContext.Current.Session["USER"]).UserId;
        //        }



        //        Request objRequest = new Request();
        //        objRequest.CreatedDate = DateTime.Now;
        //        objRequest.UserId = customerId;
        //        objRequest.CreatedBy = customerId;

        //        //create a request id
        //        db.Requests.InsertOnSubmit(objRequest);
        //        db.SubmitChanges();

        //        foreach(var order in orders.orders)
        //        {
        //            order.Order.RequestId = objRequest.Id;
        //            order.Order.CustomerId = customerId;
        //            order.Order.OrderDate = DateTime.Now;
        //            db.Orders.InsertOnSubmit(order.Order);
        //            db.SubmitChanges();

        //            order.payment.OrderId = order.Order.Id;
        //            db.Payments.InsertOnSubmit(order.payment);

        //            foreach (var apt in order.OrderDetailList)
        //            {
        //                apt.OrderId = order.Order.Id;
        //            }

        //            db.OrderDetails.InsertAllOnSubmit(order.OrderDetailList);
        //        }

        //        db.SubmitChanges();

        //        //#region Send Mail
        //        //if (HttpContext.Current.Session["USER"] != null)
        //        //{                  
        //        //    var objtblUser = (User)HttpContext.Current.Session["USER"];

        //        //    string content = string.Empty;

        //        //    string filepath = "~/Email/Post.htm";
        //        //    //New user
        //        //    StringBuilder sbContent = new StringBuilder();
        //        //    StreamReader rdr = new StreamReader(HttpContext.Current.Server.MapPath(filepath));
        //        //    string strLine = "";
        //        //    while (strLine != null)
        //        //    {
        //        //        strLine = rdr.ReadLine();
        //        //        if ((strLine != null) && (strLine != ""))
        //        //        {
        //        //            sbContent.Append("\n" + strLine);
        //        //        }
        //        //    }
        //        //    rdr.Close();

        //        //    string site = ConfigurationManager.AppSettings["SiteName"].ToString();
        //        //    content = sbContent.ToString();
        //        //    //content = content.Replace("$REQ$", PostType);
        //        //    //content = content.Replace("$ID$", ID);
        //        //    content = content.Replace("$NAME$", objtblUser.FirstName + " " + objtblUser.LastName);
        //        //    content = content.Replace("$SITE$", site);

        //        //    if (!string.IsNullOrEmpty(objtblUser.email))
        //        //    {
        //        //        MailHelper.SendMailMessage("", objtblUser.email, string.Empty, string.Empty, "Thanks for Posting", content);
        //        //       // AutoServices.SendeMailToUs("Copy:Thanks for Posting", content);

        //        //    }
        //        //}
        //        //#endregion

        //       // HttpContext.Current.Session["OrderList"] = orders;

        //        return objRequest.Id;// orderDTO.Order.Id;
        //    }
        //}

        public static int SavePayemt(int requestId, int paymentStatus, int paymentMode, string cardNum, string trnNo, string NameOnCard)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var objtblUser = CommanAction.GetSession();//for yourguyonly
                var orders = (from w in db.Orders where w.RequestId == requestId select w).ToList();

                var SipBilObj = new ShippingBilling();

                string locationOfPinCode = string.Empty;
                if (orders.Count > 0)
                {
                    locationOfPinCode = (from w in db.tblLocations where w.pincode.Value == orders[0].pincode select w).First().Location;
                }

                //Variable is using to add 25 rs only one time
                bool IsCashPickup25Added = false;
                    foreach (var ord in orders)
                    {
                        

                        if( string.IsNullOrEmpty(SipBilObj.Pincode))
                        {
                        SipBilObj = DBAccess.GetShippingBillingByUserId(objtblUser.UserId,ord.pincode??0);//for yourguyonly
                        }

                        if (requestId>0)
                        {
                            var payment = (from w in db.Payments where w.OrderId == ord.Id select w).First();
                            //paymentObj.Amount = 200;
                            payment.CardNumber = cardNum;
                            payment.Mode = paymentMode; //NET BANKING-1, credit card-2, debit card - 3, cash card - 4, mobile payment-5
                            payment.NameOnCard = NameOnCard;
                            payment.TransactionNo = trnNo;
                            payment.IsActive = (paymentStatus == 1) ? 1 : 0;
                            payment.PaymentDate = DateTime.Now;


                            //Settign for offline casehpickup
                            if (paymentMode == 14 && !IsCashPickup25Added)
                            {
                                var config = DBAccess.GetConfig();
                                //order.payment.TrnChrg = Convert.ToDecimal(Caspikup + CaspikupPer * (order.payment.Amount + order.payment.DeliveryChrg) / 100);
                                payment.TrnChrg = Convert.ToDecimal(config.CashPickUpPercent * (payment.Amount + payment.DeliveryChrg) / 100) + config.CashPickUp ?? 0;

                                payment.TrnChrg = Convert.ToDecimal(String.Format("{0:.00}", payment.TrnChrg));

                                //payment.TrnChrg = Convert.ToInt32(payment.TrnChrg + config.CashPickUp ?? 0);
                                IsCashPickup25Added = true;
                            }


                            ord.PaymentDone = paymentStatus;//SUCCESS -1 , failure - 0 , invalid =3, abort = 4 ---  paymentMode != 5 ? 1 : 0; //5 means offline
                            ord.IsActive = (paymentStatus==1)?1:0;



                            if (paymentStatus == 1 && (paymentMode != 11 && paymentMode != 12 && paymentMode != 13 && paymentMode != 14)) //Not offline and not cash pickup
                            {
                                var orderDetails = (from w in db.OrderDetails where w.OrderId == ord.Id select w);

                                //Yourguy  productid
                                var prodcId = "0";                                
                                //Your guy DateColletion 
                                List<string> lstDeliveryDate = new List<string>();
                                //Your guy time
                                string Deliverytime = ord.IsLunch == 1 ? "2015-01-01T12:15:02Z" : "2015-01-01T20:15:02Z";
                                string time = ord.IsLunch == 1 ? "12:16:06Z" : "20:16:06Z";
                                string PickUptime = ord.IsLunch == 1 ? "2015-01-01T10:16:06Z" : "2015-01-01T18:16:06Z";


                                foreach (var od in orderDetails)
                                {
                                    prodcId = "0";// od.SubProductId.ToString();
                                    lstDeliveryDate.Add(od.DeliverDate.Value.ToString("yyyy-MM-ddT") + time);

                                    od.IsActive = 1;
                                    //od.YourguyOrderId = YourGuy(od.Id.ToString(), ord.Id.ToString(), SipBilObj, od.DeliverDate.Value.ToString("yyyy-MM-ddT") + time);
                                    //"2015-07-22T12:16:06Z"
                                }

                                //Yourguy service TODO: UNDO ONCE READY BY YOUR GUY
                                //ord.YourguyOrderId = CallYourGuy(prodcId, ord.Id.ToString(), SipBilObj, Deliverytime, PickUptime, lstDeliveryDate, locationOfPinCode);
                            }

                            

                            db.SubmitChanges();

                            
                        }
                        //else
                        //{
                        //    //ord.PaymentDone = 3; //Payment Failed
                        //    //ord.IsActive = 1;
                        //    //db.SubmitChanges();    
                        //}
                        
                    }
                    
               
                
                return 1;
            }
        }

        public static int CallYourGuy()
        {
            int yourGuyOrderId = 0;

            // Create a request for the URL.       
            var request = WebRequest.Create("http://yourguytestserver.herokuapp.com/api/v1/order/0/place_order/");
            ((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            request.Headers.Add("Authorization", "Token OTMyMzYyMDAzMTp2ZW5kb3I=");
            

            //System.Web.Script.Serialization.JavaScriptSerializer jSearializer =  new System.Web.Script.Serialization.JavaScriptSerializer();
            //var datecollecion = jSearializer.Serialize(deliverydateCollection);
            ////JsonConvert.SerializeObject(keys);
            

            //string json = "{" + "\"pickup_address\": {" + "\"flat_number\":\"" + flatnoPickup + "\"," + "\"building\":\"" + buildingPickup + "\"," + "\"street\":\"" + streetPickup + "\"," + "\"landmark\":\"" + landMarkPickup + "\"," + "\"pincode\":\"400072\"}," +
            //    "" + "\"delivery_address\": {" + "\"flat_number\":\"" + flatno + "\"," + "\"building\":\"" + building + "\"," + "\"street\":\"" + street + "\"," + "\"landmark\":\"" + SipBilObj.LandMark + "\"," + "\"pincode\":\"" + SipBilObj.Pincode + "\"}," +
            //        "" + "\"order_items\": [{" + "\"product_id\":\"" + productid + "\"," + "\"quantity\": 1}]," +
            //        "" + "\"recurring\": {" + "\"start_date\":null," + "\"end_date\":null," + "\"by_day\":null," + "\"additional_dates\":" + datecollecion + "}," +
            //    "" + "\"is_reverse_pickup\":\"false\"," + "\"customer_phone_number\":\"" + SipBilObj.mobile + "\"," + "\"vendor_order_id\":\"" + orderid + "\"," + "\"customer_name\":\"" + SipBilObj.FirstName + "\"," + "\"delivery_datetime\":\""+ deliverytime +"\"," + "\"pickup_datetime\":\"" + pickuptime + "\"" +
            //    "}";


            




            //Working below
            //string json = "{" + "\"pickup_address\": {" + "\"flat_number\":\"" + flatnoPickup + "\"," + "\"building\":\"" + buildingPickup + "\"," + "\"street\":\"" + streetPickup + "\"," + "\"landmark\":\"" + landMarkPickup + "\"," + "\"pincode\":\"400072\"}," +
            //    "" + "\"delivery_address\": {" + "\"flat_number\":\"" + flatno + "\"," + "\"building\":\"" + building + "\"," + "\"street\":\"" + street + "\"," + "\"landmark\":\"" + SipBilObj.LandMark + "\"," + "\"pincode\":\"" + SipBilObj.Pincode + "\"}," +
            //        "" + "\"order_items\": [{" + "\"product_id\":\"" + productid + "\"," + "\"quantity\": 1}]," +
            //    "" + "\"is_reverse_pickup\":\"false\"," + "\"customer_phone_number\":\"" + SipBilObj.mobile + "\"," + "\"vendor_order_id\":\"" + orderid + "\"," + "\"customer_name\":\"" + SipBilObj.CompanyName + "\"," + "\"delivery_datetime\":\"" + deliverydateTime + "\"," + "\"pickup_datetime\":\"" + deliverydateTime + "\"" +
            //    "}";

            //string json = "{" + "\"pickup_address\": {" + "\"flat_number\":\"" + flatno + "\"," + "\"building\":\"trade avanue\"," + "\"street\":\"suren road\"," + "\"landmark\":\"suren road\"," + "\"pincode\":\"1233\"}," +
            //    "" + "\"delivery_address\": {" + "\"flat_number\":\"" + flatno + "\"," + "\"building\":\"trade avanue\"," + "\"street\":\"suren road\"," + "\"landmark\":\"suren road\"," + "\"pincode\":\"1233\"}," +
            //    "" + "\"order_items\": [{" + "\"flat_number\":\"" + flatno + "\"," + "\"building\":\"trade avanue\"," + "\"street\":\"suren road\"," + "\"landmark\":\"suren road\"," + "\"pincode\":\"1233\"}]," +
            //    "" + "\"is_reverse_pickup\":\"" + flatno + "\"," + "\"customer_phone_number\":\"9959026007\"," + "\"customer_name\":\"Mahesh\"," + "\"delivery_datetime\":\"2015-07-22T12:16:06Z\"," + "\"pickup_datetime\":\"2015-07-22T12:16:06Z\"" +
            //    "}";

            //request.ContentType = "application/json"; //your contentType, Json, text,etc. -- or comment, for text
            //request.ContentLength = json.Length;
            //request.Method = WebRequestMethods.Http.Post; // "Post"; //method, GET, POST, etc -- or comment for GET


            ////request.PERA
            ////Stream dataStream = request.GetRequestStream();
            //var streamWriter = new StreamWriter(request.GetRequestStream());
            //streamWriter.Write(json);
            ////streamWriter.Write(json);
            //streamWriter.Flush();
            //dataStream.Write(byteArray, 0, byteArray.Length);
            //streamWriter.Close();

            try
            {
                WebResponse myHttpWebResponse = request.GetResponse();
                Stream responseStream = myHttpWebResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);
                string pageContent = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                responseStream.Close();
                myHttpWebResponse.Close();



            if (pageContent.Contains("order_id"))
            {

                JavaScriptSerializer javaSerial = new JavaScriptSerializer();
               // var obj = javaSerial.DeserializeObject(pageContent);
                //Console.WriteLine(obj["user"]["id"]));
                //yourGuyOrderId = Convert.ToInt32(pageContent.Split('[')[1].Split(']')[0]);
                //JavaScriptSerializer js = new JavaScriptSerializer();
                //AllLiTags[] Tags = js.Deserialize<AllLiTags[]>(pageContent);
                var dict = javaSerial.Deserialize<dynamic>(pageContent);
               // Console.WriteLine(dict["some_number"]); //outputs 108.541
                //Console.WriteLine(dict["more_data"]["field2"]); //outputs hello

                //IDictionary dict = javaSerial.Deserialize<Dictionary<string, object>>(pageContent);

                try
                {

                    yourGuyOrderId = Convert.ToInt32(dict["data"]["order_id"]);//; Dictionary<string, object>)(dict["data"])))).Items[0].Value
                }
                catch (Exception ex)
                {
                    throw ex;
                }



            }
            }
            catch (Exception ex)
            {
             //   HttpContext.Current.Response.Write(json);
                throw  ex;
            }

            return yourGuyOrderId;

            //"{"data":{"order_id":[319]},"message":"Your Order has been placed."}"

            //var httpResponse = (HttpWebResponse)request.GetResponse();
            ////using (var streamReader = new StreamReader(request.GetResponseStream()))
            ////{
            ////    var result = streamReader.ReadToEnd();
            ////}

            //  dataStream.Close();
            //try
            //{

            //    using (WebResponse resp = request.GetResponse())
            //    {
            //        if (resp == null)
            //            new Exception("Response is null");

            //        // return resp.GetResponseStream();//Get stream
            //    }

            //    // dataStream.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;                
            //}

        }

    }

    public class AllLiTags
    {
        public string Id { get; set; }
        public string Index { get; set; }
    }
}