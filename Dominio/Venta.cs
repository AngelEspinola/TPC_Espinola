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
        public List<Detalle> Detalle { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }

    }
}
