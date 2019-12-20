using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Stock
    {
        public Producto Producto { get; set; }
        public long StockActual { get; set; }
        public long StockMinimo { get; set; }
    }
}
