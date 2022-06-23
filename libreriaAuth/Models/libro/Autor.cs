using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace autentifAuthorized.Models
{
    public class Autor
    {
        public int id { get; set; }
        [Display(Name = "Autor")]
        public string nombre { get; set; }
    }
}