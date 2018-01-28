using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using KitchenOnMyPlate.Classes;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;
using System.Configuration;
using KitchenOnMyPlate.DataAccess;

namespace KitchenOnMyPlate
{
    /// <summary>
    /// Summary description for KompServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class KompServices : System.Web.Services.WebService
    {
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;

        String cs = System.Configuration.ConfigurationManager.ConnectionStrings["DevKOMPConnectionString"].ConnectionString;

        [WebMethod()]
        public int CorporateMessage(string name, string mobile, string email, string message, string compName, string location, string noofpeople, string besttimetocall)
        {
            //DBKotaEstateDataContext db = new DBKotaEstateDataContext();

           // Message msg = new Message { mobile = mobile, email = email, name = name, message1 = message, touser = agentId, CreatedOn = DateTime.Now, propertyId = propertyId };

            return DataAccess.DBAccess.CorporateMessage(name,mobile,email,message,compName, location, noofpeople, besttimetocall);
        }


        [WebMethod()]
        public int SendCorporateMsg(string name, string mobile, string email, string message, int agentId, int propertyId)
        {
            //DBKotaEstateDataContext db = new DBKotaEstateDataContext();

            Message msg = new Message { mobile = mobile, email = email, name = name, message1 = message, touser = agentId, CreatedOn = DateTime.Now, propertyId = propertyId };

            return DataAccess.DBAccess.SendMsgToAgent(msg);
        }

        [WebMethod()]
        public int SendMsgToAgent(string name, string mobile, string email, string message, int agentId, int propertyId)
        {
            //DBKotaEstateDataContext db = new DBKotaEstateDataContext();

            Message msg = new Message { mobile = mobile, email = email, name = name, message1 = message, touser = agentId, CreatedOn = DateTime.Now, propertyId = propertyId };

            return DataAccess.DBAccess.SendMsgToAgent(msg);
        }


        [WebMethod()]
        public Menu[] GetProducts()
        {
            return DataAccess.DBAccess.GetProducts().ToArray();
        }

        [WebMethod()]
        public MenuItem[] GetSubProducts()
        {
            return DataAccess.DBAccess.GetSubProducts().ToArray();
        }

        [WebMethod()]
        public HoliDay[] GetHoliday()
        {
            return DataAccess.DBAccess.GetHoliday().ToArray();
        }

        [WebMethod()]
        public int SubmitHoliday(List<HoliDay> list)
        {
            return DataAccess.DBAccess.SubmitHoliday(list);            
        }        

        [WebMethod()]
        public string GetOrderDetails(int orderId)
        {
            return DataAccess.HTMLGenerator.GetOrderedItems(orderId);
        }


        [WebMethod(EnableSession = true)]
        public int SaveOrder(string method)
        {
            return OrderManagement.SaveOrder(method);
        }
        //[WebMethod(EnableSession=true)]
        //public int SaveOrder(OrderList orders)
        //{
        //    return OrderManagement.SaveOrder(orders);
        //}

        [WebMethod(EnableSession=true)]
        public string CreateOrdersSessionOnHome(int index)
        {
            return OrderManagement.CreateOrdersSessionOnHome(index);
        }

        [WebMethod(EnableSession=true)]
        public string GetPlacedOrderFinalHTML()
        {
            return OrderManagement.GetPlacedOrderFinalHTML();
        }
        
        
        [WebMethod(EnableSession=true)]
        public string CreateOrdersSession(OrderList orders)
        {
            return OrderManagement.CreateOrdersSession(orders);
        }
        

        [WebMethod()]
        public int SaveWeeklyMenu(WeeklyMenu weeklyMenu)
        {
            return DataAccess.DBAccess.SaveWeeklyMenu(weeklyMenu);
        }

         [WebMethod()]
        public int DeltedWeeklyMenuItem(int id)
        {
            return DataAccess.DBAccess.DeltedWeeklyMenuItem(id);
        }

        

        [WebMethod()]
        public int SubmitUser(string firstName, string lastName, string email, string mobile, string passsword, int NewOld, string userType, string location, string WorkingSince, string picture, string std, string landline, string landline1, string landline2, string web, string social, string address, string aboutu, string companyName, string companyLogo)
        {
            int savetype = 0;

            if (NewOld == 1)
            {
                savetype = DataAccess.DBAccess.CheckExistingUser(email, mobile);
            }

            if (savetype == 0)
            {

                savetype = DataAccess.DBAccess.InsertUpdateUserDetails(new User { FirstName = firstName, LastName = lastName, password = passsword, UserLoginID = email, mobile = mobile, email = email, CreatedDate = DateTime.Now, UserType = userType, LocationId = Convert.ToInt32(location), WorkingSince = Convert.ToInt32(WorkingSince), picture = picture, STDCode = std, LandLine = landline, LandLine1 = landline1, LandLine2 = landline2, WebsiteLink = web, SocialLink = social, Address = address, AboutUs = aboutu, CompanyName = companyName, CompanyLogo = companyLogo });
            }
            return savetype;
        }

        [WebMethod(EnableSession = true)]
        public User CreateSession(string userid)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                KitchenOnMyPlate.User usr = new KitchenOnMyPlate.User();
                HttpContext.Current.Session["USER"] = db.Users.Where(w => w.email == userid).First();
                DataAccess.DBAccess.CreateCookie();
                return ( KitchenOnMyPlate.User)(HttpContext.Current.Session["USER"]);
            }
        }

        [WebMethod()]
        public bool IsValidUser(string userid, string password, int rememberme)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                User usr = new User();
                usr.UserLoginID = userid;
                usr.password = password;

                if (rememberme == 1)
                {
                    HttpContext.Current.Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    HttpContext.Current.Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                }

             HttpContext.Current.Response.Cookies["UserName"].Value = userid;
                    
                

                return (from w in db.Users
                        where (w.email == userid || w.mobile == userid) & w.password == password
                        select w).Count() > 0 ? true : false;
            }

        }

        [WebMethod(EnableSession = true)]
        public int SaveJob(JobPostDTO jobPostDTO)
        {
            DBKOMPDataContext db = new DBKOMPDataContext();

            return DataAccess.DBAccess.SaveJob(jobPostDTO);
        }

        [WebMethod(EnableSession = true)]
        public User CreateSessionFB(string userid, string emailId, string firstName, string lastName)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                User usr = new User();
                var count = (from w in db.Users where w.email == emailId  select w).Count();
                if (count > 0)
                {
                    usr = db.Users.Where(w => w.email == emailId ).First();
                    //usr = (User)(HttpContext.Current.Session["USER"]);
                }
                else
                {
                    usr.email = emailId;
                    usr.UserLoginID = emailId;
                    usr.FirstName = firstName;
                    usr.LastName = lastName;
                    usr.UserType = "F";
                    usr.password = "1234";
                    db.Users.InsertOnSubmit(usr);
                    db.SubmitChanges();
                }
                HttpContext.Current.Session["USER"] = usr;
                DataAccess.DBAccess.CreateCookie();
                //KotaCoachings.DataAccess.DBAccess.CreateCookie();
                return usr;
            }
        }

        [WebMethod]
        public tblLocation CheckDeliveryArea(int pin)
        {

            return DataAccess.DBAccess.CheckDeliveryArea(pin);
            
        }

        [WebMethod]
        public int SavePayementDetails(Payment objPaymentHistory)
        {

            SqlTransaction transaction = null;
            try
            {
                if (objPaymentHistory.OrderId == 0)
                {
                    //throw (new Exception("Please retrieve Customer ID"));                    
                    return 0;
                }


                if (objPaymentHistory.Amount == 0)
                {
                    //throw (new Exception("Please retrieve Customer ID"));                    
                    return 0;
                }



                con = new SqlConnection(cs);
                con.Open();
                transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);

                String cbt = "select TotalPayment from [Order] where Id= '" + objPaymentHistory.OrderId + "'";
                cmd = new SqlCommand(cbt);
                cmd.Connection = con;
                cmd.Transaction = transaction;
                decimal amt = Convert.ToDecimal(cmd.ExecuteScalar());

                int paymenStatus = 2;
                if (objPaymentHistory.Amount >= amt)
                {
                    paymenStatus = 1; //Paid
                }

                //string invoiceno = "INV-" + GetUniqueKey(8);
                //String cb = "update [Order] set IsActive='1', PaymentDone='" + paymenStatus + "',TotalPayment = TotalPayment + " + objPaymentHistory.Amount + " where Id= '" + objPaymentHistory.OrderId + "'";
                String cb = "update [Order] set IsActive='1', PaymentDone='" + paymenStatus + "',TotalPayment = " + objPaymentHistory.Amount + " where Id= '" + objPaymentHistory.OrderId + "'";
                //string cb = "insert Into Sales(InvoiceNo,InvoiceDate,CustomerID,SubTotal,VATPercentage,VATAmount,GrandTotal,TotalPayment,PaymentDue,Remarks) VALUES ('" + invoiceno + "','" + objInvoiceData.InvoiceItems[0].InvoiceDate + "','" + objInvoiceData.InvoiceItems[0].CustomerID + "'," + objInvoiceData.InvoiceItems[0].SubTotal + "," + objInvoiceData.InvoiceItems[0].VATPercentage + "," + objInvoiceData.InvoiceItems[0].VATAmount + "," + objInvoiceData.InvoiceItems[0].GrandTotal + "," + objInvoiceData.InvoiceItems[0].TotalPayment + "," + objInvoiceData.InvoiceItems[0].PaymentDue + ",'" + objInvoiceData.InvoiceItems[0].Remarks + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Transaction = transaction;

                cmd.ExecuteNonQuery();

                //cb = "update [OrderDetails] set IsActive='1'  where OrderId= '" + objPaymentHistory.OrderId + "'";
                //cmd = new SqlCommand(cb);
                //cmd.Connection = con;
                //cmd.Transaction = transaction;

                //cmd.ExecuteNonQuery();



                //if (con.State == ConnectionState.Open)
                //{
                //    con.Close();
                //}
                //con.Close();


                //Delete product 
                //con = new SqlConnection(cs);
                //con.Open();
                //string invoiceno = "INV-" + GetUniqueKey(8);
                //String cb1 = "insert from ProductSold where Invoiceno= '" + objInvoiceData.InvoiceItems[0].InvoiceNo + "'";
                string cb1 = "update Payment set PaymentDate='" + objPaymentHistory.PaymentDate.Value.ToString("yyyy-MM-dd") +" "+ DateTime.Now.ToLocalTime().TimeOfDay.ToString().Substring(0,12) + "', Mode='" + objPaymentHistory.Mode + "',TransactionNo='" + objPaymentHistory.TransactionNo + "',Bank='" + objPaymentHistory.Bank + "',Branch='" + objPaymentHistory.Branch + "',Comments='" + objPaymentHistory.Comments + "', IsActive=1  where Orderid='" + objPaymentHistory.OrderId + "'";
                //string cb1 = "update Payment set Amount =Amount  + " + objPaymentHistory.Amount + ",PaymentDate='" + objPaymentHistory.PaymentDate + "', Mode='" + objPaymentHistory.Mode + "',TransactionNo='" + objPaymentHistory.TransactionNo + "',IsActive=1  where Orderid='" + objPaymentHistory.OrderId + "'";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();


                transaction.Commit();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();
                //TODO:LATER
                //for (int i = 0; i <= objInvoiceData.CartItems.Count - 1; i++)
                //{
                //    con = new SqlConnection(cs);
                //    con.Open();
                //    string cb1 = "update stock set Quantity = Quantity - " + objInvoiceData.CartItems[i].Qty + " where ConfigID= " + objInvoiceData.CartItems[i].ConfigID + "";
                //    cmd = new SqlCommand(cb1);
                //    cmd.Connection = con;
                //    cmd.ExecuteNonQuery();
                //    con.Close();
                //}
                //for (int i = 0; i <= objInvoiceData.CartItems.Count - 1; i++)
                //{
                //    con = new SqlConnection(cs);
                //    con.Open();

                //    string cb2 = "update stock set TotalPrice = Totalprice - '" + objInvoiceData.CartItems[i].TotalAmount + "' where ConfigID= " + objInvoiceData.CartItems[i].ConfigID + "";
                //    cmd = new SqlCommand(cb2);
                //    cmd.Connection = con;
                //    cmd.ExecuteReader();
                //    con.Close();
                //}

                
                String cbt1 = "select RequestId from [Order] where Id= '" + objPaymentHistory.OrderId + "'";
                cmd = new SqlCommand(cbt1);
                con.Open();
                cmd.Connection = con;
                //cmd.Transaction = transaction;
                int rqst = Convert.ToInt32(cmd.ExecuteScalar());
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();


                #region Calling yourguy api
               // var objtblUser = CommanAction.GetSession();//for yourguyonly
                
                using (DBKOMPDataContext db = new DBKOMPDataContext())
                {
                    var orders = (from w in db.Orders where w.Id == objPaymentHistory.OrderId select w).First();
                    var SipBilObj = DBAccess.GetShippingBillingByUserId(orders.CustomerId??0, orders.pincode ?? 0);//for yourguyonly
                    var orderDetails = (from w in db.OrderDetails where w.OrderId == objPaymentHistory.OrderId select w);
                    //string time = orders.IsLunch == 1 ? "12:16:06Z" : "20:16:06Z";

                    string locationOfPinCode = string.Empty;                    
                    locationOfPinCode = (from w in db.tblLocations where w.pincode.Value == orders.pincode select w).First().Location;
                    




                    //Yourguy  productid
                    var prodcId = "0";                                

                    //Your guy DateColletion 
                    List<string> lstDeliveryDate = new List<string>();
                    //Your guy time
                    //string time = orders.IsLunch == 1 ? "12:16:06Z" : "20:16:06Z";
                    //Your guy time
                    string Deliverytime = orders.IsLunch == 1 ? "2015-01-01T12:16:06Z" : "2015-01-01T20:16:06Z";
                    string time = orders.IsLunch == 1 ? "12:16:06Z" : "20:16:06Z";
                    string PickUptime = orders.IsLunch == 1 ? "2015-01-01T10:16:06Z" : "2015-01-01T18:16:06Z";

                    foreach (var od in orderDetails)
                    {
                        prodcId = "0"; //prodcId = od.SubProductId.ToString();
                        lstDeliveryDate.Add(od.DeliverDate.Value.ToString("yyyy-MM-ddT") + time);

                        od.IsActive = 1;
                        //od.YourguyOrderId = OrderManagement.CallYourGuy(od.Id.ToString(), objPaymentHistory.OrderId.ToString(), SipBilObj, od.DeliverDate.Value.ToString("yyyy-MM-ddT") + time);
                        //"2015-07-22T12:16:06Z"
                    }

                    //Yourguy service //Yourguy service TODO: UNDO ONCE READY BY YOUR GUY
                    //orders.YourguyOrderId = OrderManagement.CallYourGuy(prodcId, orders.Id.ToString(), SipBilObj, Deliverytime, PickUptime, lstDeliveryDate, locationOfPinCode);

                    db.SubmitChanges();
                }
                #endregion



                ShippingBilling objSB = DBAccess.GetShippingBilling(rqst);

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
                content = content.Replace("$ORDERSUMMARY$", "Congratulation!! Your Order #" + objPaymentHistory.OrderId + " is confirmed!<br/>KOMP has received payment of Rs. " + objPaymentHistory.Amount+" /-");


                var sb = new StringBuilder();
                //divFinal.RenderControl(new HtmlTextWriter(new StringWriter(sb)));
                content = content.Replace("$REQ$", "");
                content = content.Replace("$NAME$", objSB.FirstName );
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
                content = content.Replace(">01<", "");
                content = content.Replace(">03<", "");   

                if (!string.IsNullOrEmpty(objSB.LastName)) //Note : last name is as emailid
                {
                    MailHelper.SendMailMessage("", objSB.LastName, string.Empty, string.Empty, "KOMP : Your order #" + objPaymentHistory.OrderId + " is confirmed", content);
                    AutoServices.SendeMailToUs("Copy:KOMP : Your order #" + objPaymentHistory.OrderId + " is confirmed", content);

                }
                #endregion

                return 1;


            }
            catch (Exception exc)
            {
                transaction.Rollback();
                return 0;
                //throw exc;
            }
        }

        [WebMethod]
        public int DeleteOrder(int orderId)
        {           
           
                return DBAccess.DeleteOrder(orderId); 
           
           
        }

        [WebMethod()]
        public int SubmitShippingBilling(ShippingBilling shippingBilling)
        {
            int savetype = 0;
            savetype = DataAccess.DBAccess.SaveShippingBilling(shippingBilling);

            return savetype;
        }


        [WebMethod()]
        public Config GetConfigValues()
        {
            Config cf = new Config();
            cf = DataAccess.DBAccess.GetConfig();

            return cf;
        }


        [WebMethod()]
        public Plan GetDiscount(int DaysCout)
        {
            Plan Discount = new Plan();
            Discount = DataAccess.DBAccess.GetDiscount(DaysCout);

            return Discount;
        }




    }
}
