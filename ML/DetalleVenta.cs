using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public Producto Producto { get; set; }
        public Venta Venta { get; set; }
        public int Piezas { get; set; }
        public List<Object> DetallesVenta { get; set; }
    }
}
