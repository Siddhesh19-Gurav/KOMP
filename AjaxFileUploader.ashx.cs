using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace KitchenOnMyPlate
{
    /// <summary>
    /// Summary description for AjaxFileUploader
    /// </summary>
    public class AjaxFileUploader : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
          if (context.Request.Files.Count > 0)

{

              string path = (context.Request.Form["name"] == "logan1") ? context.Server.MapPath("~/images/User") : (context.Request.Form["name"] == "loganProject") ? context.Server.MapPath("~/images/Project") : (context.Request.Form["name"] == "loganLogo") ? context.Server.MapPath("~/images/CoachingLogo") : (context.Request.Form["name"] == "CV")?context.Server.MapPath("~/CV"):context.Server.MapPath("~/images/Property");

if (!Directory.Exists(path))
Directory.CreateDirectory(path); 

var file = context.Request.Files[0];

string fileName;

if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")

{

string[] files = file.FileName.Split(new char[] { '\\' });

fileName = files[files.Length - 1];

}

else

{

fileName = file.FileName;

}

//Mahesh Changed for GUI
//string strFileName = System.Guid.NewGuid().ToString("N") + fileName;
//fileName = Path.Combine(path, fileName);
string strFileName = System.Guid.NewGuid().ToString("N") + fileName;
fileName = Path.Combine(path, strFileName);

file.SaveAs(fileName);

if (context.Request.Form["name"] != "CV")
{
    Bitmap objBitmap = CreateThumbnail(fileName, 250, 149);
    objBitmap.Save(path + "/thumbs/thumbs_" + strFileName);
}

//imgProperty.Src = "images/" + UploadInFolder + "/thumbs/thumbs_" + fileName;

 

string msg = "{";

msg += string.Format("error:'{0}',\n", string.Empty);

msg += string.Format("msg:'{0}'\n", strFileName);

msg += "}";



context.Response.Write(msg);

}
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public static Bitmap CreateThumbnail(string lcFilename, int lnWidth, int lnHeight)
        {
            System.Drawing.Bitmap bmpOut = null;
            try
            {
                Bitmap loBMP = new Bitmap(lcFilename);
                ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                //*** If the image is smaller than a thumbnail just return it
                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)
                    return loBMP;

                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;
                    lnNewWidth = lnWidth;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;
                    lnNewHeight = lnHeight;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }
                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

                loBMP.Dispose();
            }
            catch (Exception ex)
            {
                return null;
            }

            return bmpOut;
        }
    }
}