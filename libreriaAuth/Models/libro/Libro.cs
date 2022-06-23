using libreriaAuth.Models;
using libreriaAuth.Models.libro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace autentifAuthorized.Models
{
    public class Libro:Vendible
    {
        [Required]
        [StringLength(13,MinimumLength =10,ErrorMessage = "El ISBN debe estar comprendido entre 10-13 caracteres")]
        [Index(IsUnique =true)]
        public String Isbn { get; set; }
        [Required]
        [ForeignKey("Autor")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        [ForeignKey("Genero")]
        public int GeneroId { get; set; }
        public Tematica Genero { get; set; }
        [ForeignKey("Formato")]
        public int FormatoId { get; set; }
        public Formato Formato { get; set; }
        [ForeignKey("Estado")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        [ForeignKey("Editorial")]
        public int EditorialId { get; set; }
        public Editorial Editorial { get; set; }

        public Libro() : base(){ }
    }
}