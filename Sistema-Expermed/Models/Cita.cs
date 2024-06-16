namespace Sistema_Expermed.Models
{
    public class Cita
    {
        public int IdCitas { get; set; }
        public DateTime FechacreacionCitas { get; set; }
        public string? UsuarioCreacionCitas { get; set; }
        public DateTime FechadelacitaCitas { get; set; }
        public int MedicoCitasU { get; set; }
        public int PacienteCitasP { get; set; }
        public int ConsultaCitasCo { get; set; }
        public int TipoconsultaCitasCa { get; set; }
        public int EspecialidadCitasCa { get; set; }

        public Cita()
        {
            FechacreacionCitas = DateTime.Today;

           
        }

    }
}
