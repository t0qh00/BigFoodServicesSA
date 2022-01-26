using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductosInterCambiables
    {
        public int idCombo { set; get; }
        public int idProducto { set; get; }
        public int idProductoInterCambiable { set; get; }
        public DateTime fechaRegistro { set; get; }
        public string registradoPor { set; get; }
    }
}
