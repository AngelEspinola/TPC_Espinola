using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Identificador { get; set; }
        public string Contraseña { get; set; }
        public int Nivel { get; set; } // 1=Administrador ; 2=Supervisor ; 3=Staff
        public string Email { get; set; }
    }
}
