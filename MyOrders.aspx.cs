using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace KitchenOnMyPlate
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected int loggiedIn = 0;
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;
        String cs = System.Configuration.ConfigurationManager.ConnectionStrings["DBKOMPConnectionString"].ConnectionString;

        private bool ISAdding = false;
        
        //private bool IsEnabled = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["USER"] != null)
            {

                if (((User)Session["USER"]).UserType != "N") // If not admin
                {
                    // Response.Redirect("/");
                }
            }
            else
            {
                Response.Redirect("/");
            }


            if (!IsPostBack)
            {

                if (Session["USER"] != null)
                {
                    var userObj = ((User)Session["USER"]);
                    loggiedIn = userObj.UserId;

                    BindOrderID();
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

            gvPrice.RenderControl(HtmlTextWriter);// render gridview control
            Response.Write(StringWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }

        public void BindOrderID()
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                cmd = new SqlCommand("select [order].ID,[order].ID as ID1, OrderStartDate, OrderDate, case NonCustomized when 0 then 'CUSTOMIZED PLATE' else case IsLunch when 1 then 'Lunch' else 'Dinner' end  end , case PAymentDone when 1 then 'Paid' when 0 then 'Pending' else 'Failed' end, NonCustomized,IsLunch , (select count(*) from OrderDetails where OrderId=[order].id ) as quantity from [order]inner join  Payment  on [order].Id = Payment.OrderId where  CustomerId='" + loggiedIn + "'  order by 1  desc", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Sales");

                //drpLocation.DataSource = myDataSet;
                //drpLocation.DataTextField = "ID";
                //drpLocation.DataValueField = "ID1";
                //drpLocation.DataBind();

                string strOrders = string.Empty;
                
                //strOrders = strOrders + "<div style='clear:both;width:100%'> <div style='width:10%;float:left'> <b> Order Id </b> </div><div style='width:20%;float:left'> <b>Order Started Date</b> </div><div style='width:20%;float:left'> <b>Order Placed Date</b> </div><div style='width:20%;float:left'> <b>Meal Type</b> </div><div style='width:20%;float:left'> <b>Status</b> </div><div style='width:10%;float:left'> </div></div>";

                for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
                {
                    string button = string.Empty;
                    if (myDataSet.Tables[0].Rows[i]["NonCustomized"].ToString() == "1")
                    {
                        //button = "<input type='button' class='proceed' onclick=window.location.href='Service.aspx?il=" + myDataSet.Tables[0].Rows[i]["IsLunch"] + "&OrderRqst=" + myDataSet.Tables[0].Rows[i][0] + "' value='Order Again' />";
                    }
                    else
                    {
                        //button = "<input type='button' class='proceedBack' onclick=window.location.href='YourOrder.aspx' value='New Customized Order' />";
                    }

                    strOrders = strOrders + "<tr class='divRow DR' id='Ord" + i + "' align='center'><td  style=''>" + myDataSet.Tables[0].Rows[i][0] + "</td><td  style=''>" + myDataSet.Tables[0].Rows[i][4] + "</td><td  style=''>" + myDataSet.Tables[0].Rows[i][8] + "</td><td  align='left'> <span>" + Convert.ToDateTime(myDataSet.Tables[0].Rows[i][3]).ToString("dd/MM/yyyy") + "</span</td><td>" + myDataSet.Tables[0].Rows[i][5] + "</td><td><input type='button' class='proceed' style='float:left;' onclick='GetOrderDetails(" + myDataSet.Tables[0].Rows[i][0] + ")' value='ORDER DETAILS' />" + button + "</td></tr>";
                    //strOrders = strOrders + "<div style='clear:both;width:100%'><div style='width:10%;float:left'>" + myDataSet.Tables[0].Rows[i][0] + "</div><div style='width:20%;float:left'>" + myDataSet.Tables[0].Rows[i][2] + " </div><div style='width:20%;float:left'>" + myDataSet.Tables[0].Rows[i][3] + " </div><div style='width:20%;float:left'>" + myDataSet.Tables[0].Rows[i][4] + " </div><div style='width:20%;float:left'>" + myDataSet.Tables[0].Rows[i][5] + " </div><div style='width:10%;float:left'> <input type='button' onclick='GetOrderDetails(" + myDataSet.Tables[0].Rows[i][0] + ")' value='Order Detail' /> "+button+" </div></div>";
                }

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
    }
}