using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Detalle
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }

        public float SubTotal { get; set; }
    }
}
