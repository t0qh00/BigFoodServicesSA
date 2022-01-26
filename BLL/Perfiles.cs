using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Perfiles
    {
        public string login { set; get; }
        public string nombreCompleto { set; get; }
        public string contraseña { set; get; }
        public DateTime fechaCreacion { set; get; }
        public char roll { set; get; }
        public char estado { set; get; }
    }
}
