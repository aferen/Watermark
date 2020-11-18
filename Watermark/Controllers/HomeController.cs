using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Watermark.Models;

namespace Watermark.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Feature());
        }

        [HttpPost]
        public ActionResult Index(Feature feature, HttpPostedFileBase file)
        {
            try
            {
                if (file == null)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase yuklenecekDosya = Request.Files[i];
                        string path = "~/Files/" + yuklenecekDosya.FileName;
                        Image image = Image.FromStream(yuklenecekDosya.InputStream);
                        int width = image.Width;
                        int height = image.Height;
                        Bitmap bmp = new Bitmap(width, height);
                        Graphics graphics = Graphics.FromImage((Image)bmp);
                        graphics.InterpolationMode = InterpolationMode.High;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.Clear(Color.Transparent);
                        graphics.DrawImage(image, 0, 0, width, height);
                        Font font = new Font("Arial", feature.FontSize, FontStyle.Regular);
                        SolidBrush brush = new SolidBrush(Color.FromArgb(70, 240, 240, 240));
                        graphics.RotateTransform(-34);
                        graphics.TranslateTransform(3.0F, 180.0F, MatrixOrder.Append);
                        graphics.DrawString(feature.Title, font, brush, 0, 0);
                        Image newImage = (Image)bmp;
                        newImage.Save(Server.MapPath("~/Files/" + yuklenecekDosya.FileName));
                        graphics.Dispose();
                        feature.SuccessMessage = "The process has completed successfully";
                    }
                }
            }
            catch (Exception e)
            {
                feature.ErrorMessage = e.ToString();
            }
           
            return View(feature);
        }
    }
}