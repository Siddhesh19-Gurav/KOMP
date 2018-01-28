using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using KitchenOnMyPlate;
using System.Data.SqlClient;
using System.Data;

namespace MumbaiPropertyMart
{
    public partial class ReportLocationView : System.Web.UI.Page
    {
        protected int loggiedIn = 0;
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;
        String cs = System.Configuration.ConfigurationManager.ConnectionStrings["DBKOMPConnectionString"].ConnectionString;

        private bool ISAdding = false;
        
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["USER"] != null)
            {

                if (((User)Session["USER"]).UserType != "N") // If not admin
                {
                    Response.Redirect("/");
                }
            }
            else
            {
                Response.Redirect("/");
            }


            if (!IsPostBack)
            {
                var userObj = ((User)Session["USER"]);
                loggiedIn = userObj.UserId;

                BindOrderID();
                //KotaCoachings.DataAccess.DBAccess.BindAllLocationOfPropertyOrProject(drpLocation);
                BindReport();
            }
        }

        public void BindOrderID()
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                cmd = new SqlCommand("select [order].ID,[order].ID as ID1, OrderStartDate, OrderDate, case IsLunch when 1 then 'Lunch' else 'Dinner' end  , case PAymentDone when 1 then 'Completed' else 'Pending' end  from [order]inner join  Payment  on [order].Id = Payment.OrderId where [order].IsActive=1 and CustomerId='" + loggiedIn + "'  order by 1  ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Sales");

                drpLocation.DataSource = myDataSet;
                drpLocation.DataTextField = "ID";
                drpLocation.DataValueField = "ID1";
                drpLocation.DataBind();

                con.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        protected void BindReport()
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                cmd = new SqlCommand("select OrderId as 'Order Id',MenuItems.Header as 'Menu Item', case MenuItems.Veg when 1 then 'Veg' else 'Non-Veg' end as Type, Quantity, MenuItems.Price   from OrderDetails inner join MenuItems on MenuItems.Id =  OrderDetails.SubProductId where OrderDetails.IsActive=1 and MenuItems.IsActive=1 and OrderId='" + drpLocation.SelectedValue + "'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Sales");

                if (myDataSet.Tables[0].Rows.Count > 0)
                {
                    gvPrice.Visible = true;

                    lblTotal.Text = myDataSet.Tables[0].Rows.Count.ToString();


                    gvPrice.DataSource = myDataSet;
                    gvPrice.DataBind();
                }
                else
                {
                    gvPrice.Visible = false;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      protected void EditCustomer(object sender, GridViewEditEventArgs e)
      {

          gvPrice.EditIndex = e.NewEditIndex;     
     
          //BindUsers( gvPrice.Rows[e.NewEditIndex].Cells[2].Text);

      }

      protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
      {
         // BindDivision();
          gvPrice.EditIndex = -1;

         // BindUsers(gvPrice.Rows[e.RowIndex].Cells[2].Text);

      }


      protected void DeleteLocation(object sender, GridViewDeleteEventArgs e)
      {   
          
          //KotaCoachings.DataAccess.DBAccess.DeleteUser( Convert.ToInt32(gvPrice.Rows[e.RowIndex].Cells[2].Text), drpRegion.SelectedValue);
          //BindUsers(drpRegion.SelectedValue);

         // Page.ClientScript.RegisterStartupScript(typeof(Page), "deleted", "alert('Deleted Successfully!');", true);
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
              if (e.Row.Cells[2].Text != "0")
              {
                  e.Row.Cells[2].Attributes.Add("style", "color:blue;cursor:pointer");
                  e.Row.Cells[2].Attributes["onClick"] = string.Format("MyPopUpWin('/Reports/ReportProjects.aspx?locationId=" + e.Row.Cells[0].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "', 900, 600);");
                  //e.Row.Cells[2].Attributes["onClick"] = string.Format("window.open('ReportProjects.aspx?locationId=" + e.Row.Cells[0].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "')");
              }

              if (e.Row.Cells[3].Text != "0")
              {
                  e.Row.Cells[3].Attributes.Add("style", "color:blue;cursor:pointer");
                  //e.Row.Cells[3].Attributes["onClick"] = string.Format("window.open('ReportProperties.aspx?locationId=" + e.Row.Cells[0].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "')");
                  e.Row.Cells[3].Attributes["onClick"] = string.Format("MyPopUpWin('/Reports/ReportProperties.aspx?locationId=" + e.Row.Cells[0].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "', 900, 600);");

              }

              //if (e.Row.Cells[4].Text != "0")
              //{
              //    e.Row.Cells[4].Attributes.Add("style", "color:blue");
              //    e.Row.Cells[4].Attributes["onClick"] = string.Format("window.open('ReportProperties.aspx?userid=" + e.Row.Cells[1].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "')");
              //}

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