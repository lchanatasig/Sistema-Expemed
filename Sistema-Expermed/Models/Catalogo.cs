namespace Sistema_Expermed.Models
{
    public class Catalogo
    {
        public int IdCatalogo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int Activo { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
    }

}
