using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Clientes
    {
        public int id { set; get; }
        public char tipoCedula { set; get; }
        public string cedulaLegal { set; get; }
        public string nombreLegal { set; get; }
        public string direccion { set; get; }
        public string telefono { set; get; }
        public string email { set; get; }
        public DateTime fechaCreacion { set; get; }
        public string creadoPor { set; get; }
        public char estado { set; get; }
    }
}
