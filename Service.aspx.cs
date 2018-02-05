using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KitchenOnMyPlate.DataAccess;
using KitchenOnMyPlate.Classes;
using System.Web.Script.Serialization;
using System.Globalization;

namespace KitchenOnMyPlate
{
    public partial class Service : System.Web.UI.Page
    {
        protected int loggiedIn = 0;
        protected int minDateAdmin = 3;
        protected string disabledSpecificDays;
        protected string RenewRequest=string.Empty;
        protected bool IsLunch = false;
        protected int DeliveryChrg = 0;
        protected int TrnChrg = 0; //in percent

        protected float chkCashPickUp = 0; //in 
        protected double chkCashPickUpPers = 0; //in percent

        protected OrderDTO[] orderlst = new List<OrderDTO>().ToArray();
        public JavaScriptSerializer javaSerial = new JavaScriptSerializer();

        protected void Page_Load(object sender, EventArgs e)
        {
             if (HttpContext.Current.Session["OrderList"] != null)
            {


                  //public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
                //HttpContext.Current.Session["OrderList"] = orders;
                orderlst = ((OrderList)HttpContext.Current.Session["OrderList"]).orders.ToArray();

                //foreach (var itm in orderlst)
                //{
                //    itm.Order.OrderDate = itm.Order.OrderDate.Value.Date;
                //}
                if (orderlst.Length > 0)
                {
                    txtPinCode.Value = orderlst[0].Order.pincode.ToString();
                    txtPinCode.Disabled = true;
                }
            }
            

            //if (Session["USER"] != null)
            //{
                loggiedIn = CommanAction.GetSession().UserId;
                minDateAdmin = (CommanAction.GetSession().UserType == "N") ? 3 : 3;//4 : 0;

                //If requst order from tomorrow start            
                if (Session["ORDERFROMTOMORROW"] != null)
                {
                    DateTime serverTime = DateTime.Now;
                    DateTime utcTime = serverTime.ToUniversalTime();
                    // convert it to Utc using timezone setting of server computer
                    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                    DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                    string date = Session["ORDERFROMTOMORROW"].ToString().Trim();
                    int dd = Convert.ToInt32(date.ToString().Substring(0, 2)) / 2;
                    int mm = Convert.ToInt32(date.ToString().Substring(2, 2)) / 2;
                    int yy = Convert.ToInt32(date.ToString().Substring(4, 2)) / 2;

                    if ((dd.ToString().PadLeft(2, '0') + mm.ToString().PadLeft(2, '0') + yy.ToString().PadLeft(2, '0')) == localTime.ToString("ddMMyy"))
                    {
                        minDateAdmin = 3;
                    }
                }
                else
                {
                    var zone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                    var timeInIndia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zone);
                    var timeInIndiaAsString = timeInIndia.ToString("hh:mm tt", CultureInfo.InvariantCulture);

                    //start from 4 PM
                    if (timeInIndia.Hour > 16 && timeInIndiaAsString.Contains("PM"))
                    {
                        minDateAdmin = 2;
                    }
                    else
                    {
                        minDateAdmin = 3;
                    }
                }
                //If requst order from tomorrow end


            //}

                var item = Page.RouteData.Values["itm"] as string;
                var il = Page.RouteData.Values["il"] as string;
            if(! string.IsNullOrEmpty(Request.QueryString["OrderRqst"]))
            {
                RenewRequest = DBAccess.GetOrderedItemNonCust( Convert.ToInt32(Request.QueryString["OrderRqst"])).ToString();
            }

            if (!string.IsNullOrEmpty(il))
            {
                IsLunch = (il.ToUpper()=="LUNCH");
            }
            

            if (!IsPostBack)
            {
                SetHoidays();
                BindLocation();
                SetItems();
                
                SetConfig();
            }
        }

        private void BindLocation()
        {
           // DBAccess.BindAllLocation(drpAgentLocation);
        }

        private void SetItems()
        {
            var item = Page.RouteData.Values["itm"] as string;

            if (!string.IsNullOrEmpty(item))
            {





                if (IsLunch && item.ToUpper() == "NUTRIMEAL") 
                {
                    mainHdr.InnerHtml = "NUTRIMEAL LUNCH";
                    lunchNutri.Visible = true;
                    imgB.Src = "images/banner/Tiffin Service - Lunch Nutri-Meals.jpg";
                    btnWeekly.Visible = true;
                    SetWeeklyMenu("NL");
                    lblWEEKLYTEXT.Text = "OUR VEG & NON-VEG SAMPLE MENU (LUNCH)";
                    btnWeeklyM.Value = "SAMPLE MENU - LUNCH";

                    Page.Title = "Nutrimeal Plate | Nutrimeal Lunch in Mumbai - kitchenonmyplate.com";
                    Page.MetaDescription = "Nutrimeal Lunch Tiffin services with both veg and non-veg food items in Mumbai, We deliver delicious Nutri Meal lunch or meals across Mumbai.";
                    Page.MetaKeywords = "Nutrimeal Plate, Nutrimeal Lunch, Nutrimeal Lunch in Mumbai, Nutri Meal lunch, Nutrimeal Tiffin services in Mumbai, Nutrimeal Breakfast, Nutrimeal Evening Snacks, Nutrimeal Food";

                }
                else if (!IsLunch && item.ToUpper() == "NUTRIMEAL")
                {

                    mainHdr.InnerHtml = "NUTRIMEAL DINNER";
                    dinnerNutri.Visible = true;
                    imgB.Src = "images/banner/Tiffin Service - Dinner Nutri-Meals.jpg";
                    btnWeekly.Visible = true;
                    SetWeeklyMenu("ND");
                    lblWEEKLYTEXT.Text = "OUR VEG & NON-VEG SAMPLE MENU (DINNER)";
                    btnWeeklyM.Value = "SAMPLE MENU - DINNER";

                    Page.Title = "Order Online Nutrimeal Lunch in Mumbai | Nutrimeal Plate - kitchenonmyplate.com";
                    Page.MetaDescription = "Order online nutrimeal Dinner Tiffin services with both veg and non-veg. We deliver delicious nutri meal dinner tiffin services across Mumbai.";
                    Page.MetaKeywords = "Nutrimeal Plate, Nutrimeal Dinner, Nutrimeal Dinner in Mumbai, Nutri Meal Dinner, Nutrimeal Tiffin services in Mumbai, Nutrimeal Plate, Nutrimeal Food";

                }
                else if (IsLunch && item.ToUpper() == "TRADITIONAL")//Lunch
                {
                    mainHdr.InnerHtml = "LUNCH TIFFIN SERVICE";
                    lunch.Visible = true;
                    imgB.Src = "images/banner/Tiffin_Service_Lunch.jpg";
                    SetWeeklyMenu("TL");
                    lblWEEKLYTEXT.Text = "OUR VEG & NON-VEG SAMPLE MENU (LUNCH)";
                    btnWeeklyM.Value = "SAMPLE MENU - LUNCH";


                    Page.Title = "Traditional Indian Plate | Traditional Lunch Tiffin - kitchenonmyplate.com";
                    Page.MetaDescription = "The traditional food of India has been widely cherished for its tremendous use of herbs and spices. KOMP caters a variety of traditional Indian plate services for Weddings, Birthday, Parties, Religious Functions and Festivals etc.";
                    Page.MetaKeywords = "Traditional Indian Plate, Traditional Lunch Tiffin, traditional Indian Food, Indian Dishes, Traditional Tiffin Varieties, Indian Foods, Traditional Tiffin Services in India, Lunch Tiffin Services, Traditional Veg Lunch, Traditional Non Veg Lunch Services";

                }
                else if (!IsLunch && item.ToUpper() == "TRADITIONAL")//Dinner
                {
                    mainHdr.InnerHtml = "DINNER TIFFIN SERVICE";
                    dinner.Visible = true;
                    imgB.Src = "images/banner/DINNER_tiffin_service_thumbs.jpg";
                    SetWeeklyMenu("TD");
                    lblWEEKLYTEXT.Text = "OUR VEG & NON-VEG SAMPLE MENU (DINNER)";
                    btnWeeklyM.Value = "SAMPLE MENU - DINNER ";

                    Page.Title = "Traditional Dinner Tiffin | Dinner Tiffin Services Mumbai - kitchenonmyplate.com";
                    Page.MetaDescription = "A tasty and healthy traditional dinner tiffin services in Mumbai.You choose and customize Veg and Non Veg dinner tiffin services & we will deliver and price accordingly.";
                    Page.MetaKeywords = "Traditional Dinner Tiffin Services, Dinner Tiffin Services Mumbai, tasty and healthy dinner Tiffin, Traditional Dinner Tiffin, Customize Dinner Tiffin Mumbai, Veg dinner tiffin services, Non Veg dinner tiffin services";

                }
                divItem.InnerHtml = HTMLGenerator.GetSubProductUnderProduct("N", (item.ToUpper() == "NUTRIMEAL") ? 6 : 1, IsLunch ? "1" : "0");

                //<!--Note start-->
                if (!IsLunch && item.ToUpper() == "TRADITIONAL")//Dinner
                {
                    divItem.InnerHtml = divItem.InnerHtml + "<div id='Note3382' style='clear: both;width: 100%;height: auto;border: 1px solid #c8c6c6;border-bottom: 0px !important;font-family: RobotoBlack;'>" +
"<div class='leftsubDetails'>" +
"<div style='clear:both'></div>" +
"<div class='subProductDetails'>" +
"<span style='font-size:13px; ' >*Meal Prices are exclusive of all Taxes.  <br />" +
"*Delivery Charges : 5 Days – Rs. 225 | 10 Days – Rs. 350 | 22 Days – Rs. 770 |44 Days – Rs. 1540" +
"</span>" +
"</div>" +
"</div>" +
"<div style='clear:both;'></div>" +
"</div>";
                }
                else
                {
                    divItem.InnerHtml = divItem.InnerHtml + "<div id='Note3382' style='clear: both;width: 100%;height: auto;border: 1px solid #c8c6c6;border-bottom: 0px !important;font-family: RobotoBlack;'>" +
"<div class='leftsubDetails'>" +
"<div style='clear:both'></div>" +
"<div class='subProductDetails'>" +
"<span style='font-size:13px; ' >*Meal Prices are exclusive of all Taxes.  <br />" +
"*Delivery Charges : 5 Days – Rs. 200 | 10 Days – Rs. 300 | 22 Days – Rs. 660 | 44 Days – Rs. 1320" +
"</span>" +
"</div>" +
"</div>" +
"<div style='clear:both;'></div>" +
"</div>";
                    //<!--Note start-->
                }
            }

        }

        private void SetConfig()
        {
            var config = DBAccess.GetConfig();
            DeliveryChrg = config.DeliveryChrg??0;
            TrnChrg = config.TrnChrg??0; //in percent

            chkCashPickUp = config.CashPickUp??0; //in 
            chkCashPickUpPers = Convert.ToDouble(config.CashPickUpPercent); //in percent
        }

        private void SetHoidays()
        {
         //disabledSpecificDays = ["3-20-2015", "9-24-2015", "9-25-2015", "10-01-2015"];
            var holidays = DataAccess.DBAccess.GetHoliday();
            var list =  new List<string>();
            foreach (var holiday in holidays)
            {
                list.Add(holiday.DeliverDate.Value.ToString("M-d-yyyy"));
                //disabledSpecificDays = ( string.IsNullOrEmpty(disabledSpecificDays)) ? "\"" + holiday.DeliverDate.Value.ToString("MM-dd-yyyy") + "\"" : disabledSpecificDays + ",\"" + holiday.DeliverDate.Value.ToString("MM-dd-yyyy") + "\"";
                //disabledSpecificDays = (string.IsNullOrEmpty(disabledSpecificDays)) ?  holiday.DeliverDate.Value.ToString("MM-dd-yyyy") : disabledSpecificDays + "," + holiday.DeliverDate.Value.ToString("MM-dd-yyyy");
                
            }
            disabledSpecificDays = (new JavaScriptSerializer()).Serialize(list);
            //disabledSpecificDays =  list.ToArray();
        }

        private void SetWeeklyMenu(string showin)
        {
            ltrlRow.Text = HTMLGenerator.GetWeeklyMenu(string.Empty, showin);

            //lblDt1.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 1).ToString("dd-MMM-yyyy");
            //lblDt2.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 2).ToString("dd-MMM-yyyy");
            //lblDt3.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 3).ToString("dd-MMM-yyyy");
            //lblDt4.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 4).ToString("dd-MMM-yyyy");
            //lblDt5.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 5).ToString("dd-MMM-yyyy");
            //lblDt6.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 6).ToString("dd-MMM-yyyy");
        }
    }
}