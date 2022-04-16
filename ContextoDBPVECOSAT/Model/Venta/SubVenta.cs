using ContextoDBPVECOSAT.Model.Tienda;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDBPVECOSAT.Model.Venta
{
    [Table("SubVentas", Schema = "Venta")]

    public class SubVenta
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }

        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
    }
}
