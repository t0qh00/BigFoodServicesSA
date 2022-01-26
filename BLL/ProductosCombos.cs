using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductosCombos
    {
        public int idCombo { set; get; }
        public int idProducto { set; get; }
        public decimal precioVenta { set; get; }
        public decimal cantidad { set; get; }
        public DateTime fechaCreacion { set; get; }
        public string creadoPor { set; get; }
        public char interCambiar { set; get; }
        public string productosIntercambiables { set; get; }

    }
}
