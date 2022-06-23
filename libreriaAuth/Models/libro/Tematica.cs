using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace autentifAuthorized.Models
{
    public class Tematica
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }
}