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
    public partial class DailyPaymentStatus : System.Web.UI.Page
    {
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
               // var userObj = ((User)Session["USER"]);
               // loggiedIn = userObj.UserId;
                BindLocation();
                //BindOrderID();
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

                //drpLocation.DataSource = myDataSet;
                //drpLocation.DataTextField = "ID";
                //drpLocation.DataValueField = "ID1";
                //drpLocation.DataBind();

                con.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BindLocation()
        {
          //  DBAccess.BindAllLocation(drpLocation);
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

        protected void BindReport(bool IsLast)
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                //cmd = new SqlCommand("select OrderId as 'Order Id',MenuItems.Header as 'Menu Item', case MenuItems.Veg when 1 then 'Veg' else 'Non-Veg' end as Type, Quantity, MenuItems.Price   from OrderDetails inner join MenuItems on MenuItems.Id =  OrderDetails.SubProductId where OrderDetails.IsActive=1 and MenuItems.IsActive=1 and OrderId='" + drpLocation.SelectedValue + "'", con);

                string strQuery = "SELECT *  FROM  (select ROW_NUMBER() OVER (ORDER BY OrderId desc) as Sr, OrderId as 'Order No', [Order].OrderDate as 'Order Date',"+
" ShippingBilling.FirstName as 'Customer''s Full Name',ShippingBilling.mobile as 'Contact Number',"+
" 'Yes' as 'Delivery Area Confirmed',"+
//" ShippingBilling.Address+','+ShippingBilling.City as 'Address', "+
" case when  [Order].PaymentDone = '1' then 'Paid' when  [Order].PaymentDone = '0' then 'Pending'  else 'Failed' end as 'Payment Status', "+
" convert(varchar(10), cast(PaymentDate as date), 103) 'Payment Received Date',  " +
" RIGHT(CONVERT(VARCHAR, PaymentDate, 100),7) as 'Payment Time Stamp', " +
" convert(varchar(10), cast([Order].OrderStartDate as date), 103) as 'Meal Start Date',"+
" case [Order].NonCustomized when 1 then (case [Order].IsLunch when 1 then 'Lunch' else 'Dinner' end) else 'Customised Lunch' end as 'Tiffin Service'," +
//" [Menu].Header  as 'Plate Type',  " +
//" case MenuItems.Veg when 1 then 'Veg' else 'Non-Veg' end as 'Meal Type',  " +
//" MenuItems.Header as 'Menu Plan',  " +
//" (select COUNT(*) from [OrderDetails] as t where t.orderid=[Order].id ) as 'Menu Pack Chosen',  " +
" case mode when 1 then 'Online'  when 2 then 'Online'  when 3 then 'Online'  when 4 then 'Online'  when 5 then 'Online'  when 11 then 'Offline'  when 12 then 'Offline'  when 13 then 'Offline' when 14 then 'Offline' else '' end as 'Payment Type',  " +
" case mode when 1 then 'NET BANKING'  when 2 then 'CREDIT CARD'  when 3 then 'DEBIT CARD'  when 4 then 'CASH CARD'  when 5 then 'MOBILE PAYMENT'  when 11 then 'OFFLINE CASH DEPOSIT'  when 12 then 'OFFLINE CHEQUE DEPOIST'  when 13 then 'OFFLINE NEFT' when 14 then 'OFFLINE CASH PICK UP' else '' end as 'Payment Method',  " +
" Bank as 'Bank', "+
" Branch as 'Branch', " +
" case mode when 1 then TransactionNo when 2 then TransactionNo when 3 then TransactionNo when 4 then TransactionNo when 5 then TransactionNo else TransactionNo  end as  'Transaction No'," +
" case mode when 12 then TransactionNo  end as  'Cheque No.'," +
" case mode when 13 then TransactionNo  end as  'NEFT Ref. No.'," +
" case mode when 14 then TransactionNo  end as  'Cash Pick up Receipt No.',"+
" Payment.Amount as  'Meal Pack Amount',"+
" Payment.deliveryChrg as  'Delivery Charge'," +
" case mode when 14 then 0 else Payment.TrnChrg end as  'Online Processing Charge',"+
" case mode when 14 then Payment.TrnChrg end as  'Cash Pick up Charge',"+
" [Order].[TotalPayment] as  'Final Billed Amount',"+
" '' as  'Comments'"+
" from    [Order] inner Join Payment on [Order].Id= Payment.OrderId  inner join Users on Users.UserId =  [Order].CustomerId  "+
" inner join ShippingBilling on ShippingBilling.UserId=  Users.UserId " +
" where 1=1 and ShippingBilling.requestId=[Order].requestId";
    //[Order].IsActive in 0 

              

                if (drpPaymentStatus.SelectedValue != "-1")
                {
                    strQuery = strQuery + " and  [Order].PaymentDone=" + drpPaymentStatus.SelectedValue;
                }

//                if (drpPaymentStatus.SelectedValue != "-1")
//                {
//                    if (drpPaymentStatus.SelectedValue == "3")//Pending - Not redirected to payment gatway
//                    {
//                        strQuery = "select [Order].Id  as 'Order Id', Users.FirstName+' '+Users.LastName as 'Cstomrer Name'," +
//                        " tbllocation.Location, users.Address,users.Mobile," +
//                        "  'Pending'  as 'Payment Status', TotalPayment As 'Amount' ,'' as 'Mode', '' as 'PaymentDate', '' as 'NameOnCard', '' as 'CardNumber'" +
//                        " from    [Order] " +
//                        " inner join Users on Users.UserId =  [Order].CustomerId " +
//                        " inner join tbllocation on tbllocation.id=  Users.LocationId and 1 > ( select count(*) from Payment where Payment.OrderId=[Order].Id)" +
//                        " and [Order].IsActive = 0 ";
//                    }
                  

//                   // strQuery = strQuery + " and MenuItems.Veg=" + drpPaymentStatus.SelectedValue;
//                }
//                else
//                {
//                    strQuery = strQuery + "union select [Order].Id  as 'Order Id', Users.FirstName+' '+Users.LastName as 'Cstomrer Name'," +
//"tbllocation.Location, users.Address,users.Mobile," +
//"'Pending'  as 'Payment Status', TotalPayment ,'', '', '', ''" +
//"from    [Order] " +
//"inner join Users on Users.UserId =  [Order].CustomerId " +
//"inner join tbllocation on tbllocation.id=  Users.LocationId and 1 > ( select count(*) from Payment where Payment.OrderId=[Order].Id)" +
//"and [Order].IsActive = 0 ";
//                }

                if (txtOrderNo.Text != "")
                {
                    strQuery = strQuery + " and [Order].Id =" + txtOrderNo.Text;
                }

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

                //if (txtOrderNo.Text != "")
                //{
                //    strQuery = strQuery + " and [Order].Id =" + txtOrderNo.Text;
                //}

                strQuery = strQuery + " and Sr BETWEEN ( ((" + @Index + " - 1) * " + gvPrice.PageSize + " )+ 1) AND " + @Index + "*" + gvPrice.PageSize + " order by 2 desc";

                cmd = new SqlCommand(strQuery, con);

                myDA = new SqlDataAdapter(cmd);
                myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Sales");
                lblPage.Text = "Page : " + @Index;
                if (myDataSet.Tables[0].Rows.Count > 0)
                {
                    gvPrice.Visible = true;

                    //.Text = myDataSet.Tables[0].Rows.Count.ToString();

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

              //}

              //if (e.Row.Cells[3].Text != "0")
              //{
              //    e.Row.Cells[3].Attributes.Add("style", "color:blue;cursor:pointer");

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