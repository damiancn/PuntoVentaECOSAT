namespace ContextoDBPVECOSAT.ModelVM.VentaVM
{
    public class SubVentaVM
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public string ProductoDescripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
    }
}
