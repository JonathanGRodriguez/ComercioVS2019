using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Subcategoria
    {
        public int IdSubcategoria { get; set; }
        public Categoria Categoria { get; set; }
        public string Nombre { get; set; }
        public List<object> Subcategorias { get; set; }
    }
}
