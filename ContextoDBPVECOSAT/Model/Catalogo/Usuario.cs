using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDBPVECOSAT.Model.Catalogo
{
    [Table("Usuarios", Schema = "Catalogo")]

    public class Usuario
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string NombreUsuario { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public int RolUsuarioId { get; set; }

        public RolUsuario RolUsuario { get; set; }
    }
}
