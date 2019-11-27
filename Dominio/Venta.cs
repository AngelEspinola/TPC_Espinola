using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int ID { get; set; }
        public List<DetalleVenta> Detalle { get; set; }
        public Cliente cliente { get; set; }
        public float total { get; set; }

    }
}
