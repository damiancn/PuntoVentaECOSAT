using ContextoDBPVECOSAT.Model.Catalogo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDBPVECOSAT.Model.Venta
{
    [Table("Ventas", Schema = "Venta")]
    public class Venta
    {
        public int Id { get; set; }
        public decimal ImporteTotal { get; set; }
        public int CantidadProductos { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<SubVenta> SubVentas { get; set; }
    }
}
