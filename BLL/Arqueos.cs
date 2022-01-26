using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Arqueos
    {
        public int idCaja { set; get; }
        public int idDenominacion { set; get; }
        public int cantidad { set; get; }
        public DateTime fechaCreacion { set; get; }
        public string creadoPor { set; get; }
        public int moneda { set; get; }
    }
}
