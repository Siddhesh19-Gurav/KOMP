using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MumbaiPropertyMart
{
    public partial class ReportUsers : System.Web.UI.Page
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
                
                
            }
        }

        void BindDivision()
        {
        //var cityDivision = KotaCoachings.DataAccess.DBAccess.GetDivisions();
        //listCityDivision = cityDivision;

        //if (!ISAdding)
        //{
        //    drpRegion.DataSource = cityDivision;
        //    drpRegion.DataTextField = "Namve";
        //    drpRegion.DataValueField = "Id";
        //    drpRegion.DataBind();
        //    drpRegion.Items.Add(new ListItem { Value = "0", Text = "--Select Region--", Selected = true });
        //}


      

        }

        protected void gvPrice_UpdateCommand(object sender, GridViewEditEventArgs e)
        {

        }

        protected void BindUsers(string userType)
  {
      using (DBKotaEstateDataContext obj = new DBKotaEstateDataContext())
      {
          var list = (from n in obj.Users

                      join L in obj.tblLocations
                                 on n.LocationId equals L.Id into wlL
                      from F in wlL.DefaultIfEmpty()

                      where (userType == "" ? true : n.UserType == userType)
                      && n.UserType != "N"
                      select new { ID = (n.UserType + n.UserId), UserName = n.FirstName + " " + n.LastName, Location = F.Location, UserType = n.UserType == "A" ? "Agent" : n.UserType == "B" ? "Builder" : n.UserType == "O" ? "Owner" : "Customer", ContactNo = n.mobile, Email = n.email, NoOfProjects = (from w in obj.Projects where w.BuilderId == n.UserId select w).Count(), NoOfProperties = (from w in obj.Properties where w.Owner == n.UserId where w.PostType == "SELL" select w).Count(), NoOfPostedRequirement = (from w in obj.Properties where w.Owner == n.UserId where w.PostType == "NEED" select w).Count() });

          lblTotal.Text = list.Count().ToString();
          gvPrice.DataSource = list;
          gvPrice.DataBind();
      }
        }

      protected void EditCustomer(object sender, GridViewEditEventArgs e)
      {

          gvPrice.EditIndex = e.NewEditIndex;     
     
          BindUsers( gvPrice.Rows[e.NewEditIndex].Cells[2].Text);

      }

      protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
      {
          //BindDivision();
          gvPrice.EditIndex = -1;

          BindUsers(gvPrice.Rows[e.RowIndex].Cells[2].Text);

      }


      protected void DeleteLocation(object sender, GridViewDeleteEventArgs e)
      {   
          
          KotaCoachings.DataAccess.DBAccess.DeleteUser( Convert.ToInt32(gvPrice.Rows[e.RowIndex].Cells[2].Text), drpRegion.SelectedValue);
          BindUsers(drpRegion.SelectedValue);

          Page.ClientScript.RegisterStartupScript(typeof(Page), "deleted", "alert('Deleted Successfully!');", true);
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
              if (e.Row.Cells[7].Text != "0")
              {
                  e.Row.Cells[7].Attributes.Add("style", "color:blue;cursor:pointer");
                  //e.Row.Cells[7].Attributes["onClick"] = string.Format("window.open('ReportProjects.aspx?userid=" + e.Row.Cells[1].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "')");
                  e.Row.Cells[7].Attributes["onClick"] = string.Format("MyPopUpWin('/Reports/ReportProjects.aspx?userid=" + e.Row.Cells[1].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "', 900, 600);");
              }

              if (e.Row.Cells[8].Text != "0")
              {
                  e.Row.Cells[8].Attributes.Add("style", "color:blue;cursor:pointer");
                  //e.Row.Cells[8].Attributes["onClick"] = string.Format("window.open('ReportProperties.aspx?userid=" + e.Row.Cells[1].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "')");
                  e.Row.Cells[8].Attributes["onClick"] = string.Format("MyPopUpWin('/Reports/ReportProperties.aspx?userid=" + e.Row.Cells[1].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "', 900, 600);");
              }

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
          BindUsers(drpRegion.SelectedValue);
      }

      protected void lnkShow_Click(object sender, EventArgs e)
      {
          BindUsers(drpRegion.SelectedValue);
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