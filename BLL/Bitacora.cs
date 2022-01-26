using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bitacora
    {
        public string tabla { set; get; }
        public string usuario { set; get; }
        public string maquina { set; get; }
        public DateTime fecha { set; get; }
        public char tipo { set; get; }
        public string registro { set; get; }
    }
}
