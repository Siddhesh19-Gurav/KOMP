using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MumbaiPropertyMart
{
    public partial class ReportProperties : System.Web.UI.Page
    {
        private bool ISAdding = false;
        private List<CityDivision> listCityDivision;
        //private bool IsEnabled = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["USER"] != null)
            {

                if (((User)Session["USER"]).UserType != "N") // If not admin
                {
                    // Response.Redirect("Default.aspx?Q=123456789");
                }
            }
            else
            {
                //Response.Redirect("Default.aspx");
            }


            if (!IsPostBack)
            {
                BindDivision();
                if (!string.IsNullOrEmpty(Request.QueryString["userid"]))
                {
                    drpRegion.SelectedValue = Request.QueryString["userid"];                    
                }

                if (!string.IsNullOrEmpty(Request.QueryString["locationId"]))
                {
                    drpLocation.SelectedValue = Request.QueryString["locationId"];
                }

                if (!string.IsNullOrEmpty(Request.QueryString["propertyType"]))
                {
                    drpPropertyType.SelectedValue = Request.QueryString["propertyType"];
                }


                BindProjects();                    

            }
        }

        void BindDivision()
        {
            using (DBKotaEstateDataContext obj = new DBKotaEstateDataContext())
            {
                var userList = (from n in obj.Users
                                orderby n.FirstName
                                select new { ID = n.UserId, UserName = n.FirstName + " " + n.LastName + "(" + n.UserType + n.UserId + ")" });

                //var cityDivision = KotaCoachings.DataAccess.DBAccess.GetDivisions();
                //listCityDivision = cityDivision;

                if (!ISAdding)
                {
                    drpRegion.DataSource = userList;
                    drpRegion.DataTextField = "UserName";
                    drpRegion.DataValueField = "Id";
                    drpRegion.DataBind();
                    drpRegion.Items.Add(new ListItem { Value = "0", Text = "--Select User--", Selected = true });
                }
            }


            KotaCoachings.DataAccess.DBAccess.BindAllPropertyType(drpPropertyType);
            KotaCoachings.DataAccess.DBAccess.BindAllLocationOfProperties(drpLocation);
        }

        protected void gvPrice_UpdateCommand(object sender, GridViewEditEventArgs e)
        {

        }

        protected void BindProjects()
        {

            using (DBKotaEstateDataContext obj = new DBKotaEstateDataContext())
            {
                string buyType = "";
                    if(rdBuy.Checked)
                    {
                        buyType = "S";
                    }
                    else if ( rdRent.Checked)
                    {
                        buyType = "R";
                    }

                    if ((from n in obj.Properties

                         join t in obj.PropertyTypes
                                   on n.PropertyType equals t.Id.ToString()


                         join u in obj.Users
                                   on n.Owner equals u.UserId

                         join L in obj.tblLocations
                                    on n.LocationId equals L.Id into wlL
                         from F in wlL.DefaultIfEmpty()

                         where (drpRegion.SelectedValue == "0" ? true : n.Owner == Convert.ToInt32(drpRegion.SelectedValue))
                         && (drpLocation.SelectedValue == "0" ? true : F.Id == Convert.ToInt32(drpLocation.SelectedValue))
                         && (buyType == "" ? true : n.BuyType == buyType)
                         && (drpPropertyType.SelectedValue == "0" ? true : t.Id.ToString() == drpPropertyType.SelectedValue)
                         select u).Count() > 0)
                {
                    gvPrice.Visible = true;

                    var list = (from n in obj.Properties

                                join t in obj.PropertyTypes
                                          on n.PropertyType equals t.Id.ToString()


                                join u in obj.Users
                                          on n.Owner equals u.UserId

                                join L in obj.tblLocations
                                           on n.LocationId equals L.Id into wlL
                                from F in wlL.DefaultIfEmpty()

                                where (drpRegion.SelectedValue == "0" ? true : n.Owner == Convert.ToInt32(drpRegion.SelectedValue))
               && (drpLocation.SelectedValue == "0" ? true : F.Id == Convert.ToInt32(drpLocation.SelectedValue))
               && (buyType == "" ? true : n.BuyType == buyType)
               && (drpPropertyType.SelectedValue == "0" ? true : t.Id.ToString() == drpPropertyType.SelectedValue)
                                select new
                                {
                                    ID = ("P" + n.BuyType + n.Id),
                                    PropertyType = ((n.BedRoom > 0) ? (n.BedRoom + " BHK " + t.Name) : t.Name),
                                    Area = (n.Area.ToString() + ((n.MeasureUnit == 1) ? "Square-Feet" :
                                    n.MeasureUnit == 2 ? "Square-Meter" :
                                    n.MeasureUnit == 3 ? "Square-Yard" :
                                    n.MeasureUnit == 4 ? "Hectares" :
                                    n.MeasureUnit == 5 ? "Acres" :
                                    n.MeasureUnit == 6 ? "Bigha" : "")),
                                    Price = n.Price + " INR",
                                    RentOrSale = ((n.BuyType == "R") ? " on Rent" : " for Sale"),
                                    Location = F.Location,
                                    Address = n.Address,
                                    CreatedDate = n.CreatedOn,
                                    User = (u.FirstName + " " + u.LastName),
                                    Email = u.email,
                                    contact1 = u.mobile,
                                    contact2 = u.LandLine,
                                    contact3 = u.LandLine1,
                                    contact4 = u.LandLine2
                                });

                    lblTotal.Text = list.Count().ToString();
                    gvPrice.DataSource = list;
                    //n.CreatedOn.Value.ToString("dd/MMM/yy")

                    

                    gvPrice.DataBind();
                }
                else
                {
                    gvPrice.Visible = false;
                }
            }
        }

        private string GetUnitType(int type)
        {
            //Unit Type Start
            string UnitType = "Square-Feet";

            if (type == 1 || type == 0)
            {
                UnitType = "Square-Feet";
            }
            else if (type == 2)
            {
                UnitType = "Square-Meter";
            }
            else if (type == 3)
            {
                UnitType = "Square-Yard";
            }
            else if (type == 4)
            {
                UnitType = "Hectares";
            }
            else if (type == 5)
            {
                UnitType = "Acres";
            }
            else if (type == 6)
            {
                UnitType = "Bigha";
            }
            //Unity Type end

            return UnitType;
        }

        protected void EditCustomer(object sender, GridViewEditEventArgs e)
        {

            gvPrice.EditIndex = e.NewEditIndex;

           // BindUsers(gvPrice.Rows[e.NewEditIndex].Cells[2].Text);

        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            BindDivision();
            gvPrice.EditIndex = -1;

            //BindUsers(gvPrice.Rows[e.RowIndex].Cells[2].Text);

        }


        protected void DeleteLocation(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void UpdateLocation(object sender, GridViewUpdateEventArgs e)
        {
            //string location = ((TextBox)gvPrice.Rows[e.RowIndex].FindControl("txtLocation")).Text;
            //int id = Convert.ToInt32(((Label)gvPrice.Rows[e.RowIndex].FindControl("lblID")).Text);

            //int divisionid = Convert.ToInt32(((DropDownList)gvPrice.Rows[e.RowIndex].FindControl("drpRegionTemp")).SelectedValue);


            //UpdateSelectedLocation( divisionid,id, location);

            //gvPrice.EditIndex = -1;


            //BindUsers();

        }

        void UpdateSelectedLocation(int divisionid, int id, string location)
        {
            // KotaCoachings.DataAccess.DBAccess.UpdateLocation(divisionid,id, location);
        }

        protected void gvPrice_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //LinkButton buttonCommandField = e.Row.Cells[1].Controls[0] as LinkButton;
                //buttonCommandField.Attributes["onClick"] =
                //       string.Format("return confirm('Are you sure want to delete this user?')");

                //DropDownList drp = (DropDownList)e.Row.FindControl("drpRegionTemp");
                //drp.DataSource = listCityDivision;
                //drp.DataTextField = "Namve";
                //drp.DataValueField = "Id";
                //drp.DataBind();
                //drp.Items.Add(new ListItem { Value = "0", Text = "--Select Region--", Selected = true });

                //drp.SelectedValue = DataBinder.Eval(e.Row.DataItem, "DivisionID").ToString();

                //drp.Enabled = false;

                //if (gvPrice.EditIndex == e.Row.RowIndex)
                //{
                //    drp.Enabled = true;
                //}

                //LinkButton buttonCommandField = e.Row.Cells[1].Controls[0] as LinkButton;
                //e.Row.Cells[0].Attributes["onClick"] = string.Format("window.open('ReportProjects.aspx')");

                //DropDownList drp = (DropDownList)e.Row.FindControl("drpRegionTemp");
                //drp.DataSource = listCityDivision;
                //drp.DataTextField = "Namve";
                //drp.DataValueField = "Id";
                //drp.DataBind();
                //drp.Items.Add(new ListItem { Value = "0", Text = "--Select Region--", Selected = true });

                //drp.SelectedValue = DataBinder.Eval(e.Row.DataItem, "DivisionID").ToString();

                //drp.Enabled = false;

                //if (gvPrice.EditIndex == e.Row.RowIndex)
                //{
                //    drp.Enabled = true;
                //}
            }

        }


        protected void btnAddPrice1_Click(object sender, EventArgs e)
        {

            //if(txtAddLocation.Text!="")
            //{
            //    //KotaCoachings.DataAccess.DBAccess.InsertLocaion(Convert.ToInt32(drpRegion.SelectedValue), txtAddLocation.Text);
            //    //drpRegion.SelectedValue = "0";
            //    //txtAddLocation.Text = "";
            //    //ISAdding = true;
            //    //BindDivision();
            //    ////BindUsers();
            //}
        }

        protected void drpRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProjects();
        }

        protected void lnkShow_Click(object sender, EventArgs e)
        {
            BindProjects();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + "Excelsheet_" + DateTime.Now.Ticks.ToString() + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringWriter StringWriter = new System.IO.StringWriter();
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            gvPrice.RenderControl(HtmlTextWriter);// render gridview control
            Response.Write(StringWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }
    }
}