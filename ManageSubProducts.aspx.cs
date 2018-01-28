using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
//using CKEditor.NET;
using SwamiSamarthSeva;
using KitchenOnMyPlate.Classes;
using KitchenOnMyPlate.DataAccess;

namespace KitchenOnMyPlate.Masters
{
    public partial class ManageSubProducts : System.Web.UI.Page
    {
        string cul = "en-US";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["folderName"] = FileUploadControl1.UploadInFolder;
                //  Page.ClientScript.RegisterStartupScript(typeof(Page), "dfe", "SetPictureOnIframe();", true);


              
                if (!string.IsNullOrEmpty(Request.QueryString["lang"]))
                {
                    Session["lang"] = Request.QueryString["lang"];
                    //Response.Redirect("/");
                }

                if (Session["lang"] != null)
                {
                    cul = Session["lang"].ToString();
                    // SetCulture(Session["lang"].ToString());
                }
                else
                {
                    cul = "en-US";
                    // SetCulture("en-US");
                }

                if (Session["USER"] != null)
                {

                    if (((User)Session["USER"]).UserType != "N") // If not admin
                    {
                        Response.Redirect("/");
                    }
                }
                else
                {
                    Response.Redirect("Masters/ManageOrders.aspx");
                }


                //txtDescription.config.uiColor = "#BFEE62";
                //txtDescription.config.language = "de";
                //txtDescription.config.enterMode = EnterMode.BR;
               
                DBAccess.BindProducts(dropMainProducts);
                BindGrid();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (dropMainProducts.SelectedValue == "0")
            {
                lblMsg.Text = "Select Main Menu";
                dropMainProducts.Focus();
                return;
            }
            else if (drpVegNonVeg.SelectedValue == "-1")
            {
                lblMsg.Text = "Select Veg/Non-Veg";
                drpVegNonVeg.Focus();
                return;
            }
            else if (drpCust.SelectedValue == "-1")
            {
                lblMsg.Text = "Select Custmoized/Non-Custmoized";
                drpCust.Focus();
                return;
            }
            else if (txtNwsBy.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Price";
                txtNwsBy.Focus();
                return;
            }


            if (txtHeader.InnerText != string.Empty && txtDescription.InnerText != string.Empty)
            {


              KitchenOnMyPlate.MenuItem newObject = new KitchenOnMyPlate.MenuItem();
                newObject.Header = txtHeader.InnerText;
                newObject.Detail = txtDescription.InnerText;
                //newObject.Date = DateTime.Now;

                newObject.Picture = hdnImageNws.Value;
                newObject.Price = Convert.ToInt32( txtNwsBy.Text);
                newObject.PicDetails = txtPicDetails.InnerText;
                //newObject.cul = cul;

                newObject.MenuId = Convert.ToInt32(dropMainProducts.SelectedValue);
                newObject.Veg =  Convert.ToInt32(drpVegNonVeg.SelectedValue);
                newObject.NonCustomized =  Convert.ToInt32(drpCust.SelectedValue);

                newObject.ShowDetails = chkShowCOP.Checked ? 1 : 0;
                newObject.Varity = txtVarity.InnerText;  
                

                newObject.IsActive =  Convert.ToInt32(drpActive.SelectedValue);

                if (drpCust.SelectedValue == "0")
                {
                    if (chk1.Checked)
                    {
                        newObject.AvailableDay = "1";
                    }

                    if (chk2.Checked)
                    {
                        newObject.AvailableDay = !string.IsNullOrEmpty(newObject.AvailableDay) ? newObject.AvailableDay + ",2" : "2";
                    }

                    if (chk3.Checked)
                    {
                        newObject.AvailableDay = !string.IsNullOrEmpty(newObject.AvailableDay) ? newObject.AvailableDay + ",3" : "3";
                    }

                    if (chk4.Checked)
                    {
                        newObject.AvailableDay = !string.IsNullOrEmpty(newObject.AvailableDay) ? newObject.AvailableDay + ",4" : "4";
                    }

                    if (chk5.Checked)
                    {
                        newObject.AvailableDay = !string.IsNullOrEmpty(newObject.AvailableDay) ? newObject.AvailableDay + ",5" : "5";
                    }

                    if (chk6.Checked)
                    {
                        newObject.AvailableDay = !string.IsNullOrEmpty(newObject.AvailableDay) ? newObject.AvailableDay + ",6" : "6";
                    }

                    if (chk7.Checked)
                    {
                        newObject.AvailableDay = !string.IsNullOrEmpty(newObject.AvailableDay) ? newObject.AvailableDay + ",7" : "7";
                    }

                    if (hdnID.Value != "" && hdnID.Value != "0")
                    {
                        newObject.Id = Convert.ToInt32(hdnID.Value);
                    }
                }

                CMSActivieies.SaveNews(newObject);
                CacheHelper.Clear("SubMenues");
                BindGrid();

                Reset(); 
                dropMainProducts.SelectedValue = "0";
                drpVegNonVeg.SelectedValue = "-1";
                drpCust.SelectedValue = "-1";

                txtHeader.InnerText = "";
                txtDescription.InnerText = "";
                lblMsg.Text = "";
            }
            else
            {
                lblMsg.Text = "Fill all fields";
            }
        }

        void BindGrid()
        {


            GridNews.DataSource = CMSActivieies.GetSubProducts();
            GridNews.DataBind();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            txtDescription.Value = "";            
            txtHeader.Value = "";            
            hdnID.Value = "0";
            lblMsg.Text = "";
            drpCust.SelectedValue = "-1";
            dropMainProducts.SelectedValue = "0";
            txtNwsBy.Text = "";
            divCuct.Visible = false;
            drpVegNonVeg.SelectedValue = "-1";
            
        }

        protected void GridNews_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblMsg.Text = "";
            int index = e.NewSelectedIndex;
            hdnID.Value = GridNews.Rows[index].Cells[2].Text;
            btnNew.Visible = true;

            DataTable dt = CMSActivieies.GetSubProductById( Convert.ToInt32( hdnID.Value));
            
            txtHeader.InnerText = dt.Rows[0][1].ToString();
            txtDescription.InnerText = dt.Rows[0][2].ToString();

            //loadingLogo.Src = "images/News/thumbs/thumbs_" + GridNews.Rows[index].Cells[6].Text;
            hdnImageNws.Value = "images/SubProduct/thumbs/thumbs_" + dt.Rows[0][8].ToString(); ;
            Page.ClientScript.RegisterStartupScript(typeof(Page), "ddfe", "SetPicturesNews('dipPics', '1', '"+hdnImageNws.Value+"',  '"+ dt.Rows[0][8].ToString()+"');", true);

            txtNwsBy.Text = dt.Rows[0][7].ToString(); ;
            txtPicDetails.InnerText = dt.Rows[0][9].ToString();

            hdnImageNws.Value = dt.Rows[0][8].ToString();

            dropMainProducts.SelectedValue = dt.Rows[0][12].ToString();
            drpVegNonVeg.SelectedValue = dt.Rows[0][10].ToString();
            drpCust.SelectedValue = dt.Rows[0][11].ToString();
            drpActive.SelectedValue = dt.Rows[0][13].ToString();

            chkShowCOP.Checked = (dt.Rows[0]["ShowDetails"].ToString() == "1");
            txtVarity.InnerText = dt.Rows[0]["Varity"].ToString();

            if (drpCust.SelectedValue == "0" || drpCust.SelectedValue == "2")
            {
                divCuct.Visible = true;
                var availDays = dt.Rows[0][14].ToString();

                chk1.Checked = false;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;

                foreach (var a in availDays.Split(','))
                {
                    if (a == "1")
                    {
                        chk1.Checked = (a == "1");
                    }

                    if (a == "2")
                    {
                        chk2.Checked = (a == "2");
                    }

                    if (a == "3")
                    {
                        chk3.Checked = (a == "3");
                    }

                    if (a == "4")
                    {
                        chk4.Checked = (a == "4");
                    }

                    if (a == "5")
                    {
                        chk5.Checked = (a == "5");
                    }

                    if (a == "6")
                    {
                        chk6.Checked = (a == "6");
                    }

                    if (a == "7")
                    {
                        chk7.Checked = (a == "7");
                    }
                }
            }
            else
            {
                divCuct.Visible = false;
            }


                       

        }

        protected void GridNews_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[2].Style.Add("display", "none");
            //e.Row.Cells[4].Style.Add("display", "none");
            //e.Row.Cells[6].Style.Add("display", "none");
            //e.Row.Cells[7].Style.Add("display", "none");
            //e.Row.Cells[8].Style.Add("display", "none");
            //e.Row.Cells[9].Style.Add("display", "none");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[5].Text = Convert.ToDateTime(e.Row.Cells[5].Text).ToString("dd-MMM-yyyy");
                //string data = e.Row.Cells[4].Text;
                //e.Row.Cells[4].Text=string.Empty;
                //e.Row.Cells[4].Controls.Add(new Literal { Text = data });
            }

        }

        protected void GridNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            var Id = Convert.ToInt32(GridNews.Rows[index].Cells[2].Text);
            CMSActivieies.DeleteNews(Id);
            lblMsg.Text = "";
            BindGrid();
            CacheHelper.Clear("SubMenues");
            Reset(); 
        }

        protected void drpCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            divCuct.Visible = (drpCust.SelectedValue == "0");
        }
       

 
    }
}
