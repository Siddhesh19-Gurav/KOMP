<%@ WebHandler Language="C#" Class="Uploader" %>

using System;
using System.Web;
using System.Web.SessionState;

public class Uploader : IHttpHandler, IReadOnlySessionState
{
    
    public void ProcessRequest (HttpContext context) {

        if (context.Session["folderName"] != null)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile uploadFiles = context.Request.Files["Filedata"];
            string path = HttpContext.Current.Server.MapPath("~/images/" + HttpContext.Current.Session["folderName"].ToString() + "/");

            string fileName = System.Guid.NewGuid().ToString("N") + uploadFiles.FileName;
            //string fileName = System.Guid.NewGuid().ToString("N") + uploadFiles.FileName;        

            string pathToSave = path + fileName;
            uploadFiles.SaveAs(pathToSave);

            System.Drawing.Bitmap objBitmap = CreateThumbnail(pathToSave, 299, 290);

            if (!System.IO.Directory.Exists(path + "\\thumbs"))
            {
                System.IO.Directory.CreateDirectory(path + "\\thumbs");
            } 
            
            
            objBitmap.Save(path + "\\thumbs\\thumbs_" + fileName);
            context.Response.ContentType = "application/json";
            context.Response.Write(fileName);

            //if (HttpContext.Current.Session["folderName"].ToString() != "News")
            //{
            //    PeraFin.PeraFinDBAccess.SaveEventNPics(new SwamiSamarthSeva.PeraImage { Id = 0, FileName = fileName, Detail = uploadFiles.FileName, Directory = HttpContext.Current.Session["folderName"].ToString() });
            //}
        }
        
    }

    public static System.Drawing.Bitmap CreateThumbnail(string lcFilename, int lnWidth, int lnHeight)
    {
        System.Drawing.Bitmap bmpOut = null;
        try
        {
            System.Drawing.Bitmap loBMP = new System.Drawing.Bitmap(lcFilename);
            System.Drawing.Imaging.ImageFormat loFormat = loBMP.RawFormat;

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
            bmpOut = new System.Drawing.Bitmap(lnNewWidth, lnNewHeight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmpOut);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.FillRectangle(System.Drawing.Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
            g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

            loBMP.Dispose();
        }
        catch (Exception ex)
        {
            return null;
        }

        return bmpOut;
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}