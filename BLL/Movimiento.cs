using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Movimiento
    {
        public int id { set; get; }
        public string responsable { set; get; }
        public DateTime fecha { set; get; }
        public string observacion { set; get; }
        public char tipo { set; get; }
        public char motivo { set; get; }
        public char estado { set; get; }
        public int idCierreInventario { set; get; }
    }
}
