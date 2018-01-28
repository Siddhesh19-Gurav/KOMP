using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KitchenOnMyPlate.DataAccess;

namespace KitchenOnMyPlate
{

    
    public partial class Search : System.Web.UI.Page
    {
        protected string searchtext = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Request.QueryString["q"]))
            {
                searchtext = Request.QueryString["q"];
                string[] strlist =  Request.QueryString["q"].Split(' ');
                var products = DBAccess.GetProducts();
                var subproducts = DBAccess.GetSubProducts();
                
                string dinnerLunch = Request.QueryString["q"].ToUpper().Contains("DINNER")?"0":"1";

                foreach (var item in strlist)
                {
                    string item1 = item.ToString().ToUpper();
                    string str = string.Empty;
                    //string custDivInner = string.Empty;
                    
                    foreach (var prd in products)
                    {
                        var subproducts1 = from w in subproducts where w.MenuId == prd.Id select w;
                        foreach (var subprd in subproducts1)
                        {
                            if (subprd.Header.ToUpper().Contains(item1) || subprd.Detail.ToUpper().Contains(item1))
                            {
                                if ((prd.ShowInBoth == "N" || prd.ShowInBoth == "B"))
                                {
                                    custDivInner.InnerHtml = custDivInner.InnerHtml + "<span> <a href='Service.aspx?il=" + dinnerLunch + "&itm=" + subprd.Id + "'>" + subprd.Header + "</a></span><br/><p>" + subprd.Detail + "</p><hr />";
                                }
                                else
                                {
                                    custDivInner.InnerHtml = custDivInner.InnerHtml + "<span> <a href='YourOrder.aspx?itm=" + subprd.Id + "'>" + subprd.Header + "</a></span><br/><p>" + subprd.Detail + "</p><hr />";
                                }

                            }


                        }

                        if (prd.Header.ToUpper().Contains(item1) || prd.Detail.ToUpper().Contains(item1))
                        {
                            var detail = prd.Detail.Length > 120 ? (prd.Detail.Substring(0, 120) + "..") : prd.Detail;
                            if ((prd.ShowInBoth == "N" || prd.ShowInBoth == "B"))
                            {

                                custDivInner.InnerHtml = custDivInner.InnerHtml + "<span> <a href='Service.aspx?il=" + dinnerLunch + "&itm=" + prd.Id + "'>" + prd.Header + "</a></span><br/><p>" + detail + "</p><hr />";
                            }
                            else
                            {
                                custDivInner.InnerHtml = custDivInner.InnerHtml + "<span> <a href='YourOrder.aspx?itm=" + prd.Id + "'>" + prd.Header + "</a></span><br/><p>" + detail + "</p><hr />";
                            }

                        }
                        if (prd.HeaderCus.ToUpper().Contains(item1) || prd.DetailCus.ToUpper().Contains(item1))
                        {
                            var detail = prd.HeaderCus.Length > 120 ? (prd.DetailCus.Substring(0, 120) + "..") : prd.DetailCus;
                            custDivInner.InnerHtml = custDivInner.InnerHtml + "<span> <a href='YourOrder.aspx?itm=" + prd.Id + "'>" + prd.HeaderCus + "</a></span><br/><p>" + detail + "</p><hr />";
                          

                        }
                    }


              
                }

                if (custDivInner.InnerHtml == string.Empty)
                {
                    custDivInner.InnerHtml = "<b/> No Result Found !!</b>";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
      
            //FileUpload1.SaveAs(FileUpload1.PostedFile.FileName);
        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    FileUpload1.SaveAs(Server.MapPath("CV/" + FileUpload1.PostedFile.FileName));
        //    hdnCV.Value = FileUpload1.PostedFile.FileName;
        //    lblCVName.Text = FileUpload1.PostedFile.FileName;
        //}
    }
}