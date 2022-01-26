using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DetalleMovimiento
    {
        public int idMov { set; get; }
        public int idProducto { set; get; }
        public string producto { set; get; }
        public decimal cantidad { set; get; }
    }
}
