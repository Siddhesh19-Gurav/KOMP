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
    public partial class YourOrder : System.Web.UI.Page
    {
        protected int loggiedIn = 0;
        protected int minDateAdmin = 3;
        protected string disabledSpecificDays;
        protected int dayOfWeek = (int)DateTime.Today.DayOfWeek;
        protected int DeliveryChrg = 0;
        protected int TrnChrg = 0; //in percent
        protected string selectedItem = string.Empty;
        protected string scPostion = string.Empty;
        protected OrderDTO[] orderlst = new List<OrderDTO>().ToArray();
        public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
        protected float chkCashPickUp = 0; //in 
        protected double chkCashPickUpPers = 0; //in percent

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["OrderList"] != null)
            {
                //HttpContext.Current.Session["OrderList"] = orders;
                orderlst = ((OrderList)HttpContext.Current.Session["OrderList"]).orders.ToArray();
                if (orderlst.Length > 0)
                {
                    txtPinCode.Value = orderlst[0].Order.pincode.ToString();
                    txtPinCode.Disabled = true;
                }
                                
            }

            Page.Title = "Best Online Customized Tiffin Service in Mumbai - kitchenonmyplate.com";
            Page.MetaDescription = "KOMP is offers online Customised tiffin service in Mumbai. Choose Customised meal and Call us or email, we will be at your place to serve your delicious favorite meal.";
            Page.MetaKeywords = "Best Online Customized Tiffin Service in Mumbai, Customized Tiffin Service, Customised Meal Services, Stuffed Paratha Plate, Mouthwatering Biryani Plate, Special Khichdi Plate";


            if (CommanAction.GetSession() != null)
            {
                loggiedIn = CommanAction.GetSession().UserId;
                minDateAdmin = (CommanAction.GetSession().UserType == "N") ? 3 : 3;
            }

            //If requst order from tomorrow start            
            if (Session["ORDERFROMTOMORROW"] != null)
            {
                DateTime serverTime = DateTime.Now;
                DateTime utcTime = serverTime.ToUniversalTime();
                // convert it to Utc using timezone setting of server computer
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                string date = Session["ORDERFROMTOMORROW"].ToString().Trim();
                //int date = Convert.ToInt32(Session["ORDERFROMTOMORROW"]);
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

                //start from 1 PM
                if (timeInIndia.Hour > 12 && timeInIndiaAsString.Contains("PM"))
                {
                    minDateAdmin = 2;
                }
                else
                {
                    minDateAdmin = 3;
                }
            }
            //If requst order from tomorrow end

            var item = Page.RouteData.Values["itm"] as string;
            if (!string.IsNullOrEmpty(item))
            {
                selectedItem = item;
            }


            if (!IsPostBack)
            {
                BindLocation();
                SetItems();
                SetHoidays();
                SetConfig();
            }

            if (Request.QueryString["sc"] != null)
            {
                scPostion = Request.QueryString["sc"];
            }
        }

        private void BindLocation()
        {
          // DBAccess.BindAllLocation(drpAgentLocation);
        }

        private void SetItems()
        {
            divItem.InnerHtml = HTMLGenerator.GetSubProductUnderProduct("C",0,"1");
        }

        private void SetHoidays()
        {
            //disabledSpecificDays = ["3-20-2015", "9-24-2015", "9-25-2015", "10-01-2015"];
            var holidays = DataAccess.DBAccess.GetHoliday();
            var list = new List<string>();
            foreach (var holiday in holidays)
            {
                // list.Add(holiday.DeliverDate.Value.ToString("MM-dd-yyyy"));
                //disabledSpecificDays = ( string.IsNullOrEmpty(disabledSpecificDays)) ? "\"" + holiday.DeliverDate.Value.ToString("MM-dd-yyyy") + "\"" : disabledSpecificDays + ",\"" + holiday.DeliverDate.Value.ToString("MM-dd-yyyy") + "\"";
                disabledSpecificDays = (string.IsNullOrEmpty(disabledSpecificDays)) ? "'" + holiday.DeliverDate.Value.ToString("MM-dd-yyyy") + "'" : disabledSpecificDays + ",'" + holiday.DeliverDate.Value.ToString("MM-dd-yyyy") + "'";

            }
            //disabledSpecificDays =  list.ToArray();
        }

        private void SetConfig()
        {
            var config = DBAccess.GetConfig();
            DeliveryChrg = config.DeliveryChrg ?? 0;
            TrnChrg = config.TrnChrg ?? 0; //in percent

            chkCashPickUp = config.CashPickUp ?? 0; //in 
            chkCashPickUpPers = Convert.ToDouble(config.CashPickUpPercent); //in percent
        }
    }
}