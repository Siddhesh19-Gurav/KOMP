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
using KitchenOnMyPlate.DataAccess;

namespace MumbaiPropertyMart
{
    public partial class DeliveryDatesSummary : System.Web.UI.Page
    {
        protected string disabledSpecificDays;

        protected int loggiedIn = 0;
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;
        String cs = System.Configuration.ConfigurationManager.ConnectionStrings["DevKOMPConnectionString"].ConnectionString;
        static int @Index = 1;
        static int TotalCount = 0;
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
                txtPossessionDate.Value = DateTime.Today.ToString("dd/MM/yyyy");
                
                //SetHoidays();
               // var userObj = ((User)Session["USER"]);
               // loggiedIn = userObj.UserId;
                //BindLocation();
                //BindOrderID();
                //indProducts();
                //KotaCoachings.DataAccess.DBAccess.BindAllLocationOfPropertyOrProject(drpLocation);
                BindReport(false);
            }
        }

        public void BindOrderID()
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                //cmd = new SqlCommand("select [order].ID,[order].ID as ID1, OrderStartDate, OrderDate, case IsLunch when 1 then 'Lunch' else 'Dinner' end  , case PAymentDone when 1 then 'Completed' else 'Pending' end  from [order]inner join  Payment  on [order].Id = Payment.OrderId where [order].IsActive=1 and CustomerId='" + loggiedIn + "'  order by 1  ", con);
                cmd = new SqlCommand("select [order].ID,[order].ID as ID1, OrderStartDate, OrderDate, case IsLunch when 1 then 'Lunch' else 'Dinner' end  , case PAymentDone when 1 then 'Completed' else 'Pending' end  from [order]inner join  Payment  on [order].Id = Payment.OrderId where [order].IsActive=1 order by 1  ", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Sales");
                ////var products = KitchenOnMyPlate.DataAccess.DBAccess.GetSubProducts();
                ////drpProducts.DataSource = products;
                ////drpProducts.DataTextField = "Header";
                ////drpProducts.DataValueField = "Id";
                ////drpProducts.DataBind();
                ////drpProducts.Items.Add(new ListItem { Selected = true, Value = "0", Text = "--All Products--" });

                con.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BindLocation()
        {
            //DBAccess.BindAllLocation(drpLocation);
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

        private void SetHoidays()
        {
            //disabledSpecificDays = ["3-20-2015", "9-24-2015", "9-25-2015", "10-01-2015"];
            var holidays = KitchenOnMyPlate.DataAccess.DBAccess.GetHoliday();
            var list = new List<string>();
            foreach (var holiday in holidays)
            {
                // list.Add(holiday.DeliverDate.Value.ToString("MM-dd-yyyy"));
                //disabledSpecificDays = ( string.IsNullOrEmpty(disabledSpecificDays)) ? "\"" + holiday.DeliverDate.Value.ToString("MM-dd-yyyy") + "\"" : disabledSpecificDays + ",\"" + holiday.DeliverDate.Value.ToString("MM-dd-yyyy") + "\"";
                disabledSpecificDays = (string.IsNullOrEmpty(disabledSpecificDays)) ? "'" + holiday.DeliverDate.Value.ToString("MM-dd-yyyy") + "'" : disabledSpecificDays + ",'" + holiday.DeliverDate.Value.ToString("MM-dd-yyyy") + "'";

            }
            //disabledSpecificDays =  list.ToArray();
        }


        protected void gvPrice_UpdateCommand(object sender, GridViewEditEventArgs e)
        {

        }

        protected void BindReport(bool IsLast)
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                //cmd = new SqlCommand("select OrderId as 'Order Id',MenuItems.Header as 'Menu Item', case MenuItems.Veg when 1 then 'Veg' else 'Non-Veg' end as Type, Quantity, MenuItems.Price   from OrderDetails inner join MenuItems on MenuItems.Id =  OrderDetails.SubProductId where OrderDetails.IsActive=1 and MenuItems.IsActive=1 and OrderId='" + drpLocation.SelectedValue + "'", con);

                string strQuery = "SELECT *  FROM   (select ROW_NUMBER() OVER (ORDER BY [Order].OrderDate asc) as Sr,  "+
 " [Order].Id as 'Order No.',   "+
 " ShippingBilling.FirstName as 'Customer''s Full Name', "+
 " convert(varchar(10), cast(Payment.PaymentDate as date), 103) as 'Payment Received Date',"+
 " ShippingBilling.Mobile as 'Contact Number',   "+
 " 'Yes' as 'Delivery Area Confirmed',"+
 " convert(varchar(10), cast([Order].OrderStartDate as date), 103) as 'Meal Start Date',"+
 " case [Order].NonCustomized when 1 then (case [Order].IsLunch when 1 then 'Lunch' else 'Dinner' end) else 'Customised Lunch' end as 'Tiffin Service', "+
 " (select COUNT(*) from [OrderDetails] as t where t.orderid=[Order].id ) as 'Menu Pack Chosen' , "+
 " (substring(  (  SELECT (',   ' + CAST( convert(varchar(10), cast(p1.DeliverDate as date), 103)  as varchar))   "+
 " FROM orderdetails p1"+
 " WHERE [Order].Id = p1.OrderId    Order by OrderId, DeliverDate FOR XML PATH('')),3,1000)) as 'Delivery Dates'  "+
 " from "+
 " [Order] "+ 
 " inner join  Users on Users.UserId =  [Order].CustomerId    "+
 " inner join ShippingBilling on (ShippingBilling.UserId =  Users.UserId  and ShippingBilling.RequestId = [Order].RequestId)  "+
 " inner join Payment on Payment.OrderId =  [Order].Id "+
 " where [Order].IsActive=1 ";


                if (drpLunchDinner.SelectedValue != "-1")
                {
                    strQuery = strQuery + " and IsLunch=" + drpLunchDinner.SelectedValue;
                }

                if (txtOrderNo.Text != "")
                {
                    strQuery = strQuery + " and [Order].Id =" + txtOrderNo.Text;
                }

                //if (drpProducts.SelectedValue != "0")
                //{
                //    strQuery = strQuery + " and MenuItems.Id =" + drpProducts.SelectedValue;
                //}

                if (txtPossessionDate.Value != "")
                {
                    
                    var dateParts = txtPossessionDate.Value.Split('/');
                    var from = dateParts[2].Substring(0,4)  + "/" + dateParts[1].PadLeft(2, '0') + "/" + dateParts[0].PadLeft(2, '0');
                    dateParts = txtPossessionDateTo.Value.Split('/');
                    var To = dateParts[2].Substring(0, 4) + "/" + dateParts[1].PadLeft(2, '0') + "/" + dateParts[0].PadLeft(2, '0');
                    strQuery = strQuery + " and convert(varchar(10), cast(OrderDate as date), 111) between '"+from +"' and '"+ To +"'";
                }

                 strQuery = strQuery + " ";
                 strQuery = strQuery + ") tbl WHERE 1=1  ";

                 cmd = new SqlCommand(strQuery, con);
                 SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                 DataSet myDataSet = new DataSet();
                 myDA.Fill(myDataSet, "Sales");

                 TotalCount = Convert.ToInt32(myDataSet.Tables[0].Rows.Count);
                 if (IsLast)
                 {
                     @Index = TotalCount / gvPrice.PageSize;
                 }

                 strQuery = strQuery + " and Sr BETWEEN ( ((" + @Index + " - 1) * " + gvPrice.PageSize + " )+ 1) AND " + @Index + "*" + gvPrice.PageSize;

                cmd = new SqlCommand(strQuery, con);

                 myDA = new SqlDataAdapter(cmd);
                 myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Sales");
                lblPage.Text = "Page : " + @Index;
                if (myDataSet.Tables[0].Rows.Count > 0)
                {
                    gvPrice.Visible = true;

                    //lblTotal.Text = myDataSet.Tables[0].Rows.Count.ToString();
                    lblTotal.Text = TotalCount.ToString();

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
              //if (e.Row.Cells[2].Text != "0")
              //{
              //    e.Row.Cells[2].Attributes.Add("style", "color:blue;cursor:pointer");
              //    e.Row.Cells[2].Attributes["onClick"] = string.Format("MyPopUpWin('/Reports/ReportProjects.aspx?locationId=" + e.Row.Cells[0].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "', 900, 600);");
              //    //e.Row.Cells[2].Attributes["onClick"] = string.Format("window.open('ReportProjects.aspx?locationId=" + e.Row.Cells[0].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "')");
              //}

              //if (e.Row.Cells[3].Text != "0")
              //{
              //    e.Row.Cells[3].Attributes.Add("style", "color:blue;cursor:pointer");
              //    //e.Row.Cells[3].Attributes["onClick"] = string.Format("window.open('ReportProperties.aspx?locationId=" + e.Row.Cells[0].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "')");
              //    e.Row.Cells[3].Attributes["onClick"] = string.Format("MyPopUpWin('/Reports/ReportProperties.aspx?locationId=" + e.Row.Cells[0].Text.Replace("B", "").Replace("A", "").Replace("O", "").Replace("C", "") + "', 900, 600);");

              //}

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
          BindReport(false);
      }

      protected void lnkShow_Click(object sender, EventArgs e)
      {
          BindReport(false);
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

      protected void LinkButton4_Click(object sender, EventArgs e)
      {
          @Index = @Index + 1;
          BindReport(false);

      }

      protected void LinkButton2_Click(object sender, EventArgs e)
      {
          BindReport(true);
      }

      protected void LinkButton3_Click(object sender, EventArgs e)
      {
          @Index = @Index - 1;
          BindReport(false);
      }

      protected void LinkButton1_Click(object sender, EventArgs e)
      {
          @Index = 1;
          BindReport(false);
      }

      
    }
}