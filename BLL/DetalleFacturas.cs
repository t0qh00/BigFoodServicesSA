using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DetalleFacturas
    {
        public int numLinea { set; get; }
        public string numFactura { set; get; }
        public int idProducto { set; get; }
        public string descripcion { set; get; }
        public decimal precioVenta { set; get; }
        public decimal imp { set; get; }
        public decimal cantidad { set; get; }
        public decimal subTotal { set; get; }
        public char esCombo { set; get; }
    }
}
