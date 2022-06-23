using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace libreriaAuth.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string CodigoPostal { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Poblacion { get; set; }
        public Direccion(string codigoPostal, string calle, string numero,string poblacion)
        {
            CodigoPostal = codigoPostal;
            Calle = calle;
            Numero = numero;
            Poblacion = poblacion;
        }

        public Direccion()
        {
        }

        public String direccionFormateada()
        {
            return "C/" + Calle + " " + Numero + " | " + Poblacion + ", " + CodigoPostal;
        }
    }
}