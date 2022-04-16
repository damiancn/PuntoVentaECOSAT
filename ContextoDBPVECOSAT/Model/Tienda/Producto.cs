using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDBPVECOSAT.Model.Tienda
{
    [Table("Productos", Schema = "Tienda")]
    public class Producto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }
    }
}
