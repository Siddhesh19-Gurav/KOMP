using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using SwamiSamarthSeva;
using KitchenOnMyPlate;
using KitchenOnMyPlate.Classes;

namespace PeraFin
{
    public partial class ManagePhotos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["USER"] != null)
            {

                if (((User)Session["USER"]).UserType != "N") // If not admin
                {
                    Response.Redirect("Default.aspx?Q=123456789");
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                SetFolders();
                GetFolderOrdedr();
            }
            Folders.Attributes.Add("onchange","GetFiles();return false");
            DropDownList1.Attributes.Add("onchange", "GetFilesForTitle();return false");
        }

        //protected void Images()
        //{            
        //    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath("images/"+Folders.SelectedItem));
        //    //to retrieve aspx files alone
        //    System.IO.FileInfo[] fileEntries = di.GetFiles("*.jpg");            

        //    //string[] fileEntries = Directory.GetFiles(Server.MapPath("images/PhotaGallery"));
        //    foreach (FileInfo fileName in fileEntries)
        //    {
        //        ltrlImage.Text = ltrlImage.Text + "<div id='" + fileName.Name + "' ><a rel='group' class='aaa' title='" + fileName.Name + "' href='../Samples/" + fileName.Name + "'>" +
        //                 "<img src='images/" + Folders.Text + "/" + fileName.Name + "' width='40' height='30' /></a><input id='chk" + fileName.Name + "' type='checkbox' /></div>";
                
        //    }
        //}

        //protected void Folders_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Images();
        //}

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                DBKOMPDataContext db = new DBKOMPDataContext();

                // Get the HttpFileCollection
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    PeraImage obj = new PeraImage();
                    obj.Directory = Folders.SelectedItem.ToString();

                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        hpf.SaveAs(Server.MapPath("images/" + Folders.SelectedItem) + "\\" +
                          System.IO.Path.GetFileName(hpf.FileName));
                        Response.Write("<b>File: </b>" + hpf.FileName + "  <b>Size:</b> " +
                            hpf.ContentLength + "  <b>Type:</b> " + hpf.ContentType + " Uploaded Successfully <br/>");
                    }

                    obj.FileName = hpf.FileName;
                    obj.Detail = hpf.FileName.Replace(".jpg", "").Replace(".JPG", "");

                    db.PeraImages.InsertOnSubmit(obj);
                    db.SubmitChanges();
                }

                Page.ClientScript.RegisterStartupScript(typeof(Page), "sub", "GetFiles();", true);
                
               // SetFolders();
            }
            catch (Exception ex)
            {

            }
        }

        void SetFolders()
        {
            Folders.DataSource = CMSActivieies.PhotoDirectories();
            Folders.DataTextField = "FolderName";
            Folders.DataValueField = "FolderName";
            Folders.DataBind();
            Folders.Items.Insert(0,new ListItem("--Select--","0"));

            DropDownList1.DataSource = CMSActivieies.PhotoDirectories();
            DropDownList1.DataTextField = "FolderName";
            DropDownList1.DataValueField = "FolderName";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0,new ListItem("--Select--","0"));
        }

        void GetFolderOrdedr()
        {
            IEnumerable<PhotoDirectory> folderList = CMSActivieies.PhotoDirectories();

            var mainBar = from w in folderList where w.Type == "E" orderby w.Sequence select w;

            lstMainMenu.DataSource = mainBar;
            lstMainMenu.DataTextField = "AlbumName";
            lstMainMenu.DataValueField = "Id";
            lstMainMenu.DataBind();
            lstMainMenu.SelectedIndex = 0;

            lstEvents.DataSource = mainBar;
            lstEvents.DataTextField = "AlbumName";
            lstEvents.DataValueField = "Id";
            lstEvents.DataBind();
        }




        
    }
}
