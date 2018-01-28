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

using KitchenOnMyPlate.Classes;
using KitchenOnMyPlate.DataAccess;
using KitchenOnMyPlate;

namespace KotaCoachings
{
    public partial class Register : System.Web.UI.Page
    {
        protected string ISCityDisplayed = "0";
        protected string logo = string.Empty;
        protected string LID = string.Empty;
        protected string Location = string.Empty;        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                BindLocation();

                if (!string.IsNullOrEmpty(Request.QueryString["rid"]))
                {
                    string decrypt = EncryptDecrypt.DecryptString(Request.QueryString["rid"].Replace("_", "+"), "kota@1234");
                    DBAccess.CreateSession(decrypt);
                }

                //BindDivision();
                lblSite.Text = ConfigurationManager.AppSettings["SiteName"].ToString();
                Page.Title = "Real Estate in " + ConfigurationManager.AppSettings["SiteCity"].ToString()+": Registeration";

                //var locations = DataAccess.DBAccess.GetLocations();
                //drpLocation.DataSource = locations;
                //drpLocation.DataTextField = "Location";
                //drpLocation.DataValueField = "Id";
                //drpLocation.DataBind();
                //drpLocation.Items.Add(new ListItem { Value = "0", Text = "--Select--", Selected = true });

                //int CurrentYear= Convert.ToInt32(DateTime.Today.Year);
                //for(int i=0;i<70;i++)
                //{                    
                //    drpWorkingSince.Items.Add(new ListItem { Text = CurrentYear.ToString(), Value = CurrentYear.ToString() });
                //    CurrentYear--;
                //}

                if (HttpContext.Current.Session["USER"] != null)
                {
                    User tblusr = (User)Session["USER"];
                    txtFirstName.Value = tblusr.FirstName;
                    hdnIsNew.Value = "0";
                    txtLastName.Value = tblusr.LastName;
                    txtMobile.Value = tblusr.mobile;
                    txtEmail.Disabled = true;
                    divPassword.Visible = false;
                    btnRegister.Value = "UPDATE YOUR ACCOUNT";
                    registerH1.InnerHtml = "MY ACCOUNT";
                    //trMobileShow.Visible = true;
                    //trEmailShow.Visible = true;

                    //txtMobilOnlyShow.Text = tblusr.mobile;
                    //txtEmailUsedOnEdit.Text = tblusr.email;

                    if (tblusr.mobile == tblusr.email)
                    {
                        //txtEmailUsedOnEdit.Text = string.Empty;
                        //txtEmailUsedOnEdit.Enabled = true;

                    }

                    txtCompanyName.Value = tblusr.CompanyName;
                    drpLocation.SelectedValue = tblusr.LocationId.ToString();
                    LID = tblusr.LocationId.ToString();
                    txtAddress.InnerHtml = tblusr.Address;
                    //if (LID != "" && LID != "0")
                    //{
                    //  Location = DBAccess.GetLocationById(LID);
                    //}



                    //if (ConfigurationManager.AppSettings["ShowCityOption"].ToString() == "1")
                    //{
                    //    if (tblusr.LocationId != 0)
                    //    {
                    //        var DivID = DBAccess.GetDivisionIdByLocationID(tblusr.LocationId ?? 0);
                    //        Page.ClientScript.RegisterStartupScript(typeof(Page), "dssdfg", " SetCityOnEdit('" + DivID + "','" + tblusr.LocationId + "');", true);
                    //    }
                    //}


                   // drpWorkingSince.SelectedValue = tblusr.WorkingSince.ToString();

                   // txtStd.Text = tblusr.STDCode == "0" ? "" : tblusr.STDCode;
            



                    txtEmail.Value = tblusr.email;

                   // Page.ClientScript.RegisterStartupScript(typeof(Page), "dddf", " $('#rdUserType1').attr('checked', ('" + tblusr.UserType + "'== 'O')); $('#rdUserType2').attr('checked', ('" + tblusr.UserType + "' == 'A'));  $('#rdUserType3').attr('checked', ('" + tblusr.UserType + "' == 'C')); $('#rdUserType4').attr('checked', ('" + tblusr.UserType + "' == 'B')); $('#rdUserType5').attr('checked', ('" + tblusr.UserType + "' == 'R'));", true);

                    //if (tblusr.UserType != "O" && tblusr.UserType != "C")
                    //{
                    //    Page.ClientScript.RegisterStartupScript(typeof(Page), "hhdf", "$('#trLocation,#trLandline,#trLandline1,#trLandline2,#trWebSite,#trSL,#trCompany').show();$('#trWorkingSince,#trAddress,#trAboutu,#divCompanyLogo,#ctl00_MainContent_trCity').show();", true);

                    //    #region Set Company Logo
                    //    var pictureLogo = (string.IsNullOrEmpty(tblusr.CompanyLogo) || tblusr.CompanyLogo == "DefultLogo.png") ? "images/CompanyLogo/DefultLogo.png" : "images/CompanyLogo/thumbs/thumbs_" + tblusr.CompanyLogo;

                    //    logo = tblusr.CompanyLogo;

                    //    if (pictureLogo != "images/CompanyLogo/DefultLogo.png")
                    //    {
                    //        //imgOnProfile.Src = pictureLogo;
                    //        Page.ClientScript.RegisterStartupScript(typeof(Page), "hhdfdd", "$('#divCompanyLogo').show();", true);
                    //        Page.ClientScript.RegisterStartupScript(typeof(Page), "pdphhdfdd", "SetPicturesCompanyLogo('dipPicsCompanyLogo', '" + pictureLogo + "', '" + tblusr.CompanyLogo + "');", true);
                            
                    //    }
                    //   // Page.ClientScript.RegisterStartupScript(typeof(Page), "hhdfdLogow", "document.getElementById('ctl00_MainContent_FileUploadControlCompLogo1_uploadFrame').contentWindow.SetPicture('" + pictureLogo + "');", true);
                    //    //Page.ClientScript.RegisterStartupScript(typeof(Page), "hhdfdLogo", "$('#loadingLogo').attr('src', '" + pictureLogo + "');", true);
                    //    #endregion

                    //}

                 //   var picture = (string.IsNullOrEmpty(tblusr.picture) || tblusr.picture == "agent.jpg") ? "images/agent.jpg" : "images/UserProperty/" + tblusr.picture;
                    //Page.ClientScript.RegisterStartupScript(typeof(Page), "hhdfd", "$('#loading').attr('src', '" + picture + "');", true);

                   // Page.ClientScript.RegisterStartupScript(typeof(Page), "ppfghhdfdd", "SetPicturesUserPhoto('dipPicsUserPhoto', 1, " + picture + ", " + tblusr.picture + ");", true);


                    //txtEmail.Enabled = false;

                   // Page.ClientScript.RegisterStartupScript(typeof(Page), "df", " $('#divPassword,#trAgree,#divLoginDetails,#supportDiv').hide();$('#imgSignup').hide();$('#bSign').hide();", true);
                  //  Page.ClientScript.RegisterStartupScript(typeof(Page), "dwf", " $('#txtAddress').val('" + tblusr.Address + "');$('#txtAboutu').val('" + tblusr.AboutUs + "');", true);

                }
                else
                {
                 //   Page.ClientScript.RegisterStartupScript(typeof(Page), "dfe", "$('#divChangePassword,#pDeleteProfile,#pDeleteProfile').hide();$('#pChangePassword').hide();$('#pEditProfile').hide();$('#divProfile').removeClass('msg_body');", true);
                }

              
                #region Send Hit Mail
                //string ip;
                //ip = !string.IsNullOrEmpty(Request.ServerVariables["HTTP_X_FORWARDED_FOR"]) ? Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : Request.ServerVariables["REMOTE_ADDR"];
                //if (!string.IsNullOrEmpty(ip))
                //{
                //    string[] ipRange = ip.Split(',');
                //    string trueIP = ipRange[0].Trim();
                //}
                //else
                //{
                //    ip = Request.ServerVariables["REMOTE_ADDR"];
                //}


               // this.ClientScript.RegisterStartupScript(this.GetType(), "sendmail344", "getLocationIP('" + ip + "','hit for " + ConfigurationManager.AppSettings["SiteCity"].ToString() + "');", true);
                #endregion
                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //DBService dbs = new DBService();
            //dbs.InsertUpdateUserDetails(new tblUser { FirstName = txtFirstName.Text, MiddleName = txtMiddleName.Text, LastName = txtLastName.Text, password = txtPasssword.Text, UserLoginID = txtUID.Text, email = txtEmail.Value });
            //Response.Redirect("home.aspx");
        }

        private void BindLocation()
        {
            DBAccess.BindAllLocation(drpLocation);
        }
    }
}
