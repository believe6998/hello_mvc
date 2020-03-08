using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Again.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}