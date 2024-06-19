using Sistema_Expermed.Models;
using System.ComponentModel.DataAnnotations;


namespace Sistema_Expermed.Models
{
    public class Paciente
    {
        public int IdPacientes { get; set; }
        public DateTime FechaCreacionPacientes { get; set; }
        public string? UsuarioCreacionPacientes { get; set; }
        public DateTime FechaModificacionPacientes { get; set; }
        public string? UsuarioModificacionPacientes { get; set; }
        public int ActivoPacientes { get; set; }
        public int TipoDocumentoPacientesC { get; set; }
  
        public int CiPacientes { get; set; }
    
        public string? PrimerNombrePacientes { get; set; }
        public string? SegundoNombrePacientes { get; set; }
        public string? PrimerApellidoPacientes { get; set; }
        public string? SegundoApellidoPacientes { get; set; }
        public int SexoPacientesC { get; set; }
        public DateTime FechaNacimientoPacientes { get; set; }
        public int Edad { get; set; }
        public int TipoSangrePacientesC { get; set; }
        public string? DonantePacientes { get; set; }
        public int EstadoCivilPacientesC { get; set; }
        public int FormacionProfesionalPacientesC { get; set; }
        public int TelefonoFijoPacientes { get; set; }
        public int TelefonoCelularPacientes { get; set; }
        public string? EmailPacientes { get; set; }
        public int NacionalidadPacientesL { get; set; }
        public int ProvinciaPacientesL { get; set; }
        public string? DireccionPacientes { get; set; }
        public string? OcupacionPacientes { get; set; }
        public string? EmpresaPacientes { get; set; }
        public string? SeguroSaludPacientesC { get; set; }

        // Relación con citas (si es necesario)
     

        // Constructor que inicializa la fecha de creación con la fecha actual
        public Paciente()
        {
          
            FechaModificacionPacientes = DateTime.Today;
            UsuarioCreacionPacientes = "Admin";
         
            ActivoPacientes = 1;
        }

    }


}
