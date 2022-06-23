using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace libreriaAuth.Models
{
    public class Factura
    {
        public int Id { get; set; }
        [ForeignKey("Carrito")]
        public int Carrito_Id { get; set; }
        public Carrito Carrito { get; set; }
        public Direccion Direccion { get; set; }
        public DateTime Fecha { get; set; }
        public float ImporteTotal { get; set; }

        public Factura(Carrito carrito, DateTime fecha, float importeTotal,Direccion direccion)
        {
            this.Carrito = carrito;
            this.Fecha = fecha;
            this.ImporteTotal = importeTotal;
            this.Direccion = direccion;
        }

        public Factura()
        {
        }
    }
}