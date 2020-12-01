using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public Subcategoria Subcategoria { get; set; }
        public Proveedor Proveedor { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Piezas { get; set; }
        public string Descripcion { get; set; }
        public List<object> Productos { get; set; }
    }
}
