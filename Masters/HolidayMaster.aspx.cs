using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KitchenOnMyPlate.Masters
{
    public partial class HolidayMaster : System.Web.UI.Page
    {
        protected int cnt = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["USER"] != null)
                {

                    //if (((User)Session["USER"]).UserType != "N") // If not admin
                    //{
                    //    Response.Redirect("Default.aspx?Q=123456789");
                    //}
                }
                else
                {
                    Response.Redirect("Masters/ManageOrders.aspx");
                }
            }

            SetHoidays();
        }

        private void SetHoidays()
        {
            var holidays = DataAccess.DBAccess.GetHoliday();
            foreach(var holiday in holidays )
            {
                divHolidayList.InnerHtml = divHolidayList.InnerHtml + "<div id='divDt" + cnt + "' > <span class='spndt'>" + holiday.DeliverDate.Value.ToString("dd/MM/yyyy") + "</span> <span  style='cursor:pointer' onclick=DeleteItem('divDt" + cnt + "') ><b>X</b></span>  </div>";
                cnt++;
            }
        }
    }
}