using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Denominaciones
    {
        public int id { set; get; }
        public string denominacion { set; get; }
        public int idMoneda { set; get; }
        public decimal valor { set; get; }
        public string creadoPor { set; get; }
        public char estado { set; get; }
        public char tipo { set; get; }
        public DateTime fechaCreacion { set; get; }
    }
}
