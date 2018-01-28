using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MumbaiPropertyMart
{
    public partial class ReportPropertyType : System.Web.UI.Page
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
                            
                    BindReport();
               

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
                   
                }
            }


            //taCoachings.DataAccess.DBAccess.BindAllPropertyType(drpPropertyType);

        }

        protected void gvPrice_UpdateCommand(object sender, GridViewEditEventArgs e)
        {

        }

        protected void BindReport()
        {
            using (DBKotaEstateDataContext obj = new DBKotaEstateDataContext())
            {
                int type = (rdAll.Checked) ? 0 : rdBuy.Checked ? 1 : 2;

                var proType = (from w in KotaCoachings.DataAccess.DBAccess.GetPropertyTypes()
                               where ((type == 0) ? true : w.GroupType == type)
                               select new
                               {
                                   Id = w.Id,
                                   PropertyType = w.Name,
                                   categoriey = (w.GroupType == 1 ? "Residential" : "Commercial"),
                                   NoOfProjects = (from p in obj.Projects where p.Type == obj.tblMapProjectPropertyUnits.Where(e=>e.PropertyTypeId==w.Id).First().ProjectTypeId select p ).Count(),
                                   NoOfProperties = (from pr in obj.Properties where pr.PropertyType == w.Id.ToString() where pr.PostType == "SELL" select w).Count(),
                                   NoOfPostedRequirement = (from pr in obj.Properties where pr.PropertyType == w.Id.ToString() where pr.PostType == "NEED" select w).Count()

                               });
                lblTotal.Text = proType.Count().ToString();
                gvPrice.DataSource = proType;
                gvPrice.DataBind();
            }
         
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
                if (e.Row.Cells[3].Text != "0")
                {
                    e.Row.Cells[3].Attributes.Add("style", "color:blue;cursor:pointer");
                    //e.Row.Cells[3].Attributes["onClick"] = string.Format("window.open('ReportProjects.aspx?propertyType=" + e.Row.Cells[0].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "')");
                    e.Row.Cells[3].Attributes["onClick"] = string.Format("MyPopUpWin('/Reports/ReportProjects.aspx?propertyType=" + e.Row.Cells[0].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "', 900, 600);");
                }

                if (e.Row.Cells[4].Text != "0")
                {
                    e.Row.Cells[4].Attributes.Add("style", "color:blue;cursor:pointer");
                    //e.Row.Cells[4].Attributes["onClick"] = string.Format("window.open('ReportProperties.aspx?propertyType=" + e.Row.Cells[0].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "')");
                    e.Row.Cells[4].Attributes["onClick"] = string.Format("MyPopUpWin('/Reports/ReportProperties.aspx?propertyType=" + e.Row.Cells[0].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "', 900, 600);");
                }
           
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
            BindReport();
        }

        protected void lnkShow_Click(object sender, EventArgs e)
        {
            BindReport();
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