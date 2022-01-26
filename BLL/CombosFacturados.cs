using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CombosFacturados
    {
        public string numFactura { set; get; }
        public int idCombo { set; get; }
        public int idProducto { set; get; }
        public string producto { set; get; }
        public decimal cantidadVenta { set; get; }
        public string registradoPor { set; get; }
        public DateTime fechaRegistro { set; get; }
    }
}
