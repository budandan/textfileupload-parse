using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ImageUpload.Models;

namespace ImageUpload.DAL
{
    public class FileUploadContext: DbContext
    {
        public FileUploadContext(): base("FileUploadContext")
        {

        }

        public DbSet<File> Files { get; set; }
    }
}