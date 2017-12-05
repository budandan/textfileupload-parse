using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ImageUpload.Models
{
    [Table("File")]
    public class File
    {
        [Key]
        public int FileID { get; set; }
        public String FilePath { get; set; }
    }
}