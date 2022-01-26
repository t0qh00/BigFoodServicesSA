using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CierreInventarios
    {
        public string responsable { set; get; }
        public DateTime fecha { set; get; }
        public string RevisadoPor { set; get; }
        public DateTime fechaRevisado { set; get; }
        public DateTime fechaAnulacion { set; get; }
        public string anuladoPor { set; get; }
        public DateTime fechaCreacion { set; get; }
        public char estado { set; get; }
        public string realizadoPor { set; get; }
        public string observacion { set; get; }
        public int id { set; get; }
    }
}
