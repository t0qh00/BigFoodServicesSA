using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Productos
    {
        public int id { set; get; }
        public string descripcion { set; get; }
        public string unidadMedida { set; get; }
        public decimal precioCompra { set; get; }
        public decimal precioVenta { set; get; }
        public decimal impVenta { set; get; }
        public char controladoCierre { set; get; }
        public string codBarra { set; get; }
        public decimal existencia { set; get; }
        public DateTime fechaCreacion { set; get; }
        public string creadoPor { set; get; }
        public byte[] foto { set; get; }
        public char combo { set; get; }
        public char estado { set; get; }
        public int clasificacion { set; get; }
        public string productosCombo { set; get; }
        public int idCierreUltimAfectado { set; get; }
    }
}
