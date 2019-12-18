using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string URLImagen { get; set; }
        public float Precio { get; set; }
        public float Ganancia { get; set; }
        public long Stock { get; set; }
        public int StockMinimo { get; set; }
        public override string ToString()
        {
            return Titulo;
        }
    }
}
