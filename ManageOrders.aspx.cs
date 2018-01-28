using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace KitchenOnMyPlate.Masters
{
    public partial class ManageOrders : System.Web.UI.Page
    {
        protected int loggiedIn = 0;
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;
        String cs = System.Configuration.ConfigurationManager.ConnectionStrings["DevKOMPConnectionString"].ConnectionString;
        static int @Index = 1;
        static int PageSize = 100;
        static int TotalCount = 0;

        private bool ISAdding = false;
        
        //private bool IsEnabled = false;
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
                Response.Redirect("Masters/CMS.aspx");
            }


            if (!IsPostBack)
            {

                if (Session["USER"] != null)
                {
                    var userObj = ((User)Session["USER"]);
                    loggiedIn = userObj.UserId;

                    BindReport(false);
                    //BindReport(); ;
                }
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

 
        protected void EditCustomer(object sender, GridViewEditEventArgs e)
        {

           // gvPrice.EditIndex = e.NewEditIndex;

            //BindUsers( gvPrice.Rows[e.NewEditIndex].Cells[2].Text);

        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // BindDivision();
          //  gvPrice.EditIndex = -1;

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

        //protected void drpRegion_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindReport();
        //}

        //protected void lnkShow_Click(object sender, EventArgs e)
        //{
        //    BindReport();
        //}

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

            ////////////
            con = new SqlConnection(cs);
            con.Open();
            string strQuery = "SELECT *  FROM   (select ROW_NUMBER() OVER (ORDER BY [Order].Id desc) as Sr,  " +
      " [order].ID,[order].ID as ID1,ShippingBilling.FirstName as 'Customer Name', replace(ShippingBilling.Address,'$',', ')+ShippingBilling.LandMark+' '+ShippingBilling.pincode as 'Address',ShippingBilling.mobile as 'Mobile', "+
      "(select top 1 convert(varchar(10), cast(DeliverDate as date), 103) from [OrderDetails] as s where s.orderid=[Order].id order by s.DeliverDate asc ) as 'OrderStartDate', " +
      " OrderDate, case IsLunch when 1 then (case NonCustomized when 1 then 'Lunch' else 'Customised Lunch' end )  else 'Dinner' end  as 'Meal Type' , " +
      "(select top 1 convert(varchar(10), cast(DeliverDate as date), 103) from [OrderDetails] as p where p.orderid=[Order].id order by p.DeliverDate desc ) as 'OrderEndDate'," +
      " case mode when 1 then 'NET BANKING'  when 2 then 'CREDIT CARD'  when 3 then 'DEBIT CARD'  when 4 then 'CASH CARD'  when 5 then 'MOBILE PAYMENT'  when 11 then 'OFFLINE CASH DEPOSIT'  when 12 then 'OFFLINE CHEQUE DEPOIST'  when 13 then 'OFFLINE NEFT' when 14 then 'OFFLINE CASH PICK UP' else '' end as 'Payment Method'," +
      " case when  [Order].PaymentDone = '1' then 'Paid' when  [Order].PaymentDone = '0' then 'Pending'  else 'Failed' end as 'Payment Status', NonCustomized,IsLunch, (Payment.Amount+Payment.TrnChrg+Payment.DeliveryChrg) as TotalPayment,(Payment.Amount+Payment.TrnChrg+Payment.DeliveryChrg)-TotalPayment as Due,[order].PaymentDone from [order] inner join  Payment  on [order].Id = Payment.OrderId INNER JOIN ShippingBilling ON ShippingBilling.requestId=[Order].requestId where 1=1  ";

            if (txtOrderNo.Text != "")
            {
                strQuery = strQuery + " and [Order].Id =" + txtOrderNo.Text;
            }
            strQuery = strQuery + " ";
            strQuery = strQuery + ") tbl WHERE 1=1  ";

            cmd = new SqlCommand(strQuery, con);
            SqlDataAdapter myDA = new SqlDataAdapter(cmd);
            DataSet myDataSet = new DataSet();
            myDA.Fill(myDataSet, "Sales");

            //TotalCount = Convert.ToInt32(myDataSet.Tables[0].Rows.Count);
            //if (IsLast)
            //{
            //    @Index = TotalCount / PageSize;
            //}

            strQuery = strQuery + " and Sr BETWEEN ( ((" + @Index + " - 1) * " + PageSize + " )+ 1) AND " + @Index + "*" + PageSize;

            cmd = new SqlCommand(strQuery, con);

            myDA = new SqlDataAdapter(cmd);
            myDataSet = new DataSet();
            myDA.Fill(myDataSet, "Sales");

            // instantiate a datagrid
            DataGrid dg = new DataGrid();
            dg.DataSource = myDataSet.Tables[0];
            dg.DataBind();
            dg.RenderControl(HtmlTextWriter);
            // response.Write(sw.ToString());

            Response.Write(StringWriter.ToString());
            Response.End();

            con.Close();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }

        public void BindReport(bool IsLast)
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();


                string strQuery="SELECT *  FROM   (select ROW_NUMBER() OVER (ORDER BY [Order].OrderDate desc) as Sr,  "+
                " [order].ID,[order].ID as ID1,ShippingBilling.FirstName as 'Customer Name', replace(ShippingBilling.Address,'$',', ')+ShippingBilling.LandMark+' '+ShippingBilling.pincode as 'Address',ShippingBilling.mobile as 'Mobile', ShippingBilling.lastname as 'email'," +
                "(select top 1 convert(varchar(10), cast(DeliverDate as date), 103) from [OrderDetails] as s where s.orderid=[Order].id order by s.DeliverDate asc ) as 'OrderStartDate', " +
                " OrderDate, case IsLunch when 1 then (case NonCustomized when 1 then 'Lunch' else 'Customised Lunch' end )  else 'Dinner' end  as 'Meal Type' , " +
                "(select top 1 convert(varchar(10), cast(DeliverDate as date), 103) from [OrderDetails] as p where p.orderid=[Order].id order by p.DeliverDate desc ) as 'OrderEndDate',"+
                " case mode when 1 then 'NET BANKING'  when 2 then 'CREDIT CARD'  when 3 then 'DEBIT CARD'  when 4 then 'CASH CARD'  when 5 then 'MOBILE PAYMENT'  when 11 then 'OFFLINE CASH DEPOSIT'  when 12 then 'OFFLINE CHEQUE DEPOIST'  when 13 then 'OFFLINE NEFT' when 14 then 'OFFLINE CASH PICK UP' else '' end as 'Payment Method',"+
                " case when  [Order].PaymentDone = '1' then 'Paid' when  [Order].PaymentDone = '0' then 'Pending'  else 'Failed' end as 'Payment Status', NonCustomized,IsLunch, (Payment.Amount+Payment.TrnChrg+Payment.DeliveryChrg) as TotalPayment,(Payment.Amount+Payment.TrnChrg+Payment.DeliveryChrg)-TotalPayment as Due,[order].PaymentDone from [order] inner join  Payment  on [order].Id = Payment.OrderId INNER JOIN ShippingBilling ON ShippingBilling.requestId=[Order].requestId where 1=1 ";
                 
                if (txtOrderNo.Text != "")
                {
                    strQuery = strQuery + " and [Order].Id =" + txtOrderNo.Text;
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
                     @Index = TotalCount / PageSize;
                 }

                 strQuery = strQuery + " and Sr BETWEEN ( ((" + @Index + " - 1) * " + PageSize + " )+ 1) AND " + @Index + "*" + PageSize;

                cmd = new SqlCommand(strQuery, con);

                 myDA = new SqlDataAdapter(cmd);
                 myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Sales");
                lblPage.Text = "Page : " + @Index;
                if (myDataSet.Tables[0].Rows.Count > 0)
                {
                  //  gvPrice.Visible = true;

                    //lblTotal.Text = myDataSet.Tables[0].Rows.Count.ToString();
                    //lblTotal.Text = TotalCount.ToString();

                    //gvPrice.DataSource = myDataSet;
                    //gvPrice.DataBind();
                }
                else
                {
                    //gvPrice.Visible = false;
                }



                cmd = new SqlCommand(strQuery, con);
                myDA = new SqlDataAdapter(cmd);
                myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Sales");

                //drpLocation.DataSource = myDataSet;
                //drpLocation.DataTextField = "ID";
                //drpLocation.DataValueField = "ID1";
                //drpLocation.DataBind();

                string strOrders = "<table class='tbl' cellspacing='1'>";

                //strOrders = strOrders + "<div style='clear:both;width:100%'> <div style='width:10%;float:left'> <b> Order Id </b> </div><div style='width:10%;float:left'> <b>Start Date</b> </div><div style='width:10%;float:left'> <b>Order On</b> </div><div style='width:10%;float:left'> <b>Meal Type</b> </div><div style='width:10%;float:left'> <b>Status</b> </div><div style='width:10%;float:left'>Total Amount</div><div style='width:10%;float:left'>Due Amount</div><div style='width:30%;float:left'>Actions</div></div>";
                strOrders = strOrders + "<tr class='divRow dataHeader' style='background:#F16822;color:#fff;font-family:RobotoBold;font-size:1.2em;' ><td> Order #</td><td> Customer Details</td> <td>Start Date</td> <td>End Date</td> <td>Order On</td> <td>Meal Type</td> <td> Payment Method</td> <td> Payment Status</td> <td>Total Amount</td> <td>Actions</td></tr>";

                for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
                {
                    string button = string.Empty;
                    string status = myDataSet.Tables[0].Rows[i]["Payment Status"].ToString(); 
                    if (myDataSet.Tables[0].Rows[i]["PaymentDone"].ToString() != "1") //2 failed, 0 pening , 1 paid
                    {
                        var dt = myDataSet.Tables[0].Rows[i]["OrderStartDate"].ToString();
                        string dttime = dt.Split('/')[1] + "/" + dt.Split('/')[0] + "/" + dt.Split('/')[2];

                        if (Convert.ToDateTime(dttime) <= DateTime.Today.Date)
                        {//expired
                            button = "<a  href='javascript:;'  title='Delete Order' onclick=DeleteOrder(" + i + ",'" + myDataSet.Tables["Sales"].Rows[i]["ID"] + "') class='btnView' style='background: #F16822;padding: 10px !important;margin: 0 auto !important;font-size: 1em !important;margin-top: 0px !important;margin:3px!important' >Delete Order</a>";
                            status = "<span style='color:red;'><b>Expired</b></span><br/>";
                        }
                        else
                        {
                        button = "<a  href='#divAddAmount'  title='Add Amount' onclick=SetMakePayementDetails(" + i + ",'" + myDataSet.Tables["Sales"].Rows[i]["ID"] + "','" + myDataSet.Tables["Sales"].Rows[i]["TotalPayment"] + "','" + myDataSet.Tables["Sales"].Rows[i]["Due"] + "') class='btnView addAmountInvoice ReporActionBtn' style='margin:3px!important' >Add Payment</a><br/>" +
                                 "<a  href='javascript:;'  title='Delete Order' onclick=DeleteOrder(" + i + ",'" + myDataSet.Tables["Sales"].Rows[i]["ID"] + "') class='btnView' style='background: #F16822;padding: 10px !important;margin: 0 auto !important;font-size: 1em !important;margin-top: 0px !important;margin:3px!important' >Delete Order</a>";
                            }
                    }
                    else
                    {
                        button = "";// "<a  href='#divAddAmount'  title='Add Amount' onclick=SetMakePayementDetails(" + i + ",'" + myDataSet.Tables["Sales"].Rows[i]["ID"] + "','" + myDataSet.Tables["Sales"].Rows[i]["TotalPayment"] + "','" + myDataSet.Tables["Sales"].Rows[i]["Due"] + "') class='btnView addAmountInvoice ' >Add Payment</a>";
                    }

                    strOrders = strOrders + "<tr class='divRow' id='divRow" + i.ToString() + "'> <td>" + myDataSet.Tables[0].Rows[i]["ID"] + "</td><td>" + myDataSet.Tables[0].Rows[i]["Customer Name"] + " </br> Add : " + myDataSet.Tables[0].Rows[i]["Address"].ToString().Replace("$", ", ") + " <br/> Contact:" + myDataSet.Tables[0].Rows[i]["Mobile"] + " <br/> Email Id:" + myDataSet.Tables[0].Rows[i]["email"] + "  </td><td>" + myDataSet.Tables[0].Rows[i]["OrderStartDate"] + " </td><td>" + myDataSet.Tables[0].Rows[i]["OrderEndDate"] + " </td><td>" + Convert.ToDateTime(myDataSet.Tables[0].Rows[i]["OrderDate"]).ToString("dd/MMM/yyyy") + " </td>  <td>" + myDataSet.Tables[0].Rows[i]["Meal Type"] + " </td><td>" + myDataSet.Tables[0].Rows[i]["Payment Method"] + " </td>  <td>" + status + " </td><td>" + myDataSet.Tables[0].Rows[i]["TotalPayment"] + " </td><td> <a  href='#divSumm'  title='details' onclick=GetOrderDetailsMaster(" + myDataSet.Tables[0].Rows[i]["ID"] + ") class='btnView addAmountInvoice ReporActionBtn' style='margin-top:5px;margin:3px!important'  >Order Details</a> " + button + " </td></tr>";
                }
                strOrders = strOrders + "</table>";
                divOrders.InnerHtml = strOrders;

                con.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //public void BindReport()
        //{
        //    try
        //    {
        //        con = new SqlConnection(cs);
        //        con.Open();
        //        cmd = new SqlCommand("select OrderId as 'Order Id',MenuItems.Header as 'Menu Item', case MenuItems.Veg when 1 then 'Veg' else 'Non-Veg' end as Type, Quantity, MenuItems.Price   from OrderDetails inner join MenuItems on MenuItems.Id =  OrderDetails.SubProductId where OrderDetails.IsActive=1 and MenuItems.IsActive=1 and OrderId='" + drpLocation.SelectedValue + "'", con);
        //        SqlDataAdapter myDA = new SqlDataAdapter(cmd);
        //        DataSet myDataSet = new DataSet();
        //        myDA.Fill(myDataSet, "Sales");

        //        gvPrice.DataSource = myDataSet;
        //        gvPrice.DataBind();

        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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

        protected void btnReport1_Click(object sender, EventArgs e)
        {
            @Index = 1;
            BindReport(false);
        }
    }
}