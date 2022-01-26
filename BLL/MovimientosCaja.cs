using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MovimientosCaja
    {
        public int id { set; get; }
        public int idCaja{ set; get; }
        public string concepto { set; get; }
        public decimal monto { set; get; }
        public char tipo { set; get; }
        public DateTime fechaRegistro { set; get; }
        public string creadoPor { set; get; }
    }
}
