using System.ComponentModel.DataAnnotations;

namespace Sistema_Expermed.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        [Required (ErrorMessage ="El campo CI es obligatorio")] //Validación de campo obligatorio
        public int? CiUsuario { get; set; }
        public string? NombresUsuario { get; set; }
        public string? ApellidosUsuario { get; set; }
        public string? TelefonoUsuario { get; set; }
        public string? EmailUsuario { get; set; }
        public string? EstablecimientoUsuario { get; set; }
        public string? direcccionestable_usuario { get; set; }
        public string? ciudad_usuario { get; set; }
        public string? provincia_usuario { get; set; }
        public DateTime? FechacreacionUsuario { get; set; }
        public DateTime? FechamodificacionUsuario { get; set; }
        public string? LoginUsuario { get; set; }
        public string? ClaveUsuario { get; set; }
        public int? ActivoUsuario { get; set; }
        public int? PerfilUsuarioP { get; set; }
        public string? descripcionperfil_usuario { get; set; }
        public string? CodigoUsuario { get; set; }


        // public virtual Perfil? PerfilUsuarioPNavigation { get; set; }




        public Usuario()
        {
            
            //UsuarioCreacionPacientes = "Admin";
            ActivoUsuario = 1;
        }

    }


}
