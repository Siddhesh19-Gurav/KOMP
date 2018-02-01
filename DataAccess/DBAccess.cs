using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Configuration;
using KitchenOnMyPlate.Classes;
using System.Web.UI.WebControls;

namespace KitchenOnMyPlate.DataAccess
{
    public class DBAccess
    {
        public static List<Menu> GetProducts()
        {
            List<Menu> list;
            //if (!CacheHelper.Get("Menu", out list))
            //{
                using (DBKOMPDataContext db = new DBKOMPDataContext())
                {
                    list = new List<Menu>();

                    var propertyType = (from w in db.Menus where w.IsActive == 1 orderby  w.Id select w).ToList();

                    foreach (var item in propertyType)
                    {
                        list.Add(item);
                    }

                   // CacheHelper.Add(list, "Menu", 2000);
              //  }
            }

            return list;

        }

        public static List<HoliDay> GetHoliday()
        {
            List<HoliDay> list;
            if (!CacheHelper.Get("Holiday", out list))
            {
                using (DBKOMPDataContext db = new DBKOMPDataContext())
                {
                    list = new List<HoliDay>();

                    var HoliDays = (from w in db.HoliDays where w.IsActive == 1 orderby w.DeliverDate select w).ToList();

                    foreach (var item in HoliDays)
                    {
                        item.DeliverDate = Convert.ToDateTime(item.DeliverDate.Value.ToShortDateString());
                        list.Add(item);
                    }

                    CacheHelper.Add(list, "Holiday", 2000);
                }
            }

            return list;

        }


        public static string GetAvailabilityOfMainProduct(int id)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var avlStr = string.Empty;
                var aval = (from w in db.MenuItems where w.MenuId == id select w);
                //
                string strav =string.Empty;
                foreach (var item in aval)
                {
                    strav = strav + item.AvailableDay;
                }

                //var list = aval.AvailableDay.Split(',');
                //foreach(var item in aval)
                //{

                string containsAll = string.Empty;
                    if (strav.Contains("1"))
                    {
                        if (avlStr != string.Empty)
                        {
                            avlStr = avlStr + " | ";
                        }
                        avlStr = avlStr + "MON";
                        containsAll = containsAll + "1";
                        
                    }

                    if (strav.Contains("2"))
                    {
                        if (avlStr != string.Empty)
                        {
                            avlStr = avlStr + " | ";
                        }
                        avlStr = avlStr + "TUE";
                        containsAll = containsAll + "2";
                    }

                    if (strav.Contains("3"))
                    {
                        if (avlStr != string.Empty)
                        {
                            avlStr = avlStr + " | ";
                        }
                        avlStr = avlStr + "WED";
                        containsAll = containsAll + "3";
                    }

                    if (strav.Contains("4"))
                    {
                        if (avlStr != string.Empty)
                        {
                            avlStr = avlStr + " | ";
                        }
                        avlStr = avlStr + "THU";
                        containsAll = containsAll + "4";
                    }

                    if (strav.Contains("5"))
                    {
                        if (avlStr != string.Empty)
                        {
                            avlStr = avlStr + " | ";
                        }
                        avlStr = avlStr + "FRI";
                        containsAll = containsAll + "5";
                    }

                    if (strav.Contains("6"))
                    {
                        if (avlStr != string.Empty)
                        {
                            avlStr = avlStr + " | ";
                        }
                        avlStr = avlStr + "SAT";
                        containsAll = containsAll + "6";
                    }

                    if (strav.Contains("7"))
                    {
                        if (avlStr != string.Empty)
                        {
                            avlStr = avlStr + " | ";
                        }
                        avlStr = avlStr + "SUN";
                        containsAll = containsAll + "7";
                    }

                //}

                    if (containsAll.Contains("12"))
                    {
                        avlStr = "MON - TUE";
                    }

                    if (containsAll.Contains("123"))
                    {
                        avlStr = "MON - WED";
                    }

                    if (containsAll.Contains("1234"))
                    {
                        avlStr = "MON - THU";
                    }

                    if (containsAll.Contains("12345"))
                    {
                        avlStr = "MON - FRI";
                    }
                    if (containsAll.Contains("123456"))
                    {
                        avlStr = "MON - SAT";
                    }

                    if (containsAll.Contains("1234567"))
                    {
                        avlStr = "MON - SUN";
                    }

                return avlStr;
            }
        }

        public static string GetAvailability(int id)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var avlStr = string.Empty;
                var aval = (from w in db.MenuItems where w.Id == id select w).First();
                var list = aval.AvailableDay.Split(',');
                for (var i = 0; i < list.Length;i++)
                {
                    if (avlStr != string.Empty)
                    {
                        avlStr = avlStr + " | ";
                    }

                    if (list[i] == "1")
                    {
                        avlStr = "Mo";
                    }                    
                    else if (list[i] == "2")
                    {
                        avlStr = avlStr + "Tu";
                    }
                    else if (list[i] == "3")
                    {
                        avlStr = avlStr + "We";
                    }
                    else if (list[i] == "4")
                    {
                        avlStr = avlStr + "Th";
                    }
                    else if (list[i] == "5")
                    {
                        avlStr = avlStr + "Fr";
                    }
                    else if (list[i] == "6")
                    {
                        avlStr = avlStr + "Sa";
                    }
                    else if (list[i] == "7")
                    {
                        avlStr = avlStr + "Su";
                    }

                }

                return avlStr;
            }
        }

        public static List<MenuItem> GetSubProducts()
        {
            List<MenuItem> list;
            //if (!CacheHelper.Get("SubMenues", out list))
            //{
                using (DBKOMPDataContext db = new DBKOMPDataContext())
                {
                    list = new List<MenuItem>();

                    var propertyType = (from w in db.MenuItems where w.IsActive == 1 orderby w.MenuId select w).ToList();

                    foreach (var item in propertyType)
                    {
                        list.Add(item);
                    }

                   // CacheHelper.Add(list, "SubMenues", 2000);
                //}
            }

            return list;

        }

        public static List<Plan> GetMealPlans()
        {
            List<Plan> list;
            //if (!CacheHelper.Get("Plan", out list))
            //{
                using (DBKOMPDataContext db = new DBKOMPDataContext())
                {
                    list = new List<Plan>();

                    var propertyType = (from w in db.Plans where w.IsActive == 1 orderby w.Id select w).ToList();

                    foreach (var item in propertyType)
                    {
                        list.Add(item);
                    }

                    //CacheHelper.Add(list, "Plan", 2000);
                //}
            }

            return list;

        }

        
        public static List<RequestSummary> GetRequestedItems(int requestId)
        {
            List<RequestSummary> requestSummary = new List<RequestSummary>();
            
            
                using (DBKOMPDataContext db = new DBKOMPDataContext())
                {

                    var orders = (from w in db.Orders where w.RequestId == requestId select w);

                    foreach (var order in orders)
                    {
                                                
                        //var proDetails =  (order.IsLunch==1)?"Lunch":"Dinner";
                        //var menu = from w in db.Menus where w.Id == order.

                        
                        List<OrderedItems> list;
                        list = new List<OrderedItems>();
                        var propertyType = (from w in db.MenuItems
                                            join O in db.OrderDetails
                                            on w.Id equals O.SubProductId
                                            where w.IsActive == 1 && O.OrderId == order.Id
                                            orderby O.Id
                                            select new { subProductId = w.Id, SubProductName = w.Header, DeleiveryDate = O.DeliverDate, Price = w.Price, menuId= w.MenuId }).ToList();

                        int index=0;
                        string menuName = string.Empty; //It is not for customized
                        foreach (var item in propertyType)
                        {
                            if(index==0)
                            {
                                menuName = (from w in db.Menus where w.Id == item.menuId select w).First().Header;
                            }
                            index++;
                            OrderedItems orderedItems = new OrderedItems { ProductId = item.subProductId.ToString(), ProductName = item.SubProductName, DeliverDate = item.DeleiveryDate.ToString(), Price = item.Price.ToString() };
                            list.Add(orderedItems);
                        }

                        var proDetails = (order.NonCustomized==0)?"CUSTOMIZED MEALS":((order.IsLunch==1)?"Lunch - "+menuName:"Dinner - "+menuName);
                        var payment = (from w in db.Payments where w.OrderId == order.Id select w).First();

                        requestSummary.Add(new RequestSummary { orderId = order.Id, productDetails = proDetails, orderedItems = list, deliveryCharges = payment.DeliveryChrg ?? 0, transCharges = payment.TrnChrg ?? 0, subTotal = payment.Amount??0, grandTotal = (payment.Amount + payment.DeliveryChrg ?? 0 + payment.TrnChrg ?? 0), nonCustomized = order.NonCustomized ?? 0, IsTiffin=order.IsLunch });
                    }
                        



                    
                }
            

            return requestSummary;

        }

        /// <summary>
        /// For Non custimized
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static int GetOrderedItemNonCust(int orderId)
        {            
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {           

             return  (from w in db.MenuItems
                                    join O in db.OrderDetails
                                    on w.Id equals O.SubProductId
                                    where w.IsActive == 1 && O.OrderId == orderId
                                    orderby w.Id
                                    select new { subProductId = w.Id, SubProductName = w.Header, DeleiveryDate = O.DeliverDate, Price = w.Price }).First().subProductId;
            }

        }

        public static User CreateSession(string userid)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                KitchenOnMyPlate.User usr = new KitchenOnMyPlate.User();

                HttpContext.Current.Session["USER"] = db.Users.Where(w => w.email == userid).First();

                CreateCookie();

                return ((KitchenOnMyPlate.User)(HttpContext.Current.Session["USER"]));
            }
        }

        //public static User CreateSessionOnRequestid(string requestId)
        //{
        //    using (DBKOMPDataContext db = new DBKOMPDataContext())
        //    {
        //        from w in db.Orders where 
        //        User usr = new User();
        //        HttpContext.Current.Session["USER"] = db.Users.Where(w => w.email == userid || w.mobile == userid).First();

        //        CreateCookie();

        //        return ((User)(HttpContext.Current.Session["USER"]));
        //    }
        //}

        public static void CreateCookie()
        {
            if (HttpContext.Current.Request.Cookies["USERMART"] == null)
            {
                //create a cookie
                HttpCookie myCookie = new HttpCookie("USERMART");


                //Add key-values in the cookie
                myCookie.Values.Add("EMAIL", ((User)(HttpContext.Current.Session["USER"])).email);
                // myCookie.Values.Add("USERNAME", ((User)(HttpContext.Current.Session["USER"])).FirstName);
                //set cookie expiry date-time. Made it to last for next 12 hours.
                myCookie.Expires = DateTime.Now.AddDays(1d);
                //Most important, write the cookie to client.
                HttpContext.Current.Response.Cookies.Add(myCookie);
            }
        }

        public static Config GetConfig()
        {
            Config config = new Config();

            //if (!CacheHelper.Get("Config", out config))
            //{
                using (DBKOMPDataContext db = new DBKOMPDataContext())
                {
                    config = (from w in db.Configs select w).First();
                    ///CacheHelper.Add(config, "Config", 2000);
                }
            //}

            return config;

        }

        public static int CheckExistingUserAndGetID(string email, string mobile)
        {
            DBKOMPDataContext db = new DBKOMPDataContext();
            var userID = 0;
            if ((from w in db.Users where w.email == email || w.mobile == mobile select w).Count() > 0)
            {
                userID = (from w in db.Users where w.email == email || w.mobile == mobile select w).First().UserId;
            }

            return userID;

        }

        public static int ChangePassword(string UID, string ChngPass, string OldPassword)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                int action = 0;

                User tblus = db.Users.Single(p => p.UserLoginID == UID || p.mobile == UID);
                if (tblus.password == OldPassword)
                {
                    tblus.password = ChngPass;
                    db.SubmitChanges();
                    action = 1;


                    ChangedPasswordMail(tblus);
                }
                else
                {
                    action = 2;
                }
                return action;
            }
        }

        public static List<tblLocation> GetDeliveryAreaForZip(int pin)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                string pincode = string.Empty;

                //if (email != string.Empty && (from w in db.Users where w.email == email && w.UserType == "F" select w).Count() > 0)
                if ((from w in db.tblLocations where w.pincode == pin select w).Count() > 0)
                {

                    /////
                    return (from w in db.tblLocations where w.pincode == pin select w).ToList();
                }
                else
                {
                    return new List<tblLocation>(); 
                }
                
            }
        }

        
        public static tblLocation CheckDeliveryArea(int pin)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                string pincode = string.Empty;

                //if (email != string.Empty && (from w in db.Users where w.email == email && w.UserType == "F" select w).Count() > 0)
                if ((from w in db.tblLocations where w.pincode == pin select w).Count() > 0)
                {

                    /////
                    return (from w in db.tblLocations where w.pincode == pin select w).First();
                }
                else
                {
                    return new tblLocation { pincode = 0, Location=string.Empty }; 
                }
                
            }
        }

        private static void ChangedPasswordMail(User tblus)
        {
            string content = string.Empty;
            string filepath = "~/Email/ChangePassword.htm";
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

            string ownerEmailId = ConfigurationManager.AppSettings["OwnerEmailID"].ToString();

            content = sbContent.ToString();
            string uid = string.IsNullOrEmpty(tblus.email) ? tblus.mobile : tblus.email;
            content = content.Replace("$UID$", uid);
            content = content.Replace("$PWD$", tblus.password);
            content = content.Replace("$NAME$", tblus.FirstName + " " + tblus.LastName);
            content = content.Replace("$SITE$", site);
            content.Replace("RobotoBlack", "Arial").Replace("RobotoBold", "Arial").Replace("Roboto", "Arial");
            MailHelper.SendMailMessage("", tblus.email, string.Empty, string.Empty, "Changed Password", content);

            //MailHelper.SendMailMessage("", "awareinfosystem@gmail.com", string.Empty, string.Empty, "Changed Password", "Below Mail Details for new user<br/><br/>" + content);
            //MailHelper.SendMailMessage("", ownerEmailId, string.Empty, string.Empty, "Changed Password", "Below Mail Details for new user<br/><br/>" + content);

        }

        public static int CheckExistingUser(string email, string mobile)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var countUser = 0;

                //if (email != string.Empty && (from w in db.Users where w.email == email && w.UserType == "F" select w).Count() > 0)
                if (email != string.Empty && (from w in db.Users where w.email == email select w).Count() > 0)
                {
                    countUser = 111111;
                }
                else if (email != string.Empty && (from w in db.Users where w.email == email select w).Count() > 0)
                {
                    countUser = 9999999;
                }
                //else if ((from w in db.Users where w.mobile == mobile select w).Count() > 0)
                //{
                //    countUser = 8888888;
                //}
                return countUser;
            }

        }
        public static int InsertUpdateUserDetails(User objtblUser)
        {
            int savetype = 0;
            string content = string.Empty;
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var countUser = (from w in db.Users where (objtblUser.UserLoginID != string.Empty && w.email == objtblUser.UserLoginID) select w).Count();
                if (countUser == 0)
                {

                    objtblUser.password = objtblUser.FirstName.Substring(0,2)+"9876";

                    db.Users.InsertOnSubmit(objtblUser);

                    string filepath = "~/Email/NewRegistration.htm";
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
                    string uid = string.IsNullOrEmpty(objtblUser.email) ? objtblUser.UserLoginID : objtblUser.email;
                    content = content.Replace("$UID$", uid);
                    content = content.Replace("$PWD$", objtblUser.password);
                    content = content.Replace("$NAME$", objtblUser.FirstName);
                    content = content.Replace("$SITE$", site);

                    string encryptemailid = EncryptDecrypt.EncryptString(objtblUser.email, "kota@1234");
                    encryptemailid = encryptemailid.Replace("+", "_");
                    string hreflnk = "http://www." + site + "/Register.aspx?rid=" + encryptemailid;
                    content = content.Replace("$PROFILE$", hreflnk);

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


                    if (!string.IsNullOrEmpty(objtblUser.email))
                    {
                        MailHelper.SendMailMessage("", objtblUser.email, string.Empty, string.Empty, "Welcome to " + site, content);

                      //  AutoServices.SendeMailToUs("Copy:Welcome to " + site, content);


                    }
                    MailHelper.SendMailMessage("", ConfigurationManager.AppSettings["OwnerEmailID1"].ToString(), string.Empty, string.Empty, "Copy : Welcome to "+ site, "Below Mail Details for new user<br/><br/>" + content);
                    //MailHelper.SendMailMessage("", ConfigurationManager.AppSettings["OwnerEmailID2"].ToString(), string.Empty, string.Empty, "Copy : Welcome to " + site, "Below Mail Details for new user<br/><br/>" + content);
                    //string ownerEmailId = ConfigurationManager.AppSettings["OwnerEmailID"].ToString();
                    //MailHelper.SendMailMessage("", ownerEmailId, string.Empty, string.Empty, "New User is Created", "Below Mail Details for new user<br/><br/>" + content);

                }
                else
                {
                    User tblus = db.Users.Single(p => (objtblUser.UserLoginID != string.Empty && p.UserLoginID == objtblUser.UserLoginID) || p.mobile == objtblUser.mobile);

                    if (objtblUser.email == objtblUser.mobile && objtblUser.mobile != tblus.mobile)
                    {
                        tblus.email = objtblUser.mobile;
                        tblus.UserLoginID = objtblUser.mobile;
                    }

                    tblus.email = objtblUser.email;
                    tblus.UserType = objtblUser.UserType;
                    tblus.FirstName = objtblUser.FirstName;
                    tblus.LastName = objtblUser.LastName;
                    tblus.mobile = objtblUser.mobile;
                    tblus.picture = objtblUser.picture;
                    tblus.LocationId = objtblUser.LocationId;
                    tblus.WorkingSince = objtblUser.WorkingSince;

                    tblus.STDCode = objtblUser.STDCode;
                    tblus.LandLine = objtblUser.LandLine;
                    tblus.LandLine1 = objtblUser.LandLine1;
                    tblus.LandLine2 = objtblUser.LandLine2;
                    tblus.WebsiteLink = objtblUser.WebsiteLink;
                    tblus.SocialLink = objtblUser.SocialLink;

                    tblus.Address = objtblUser.Address;
                    tblus.AboutUs = objtblUser.AboutUs;
                    tblus.CompanyName = objtblUser.CompanyName;
                    tblus.CompanyLogo = objtblUser.CompanyLogo;
                }
                db.SubmitChanges();
                savetype = objtblUser.UserId;

                return savetype;
            }
        }

        public static int SaveShippingBilling(ShippingBilling shippingBilling)
        {
            int savetype = 0;
            string content = string.Empty;
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var countUser = (from w in db.ShippingBillings where w.RequestId==shippingBilling.RequestId select w).Count();
                if (countUser == 0)
                {
                    db.ShippingBillings.InsertOnSubmit(shippingBilling);
                    db.SubmitChanges();
                    savetype = shippingBilling.Id;
                }
                else
                {
                    savetype = (from w in db.ShippingBillings where w.RequestId == shippingBilling.RequestId select w).First().Id;
                }
                
                

                return savetype;
            }
        }

        public static int CheckAddressForRequestNo(int requestNo)
        {
            int savetype = 0;
            string content = string.Empty;
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                savetype = (from w in db.ShippingBillings where w.RequestId == requestNo select w).Count();                                               
            }
            return savetype;
        }

        public static int setPaymentAsFailed(int requestId)
        {
            

            int savetype = 0;
            string content = string.Empty;
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                int uid = 0;

                var rqst = (from w in db.Requests where w.Id == requestId select w).First();
                rqst.UserId = uid;

                var orders = (from w in db.Orders where w.RequestId == requestId select w);
                foreach (var ord in orders)
                {
                    ord.PaymentDone  = 2;//Failed
                }

                db.SubmitChanges();

                return savetype;
            }
        }
        
        public static int SetUserByAdminOnBehalf(int requestId,string name, string emailid)
        {
            

            int savetype = 0;
            string content = string.Empty;
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                int uid = 0;

                var countUser = (from w in db.Users where w.email.ToUpper() == emailid.ToUpper() select w).Count();
                if (countUser == 0)
                {
                    uid = InsertUpdateUserDetails(new User { UserId = 0, FirstName = name, email = emailid, UserLoginID = emailid, password = "komp" + name.Substring(0, 2) });
                }
                else
                {
                    uid = (from w in db.Users where w.email.ToUpper() == emailid.ToUpper() select w).First().UserId;
                }

                var rqst = (from w in db.Requests where w.Id == requestId select w).First();
                rqst.UserId = uid;

                System.Threading.Thread.Sleep(5000);

                var shipp = (from w in db.ShippingBillings where w.RequestId == requestId select w).First();
                shipp.UserId = uid;


                var orders = (from w in db.Orders where w.RequestId == requestId select w);
                foreach (var ord in orders)
                {
                    ord.CustomerId = uid;
                    ord.PaymentDone = 0;//pending
                }

                db.SubmitChanges();

                return savetype;
            }
        }

        public static int SubmitHoliday(List<HoliDay> list)
        {
            string content = string.Empty;
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                db.HoliDays.DeleteAllOnSubmit(from w in db.HoliDays select w);
                db.HoliDays.InsertAllOnSubmit(list);
                db.SubmitChanges();
                CacheHelper.Clear("Holiday");
                return 1;
            }
        }

        public static int DeleteOrder(int orderId)
        {
            string content = string.Empty;
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {

                int requesid = (from o in db.Orders  where o.Id  ==  orderId select o).First().RequestId??0;

                var orders1 = (from w in db.Orders where w.RequestId == requesid select w);
                //it shipping billing should be deleted in case order is one becaseu there might me more orders on same request id
                if (orders1.Count() == 1)
                {
                    db.ShippingBillings.DeleteAllOnSubmit(from w in db.ShippingBillings where w.RequestId == requesid select w);
                }


                //Here updating next paying in case cash pickup
                bool IsPriceSeted = false;
                Payment pmt;
                foreach(var ord in orders1)
                {
                   
                   
                    if (ord.Id != orderId)
                    {
                        if ((from w in db.Payments where w.OrderId == ord.Id select w).Count() > 0)
                        {
                            pmt = (from w in db.Payments where w.OrderId == ord.Id select w).First();
                        if (pmt.Mode.ToString() == "14" && !IsPriceSeted)
                            {
                                pmt.TrnChrg = (from w in db.Payments where w.OrderId == orderId select w).First().TrnChrg;
                                IsPriceSeted = true;
                            }
                        }
                    }
                }
               // var ordersBig = (from w in db.Payments where w.RequestId == requesid select w);

                db.Payments.DeleteAllOnSubmit(from w in db.Payments where w.OrderId  == orderId select w);
                db.OrderDetails.DeleteAllOnSubmit(from w in db.OrderDetails where w.OrderId == orderId  select w);
                db.Orders.DeleteAllOnSubmit(from w in db.Orders where w.Id == orderId select w);
                
                                
                db.SubmitChanges();
                CacheHelper.Clear("Holiday");
                return 1;
            }
        }

        public static int SaveJob(JobPostDTO coachingDTO)
        {
            //if (HttpContext.Current.Session["USER"] != null)
            //{

           // using (DBKOMPDataContext db = new DBKOMPDataContext())
           // {
         

                    //tblP = new JobPost();

                    //// int Maxid =(from w in db.Coachings select w.Id).Max() +1;
                    //// tblP.Id = Maxid;
                    //SetJob(coachingDTO, db, tblP);

                    //tblP.CreatedOn = DateTime.Now;
                    //db.JobPosts.InsertOnSubmit(tblP);

                    #region Send mail
                    string content = string.Empty;
                    string filepath = "~/Email/JobPost.htm";
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

                    content = sbContent.ToString();
                    content = content.Replace("$Phone$", coachingDTO.Phone);
                    content = content.Replace("$Name$", coachingDTO.Name);
                    content = content.Replace("$Email$", coachingDTO.email);
                    //content = content.Replace("$Address$", coachingDTO.Address);
                    content = content.Replace("$cvurl$", coachingDTO.CVPath);
                    content = content.Replace("$Category$", coachingDTO.CategoryName);

                    //string encryptemailid = EncryptDecrypt.EncryptString(coachingDTO.email, "kota@1234");
                    //encryptemailid = encryptemailid.Replace("+", "_");

                   // string hreflnk = "http://www.kotacoaching.com/Job.aspx?rid=" + coachingDTO.email;
                    //string Createlink = "<a href='" + hreflnk + "'>Update Profile</a> ";
                    //content = content.Replace("$CLINK$", Createlink);
                    content.Replace("RobotoBlack", "Arial").Replace("RobotoBold", "Arial").Replace("Roboto", "Arial");

                    string ownerEmailId1 = ConfigurationManager.AppSettings["OwnerEmailID1"].ToString();
                    MailHelper.SendMailMessage("", ownerEmailId1, string.Empty, string.Empty, "Job Posted by Visitor ", content);
                    string ownerEmailId2 = ConfigurationManager.AppSettings["OwnerEmailID2"].ToString();
                    MailHelper.SendMailMessage("", ownerEmailId2, string.Empty, string.Empty, "Job Posted by Visitor", content);


                   // MailHelper.SendMailMessage("support@kotacoaching.com", coachingDTO.email, string.Empty, string.Empty, "Thanks for posting resume at KotaCoachaing.com", content);
                    //MailHelper.SendMailMessage("support@kotacoaching.com", "coachinginkota@gmail.com", string.Empty, string.Empty, "Copy:Thanks for posting resume at KotaCoachaing.com", content);

                    #endregion


               
  

                return coachingDTO.Id;
           // }

        }

        public static List<tblLocation> GetLocations()
        {
            List<tblLocation> locations = new List<tblLocation>();

            if (!CacheHelper.Get("Location", out locations))
            {
                using (DBKOMPDataContext db = new DBKOMPDataContext())
                {
                    locations = (from w in db.tblLocations orderby w.CityDivisionID orderby w.CityDivisionID, w.Location select w).ToList();
                    CacheHelper.Add(locations, "Location", 2000);
                }
            }

            return locations;

        }

        public static void BindProducts(DropDownList drpid)
        {
            var locations = DataAccess.DBAccess.GetProducts();

            var OptionID = 0;

            drpid.Items.Add(new ListItem { Selected = true, Value = "0", Text = "--Select Product--" });
            for (var i = 0; i < locations.Count; i++)
            {

                var listItem = new ListItem { Value = locations[i].Id.ToString(), Text = locations[i].Header };
                // listItem.Attributes["OptionGroup"] = DivisionName;

                drpid.Items.Add(listItem);


              //  OptionID = locations[i].CityDivisionID ?? 0;
            }
            //  drpid.SelectedIndex = 1;



        }
        public static void BindAllLocation(DropDownList drpid)
        {
            var locations = DataAccess.DBAccess.GetLocations();
            
            var OptionID = 0;
            
            drpid.Items.Add(new ListItem { Selected = true, Value = "0", Text = "--Any Locality--" });
            for (var i = 0; i < locations.Count; i++)
            {

                //if (OptionID == 0 || OptionID != locations[i].CityDivisionID)
                //{

                //    for (var k = 0; k < Divisions.Count; k++)
                //    {
                //        if (locations[i].CityDivisionID == Divisions[k].Id)
                //        {
                //            DivisionName = Divisions[k].Namve;
                //        }
                //    }

                //    var listItemGroup = new ListItem { Value = "", Text = DivisionName };
                //    listItemGroup.Attributes.CssStyle.Add("background-color", "#256EB8");
                //    listItemGroup.Attributes.CssStyle.Add("color", "White");
                //    listItemGroup.Attributes.CssStyle.Add(" font-size", "15px;");

                //    listItemGroup.Attributes.Add("disabled", "disabled");




                //    drpid.Items.Add(listItemGroup);
                //    // drpid.Attributes.Add("optgroup", DivisionName);
                //}

                var listItem = new ListItem { Value = locations[i].Id.ToString(), Text = locations[i].Location };
                // listItem.Attributes["OptionGroup"] = DivisionName;

                drpid.Items.Add(listItem);


                OptionID = locations[i].CityDivisionID ?? 0;
            }
            //  drpid.SelectedIndex = 1;



        }


        public static int CorporateMessage(string name, string mobile, string email, string message, string compName, string location, string noofpeople, string besttimetocall)
        {
            //using (DBKOMPDataContext db = new DBKOMPDataContext())
            //{
            //    db.Messages.InsertOnSubmit(msg);
            //    db.SubmitChanges();

                #region Send Mail


                string content = string.Empty;

                string filepath = "Email/CorporateMessage.htm";
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

                content = content.Replace("$USER$", name);
                content = content.Replace("$MESSAGE$", message );

                content = content.Replace("$EMAIL$", email);
                content = content.Replace("$MOBILE$", mobile);

                content = content.Replace("$compName$", compName);
                if (location == "")
                {
                    content = content.Replace("Location : $location$<br/>", location);
                }
                else
                {
                    content = content.Replace("$location$", location);
                }

                if (besttimetocall == "")
                {
                    content = content.Replace("Best Time To Call : $besttimetocall$<br/>", "");
                }

                if (besttimetocall.Length>50)
                {
                    content = content.Replace("Best Time To Call : $besttimetocall$<br/>", besttimetocall);
                }

                
            
                content = content.Replace("$noofpeople$", noofpeople);
                content = content.Replace("$besttimetocall$", besttimetocall);

                content = content.Replace("$SITE$", site);
                content.Replace("RobotoBlack", "Arial").Replace("RobotoBold", "Arial").Replace("Roboto", "Arial");
                //MailHelper.SendMailMessage("", objtblUser.email, string.Empty, string.Empty, "Thanks for Posting", content);
                //MailHelper.SendMailMessage("", "friend.panchal@gmail.com", string.Empty, string.Empty, "User message", content);
                string ownerEmailId1 = ConfigurationManager.AppSettings["OwnerEmailID1"].ToString();
                MailHelper.SendMailMessage("", ownerEmailId1, string.Empty, string.Empty, "Corporate's user message", content);
                string ownerEmailId2 = ConfigurationManager.AppSettings["OwnerEmailID2"].ToString();
                MailHelper.SendMailMessage("", ownerEmailId2, string.Empty, string.Empty, "Corporate's user message", content);


                #endregion

                return 1;
           // }
        }

        public static int SendMsgToAgent(Message msg)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                db.Messages.InsertOnSubmit(msg);
                db.SubmitChanges();

                #region Send Mail


                string content = string.Empty;

                string filepath = "Email/UserMessage.htm";
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

                content = content.Replace("$USER$", msg.name);
                content = content.Replace("$MESSAGE$", msg.message1);

                content = content.Replace("$EMAIL$", msg.email);
                content = content.Replace("$MOBILE$", msg.mobile);

                content = content.Replace("$SITE$", site);
                content.Replace("RobotoBlack", "Arial").Replace("RobotoBold", "Arial").Replace("Roboto", "Arial");
                //MailHelper.SendMailMessage("", objtblUser.email, string.Empty, string.Empty, "Thanks for Posting", content);
                //MailHelper.SendMailMessage("", "friend.panchal@gmail.com", string.Empty, string.Empty, "User message", content);
                string ownerEmailId1 = ConfigurationManager.AppSettings["OwnerEmailID1"].ToString();
                MailHelper.SendMailMessage("", ownerEmailId1, string.Empty, string.Empty, "Visitor's message", content);
                string ownerEmailId2 = ConfigurationManager.AppSettings["OwnerEmailID2"].ToString();
                MailHelper.SendMailMessage("", ownerEmailId2, string.Empty, string.Empty, "Visitor's message", content);


                #endregion

                return 1;
            }
        }

        public static int SaveWeeklyMenu(WeeklyMenu weeklyMenu)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                if (weeklyMenu.Id == 0)
                {
                    db.WeeklyMenus.InsertOnSubmit(weeklyMenu);
                }
                else
                {
                    var obj = db.WeeklyMenus.Where(w => w.Id == weeklyMenu.Id).First();
                    obj.Monday = weeklyMenu.Monday;
                    obj.Tuesday = weeklyMenu.Tuesday;
                    obj.Wednesday = weeklyMenu.Wednesday;
                    obj.Thursday = weeklyMenu.Thursday;
                    obj.Friday = weeklyMenu.Friday;
                    obj.Saturday = weeklyMenu.Saturday;
                    obj.Sunday = weeklyMenu.Sunday;
                }
                
                db.SubmitChanges();
                CacheHelper.Clear("WEEKLYMENU");
                CacheHelper.Clear("WEEKLYMENUA");
            }

            return weeklyMenu.Id;
            // }

        }
        public static int DeltedWeeklyMenuItem(int id)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                if (id != 0)
                {
                    db.WeeklyMenus.DeleteOnSubmit( db.WeeklyMenus.Where(w => w.Id == id).First());
                }

                db.SubmitChanges();
                CacheHelper.Clear("WEEKLYMENU");
                CacheHelper.Clear("WEEKLYMENUA");
            }

            return id;
        }

        public static List<WeeklyMenu> GetWeeklyMenu(string showin)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                return db.WeeklyMenus.Where(w => w.IsActive == 1 && w.ShowIn==showin).ToList();
            }

        }


        //will retrive last one
        public static ShippingBilling GetShippingBillingByUserId(int uid, int pin)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                if ((from w in db.ShippingBillings where w.UserId == uid && w.Pincode == pin.ToString() orderby w.Id descending select w).Count() > 0)
                {
                    return (from w in db.ShippingBillings where w.UserId == uid && w.Pincode == pin.ToString() orderby w.Id descending select w).First();
                }
                else
                {
                    return new ShippingBilling();
                }

            }

        }

        public static ShippingBilling GetShippingBilling(int rqstId)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                if (db.ShippingBillings.Where(w => w.RequestId == rqstId).Count() > 0)
                {
                    return db.ShippingBillings.Where(w => w.RequestId == rqstId).First();
                }
                else {
                    return new ShippingBilling();
                }
            }

        }

        public static Plan GetDiscount(int DaysPlan)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                return db.Plans.Where(m => m.DaysInPlan == DaysPlan).SingleOrDefault();
            }

        }

        public static Payment GetPayment(int OrderId)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                return db.Payments.Where(m => m.OrderId == OrderId).SingleOrDefault();
            }

        }


    }
}