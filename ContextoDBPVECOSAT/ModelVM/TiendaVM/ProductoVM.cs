namespace ContextoDBPVECOSAT.ModelVM.TiendaVM
{
    public class ProductoVM
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int DepartamentoId { get; set; }
        public string DepartamentoDescripcion { get; set; }
    }
}
