using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KitchenOnMyPlate.DataAccess;

namespace KitchenOnMyPlate.Masters
{
    public partial class WeeklyMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void weeklyMenu()
        {
            if(drpMenyType.SelectedValue=="0")
            {
                tblenter.Visible = false;
              //  tblweekly.Style.Add("disppaly","none");
            }else
            {
              //  tblweekly.Style.Remove("disppaly");
                tblenter.Visible = true;

            ltrlRow.Text = HTMLGenerator.GetWeeklyMenu(drpMenyType.SelectedValue, drpMenyType.SelectedValue);
            }

            lblDt1.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 1).ToString("dd-MMM-yyyy");
            lblDt2.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 2).ToString("dd-MMM-yyyy");
            lblDt3.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 3).ToString("dd-MMM-yyyy");
            lblDt4.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 4).ToString("dd-MMM-yyyy");
            lblDt5.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 5).ToString("dd-MMM-yyyy");
            lblDt6.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 6).ToString("dd-MMM-yyyy");
            lblDt7.Text = DateTime.Today.AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 7).ToString("dd-MMM-yyyy");
        }

        protected void drpMenyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            weeklyMenu();
        }
    }
}