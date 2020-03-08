using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Again.Models
{
    public class Student
    {
        [Key]
        [DisplayName("Mã sinh viên")]
        public string RollNumber { get; set; }
        [DisplayName("Tên sinh viên")]
        public string Name { get; set; }
       
    }
}