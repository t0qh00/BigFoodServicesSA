using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cajas
    {
        public int id { set; get; }
        public string responsabe { set; get; }
        public decimal montoApertura { set; get; }
        public char estado { set; get; }
        public DateTime fechaApertura { set; get; }
        public string cocineroTurno { set; get; }
        public DateTime fechaCierre { set; get; }
        public decimal montoCierre { set; get; }
        public decimal montoCierreDolares { set; get; }
        public decimal montoTarjetaBn { set; get; }
        public decimal montoTarjetaBac { set; get; }
    }
}
