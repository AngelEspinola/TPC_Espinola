using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor
    {
        public int ID { get; set; }
        public string CUIT { get; set; }
        public string RazonSocial { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public string FechaRegistro { get; set; }
        public List<Producto> Productos { get; set; }

        public override string ToString()
        {
            return RazonSocial;
        }
    }
}
