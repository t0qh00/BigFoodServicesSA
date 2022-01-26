using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClavesAutorizacion
    {
        public int idAutorizacion { set; get; }
        public int clave { set; get; }
        public DateTime fechaEmision { set; get; }
        public char estado { set; get; }
        public string documento { set; get; }
        public string email { set; get; }
    }
}
