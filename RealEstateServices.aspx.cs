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
using System.Web.Services;
using System.Collections.Generic;
using MumbaiPropertyMart;

namespace KotaCoachings
{
    public partial class RealEstateServices : System.Web.UI.Page
    {
        static int pageIndex = 0;
        public static int totalCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // ReInitializeGrid();
              //  lblhits.Text = KotaCoachings.DataAccess.DBAccess.Hit(Request.UserHostAddress).ToString();

                #region Send Hit Mail
                string ip;
                ip = !string.IsNullOrEmpty(Request.ServerVariables["HTTP_X_FORWARDED_FOR"]) ? Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : Request.ServerVariables["REMOTE_ADDR"];
                if (!string.IsNullOrEmpty(ip))
                {
                    string[] ipRange = ip.Split(',');
                    string trueIP = ipRange[0].Trim();
                }
                else
                {
                    ip = Request.ServerVariables["REMOTE_ADDR"];
                }


                this.ClientScript.RegisterStartupScript(this.GetType(), "sendmail344", "getLocationIP('" + ip + "','Hitting Real Estat Services');", true);
                #endregion

                ///////////////////////////////////



                Page.Title = "Real Estate | Property in  " + ConfigurationManager.AppSettings["SiteCity"].ToString() + " | Buy/Sale/Rent Properties in " + ConfigurationManager.AppSettings["SiteCity"].ToString();
                Page.MetaDescription = "Real Estate Services in  " + ConfigurationManager.AppSettings["SiteCity"].ToString()+ ", Furniture in  " + ConfigurationManager.AppSettings["SiteCity"].ToString() +", the best property site in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ". Buy, Sell, Rent residential and commercial properties" + ",1BHK in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ",2BHK in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ",3BHK in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ", 1BHK flat in " + ConfigurationManager.AppSettings["SiteCity"].ToString();
                Page.MetaKeywords = "Real Estate Services in  " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ", Furniture in  " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ",  Real Estate, Property in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ", Properties in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ", Real Estate in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ", Rent in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ", Buy in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + "," + ConfigurationManager.AppSettings["SiteCity"].ToString() + ", Marriage Hall in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ",1BHK in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ",2BHK in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ",3BHK in " + ConfigurationManager.AppSettings["SiteCity"].ToString() + ", 1BHK flat in " + ConfigurationManager.AppSettings["SiteCity"].ToString();



            }
        }



        

        

        //[WebMethod]
        //public static Coaching[] GetCoachings(int Id, int pageBase, int pageIndex)
        //{
        //    return KotaCoachings.DataAccess.DBAccess.GetCoachings(Id, pageBase, pageIndex).ToArray();
        //}

       
        [WebMethod]
        public static ServiceType[] GetServiceType()
        {            
           return KotaCoachings.DataAccess.RealEstateServices.GetServiceTypes().ToArray();
        }

        [WebMethod]
        public static Service[] GetServices()
        {
           return KotaCoachings.DataAccess.RealEstateServices.GetServices().ToArray();
        }

        //[WebMethod]
        //public static CoachingCenter[] GetCoachingsAll()
        //{
        //    List<CoachingCenter> lst = new List<CoachingCenter>();
        //    var coachings = KotaCoachings.DataAccess.DBAccess.GetCoachingsAll();
        //    foreach (var ch in coachings)
        //    {
        //        lst.Add(new CoachingCenter { Id = ch.Id, Name = ch.Name });
        //    }
        //    return lst.ToArray();
        //}


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
          //  ReInitializeGrid();

        }

        //private void ReInitializeGrid()
        //{
        //    int CourseId = hdnCourse.Value == "" ? 0 : Convert.ToInt32(hdnCourse.Value);
        //    int CoachingId = hdnCoaching.Value == "" ? 0 : Convert.ToInt32(hdnCoaching.Value);

        //    List<CoachingDTO> listDto = new List<CoachingDTO>();
        //    var list = KotaCoachings.DataAccess.DBAccess.GetCoachings(CourseId, CoachingId, JQGrid1.PageSize, 0, ref totalCount);
        //    //foreach (Coaching dto in list)
        //    //{
        //    //    CoachingDTO obj = new CoachingDTO();
        //    //    obj.Id = dto.Id;
        //    //    obj.Name = dto.Name;
        //    //    obj.Phone = (dto.Phone == null) ? "" : dto.Phone;
        //    //    obj.Star = dto.Star ?? 0;
        //    //    obj.Fax = (dto.Fax == null) ? "" : dto.Fax;
        //    //    obj.email = (dto.email == null) ? "" : dto.email;
        //    //    obj.Details = (dto.Details == null) ? "" : dto.Details;
        //    //    obj.Address = (dto.Address == null) ? "" : dto.Address;
        //    //    obj.Total = totalCount;
        //    //    listDto.Add(obj);
        //    //}

        //    JQGrid1.DataSource = listDto;
        //    JQGrid1.DataBind();

        //    int toCount;
        //    toCount = (totalCount <= 20) ? totalCount : ((pageIndex * 20) + 20);
        //    lblRow.Text = "Records from " + (pageIndex * 20 + 1) + " to " + toCount + " out of " + totalCount;
        //    FirstSettingPagging();
        //}

        //private void LoadGrid()
        //{
        //    int CourseId = hdnCourse.Value == "" ? 0 : Convert.ToInt32(hdnCourse.Value);
        //    int CoachingId = hdnCoaching.Value == "" ? 0 : Convert.ToInt32(hdnCoaching.Value);

        //    JQGrid1.DataSource = KotaCoachings.DataAccess.DBAccess.GetCoachings(CourseId,CoachingId, JQGrid1.PageSize, pageIndex);
        //    JQGrid1.DataBind();
        //    //JQGrid1.HeaderRow.Style.Add("background-image", "url('images/3.png')");
        //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "lst", "$('#ctl00_MainContent_JQGrid1 tr:last').parent().parent().parent().css('background-image','url(images/3.png)');", true);
        //    int ToRecord = ((pageIndex * 20) + 20);
        //    if ((totalCount - pageIndex * 20) < 20)
        //    {
        //        ToRecord = totalCount;
        //    }
        //    lblRow.Text = "Records from " + (pageIndex * 20 + 1) + " to " + ToRecord + " out of " + totalCount;
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "DisableSelectMain();", true);

        //}
        protected void imgFirst_Click(object sender, ImageClickEventArgs e)
        {
            FirstSettingPagging();

            //LoadGrid();

        }

        private void FirstSettingPagging()
        {
            //pageIndex = 0;
            //imgFirst.Enabled = false;
            //imgFirst.ImageUrl = "images/firstSelect.png";

            //imgPrevious.Enabled = false;
            //imgPrevious.ImageUrl = "images/previousSelect.png";

            //bool IsGreater = (totalCount <= JQGrid1.PageSize) ? false : true;
            //imgNext.Enabled = IsGreater;
            //imgNext.ImageUrl = IsGreater ? "images/next.png" : "images/nextSelect.png";
            //imgLast.Enabled = IsGreater;
            //imgLast.ImageUrl = IsGreater ? "images/last.png" : "images/lastSelect.png";

        }

        protected void imgPrevious_Click(object sender, ImageClickEventArgs e)
        {
            //pageIndex--;
            //LoadGrid();
            //imgLast.Enabled = true;
            //if (pageIndex == 0)
            //{
            //    imgFirst.Enabled = false;
            //    imgFirst.ImageUrl = "images/firstSelect.png";

            //    imgPrevious.Enabled = false;
            //    imgPrevious.ImageUrl = "images/previousSelect.png";
            //}

            //imgNext.Enabled = true;
            //imgNext.ImageUrl = "images/next.png";
            //imgLast.Enabled = true;
            //imgLast.ImageUrl = "images/last.png";
        }

        protected void imgNext_Click(object sender, ImageClickEventArgs e)
        {
            //pageIndex++;
            //LoadGrid();
            //imgFirst.Enabled = true;
            //imgFirst.ImageUrl = "images/first.png";
            //imgPrevious.Enabled = true;
            //imgPrevious.ImageUrl = "images/previous.png";

            //int extra = ((totalCount % 20) > 0) ? 1 : 0;
            //if (pageIndex == ((totalCount / 20) + extra) - 1)
            //{
            //    imgNext.Enabled = false;
            //    imgNext.ImageUrl = "images/nextSelect.png";

            //    imgLast.Enabled = false;
            //    imgLast.ImageUrl = "images/lastSelect.png";

            //}
        }

        protected void imgLast_Click(object sender, ImageClickEventArgs e)
        {
            //int extra = ((totalCount % 20) > 0) ? 1 : 0;
            //string totalCountStr = Convert.ToDecimal(totalCount / 20).ToString();
            //pageIndex = (Convert.ToInt32(totalCountStr) + extra) - 1;
            //LoadGrid();
            //imgLast.Enabled = false;
            //imgLast.ImageUrl = "images/lastSelect.png";

            //imgNext.Enabled = false;
            //imgNext.ImageUrl = "images/nextSelect.png";

            //imgFirst.Enabled = true;
            //imgFirst.ImageUrl = "images/first.png";
            //imgPrevious.Enabled = true;
            //imgPrevious.ImageUrl = "images/previous.png";
        }

        [WebMethod()]
        public static UserDetailsDTO[] FillGridServices(string serviceId, string serviceTypeId, int pageIndex, int fistTime)
        {
            DBKotaEstateDataContext db = new DBKotaEstateDataContext();
            List<UserDetailsDTO> list;
            if (fistTime == 1)
            {
                list = KotaCoachings.DataAccess.RealEstateServices.GetProviders(Convert.ToInt32(serviceId), Convert.ToInt32(serviceTypeId), 10, pageIndex, ref totalCount);
            }
            else
            {
                list = KotaCoachings.DataAccess.RealEstateServices.GetProviders(Convert.ToInt32(serviceId), Convert.ToInt32(serviceTypeId), 10, pageIndex);
            }

            //List<UserDetailsDTO> listDto = new List<UserDetailsDTO>();

            //foreach (Coaching dto in list)
            //{
            //    CoachingDTO obj = new CoachingDTO();
            //    obj.Id = dto.Id;
            //    obj.Name = dto.Name;
            //    obj.Phone = (dto.Phone == null) ? "" : dto.Phone;
            //    obj.Phone2 = (dto.Phone2 == null) ? "" : dto.Phone2;
            //    obj.Phone3 = (dto.Phone3 == null) ? "" : dto.Phone3;
            //    obj.Phone4 = (dto.Phone4 == null) ? "" : dto.Phone4;

            //    obj.Star = dto.Star??0;
            //    obj.Fax = (dto.Fax == null) ? "" : dto.Fax;
            //    obj.email = (dto.email == null) ? "" : dto.email;
            //    obj.Details = (dto.Details==null)?"":dto.Details;
            //    obj.Address = (dto.Address == null) ? "" : dto.Address;
            //    obj.Total = totalCount;
            //    obj.CoachingLogo = (dto.CoachingLogo == null) ? "" : dto.CoachingLogo; 
            
            
            //    var courses = (from w in db.CoachingCourses
            //                   join u in db.Cources on w.CourseId equals u.Id
            //                   where (w.CoachingId == dto.Id)
            //                   select new { CourseName = u.Course });

            //    foreach (var item in courses)
            //    {
            //        obj.CourseList = string.IsNullOrEmpty(obj.CourseList) ? obj.CourseList + item.CourseName : obj.CourseList + "," + item.CourseName;
            //    }

            //    obj.CourseList = !string.IsNullOrEmpty(obj.CourseList)?"Provide Coaching for " + obj.CourseList: "";

            //    listDto.Add(obj);
            //}

            return list.ToArray();
        }


        //[WebMethod()]
        //public static CoachingDTO[] FillGridAll(string course, string coaching, int pageIndex, int fistTime)
        //{
        //    DBKotaCoachingsDataContext db = new DBKotaCoachingsDataContext();
        //    List<Coaching> list;
        //    if (fistTime == 1)
        //    {
        //        list = KotaCoachings.DataAccess.DBAccess.GetCoachingsAll(Convert.ToInt32(course), Convert.ToInt32(coaching), 10, pageIndex, ref totalCount);
        //    }
        //    else
        //    {
        //        list = KotaCoachings.DataAccess.DBAccess.GetCoachingsAll(Convert.ToInt32(course), Convert.ToInt32(coaching), 10, pageIndex);
        //    }

        //    List<CoachingDTO> listDto = new List<CoachingDTO>();

        //    foreach (Coaching dto in list)
        //    {
        //        CoachingDTO obj = new CoachingDTO();
        //        obj.Id = dto.Id;
        //        obj.Name = dto.Name;
        //        obj.Phone = (dto.Phone == null) ? "" : dto.Phone;

        //        obj.Phone2 = (dto.Phone2 == null) ? "" : dto.Phone2;
        //        obj.Phone3 = (dto.Phone3 == null) ? "" : dto.Phone3;
        //        obj.Phone4 = (dto.Phone4 == null) ? "" : dto.Phone4;

        //        obj.Star = dto.Star ?? 0;
        //        obj.Fax = (dto.Fax == null) ? "" : dto.Fax;
        //        obj.email = (dto.email == null) ? "" : dto.email;
        //        obj.Details = (dto.Details == null) ? "" : dto.Details;
        //        obj.Address = (dto.Address == null) ? "" : dto.Address;
        //        obj.Total = totalCount;
        //        obj.Website = dto.Website;
        //        obj.SocialSite = dto.SocialSite;

        //        listDto.Add(obj);
        //    }

        //    return listDto.ToArray();
        //}
    }
}
