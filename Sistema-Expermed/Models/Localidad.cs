namespace Sistema_Expermed.Models
{
    public class Localidad
    {
        public int IdLocalidad { get; set; }
        public DateTime FechaCreacionLocalidad { get; set; }
        public string UsuarioCreacionLocalidad { get; set; }
        public DateTime? FechaModificacionLocalidad { get; set; }
        public string UsuarioModificacionLocalidad { get; set; }
        public bool ActivoLocalidad { get; set; }
        public string NombreLocalidad { get; set; }
        public string GentilicioLocalidad { get; set; }
        public string PrefijoLocalidad { get; set; }
        public string CodigoLocalidad { get; set; }
        public string IsoLocalidad { get; set; }
        public string IsoAdLocalidad { get; set; }
        public string CiaLocalidad { get; set; }
    }
}
