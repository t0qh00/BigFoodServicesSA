using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Factura
    {
        public string numero { set; get; }
        public DateTime fecha { set; get; }
        public char terminoPago { set; get; }
        public char medioPago { set; get; }
        public string responsable { set; get; }
        public int idCliente { set; get; }
        public int idCaja { set; get; }
        public decimal subTotal { set; get; }
        public decimal impuesto { set; get; }
        public decimal total { set; get; }
        public char estado { set; get; }
        public string anuladoPor { set; get; }
        public DateTime fechaAnulacion { set; get; }
        public decimal montoEfectivo { set; get; }
        public decimal montoTarjeta { set; get; }
        public decimal montoDolares { set; get; }
        public string numTarjeta { set; get; }
        public decimal montoDescuento { set; get; }
        public char consumoAdministrativo { set; get; }
        public decimal tipoCambio { set; get; }
    }
}
