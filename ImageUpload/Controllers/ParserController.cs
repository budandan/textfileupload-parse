using ImageUpload.DAL;
using System;
using System.Collections.Generic;
using ImageUpload.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUpload.Controllers
{
    public class ParserController : Controller
    {
        private FileUploadContext db = new FileUploadContext();
        // GET: Parser
        public ActionResult Index()
        {
            List<File> fileList = new List<File>();
            fileList = db.Files.ToList();
            return View(fileList);
        }

        public ActionResult ParseMenu(int id)
        {
            Models.File file = new Models.File();
            file = db.Files.Find(id);
            String fileContents = System.IO.File.ReadAllText(Request.MapPath("~/UploadedFiles/txt/" + file.FilePath));

            ViewBag.name = file.FilePath;
            ViewBag.fileContents = fileContents;

            return View();
        }

        public string ViewContents(String s)
        {
            return s;
        } 

        public ActionResult Parse(String s)
        {
            List<String[]> strArray = new List<String[]>();
            strArray.Add(s.Split(','));
            strArray.Add(s.Split('\t'));
            strArray.Add(s.Split('\n'));
            System.Diagnostics.Debug.WriteLine(strArray);
            ViewBag.strArray = s;
            return View();
        }
    }
}