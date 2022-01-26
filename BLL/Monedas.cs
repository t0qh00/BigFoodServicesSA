using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Monedas
    {
        public int id { set; get; }
        public string descripcion { set; get; }
        public DateTime fechaCreacion { set; get; }
        public string creadoPor { set; get; }
        public char estado { set; get; }
    }
}
