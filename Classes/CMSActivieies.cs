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
using System.Collections.Generic;
using System.Text;
using System.IO;
using SwamiSamarthSeva;
using System.Data.SqlClient;
using KitchenOnMyPlate.DataAccess;

namespace KitchenOnMyPlate.Classes
{
    public class CMSActivieies
    {
       

        public static List<MenuItem> TopNews(string cul)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var news = (from w in db.MenuItems orderby w.Id descending select w);
                return news.ToList();
            }
        }

        public static DataTable GetSubProducts()
        {
            SqlDataReader rdr = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            String cs = System.Configuration.ConfigurationManager.ConnectionStrings["DevKOMPConnectionString"].ConnectionString;
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                cmd = new SqlCommand("select MenuItems.Id, MenuItems.Header as 'Menu Item',Menu.Header as 'Product', case MenuItems.Veg when 1 then 'Veg' else 'Non-Veg' end as Type,case MenuItems.NonCustomized when 0 then 'Customized' else 'Non-Customized' end as Customized,MenuItems.Price , case MenuItems.IsActive when 1 then 'Active' else '' end as 'Active',replace(replace(replace(replace(replace(replace(replace(AvailableDay,'1','Mon'),'2','Tue') ,'3','Wed') ,'4','Thu') ,'5','Fri') ,'6','Sat') ,'7','Sat') as 'Available Days',Calories from MenuItems inner join Menu on Menu.Id=  MenuItems.MenuId Order By MenuItems.Id", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Sales");

                con.Close();

                return myDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static DataTable GetSubProductById(int Id)
        {
            SqlDataReader rdr = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            String cs = System.Configuration.ConfigurationManager.ConnectionStrings["DevKOMPConnectionString"].ConnectionString;
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                cmd = new SqlCommand("select MenuItems.Id, MenuItems.Header as 'Menu Item', MenuItems.Detail as 'Detail', Menu.Header as 'Product', case MenuItems.Veg when 1 then 'Veg' else 'Non-Veg' end as Type,case MenuItems.NonCustomized when 0 then 'Customized' else 'Non-Customized' end as Customized,case MenuItems.IsActive when 1 then 'Active' else '' end as 'Active',MenuItems.Price,MenuItems.Picture, MenuItems.PicDetails, MenuItems.Veg, MenuItems.NonCustomized, MenuItems.MenuId,  MenuItems.IsActive,AvailableDay, MenuItems.ShowDetails,MenuItems.Varity,Calories from MenuItems inner join Menu on Menu.Id=  MenuItems.MenuId where MenuItems.Id='" + Id + "' Order By MenuItems.Id", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Sales");
                
                con.Close();

                return myDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<MenuItem> News(string cul)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var news = (from w in db.MenuItems orderby w.Id descending  select w);             
                return news.ToList();
            }
        }

        public static List<MenuItem> News()
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var news = (from w in db.MenuItems orderby w.Id descending select w);
                return news.ToList();
            }
        }

        public static List<PhotoDirectory> PhotoDirectories()
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var dirs = (from w in db.PhotoDirectories orderby w.Sequence descending select w);
                return dirs.ToList();
            }
        }

        public static List<PeraImage> GetPeraImage(string dir)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var imags = (from w in db.PeraImages where w.Directory == dir select w);
                return imags.Take(3).ToList();
            }
        }

        public static List<PeraImage> GetPeraImageOnEvent(string dir)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                var imags = (from w in db.PeraImages where w.Directory == dir select w);
                return imags.ToList();
            }
        }

        public static void SaveProduct(Menu obj)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {

                if (obj.Id == 0)
                {
                    db.Menus.InsertOnSubmit(obj);
                }
                else
                {
                    KitchenOnMyPlate.Menu objUpdated = db.Menus.Where(p => (p.Id == obj.Id)).First();
                    objUpdated.Header = obj.Header;
                    objUpdated.Detail = obj.Detail;
                    objUpdated.IsActive = obj.IsActive;
                }
                db.SubmitChanges();
                db.Dispose();
                CacheHelper.Clear("Menu");
            }
        }

        public static void SaveNews(MenuItem obj)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {

                if (obj.Id == 0)
                {
                    db.MenuItems.InsertOnSubmit(obj);
                }
                else
                {
                    KitchenOnMyPlate.MenuItem objUpdated = db.MenuItems.Where(p => (p.Id == obj.Id)).First();
                    objUpdated.Header = obj.Header;
                    objUpdated.Detail = obj.Detail;
                    objUpdated.Picture = obj.Picture;
                    objUpdated.MenuId = obj.MenuId;
                    objUpdated.Price = obj.Price;
                    objUpdated.Veg = obj.Veg;
                    objUpdated.NonCustomized = obj.NonCustomized;
                    objUpdated.IsActive = obj.IsActive;
                    objUpdated.AvailableDay = obj.AvailableDay;
                    objUpdated.Varity = obj.Varity;
                    objUpdated.ShowDetails = obj.ShowDetails;
                    objUpdated.Calories = obj.Calories;
                }
                db.SubmitChanges();
                db.Dispose();
            }
        }

        public static void DeleteProduct(int id)
        {
            DBKOMPDataContext db = new DBKOMPDataContext();
            var objDelete = (from w in db.Menus where w.Id == id select w ).First();
           // db.Menus.Attach(objDelete);
            db.Menus.DeleteOnSubmit(objDelete);
            db.SubmitChanges();
            CacheHelper.Clear("Menu");
        }

        public static void DeleteNews(int id)
        {
            DBKOMPDataContext db = new DBKOMPDataContext();
            var objDelete = News().Where(p => (p.Id == id)).First();
            db.MenuItems.Attach(objDelete);
            db.MenuItems.DeleteOnSubmit(objDelete);
            db.SubmitChanges();
        
        }

        public bool UpdateFolderOrder(string folders)
        {
            DBKOMPDataContext db = new DBKOMPDataContext();
            string[] folderArr = folders.Split('^');
            for (int k = 0; k < folderArr.Length; k++)
            {
                PhotoDirectory tbl = db.PhotoDirectories.Single(p => p.Id == Convert.ToInt32(folderArr[k]));
                tbl.Sequence = k+1;
                db.SubmitChanges();
            }
            return true;
        }

        public static int SaveEventNPics(PeraImage peraImage)
        {
            try
            {
                DBKOMPDataContext db = new DBKOMPDataContext();

                db.PeraImages.InsertOnSubmit(peraImage);


                db.SubmitChanges();
                return 1;
               // Page.ClientScript.RegisterStartupScript(typeof(Page), "sub", "GetFiles();", true);

                // SetFolders();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int SendMsgToAgent(Message msg)
        {
            using (DBKOMPDataContext db = new DBKOMPDataContext())
            {
                db.Messages.InsertOnSubmit(msg);
                db.SubmitChanges();

                #region Send Mail


                string content = string.Empty;

                string filepath = "~/Email/UserMessage.htm";
                //New user
                StringBuilder sbContent = new StringBuilder();
                StreamReader rdr = new StreamReader(HttpContext.Current.Server.MapPath(filepath));
                string strLine = "";
                while (strLine != null)
                {
                    strLine = rdr.ReadLine();
                    if ((strLine != null) && (strLine != ""))
                    {
                        sbContent.Append("\n" + strLine);
                    }
                }
                rdr.Close();

                string site = ConfigurationManager.AppSettings["SiteName"].ToString();
                content = sbContent.ToString();

                content = content.Replace("$USER$", msg.name);
                content = content.Replace("$MESSAGE$", msg.message1);

                content = content.Replace("$EMAIL$", msg.email);
                content = content.Replace("$MOBILE$", msg.mobile);

                content = content.Replace("$SITE$", site);

                content = content.Replace("RobotoBlack", "Arial");
                content = content.Replace("Roboto", "Arial");
                content = content.Replace("RobotoBold", "Arial");
                content = content.Replace("images/rs3.png", "http://www.kitchenonmyplate.com/images/rs3.png");
                content = content.Replace("class", "style");
                content = content.Replace("page-titleSmallCust", "color:#4b220c; text-transform:uppercase; font-family:'Arial'; font-weight:bold;border-bottom:1px solid #c8c6c6; padding:10px 0 10px 25px ; font-size:25px; margin-top:0px;background:#EEEEEE !important;");
                content = content.Replace("OrderBox", "display:none");
                content = content.Replace("ProcessBox", "width:100%;height:auto;border:1px solid #c8c6c6;padding-bottom:10px;");
                content = content.Replace("ProcesBoxInner", "height:auto; padding:0px 25px 10px 10px;text-align: justify; text-justify: inter-word;");
                content = content.Replace("tbl", "width:100%;height:auto;border:1px solid #c8c6c6;");
                content = content.Replace("divRowHeader", "font-weight:bold; color:Black; font-size:0.85em;");
                content = content.Replace("<table", "<table style='border-collapse:collapse; border-spacing:0;' ");
                content = content.Replace("price", "font-weight:700; font-size:1.2em; color: #006400;");
                content = content.Replace("priceTotaltxt", "font-weight:700; font-size:24px; color: #006400;");
                content = content.Replace("priceTotal", "font-size:30px; color: #006400; padding-right:25px;");
                content = content.Replace("CUSTBOX", "");
                content = content.Replace("emailH5", "font-size:14px;");

                content = content.Replace(">01<", "");
                content = content.Replace(">03<", "");   
                //MailHelper.SendMailMessage("", objtblUser.email, string.Empty, string.Empty, "Thanks for Posting", content);
                //MailHelper.SendMailMessage("", "friend.panchal@gmail.com", string.Empty, string.Empty, "User message", content);
                string ownerEmailId1 = ConfigurationManager.AppSettings["OwnerEmailID1"].ToString();
                MailHelper.SendMailMessage("", ownerEmailId1, string.Empty, string.Empty, "Visitor's message", content);
                string ownerEmailId2 = ConfigurationManager.AppSettings["OwnerEmailID2"].ToString();
                MailHelper.SendMailMessage("", ownerEmailId2, string.Empty, string.Empty, "Visitor's message", content);


                #endregion

                return 1;
            }
        }


        public static MenuItem GetNews(int newsID)
        {
            DBKOMPDataContext db = new DBKOMPDataContext();

            var dto = db.MenuItems.Where(w => w.Id == newsID).First();

            MenuItem obj = new MenuItem();
            obj.Id = dto.Id;
            obj.Header = dto.Header;
            obj.Detail = dto.Detail;
            //obj.Date = Convert.ToDateTime(dto.Date).ToString("dd-MMM-yyyy");// +" " + Convert.ToDateTime(dto.Date).ToShortTimeString(); 

            obj.Picture = string.IsNullOrEmpty(dto.Picture) ? string.Empty : dto.Picture;
            //obj.NewsBy = string.IsNullOrEmpty(dto.NewsBy) ? string.Empty : dto.NewsBy;

            obj.PicDetails = string.IsNullOrEmpty(dto.PicDetails) ? string.Empty : dto.PicDetails;
            //obj.NewsURL = string.IsNullOrEmpty(dto.NewsURL) ? string.Empty : dto.NewsURL;



            return obj;
        }
    }
}
