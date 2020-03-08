using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Again.Models
{
    public class Punish
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [DisplayName("Tiền phạt")]
        public double Money { get; set; }
        [DisplayName("Chống đẩy")]
        public int pushUp { get; set; }
        [DisplayName("Ngày")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [ForeignKey("Student")]
        public string StudentRollNumber { get; set; }
        public virtual Student Student { get; set; }
    }
}