using Sistema_Expermed.Models;

namespace Sistema_Expermed.Models
{
    public class Cita
    {
        public int IdCitas { get; set; }
        public DateTime FechacreacionCitas { get; set; }
        public string UsuarioCreacionCitas { get; set; }
        public DateTime FechadelacitaCitas { get; set; }

        // Claves foráneas y propiedades de navegación
        public int MedicoCitasU { get; set; }

        public int PacienteCitasP { get; set; }
        public Paciente Paciente { get; set; } // Propiedad de navegación para el paciente

        public int ConsultaCitasCo { get; set; }


        public int TipoconsultaCitasCa { get; set; }

        public int EspecialidadCitasCa { get; set; }

        
public Cita()
{
    FechacreacionCitas = DateTime.Today;
    UsuarioCreacionCitas = "Admin";


}
    }

}