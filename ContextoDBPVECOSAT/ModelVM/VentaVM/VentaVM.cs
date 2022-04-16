namespace ContextoDBPVECOSAT.ModelVM.VentaVM
{
    public class VentaVM
    {
        public int Id { get; set; }
        public decimal ImporteTotal { get; set; }
        public int CantidadProductos { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioDescripcion { get; set; }
    }
}
