using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace libreriaAuth.Models
{
    public class Vendible
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Precio { get; set; }
        [Required]
        public String Titulo { get; set; }
        [Display(Name ="Introduce una URL con imagen jpg/jpeg/png/gif")]
        [RegularExpression(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)", ErrorMessage = "Debe introducir una URL de imagen válida")]
        public String imagen { get; set; }
        [Range(0,int.MaxValue)]
        public int Cantidad { get; set; }

    }
}