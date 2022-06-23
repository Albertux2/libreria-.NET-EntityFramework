using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace libreriaAuth.Models.libro
{
    public class Editorial
    {
        public int id { get; set; }
        [Display(Name = "Editorial")]
        public string nombre { get; set; }
    }
}