using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDBPVECOSAT.ModelVM
{
    public class RespuestaVM
    {
        public bool Estatus { get; set; }
        public string Mensaje { get; set; }
        public dynamic Objeto { get; set; }
    }
}
