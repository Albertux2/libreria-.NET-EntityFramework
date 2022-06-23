using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace libreriaAuth.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [ForeignKey("articulo")]
        public int articuloId { get; set; }
        public Vendible articulo { get; set; }
        public int cantidad { get; set; }

        public Producto(Vendible producto, int cantidad)
        {
            this.articulo = producto;
            this.cantidad = cantidad;
        }

        public Producto()
        {
        }
    }
}