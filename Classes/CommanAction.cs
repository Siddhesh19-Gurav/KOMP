using System;
using System.Data;
using System.Configuration;
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


namespace KitchenOnMyPlate.Classes
{
    public class CommanAction
    {
        public static void GetFiles(System.Web.UI.WebControls.Literal ltrCtrl, string folderName, string MainFolder, string Group)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(folderName);
            //to retrieve aspx files alone
            System.IO.FileInfo[] fileEntries = di.GetFiles("*.jpg");
            ltrCtrl.Text = string.Empty;
            //string[] fileEntries = Directory.GetFiles(Server.MapPath("images/PhotaGallery"));
            foreach (FileInfo fileName in fileEntries)
            {
                ltrCtrl.Text = ltrCtrl.Text + " <a rel='" + Group + "' style='outline: none;' class='fancy' title='" + fileName.Name.Remove(fileName.Name.IndexOf(".")) + "' href='images/" + MainFolder + "/" + fileName.Name + "'>";
                ltrCtrl.Text = ltrCtrl.Text + " <img src='images/" + MainFolder + "/" + fileName.Name + "' style='border:none;width:90px;height:70px;margin-left:15px;margin-top:8px' />";
                ltrCtrl.Text = ltrCtrl.Text + " </a>";
            }
        }

        
        ////Generate Events
        //public static string GetFiles(string folderName, string MainFolder, string Group)
        //{
        //    string htmlString = "";
        //    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(folderName));
        //    //to retrieve aspx files alone
        //    System.IO.FileInfo[] fileEntries = di.GetFiles("*.jpg");            
        //    //string[] fileEntries = Directory.GetFiles(Server.MapPath("images/PhotaGallery"));

        //    DBKOMPDataContext db = new DBKOMPDataContext();
            
        //    foreach (FileInfo fileName in fileEntries)
        //    {                
        //        PeraImage obj = new PeraImage();
        //        obj.Directory = MainFolder;

        //        htmlString = htmlString + "<div style='margin-left:5px;width:220px;float:left;'>";
        //        htmlString = htmlString + "<a rel='" + Group + "' style='outline: none;' class='fancy' title='" + fileName.Name.Remove(fileName.Name.IndexOf(".")) + "' href='images/" + MainFolder + "/" + fileName.Name + "'>";
        //        htmlString = htmlString + " <img src='images/" + MainFolder + "/" + fileName.Name + "' style='border:none;width:220px;height:240px;margin-top:8px' />";
        //        htmlString = htmlString + " </a><p style='margin-left:5px' >A Description of an image is dalled. A great momentom</p> </div>";
                
        //        obj.FileName = fileName.Name;
        //        obj.Detail = fileName.Name.Replace("jpg", "").Replace("JPG", "");

        //        db.PeraImages.InsertOnSubmit(obj);
        //        db.SubmitChanges();
        //    }

            
        //    return htmlString;
        //}


        public static User GetSession()
        {
             //Read the cookie from Request.
                HttpCookie myCookie = HttpContext.Current.Request.Cookies["USERMART"];
                if (myCookie != null)
                {
                    if (!string.IsNullOrEmpty(myCookie.Values["EMAIL"]))
                    {
                        if ( HttpContext.Current.Session["USER"] == null)
                        {
                            DataAccess.DBAccess.CreateSession(myCookie.Values["EMAIL"]);
                        }
                    }
                }

                if (HttpContext.Current.Session["USER"] == null)
                {
                    return (new User());
                }
                return ((User)HttpContext.Current.Session["USER"]);
        }

          //Generate Events
        public static string GetFilesOnEventPage(string folderName, string MainFolder, string Group)
        {
            string htmlString = "";

            List<PeraImage> images = CMSActivieies.GetPeraImageOnEvent(MainFolder);

            //System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(folderName));
            //to retrieve aspx files alone
            //System.IO.FileInfo[] fileEntries = di.GetFiles("*.jpg");            
            //string[] fileEntries = Directory.GetFiles(Server.MapPath("images/PhotaGallery"));  

            DBKOMPDataContext db = new DBKOMPDataContext();
            PeraImage obj = new PeraImage();
            obj.Directory = MainFolder;

            int indx = 1;
            string floatCss="float:left";
            string clearCss = string.Empty;
            string EventName = string.Empty;
            string CenterImage = string.Empty;
            foreach (PeraImage fileName in images)
            {
                if (indx == 1)
                {
                     EventName = (from w in db.PhotoDirectories where w.FolderName == fileName.Directory select w).First().AlbumName;
                     CenterImage = "<img src='images/" + MainFolder + "/" + fileName.FileName + "' style='position:absolute;border:none;width:auto;height:380px;margin:0 auto' />";
                }

                //floatCss = indx%2==0?"float:left":"";
                clearCss = indx%2==0?"<div style='clear:both'></div>":"";
                indx++;
                //htmlString = htmlString + "<div style='margin-left:5px;width:210px;height:210px;float:left'>";

                htmlString = htmlString + "<div style='margin-left:8px;width:90px;height:90px;margin-top:8px;" + floatCss + "'>";
                htmlString = htmlString + "<div style='width:90px;height:90px;overflow:hidden;'  class='BoxPicBG'>";
                //TODO : un commne blow an comment belwo next
                htmlString = htmlString + "<div style='margin:0 auto;width:90px;height:90px;overflow:hidden;vertical-align:middle;display:table-cell;' ><a rel='" + Group + "' style='outline: none;' class='fancy' title='" + fileName.Detail + "' href='images/" + MainFolder + "/" + fileName.FileName + "'>";
                //htmlString = htmlString + "<div style='margin:0 auto;width:90px;height:90px;overflow:hidden;vertical-align:middle;display:table-cell;' ><a rel='" + Group + "' style='outline: none;' class='fancy' title='" + fileName.Detail + "' href='Events.aspx?id=" + fileName.Id + "'>";
                htmlString = htmlString + " <img src='images/" + MainFolder + "/thumbs/thumbs_" + fileName.FileName + "' style='border:none;width:90px;height:90px;margin:0 auto' />";
                htmlString = htmlString + " </a></div> </div>";
                //htmlString = htmlString + "<p style='margin-left:0px;display:none' >" + fileName.Detail + "</p> 
                htmlString = htmlString + "</div>";
                htmlString = htmlString + clearCss;               
                
            }
            
            return htmlString+"^"+EventName+"^"+CenterImage;
        }

        

        //Generate Events
        public static string GetFiles(string folderName, string MainFolder, string Group)
        {
            string htmlString = "";

            List<PeraImage> images = CMSActivieies.GetPeraImage(MainFolder);

            //System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(folderName));
            //to retrieve aspx files alone
            //System.IO.FileInfo[] fileEntries = di.GetFiles("*.jpg");            
            //string[] fileEntries = Directory.GetFiles(Server.MapPath("images/PhotaGallery"));  

            DBKOMPDataContext db = new DBKOMPDataContext();
            PeraImage obj = new PeraImage();
            obj.Directory = MainFolder;

            foreach (PeraImage fileName in images)
            {
                //htmlString = htmlString + "<div style='margin-left:5px;width:210px;height:210px;float:left'>";

                htmlString = htmlString + "<div style='margin-left:5px;width:180px;height:90px;margin-top:6px'>";
                htmlString = htmlString + "<div style='width:200px;height:90px;overflow:hidden;'  class='BoxPicBG'>";
                htmlString = htmlString + "<div style='margin:0 auto;width:180px;height:90px;overflow:hidden;vertical-align:middle;display:table-cell;' ><a rel='" + Group + "' style='outline: none;' class='fancy' title='" + fileName.Detail + "' href='images/" + MainFolder + "/" + fileName.FileName + "'>";
                htmlString = htmlString + " <img src='images/" + MainFolder + "/thumbs/thumbs_" + fileName.FileName + "' style='border:none;width:180px;height:auto;margin:0 auto' />";
                htmlString = htmlString + " </a></div> </div>";
                htmlString = htmlString + "<p style='margin-left:0px;display:none' >" + fileName.Detail + "</p> </div>";

            }
            return htmlString;
        }


        public static string GetFilesForTitle(string folderName, string MainFolder, string Group)
        {
            string htmlString = "";

            List<PeraImage> images = CMSActivieies.GetPeraImage(MainFolder);
            //System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(folderName));
            //to retrieve aspx files alone
            //System.IO.FileInfo[] fileEntries = di.GetFiles("*.jpg");            
            //string[] fileEntries = Directory.GetFiles(Server.MapPath("images/PhotaGallery"));
            foreach (PeraImage fileName in images)
            {
                htmlString = htmlString + "<div id='" + fileName.FileName + "' ><a rel='" + Group + "' class='aaa' title='" + fileName.FileName + "' href='" + folderName + "/" + fileName.FileName + "'>" +
                         "<img id='img" + fileName.FileName + "' src='" + folderName + "/" + fileName.FileName + "' width='40' height='30' /></a><textarea id='txt" + fileName.FileName + "' cols='25' rows='2'>" + fileName.Detail + "</textarea></div>";

            }
            return htmlString;
        }
        public static string GetFilesWithCheckBox(string folderName, string MainFolder, string Group)
        {
            string htmlString = "";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(folderName));
            //to retrieve aspx files alone
            System.IO.FileInfo[] fileEntries = di.GetFiles("*.jpg");            
            //string[] fileEntries = Directory.GetFiles(Server.MapPath("images/PhotaGallery"));
            foreach (FileInfo fileName in fileEntries)
            {
                htmlString = htmlString + "<div id='" + fileName.Name + "' ><a rel='" + Group + "' class='aaa' title='" + fileName.Name + "' href='" + folderName + "/" + fileName.Name + "'>" +
                         "<img src='" + folderName + "/thumbs/thumbs_" + fileName.Name + "' width='40' height='30' /></a><input id='chk" + fileName.Name + "' type='checkbox' /></div>";

            }

            HttpContext.Current.Session["folderName"] = MainFolder;

            return htmlString;
        }
        

        public static string GetFiles(string folderName, string MainFolder, string Group, int indexFrom)
        {
            string htmlString = "";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(folderName));
            //to retrieve aspx files alone
            System.IO.FileInfo[] fileEntries = di.GetFiles("*.jpg");
            var files = fileEntries.Skip(indexFrom * 6).Take(6).ToList();
                       

            //string[] fileEntries = Directory.GetFiles(Server.MapPath("images/PhotaGallery"));
            foreach (FileInfo fileName in files)
            {

                htmlString = htmlString + "<div style=' margin-top:10px; margin-left:10px;width:120px;height:120px;float:left'>";
                htmlString = htmlString + "<div style='width:120px;height:120px;overflow:hidden;'  class='BoxPicBG'>";
                htmlString = htmlString + "<div style='margin:0 auto;width:120px;height:120px;overflow:hidden;vertical-align:middle;display:table-cell;' ><a rel='" + Group + "' style='outline: none;' class='fancy' title='" + fileName.Name.Remove(fileName.Name.IndexOf(".")) + "' href='images/" + MainFolder + "/" + fileName.Name + "'>";
                htmlString = htmlString + " <img src='images/" + MainFolder + "/thumbs/thumbs_" + fileName.Name + "' style='border:none;width:120px;height:auto;margin:0 auto' />";
                htmlString = htmlString + " </a></div>  </div></div>";


               // htmlString = htmlString + " <a rel='" + Group + "' style='outline: none;' class='fancy' title='" + fileName.Name.Remove(fileName.Name.IndexOf(".")) + "' href='images/" + MainFolder + "/" + fileName.Name + "'>";
               // htmlString = htmlString + " <img src='images/" + MainFolder + "/thumbs/thumbs_" + fileName.Name + "' style='border:none;width:120px;height:auto;margin-left:15px;margin-top:8px' />";
               // htmlString = htmlString + " </a>";

               
            }
          

            return htmlString;
        }


        public static string DeleteFiles(string files, string folderName)
        {
            DBKOMPDataContext db = new DBKOMPDataContext();
            string[] fileArray = files.Split(',');                
            foreach (string fileName in fileArray)
            {
                //delete from direcotry
                System.IO.FileInfo fileEntries = new FileInfo(HttpContext.Current.Server.MapPath("images/" + folderName + "/" + fileName));
                fileEntries.Delete();

                //delete from database
                var objDelete = db.PeraImages.Where(p => (p.FileName == fileName)).First();

                db.PeraImages.DeleteOnSubmit(objDelete);
                db.SubmitChanges();
            }

            return GetFilesWithCheckBox("images/" + folderName, folderName, "group1");
        }

        public static string GenerateEvents()
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var dirs = (from w in db.PhotoDirectories where w.Type == "E" orderby w.Sequence select w);
                string htmlStr = "";
                //ToDo: set outer flow
                
                
                foreach (PhotoDirectory photo in dirs)
                {
                    htmlStr = htmlStr + "<div style='margin-top:5px;' >";
                    htmlStr = htmlStr + "<p class='msg_head EventHeader' onclick=\"SetImages('div" + photo.FolderName + "','" + photo.FolderName + "','" + photo.FolderName + "')\">" + photo.AlbumName + "</p>";
                    htmlStr = htmlStr + "<div class='msg_body' id='divmsg" + photo.FolderName + "' >";




                    htmlStr = htmlStr + "<img onclick=LeftMove('div" + photo.FolderName + "') style='width:35px;z-index:10;position:absolute;margin-left:-26px;margin-top:73px' src='../images/Previous.png'/>";
                    htmlStr = htmlStr + "<div id='div" + photo.FolderName + "'  style='margin-left:6px;position:absolute;overflow:hidden;width:910px;height:280px' ></div>";
                    htmlStr = htmlStr + "<img onclick=RightMove('div" + photo.FolderName + "') style='width:35px;position:absolute;margin-left:905px;margin-top:73px' src='../images/Next.png'/>";

                        

                    htmlStr = htmlStr + "</div>";
                    htmlStr = htmlStr + "</div>";
                }
                

                return htmlStr;
            }
        }

        public static int SaveTitle(string imageFile, string title, string folderName)
        {
            DBKOMPDataContext db = new DBKOMPDataContext();

            lock (db)
            {
                System.Diagnostics.Process.GetCurrentProcess();

                PeraImage obj = new PeraImage();

                PeraImage objUpdated = db.PeraImages.Where(p => (p.Directory == folderName && p.FileName == imageFile)).First();
                objUpdated.Detail = title;

                db.SubmitChanges();
                db.Dispose();
            }
            return 1;
        }
        
        public static int SaveEvent(int eventId, string eventName)
        {
            DBKOMPDataContext db = new DBKOMPDataContext();

            PhotoDirectory obj = new PhotoDirectory();
            if (eventId == 0)
            {
                
                obj.AlbumName=eventName;
                obj.FolderName = eventName.Replace(" ", "");
                obj.Sequence=(from w in db.PhotoDirectories where w.Type=="E" select w).Count()+1;
                obj.Type="E";
                db.PhotoDirectories.InsertOnSubmit(obj);
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("images/"+eventName.Replace(" ","")));
            }
            else
            {
                PhotoDirectory objUpdated = db.PhotoDirectories.Where(p => (p.Id == eventId)).First();
                objUpdated.AlbumName = eventName;                
            }

            db.SubmitChanges();
            db.Dispose();
            return obj.Id;
        }
        public static bool DeleteEvent(int eventId)
        {
            DBKOMPDataContext db = new DBKOMPDataContext();
            bool Deleted = false;
            if (eventId == 0)
            {
                Deleted = false;
            }
            else
            {                
                var objDelete = db.PhotoDirectories.Where(p => (p.Id == eventId)).First();
                //db.PhotoDirectories.Attach(objDelete);
                db.PhotoDirectories.DeleteOnSubmit(objDelete);                
                Deleted = true;
                Directory.Delete(HttpContext.Current.Server.MapPath("images/" + objDelete.FolderName),true);
                db.SubmitChanges();
            }
            return Deleted;
        }

        
    }


    public class NewsDTO
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Detail { get; set; }
        public string Date { get; set; }
        public string Picture { get; set; }
        public string NewsBy { get; set; }
        public string PicDetails { get; set; }
        public string NewsURL { get; set; }
    }
}
