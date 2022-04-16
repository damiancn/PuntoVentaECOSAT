using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDBPVECOSAT.Model.Catalogo
{
    [Table("RolUsuarios", Schema = "Catalogo")]
    public class RolUsuario
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; }
    }
}
