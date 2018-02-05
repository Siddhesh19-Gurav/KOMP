using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KotaCoachings;
using System.Text;
using System.Web.UI;
using System.Configuration;
using KitchenOnMyPlate.Classes;
using System.Text.RegularExpressions;


namespace KitchenOnMyPlate.DataAccess
{
    public class HTMLGenerator
    {


        public static string GetSubProductUnderProduct(string showin,int productId, string Islunch)
        {
            string HTMLTexts = string.Empty;
            string HTMLRghtPd = string.Empty;
            string HTMLLftPd = string.Empty;
            
            var products = DataAccess.DBAccess.GetProducts();
            var subProducts = DataAccess.DBAccess.GetSubProducts();
            var plans = DataAccess.DBAccess.GetMealPlans();

            //if (!CacheHelper.Get("Food" + showin + productId + Islunch, out HTMLTexts))
            //{
            if (showin != "C") //TIFFIN/DINNER
            {
               
                foreach (var pro in products)
                {
                    
                    if (pro.Id == productId && (pro.ShowInBoth == showin || pro.ShowInBoth == "B"))
                    {
                        HTMLTexts = HTMLTexts + "<div class='ItemBox'>";

                        var header = pro.Header;
                        var detail = pro.Detail;
                        
                        //if (productId == 6)
                        //{
                            header = string.Empty;
                            detail = string.Empty;

                        //}



                            HTMLTexts = HTMLTexts + "<div class='TiffinHdrLft' ><h3 class='page-titleSmall'>" + header + "</h3>" + detail + "</div>";
                        //HTMLTexts = HTMLTexts + "<div class='TiffinHdrRgt' ><img class='ProImage' src='images/Product/thumbs/thumbs_" + pro.Picture + "' /></div>";                        

                        HTMLTexts = HTMLTexts + "<div class='Custimg'  >   <img src='images/abbg.png' style='position:absolute; right:-1px;top:-3px;' alt='" + pro.Header + "'  /><img alt='komp logo' title='komp logo' style='float:right;' class='AboutImg' src='images/Product/thumbs/thumbs_" + pro.Picture + "'></img></div>";
                        //HTMLTexts = HTMLTexts + "<div style='float:right;position:relative;width:320px;height:313px;overflow:hidden'  >   <img alt='komp logo' title='komp logo' style='float:right;' class='AboutImg' src='images/Product/thumbs/thumbs_" + pro.Picture + "'></img></div>";

                        HTMLTexts = HTMLTexts + "<div style='clear:both;height:0px'></div>";

                        HTMLTexts = HTMLTexts + "<span class='mealP'>Meal Plans</span></br>";
                            HTMLTexts = HTMLTexts + "<div style='clear:both;height:10px'></div>";

                        //V/N/TIT
                            HTMLTexts = HTMLTexts + "<div  class='subVeg' cat='1' ><span>VEG MEAL</span><div class='DownCornerShap1'></div></div><div class='subVeg'  cat='0'><span>NON-VEG MEAL</span><div class='DownCornerShap2'></div></div><div class='subVeg' cat='3'><span>V-NV</span><div class='DownCornerShap3'></div></div>";
                        var subProducts1 = (from w in subProducts where w.MenuId == pro.Id select w).ToList();
                        int subProductcount = 0;
                        int Price = 0;
                        string LastBorder = string.Empty;
                        foreach (var subPro in subProducts1)
                        {
                            subProductcount++;
                            if (subPro.NonCustomized == 0 || !(subPro.ShowInBoth == "2" || subPro.ShowInBoth == Islunch))
                            {
                                continue;
                            }

                           

                            
                            if (subProductcount == subProducts.Count)
                            {
                                //LastBorder = "subItemBoxLastBorder";
                            }

                            string strPlans = string.Empty;
                            int plancount = 0;
                            //string VegCust = subPro.Veg == 1 ? "VegCust" : "NonVegCust";
                            //string rs = subPro.Veg == 1 ? "rs.png" : "rs2.png";
                            string VegCust = "NonVegCust";
                            //var smallLarge = (subPro.Header.ToUpper().Contains("MINI")) ? "<span class='smalllarge'>(Small Portion)</span><br/>" : subPro.Header.ToUpper().Contains("NUTRI") ? "" : "<span class='smalllarge'>(Large Portion)</span><br/>";
                            string rs ="rs2.png";
                            Price = (int)subPro.Price;
                            var BreakIfMoreThan2 = (plans.Count > 2) ? "<br style='clear:both' />" : "";
                            foreach (var pl in plans)
                            {
                                plancount++;
                                string price = (pl.DaysInPlan * Convert.ToInt32(subPro.Price)).ToString();
                                price = price.Length == 3 ? price + "&nbsp;&nbsp;" : price;

                                strPlans = strPlans + "<div class='ProceedOnSub' ><span class='plan'>" + pl.Name + "</span> "+BreakIfMoreThan2+
                                    "<div style='float:left;text-align:right' ><span class='" + VegCust + "' ><img src='images/" + rs + "'  alt='Rs' />" + price + "</span></div>" +
                                    //"<br/><span class='price'><img src='images/rs.png' />" + pl.DaysInPlan * subPro.Price + "</span><br/>"+
                                    "<input class='btnRed service" + subPro.Id + pl.Id + "' type='button' onclick= SetSubPID('service" + subPro.Id +pl.Id+"','" + subPro.Id + "','" + pl.DaysInPlan + "','" + pl.ValidUpTo + "','" + pl.ValidUpTo + "','" + ((Islunch == "1") ? pl.DeliveryCharges.ToString() : pl.NightDeliveryCharges.ToString()) + "'); value='+ ORDER' /></div>";
                                strPlans = plans.Count != plancount?  strPlans +"<div class='planDivider'></div>":strPlans;
                            }
                            string strVeg = subPro.Veg == 1 ? "Veg" : (subPro.Veg == 0)?"Non-Veg":"TNT";
                            //string Category = subPro.Veg == 1 ? "class='Veg'": (subPro.Veg == 2 ? "class='TIT'":"class='Veg'");
                                                        

                            HTMLTexts = HTMLTexts + "<div id='" + subPro.Id + "' mealtype='" + subPro.Veg + "'  class='subItemBox " + LastBorder + "' >" +
                                                      //"<div class='leftsubDetails' >"+
                                                      //   "<div style='clear:both'></div>" +
                                                      //  "<div class='PNM'>" + subPro.Header +" <br/> <img src='images/rs1.png' /><span class='price' >" + subPro.Price + "</span></div>" +
                                                      //  //"<div><img src='images/rs.png' /><span class='price' >" + subPro.Price + "</span></div>"+
                                                      //"</div>" +
                                                      "<div class='leftsubDetails'>" +
                                                        "<div class='subProductHeader' >" + subPro.Header + "<span class='RSSmallMore' style='font-size:27px;color:#F16822; margin-left:15px'  ><i class='fa fa-inr'></i></span>" + Price + "</div> <span class='smalllarge' style='color:black;font-style: italic;'> " + subPro.Calories + "</span>" +
                                                            "<div style='clear:both'></div>" +
                                                            "<div class='subProductDetails' >" + ((Islunch == "1") ? subPro.Detail : subPro.DetailDinner) + "</div>" +
                                                        "<div style='clear:both'></div>"+
                                                        strPlans+
                                                      "</div>" +
                                                      "<div style='clear:both;'></div>" +
                                                    "</div>";

                        }
                        HTMLTexts = HTMLTexts + "</div>";
                    }
                }

            }
            else
            {
                int index = 0; //customized
                int indexCustCol = 0;
                int Price = 0; ;
                string LastStr = string.Empty;
                HTMLLftPd = HTMLLftPd + "<div class='CustLeft' >";
                HTMLLftPd = HTMLLftPd + "<p class='FistArt'>Yes, you can virtually design your own meals. The idea is to tickle your palate, every day. Just choose more than one plan of your choice from:</p>";
                HTMLRghtPd = HTMLRghtPd + "<div class='CustRight customise-plates' >";
                
                foreach (var pro in products)
                {
                    
                    if (pro.ShowInBoth == showin || pro.ShowInBoth == "B")
                    {
                        //LeftList Start                        
                        HTMLLftPd = HTMLLftPd + "<div>";
                        //HTMLLftPd = HTMLLftPd + "<div style='width:100%;' ><h3 class='page-titleSmallNoBorder'>" + pro.Header + "</h3></div>";
                        HTMLLftPd = HTMLLftPd + "<div style='width:100%;' ><img class='buttleted' src='images/tick.png' /> <strong>" + ((pro.ShowInBoth == "B") ? pro.HeaderCus : pro.Header) + ": </strong>" + ((pro.ShowInBoth == "B") ? pro.DetailCus : pro.Detail) + "</div>";
                        HTMLLftPd = HTMLLftPd + "</div>";
                        //LeftList List end



                        //RightList Start
                        index++;
                        indexCustCol++;
                        if (indexCustCol==5)
                        {
                            indexCustCol = 1;
                        }

                        HTMLRghtPd = (index % 2 == 1) ? HTMLRghtPd = HTMLRghtPd + "<ul>" : HTMLRghtPd;
                        LastStr = (index % 2 == 0) ? "class='last'" : "";
                        HTMLRghtPd = HTMLRghtPd + "  <li " + LastStr + ">";
                        HTMLRghtPd = HTMLRghtPd + "      <a href='YourOrder.aspx?item=" + pro.Id + "'>";
                        HTMLRghtPd = HTMLRghtPd + "      <img src='images/Product/thumbs/thumbs_" + pro.Picture + "' style='width:170px;height:120px' alt='" + pro.Header + "'>";
                        HTMLRghtPd = HTMLRghtPd + "                  <p class='col" + indexCustCol + "'>";
                        HTMLRghtPd = HTMLRghtPd + "                    <span></span>";

                        var hdrtxt = ((pro.ShowInBoth == "B") ? pro.HeaderCus : pro.Header);

                        if (hdrtxt.Split(' ')[0].Length > 12)
                        {
                            HTMLRghtPd = HTMLRghtPd + hdrtxt.Split(' ')[1].ToString() + "";

                        }
                        else
                        {
                            HTMLRghtPd = HTMLRghtPd + Regex.Match(hdrtxt, @"^(\w+\b.*?){2}").ToString() + "";
                        }

                        //HTMLRghtPd = HTMLRghtPd + "                    " + Regex.Match(((pro.ShowInBoth == "B") ? pro.HeaderCus : pro.Header), @"^(\w+\b.*?){2}").ToString() + "";

                        HTMLRghtPd = HTMLRghtPd + "                  </p>";
                        HTMLRghtPd = HTMLRghtPd + "                  </a>";
                        HTMLRghtPd = HTMLRghtPd + "              </li>";
                        HTMLRghtPd = (index % 2 == 0) ? HTMLRghtPd = HTMLRghtPd + "</ul>" : HTMLRghtPd;
                        //Rioght List end

                        //HTMLTexts = HTMLTexts + "<div class='ItemBox'>";
                        //HTMLTexts = HTMLTexts + "<div style='width:100%;' ><h3 class='page-titleSmallNoBorder'>" + pro.Header + "</h3></div>";
                        //HTMLTexts = HTMLTexts + "<div style='width:70%;float:left;' >" + pro.Detail + "</div>";
                        //HTMLTexts = HTMLTexts + "<div style='width:30%;float:left;' ><img class='ProImage' src='images/Product/thumbs/" + pro.Picture + "' /></div>";
                        //HTMLTexts = HTMLTexts + "<div style='clear:both'></div>";

                        //V/N/TIT
                        //HTMLTexts = HTMLTexts + "<div  class='subVeg' cat='1' ><span>VEG MEAL</span></div><div class='subVeg'  cat='0'><span>NON-VEG MEAL</span></div><div class='subVeg' cat='2'><span>V-NV</span></div>";
                        var subProducts1 = (from w in subProducts where w.MenuId == pro.Id && (w.NonCustomized == 1 || (w.NonCustomized != 1 && w.ShowDetails == 0))==false select w).ToList();
                        int subProductcount = 0;
                        string LastBorder = string.Empty;
                        
                        string br = index == 1 ? "" : "<br/>";
                        HTMLTexts = HTMLTexts + "<div style='clear:both;'></div>";
                        HTMLTexts = HTMLTexts + br + "<div class='CustHeader' id='selectedItem" + pro.Id + "' >" + ((pro.ShowInBoth == "B") ? pro.HeaderCus : pro.Header) + "<span class='availBDays'>(" + DBAccess.GetAvailabilityOfMainProduct(pro.Id) + ")</span></div>";
                          HTMLTexts = HTMLTexts + "<div style='clear:both;'></div>";
                        foreach (var subPro in subProducts1)
                        {
                            
                            if (subPro.NonCustomized == 1 || (subPro.NonCustomized != 1 && subPro.ShowDetails ==0))
                            {
                                continue;
                            }
                            subProductcount++;



                            if (subProductcount == subProducts1.Count)
                            {
                                LastBorder = " subItemBoxLastBorder";
                            }

                            
                            string strVeg = subPro.Veg == 1 ? "Veg" : (subPro.Veg == 0) ? "Non-Veg" : "TNT";
                            string VegCust = "NonVegCust";
                            string rs = "rs2.png";
                            Price = (int)subPro.Price;
                            //string VegCust = subPro.Veg == 1 ? "VegCust" : "NonVegCust";
                            //string rs = subPro.Veg == 1 ? "rs.png" : "rs2.png";
                            var smallLarge = (subPro.Header.ToUpper().Contains("MINI")) ? "<span class='smalllarge'>(Small Portion)</span><br/>" : (subPro.Header.ToUpper().Contains("FULL") && subPro.Header.ToUpper().Contains("GRAND")) ? "<span class='smalllarge'>(Large Portion)</span><br/>":"";
                            //string Category = subPro.Veg == 1 ? "class='Veg'": (subPro.Veg == 2 ? "class='TIT'":"class='Veg'");
                            HTMLTexts = HTMLTexts + "<div id='" + subPro.Id + "' mealtype='" + subPro.Veg + "'  class='subItemBox" + LastBorder + "' >" +

                                                      "<div class='leftsubDetailsCust' >" +
                                                            "<div class='subProductHeader' >" + subPro.Header + "</div><span class='smalllarge' style='color:black;font-style: italic;'> " + subPro.Calories + "</span>"+
                                                            "<div style='clear:both'></div>" +
                                                            "<div class='subProductDetails' >" + subPro.Detail + "</div>" +
                                                            //Available days start
                                                                                  "<div>" +
                                                                                    "<div class='availSP' ><span>" + subPro.Varity + "</span></div>" +
                                                                                  "</div>" +
                                                            //Available days end
                                                      "</div>" +
                                                      "<div class='rightsubDetails'>" +
                                                        "<div style='clear:both;float:right;text-align:right' ><span class='" + VegCust + "' ><img src='images/" + rs + "' />" + Price + "</span></div>" +
                                                      "</div>" +
                                                      

                                                      "<div style='clear:both;'></div>" +
                                                    "</div>";
                        }

                     

                    

                    }

                    
                }

                HTMLLftPd = HTMLLftPd + "</div>";
                HTMLRghtPd = HTMLRghtPd + "</div>";

                //Note start
                HTMLTexts = HTMLTexts + "<div id='3382'  style='display:block!important;clear: both;width: 100%;height: auto; margin-top:20px; border: 1px solid #c8c6c6;font-family: RobotoBlack;'>";
                HTMLTexts = HTMLTexts + "<div class='leftsubDetails'>";
                HTMLTexts = HTMLTexts + "<div style='clear:both'></div>";
                HTMLTexts = HTMLTexts + "<div class='subProductDetails'>";
                HTMLTexts = HTMLTexts + "<span style='font-size:13px;' >*Meal Prices are exclusive of all Taxes.  <br />";
                HTMLTexts = HTMLTexts + "**Delivery Charges : 5 Days – Rs. 200 | 10 Days – Rs. 300 | 22 Days – Rs. 660 |44 Days – Rs. 1320";
                HTMLTexts = HTMLTexts + "</span>";
                HTMLTexts = HTMLTexts + "</div>";
                HTMLTexts = HTMLTexts + "</div>";
                HTMLTexts = HTMLTexts + "<div style='clear:both;'></div>";
                HTMLTexts = HTMLTexts + "</div>";
                //Note end
           
                HTMLTexts = HTMLTexts + "<div class='DivWithButtonOnly'>" +
                                                "<input class='btnRed' type='button' onclick = ShowPlans(); value=' ORDER NOW! ' />" +
                                             "</div>";

              

                HTMLTexts = HTMLTexts + "</div>"; //

                HTMLTexts = HTMLLftPd + HTMLRghtPd + HTMLTexts;
           
                //}
            }

            //if (HTMLTexts != null)
            //{
            //    CacheHelper.Add(HTMLTexts, "Food" + showin + productId + Islunch, 2000);
            //}

            

            return HTMLTexts;

        }

        public static string GetProductOnHomeHTML()
        {
            string HTMLTexts = string.Empty;

            var products = DataAccess.DBAccess.GetProducts();

            var productsFilder = (from w in products where w.ShowInBoth == "C" || w.ShowInBoth == "B" select w).ToList();
           
                
                int index = 0;
                int indexCustCol = 0;
                string LastStr = string.Empty;
                foreach (var pro in productsFilder)
                {
                    index++;
                    indexCustCol++;
                     if (indexCustCol==5)
                        {
                            indexCustCol = 1;
                        }
                    HTMLTexts = (index % 2 == 1) ? HTMLTexts = HTMLTexts + "<ul>" : HTMLTexts;                    
                    LastStr = (index%2==0)?"class='last'":"";
                    HTMLTexts = HTMLTexts + "  <li " + LastStr + ">";
                        HTMLTexts = HTMLTexts + "      <a href='YourOrder.aspx?item=" + pro.Id + "&sc=pt' >";
                        HTMLTexts = HTMLTexts + "      <img src='images/Product/thumbs/thumbs_" + pro.Picture + "' style='width:170px;height:120px' alt='" + pro.Header + "' >";
                        HTMLTexts = HTMLTexts + "                  <p class='col" + indexCustCol + "'>";
                        HTMLTexts = HTMLTexts + "                    <span></span>";
                        if (pro.Header.Split(' ')[0].Length > 12)
                        {
                            HTMLTexts = HTMLTexts +  pro.Header.Split(' ')[1].ToString() + "";

                        }
                        else
                        {
                            HTMLTexts = HTMLTexts +  Regex.Match(pro.Header, @"^(\w+\b.*?){2}").ToString() + "";
                        }
                        HTMLTexts = HTMLTexts + "                  </p>";
                        HTMLTexts = HTMLTexts + "                  </a>";
                        HTMLTexts = HTMLTexts + "              </li>";

                        HTMLTexts = (index % 2 == 0) ? HTMLTexts = HTMLTexts + "</ul>" : HTMLTexts;
                }
                



            //if (HTMLTexts != null)
            //{
            //    CacheHelper.Add(HTMLTexts, "Food" + showin, 2000);
            //}



            return HTMLTexts;

        }

        public static string GetOrderedItems(int orderId)
        {
            string list = string.Empty;

            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                
                var order = (from w in db.Orders where w.Id == orderId select w).First();
                var payment = (from w in db.Payments  where w.OrderId == orderId select w).First();  

                var propertyType = (from w in db.MenuItems
                                    join O in db.OrderDetails
                                    on w.Id equals O.SubProductId
                                    where w.IsActive == 1 && O.OrderId == orderId
                                    orderby O.DeliverDate ascending 
                                    select new { subProductId = w.Id, SubProductName = w.Header, DeleiveryDate = O.DeliverDate, Price = w.Price, Detail = w.Detail }).ToList();

                var customerName = (from w in db.ShippingBillings where w.RequestId == order.RequestId select w).First().FirstName;  

                string dates_in_string = string.Empty;
                foreach (var item in propertyType)
                {
                    dates_in_string = dates_in_string != string.Empty ? dates_in_string + ", " + item.DeleiveryDate.Value.ToString("dd/MM/yyyy") : dates_in_string + item.DeleiveryDate.Value.ToString("dd/MM/yyyy");
                }

                list = "<table id='tableQuantity' class='tbl' cellspacing='1' ><tbody>";
                if (order.NonCustomized == 1)
                {
                    list = list + "<tr class='divRow dataHeader DR" + propertyType.Count + 1 + "' style='background:#fff;height:0px' ></tr>";
                    list = list + "<tr class='divRow dataHeader DR" + propertyType.Count + 1 + "' style='background:#F16822;color:#fff;font-family:RobotoBold;font-size:1.2em;' ><td colspan='5' >" + "ORDER #" + orderId + "  CUSTOMER: " + customerName.ToUpper() + "</td></tr>";
                    list = list + "<tr class='divRow dataHeader DR'><td><b>MEAL DETAILS</b></td><td><b>AMOUNT DETAILS</b></td></tr>";
                    list = list + "<tr class='divRow DR'><td style='width:70%;' id='divPNAME'>" + propertyType[0].SubProductName + "</td><td style='width:30%;' align='right'><span class='RSSmallMore'><i class='fa fa-inr'></i></span><strong style='padding-right:25px;font-family:RobotoBlack;padding-right:25px;font-size:1.4em'>" + payment.Amount + "</strong></td></tr>";
                    list = list + "<tr class='divRow DR" + propertyType.Count + 1 + "' align='right' style='font-size:1.4em' ><td><span style='font-family:RobotoBlack' >Delivery Charge&nbsp;&nbsp;</span>  </td><td align='right' ><span class='RSSmallMore'><i class='fa fa-inr'></i></span><span style='font-family:RobotoBlack;padding-right:25px' >" + payment.DeliveryChrg + "</span></td></tr>";

                    if (payment.TrnChrg > 0)
                    {
                        if (payment.Mode == 14)
                        {
                            list = list + "<tr class='divRow DR" + propertyType.Count + 1 + "'  style='font-size:1.4em' ><td align='right' ><span style='font-family:RobotoBlack' >Offline Cash Pick up Charge&nbsp;&nbsp;</span>  </td><td align='right' ><span class='RSSmall'><i class='fa fa-inr'></i></span><span style='font-family:RobotoBlack;padding-right:25px' >" + payment.TrnChrg + "</span></td></tr>";
                        }
                        else
                        {
                            list = list + "<tr class='divRow DR" + propertyType.Count + 1 + "'  style='font-size:1.4em' ><td align='right' ><span style='font-family:RobotoBlack' >Online Processing Charge&nbsp;&nbsp;</span>  </td><td align='right' ><span class='RSSmall'><i class='fa fa-inr'></i></span><span style='font-family:RobotoBlack;padding-right:25px' >" + payment.TrnChrg + "</span></td></tr>";
                        }
                    }


                    //list = list + "<tr class='divRow DR" + propertyType.Count + 1 + "' align='right' style='font-size:1.4em' ><td><span style='font-family:RobotoBlack' >Amount&nbsp;&nbsp;</span>  </td><td align='right' ><span class='RSSmall'><i class='fa fa-inr'></i></span><span style='font-family:RobotoBlack;padding-right:25px' >" + payment.Amount + "</span></td></tr>";
                    list = list + "<tr class='divRow DR" + propertyType.Count + 1 + "' align='right' style='font-size:1.4em' ><td><span style='font-family:RobotoBlack' >Total Amount&nbsp;&nbsp;</span>  </td><td align='right' ><span class='RSSmall'><i class='fa fa-inr'></i></span><span style='font-family:RobotoBlack;padding-right:25px' >" + String.Format("{0:.00}", Convert.ToDecimal(payment.Amount) + Convert.ToDecimal(payment.TrnChrg) + Convert.ToDecimal(payment.DeliveryChrg)) + "</span></td></tr>";

                    
                    list = list + "<tr class='divRow DR" + propertyType.Count + "'><td align='left' colspan='2'><span style='font-family:RobotoBlack' >Delivery Dates:" + dates_in_string + "</span></td></tr>";

                }
                else
                {
                    list = list + "<tr class='divRow dataHeader DR" + propertyType.Count + 1 + "' style='background:#fff;height:12px' ></tr>";
                    list = list + "<tr class='divRow dataHeader DR" + propertyType.Count + 1 + "' style='background:#F16822;color:#fff;font-family:RobotoBold;font-size:1.2em;' ><td colspan='5' >ORDER #"+orderId +" </td></tr>";
                    list = list + "<tr class='divRow dataHeader DR" + propertyType.Count + 1 + "'><td align='center'><b>DATE</b></td><td align='center'><b>DAY</b></td><td><b>MEAL NAME</b></td><td align='center'><b>QUANTITY</b></td><td align='center'><b>PRICE</b></td></tr>";

                    foreach (var item in propertyType)
                    {
                        list = list + "<tr class='divRow divRowData DR" + propertyType.Count + 1 + "'><td align='center'>" + item.DeleiveryDate.Value.ToString("dd/MM/yyyy") + "</td><td align='center'>" + item.DeleiveryDate.Value.DayOfWeek + "</td><td class='RobotoBold'>" + item.SubProductName + "</td><td align='center'>1</td><td align='right'><span class='RSSmallMore'><i class='fa fa-inr'></i></span><span style='padding-right:25px'>" + item.Price + "</span></td></tr>";                        
                    }

                    list = list + "<tr class='divRow DR" + propertyType.Count + 1 + "' align='right' style='font-size:1.4em' ><td colspan='4'><span style='font-family:RobotoBlack' >Delivery Charge&nbsp;&nbsp;</span>  </td><td align='right' ><span class='RSSmallMore'><i class='fa fa-inr'></i></span><span style='font-family:RobotoBlack;padding-right:25px' >" + payment.DeliveryChrg + "</span></td></tr>";

                    if (payment.TrnChrg > 0)
                    {
                        if (payment.Mode == 14)
                        {
                            list = list + "<tr class='divRow DR" + propertyType.Count + 1 + "' align='right' style='font-size:1.4em' ><td colspan='4' align='right'><span style='font-family:RobotoBlack' >Offline Cash Pick up Charge&nbsp;&nbsp;</span>  </td><td align='right' ><span class='RSSmall'><i class='fa fa-inr'></i></span><span style='font-family:RobotoBlack;padding-right:25px' >" + String.Format("{0:.00}", payment.TrnChrg) + "</span></td></tr>";
                        }
                        else
                        {
                            list = list + "<tr class='divRow DR" + propertyType.Count + 1 + "' align='right' style='font-size:1.4em' ><td colspan='4' align='right'><span style='font-family:RobotoBlack' >Online Processing Charge&nbsp;&nbsp;</span>  </td><td align='right' ><span class='RSSmall'><i class='fa fa-inr'></i></span><span style='font-family:RobotoBlack;padding-right:25px' >" + String.Format("{0:.00}", payment.TrnChrg) + "</span></td></tr>";
                        }
                        
                    }
                    list = list + "<tr class='divRow DR" + propertyType.Count + 1 + "' align='right' style='font-size:1.4em' ><td colspan='4'><span style='font-family:RobotoBlack' >Amount&nbsp;&nbsp;</span>  </td><td align='right' ><span class='RSSmall'><i class='fa fa-inr'></i></span><span style='font-family:RobotoBlack;padding-right:25px' >" + String.Format("{0:.00}", payment.Amount) + "</span></td></tr>";
                    list = list + "<tr class='divRow DR" + propertyType.Count + 1 + "' align='right' style='font-size:1.4em' ><td colspan='4'><span style='font-family:RobotoBlack' >Total Amount&nbsp;&nbsp;</span>  </td><td align='right' ><span class='RSSmall'><i class='fa fa-inr'></i></span><span style='font-family:RobotoBlack;padding-right:25px' >" + String.Format("{0:.00}", Convert.ToDecimal(payment.Amount) + Convert.ToDecimal(payment.TrnChrg) + Convert.ToDecimal(payment.DeliveryChrg)) + "</span></td></tr>";

                    
                }

                list = list + "</tbody></table>";

                //foreach (var item in propertyType)
                //{
                //    list = list + "<div style='clear:both;width:100%'><div style='width:20%;float:left'>" + item.SubProductName + "</div><div style='width:40%;float:left'>" + item.Detail + "</div><div style='width:20%;float:left'>" + item.DeleiveryDate + " </div><div style='width:20%;float:left'>" + item.Price + " </div></div>";
                //    //OrderedItems orderedItems = new OrderedItems { ProductId = item.subProductId.ToString(), ProductName = item.SubProductName, DeliverDate = item.DeleiveryDate.ToString(), Price = item.Price.ToString() };
                //    //list.Add(orderedItems)
                //      //  list = list+"";
                //}

            }


            return list;

        }

        public static string GetWeeklyMenu(string action, string showin)
        {
            string HTMLTexts = string.Empty;

            //if(action != "")
            //{
            //    CacheHelper.Clear("WEEKLYMENU" + action);
            //}

            if (!CacheHelper.Get("WEEKLYMENU"+action, out HTMLTexts))
            {

                var weeklyMenu = DataAccess.DBAccess.GetWeeklyMenu(showin);
                action = action == "" ? "style='display:none'" : "";

                // HTMLTexts = HTMLTexts + "<table class='text weeklyMenuTable' border='1' width='100%' cellspacing='0' cellpadding='2' align='center' bordercolor='#c8c6c6'>";
                /// HTMLTexts = HTMLTexts + "<tbody class='plan'>";

                string bgColor = "#fff;";
                string FColor = string.Empty;
                
                int rowCount = 0;
                foreach (var pro in weeklyMenu)
                {
                    bgColor = "#fff;";
                    FColor = string.Empty;
                    rowCount++;
                    if (rowCount == 1) { bgColor = "#4ba91f"; FColor = "color:#fff;"; } else if (rowCount == 2) { bgColor = "#963634"; FColor = "color:#fff;"; } else { bgColor = "#fff"; }

                    HTMLTexts = HTMLTexts + "<tr id='tr" + pro.Id + "' valign='middle' style='background-color:" + bgColor + ";" + FColor + "' >" +
                    "<td align='center' style='border-right-width:5px;border-right-color:#c8c6c6;border-right-style:solid;'><span><strong>" + pro.MenuItm + "</strong></span></td>" +
                    "<td align='center'><span><strong>" + pro.Monday + "</strong></span></td>" +
                    "<td align='center'><span><strong>" + pro.Tuesday + "</strong></span></td>" +
                    "<td align='center'><span><strong>" + pro.Wednesday + "</strong></span></td>" +
                    "<td align='center'><span><strong>" + pro.Thursday + "</strong></span></td>" +
                    "<td align='center'><span><strong>" + pro.Friday + "</strong></span></td>" +
                    "<td align='center'><span><strong>" + pro.Saturday + "</strong></span></td>" +
                    "<td align='center' style='display:none' ><span><strong>" + pro.Sunday + "</strong></span></td>" +
                    "<td align='center' " + action + "><span><strong><input type='button' onclick=SelectRow('tr" + pro.Id + "')  value='Select' /><input type='button' onclick=Delete('tr" + pro.Id + "')  value='Delete' /></strong></span></td>" +
                    "</tr>";
                }

                //  HTMLTexts = HTMLTexts + "</tbody></table>";

                CacheHelper.Add(HTMLTexts, "WEEKLYMENU" + action, 2000);
            }

            return HTMLTexts;

        }
    }
}