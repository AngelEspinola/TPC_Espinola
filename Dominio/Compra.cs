using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public int ID { get; set; }
        public List<Detalle> Detalle { get; set; }
        public Proveedor Proveedor { get; set; }
        public DateTime Fecha { get; set; }
    }
}
