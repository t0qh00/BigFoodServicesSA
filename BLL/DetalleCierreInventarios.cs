using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DetalleCierreInventarios
    {
        public int idCierre { set; get; }
        public int idProducto { set; get; }
        public string descripcion { set; get; }
        public decimal inicial { set; get; }
        public decimal ingreso { set; get; }
        public string observacionIngreso { set; get; }
        public decimal salida { set; get; }
        public string observacionSalida { set; get; }
        public decimal conteo { set; get; }
        public decimal gasto { set; get; }
        public decimal facturado { set; get; }
        public decimal diferencia { set; get; }
        public DateTime fechaCreacion{set;get;}

    }
}
