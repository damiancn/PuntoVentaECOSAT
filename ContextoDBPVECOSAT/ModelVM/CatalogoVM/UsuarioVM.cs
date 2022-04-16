namespace ContextoDBPVECOSAT.ModelVM.CatalogoVM
{
    public class UsuarioVM
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public int RolUsuarioId { get; set; }
        public string RolUsuarioDescripcion { get; set; }
    }
}
