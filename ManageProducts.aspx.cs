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
    public partial class ManageProducts : System.Web.UI.Page
    {
        string cul = "en-US";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["folderName"] = "Product";
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
                        Response.Redirect("Default.aspx?Q=123456789");
                    }
                }
                else
                {
                    Response.Redirect("Masters/ManageOrders.aspx");
                }


                //txtDescription.config.uiColor = "#BFEE62";
                //txtDescription.config.language = "de";
                //txtDescription.config.enterMode = EnterMode.BR;
                               
                BindGrid();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            if (txtHeader.InnerText != string.Empty && txtDescription.InnerText != string.Empty)
            {


                KitchenOnMyPlate.Menu newObject = new KitchenOnMyPlate.Menu();
                newObject.Header = txtHeader.InnerText.Replace("$BR$", "<br/>"); ;
                newObject.Detail = txtDescription.InnerText.Replace("$BR$","<br/>");
                newObject.HeaderCus = txtHeaderDesc.InnerText.Replace("$BR$", "<br/>"); ;
                newObject.DetailCus = txtDescriptionCus.InnerText.Replace("$BR$", "<br/>"); ;
                newObject.ShowInBoth = (chkTiff.Checked && chkCust.Checked) ? "B" : chkTiff.Checked ? "N" : "C";
                newObject.Picture = hdnImageNws.Value;
                //newObject.Date = DateTime.Now;
              
                newObject.IsActive =  Convert.ToInt32(drpActive.SelectedValue);


                if (hdnID.Value != "" && hdnID.Value != "0")
                {
                    newObject.Id = Convert.ToInt32(hdnID.Value);
                }

                CMSActivieies.SaveProduct(newObject);
                BindGrid();
                txtHeader.InnerText = "";
                txtDescription.InnerText = "";
                lblMsg.Text = "";

                Reset();
                CacheHelper.Clear("Menu");

              
            }
            else
            {
                lblMsg.Text = "Fill all fields";
            }
        }

        void BindGrid()
        {


            GridNews.DataSource = DBAccess.GetProducts();
            GridNews.DataBind();
        }

        protected void GridNews_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblMsg.Text = "";
            btnNew.Visible = true;
            int index = e.NewSelectedIndex;
            hdnID.Value = GridNews.Rows[index].Cells[2].Text;

            var objP = (from w in DBAccess.GetProducts() where w.Id == Convert.ToInt32(hdnID.Value) select w).First();

            txtHeader.InnerText = objP.Header.Replace("<br/>", "$BR$"); //GridNews.Rows[index].Cells[3].Text;
            txtDescription.InnerText = objP.Detail.Replace("<br/>", "$BR$");
            txtHeaderDesc.InnerText = objP.HeaderCus.Replace("<br/>", "$BR$"); 
            txtDescriptionCus.InnerText = objP.DetailCus.Replace("<br/>", "$BR$"); 
            if(objP.ShowInBoth=="B")
            {
                chkTiff.Checked = true;
                chkCust.Checked = true;
            }
            else if (objP.ShowInBoth == "N")
            {//only tiffn
                chkTiff.Checked = true;
                chkCust.Checked = false;
            }
            else if (objP.ShowInBoth == "C")
            {//only cust
                chkTiff.Checked = false;
                chkCust.Checked = true;
            }

            if (chkCust.Checked)
            {
                divCustomized.Style.Add("display", "block");
            }

            hdnImageNws.Value = "images/Product/thumbs/thumbs_" + objP.Picture.ToString(); ;
            Page.ClientScript.RegisterStartupScript(typeof(Page), "ddfe", "SetPicturesNews('dipPics', '1', '" + hdnImageNws.Value + "',  '" + objP.Picture + "');", true);


            drpActive.SelectedValue = objP.IsActive.ToString();

                       

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
              e.Row.Cells[4].Text = e.Row.Cells[4].Text == "1" ? "Yes" : "No";
                //string data = e.Row.Cells[4].Text;
                //e.Row.Cells[4].Text=string.Empty;
                //e.Row.Cells[4].Controls.Add(new Literal { Text = data });
            }

        }

        protected void GridNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            var Id = Convert.ToInt32(GridNews.Rows[index].Cells[2].Text);
            CMSActivieies.DeleteProduct(Id);
            CacheHelper.Clear("Menu");
            Reset();
            BindGrid();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            txtDescription.Value = "";
            txtDescriptionCus.Value = "";
            txtHeader.Value = "";
            txtHeaderDesc.Value = "";
            hdnID.Value = "0";
            chkCust.Checked = false;
            chkTiff.Checked = false;
            divCustomized.Style.Add("display", "none");
            lblMsg.Text = "";
        }
 
    }
}
