using ImageUpload.DAL;
using ImageUpload.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUpload.Controllers
{
    public class UploadController : Controller
    {
        private FileUploadContext db = new FileUploadContext();
        // GET: Upload
        public ActionResult SaveFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveFile(HttpPostedFileBase UploadedFile)
        {
            if (UploadedFile != null)
            {
                if(UploadedFile.ContentLength > 0)
                {
                    if (Path.GetExtension(UploadedFile.FileName) == ".txt")
                    {
                        // truncate the original .txt extension
                        string fileName = Path.GetFileName(UploadedFile.FileName);
                        fileName = fileName.Substring(0, fileName.Length - 4);

                        // append unique date time to not have collisions in db
                        fileName += "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff") + ".txt";
                        string folderPath = Path.Combine(Server.MapPath("~/UploadedFiles/txt"), fileName);
                        UploadedFile.SaveAs(folderPath);

                        ViewBag.Message = "File Uploaded Successfully.";
                        // done saving to folder

                        // save path to server
                        Models.File file = new Models.File();
                        file.FilePath = fileName;
                        db.Files.Add(file);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Message = "Extension not supported.";
                    }
                }
            }
            else
            {
                ViewBag.Message = "File not selected.";
                return View();
            }
            return View();
        }
    }
}