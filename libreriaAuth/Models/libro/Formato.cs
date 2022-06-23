using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace autentifAuthorized.Models
{
    public class Formato
    {
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}