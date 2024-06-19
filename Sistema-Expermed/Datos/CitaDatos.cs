using Microsoft.Data.SqlClient;
using Sistema_Expermed.Models;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_Expermed.Datos
{
    public class CitaDatos
    {
        public List<Cita> Listar()
        {
            List<Cita> citas = new List<Cita>();

            var cn = new Conexion();
            using (SqlConnection conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_LISTAR_CITAS", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            citas.Add(MapCita(dr));
                        }
                    }
                }
            }

            return citas;
        }

        public Cita Obtener(int idCita)
        {
            Cita cita = null;
            var cn = new Conexion();

            using (SqlConnection conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_OBTENER_CITAS", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_citas", idCita);
                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            cita = MapCita(dr);
                        }
                    }
                }
            }

            return cita;
        }

        public bool Guardar(Cita cita)
        {
            var cn = new Conexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_INSERTAR_CITA", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fechacreacion_citas", cita.FechacreacionCitas);
                        cmd.Parameters.AddWithValue("@usuariocreacion_citas", cita.UsuarioCreacionCitas);
                        cmd.Parameters.AddWithValue("@fechadelacita_citas", cita.FechadelacitaCitas);
                        cmd.Parameters.AddWithValue("@medico_citas_u", cita.MedicoCitasU);
                        cmd.Parameters.AddWithValue("@paciente_citas_p", cita.PacienteCitasP);
                        cmd.Parameters.AddWithValue("@consulta_citas_co", cita.ConsultaCitasCo);
                        cmd.Parameters.AddWithValue("@tipoconsulta_citas_ca", cita.TipoconsultaCitasCa);
                        cmd.Parameters.AddWithValue("@especialidad_citas_ca", cita.EspecialidadCitasCa);

                        conexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error al guardar la cita: {ex.Message}");
                return false;
            }
        }

        public bool Editar(Cita cita)
        {
            var cn = new Conexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_EDITAR_CITA", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_citas", cita.IdCitas);
                        cmd.Parameters.AddWithValue("@fechacreacion_citas", cita.FechacreacionCitas);
                        cmd.Parameters.AddWithValue("@usuariocreacion_citas", cita.UsuarioCreacionCitas);
                        cmd.Parameters.AddWithValue("@fechadelacita_citas", cita.FechadelacitaCitas);
                        cmd.Parameters.AddWithValue("@medico_citas_u", cita.MedicoCitasU);
                        cmd.Parameters.AddWithValue("@paciente_citas_p", cita.PacienteCitasP);
                        cmd.Parameters.AddWithValue("@consulta_citas_co", cita.ConsultaCitasCo);
                        cmd.Parameters.AddWithValue("@tipoconsulta_citas_ca", cita.TipoconsultaCitasCa);
                        cmd.Parameters.AddWithValue("@especialidad_citas_ca", cita.EspecialidadCitasCa);

                        conexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error al editar la cita: {ex.Message}");
                return false;
            }
        }

        public bool Eliminar(int idCita)
        {
            var cn = new Conexion();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ELIMINAR_CITA", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_citas", idCita);

                        conexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error al eliminar la cita: {ex.Message}");
                return false;
            }
        }
        public Paciente ObtenerP(int idPaciente)
        {

            var oPaciente = new Paciente();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("SP_OBTENER_PACIENTES", conexion);

                cmd.Parameters.AddWithValue("id_pacientes", idPaciente);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oPaciente.IdPacientes = Convert.ToInt32(dr["id_pacientes"]);
                        if (dr["fechacreacion_pacientes"] != DBNull.Value)
                        {
                            oPaciente.FechaCreacionPacientes = Convert.ToDateTime(dr["fechacreacion_pacientes"]);
                        }
                        else
                        {
                            // Decide qué hacer cuando el valor es DBNull
                            // En este ejemplo, asignamos un valor predeterminado o dejamos la fecha como DateTime.MinValue
                            oPaciente.FechaCreacionPacientes = DateTime.MinValue; // O cualquier otro valor predeterminado que desees usar
                        }
                        oPaciente.UsuarioCreacionPacientes = dr["usuariocreacion_pacientes"].ToString();
                        if (dr["fechamodificacion_pacientes"] != DBNull.Value)
                        {
                            oPaciente.FechaModificacionPacientes = Convert.ToDateTime(dr["fechamodificacion_pacientes"]);
                        }
                        else
                        {
                            // Lo mismo que los otros if/else
                            // En este ejemplo, asignamos un valor predeterminado o dejamos la fecha como DateTime.MinValue
                            oPaciente.FechaModificacionPacientes = DateTime.MinValue; // O cualquier otro valor predeterminado que desees usar
                        }
                        oPaciente.UsuarioModificacionPacientes = dr["usuariomodificacion_pacientes"].ToString();
                        if (dr["activo_pacientes"] != DBNull.Value)
                        {
                            oPaciente.ActivoPacientes = Convert.ToInt32(dr["activo_pacientes"]);
                        }
                        else
                        {
                            // Lo mismo que los otros if/else
                            // En este ejemplo, asignamos un valor predeterminado o dejamos el campo en 0 si no tiene sentido otro valor
                            oPaciente.ActivoPacientes = 0; // O cualquier otro valor predeterminado que desees usar
                        }
                        oPaciente.TipoDocumentoPacientesC = Convert.ToInt32(dr["tipodocumento_pacientes_c"]);
                        oPaciente.CiPacientes = Convert.ToInt32(dr["ci_pacientes"]);
                        oPaciente.PrimerNombrePacientes = dr["primernombre_pacientes"].ToString();
                        oPaciente.SegundoNombrePacientes = dr["segundonombre_pacientes"].ToString();
                        oPaciente.PrimerApellidoPacientes = dr["primerapellido_pacientes"].ToString();
                        oPaciente.SegundoApellidoPacientes = dr["segundoapellido_pacientes"].ToString();
                        oPaciente.SexoPacientesC = Convert.ToInt32(dr["sexo_pacientes_c"]);
                        oPaciente.FechaNacimientoPacientes = Convert.ToDateTime(dr["fechanacimiento_pacientes"]);
                        oPaciente.Edad = Convert.ToInt32(dr["edad"]);
                        oPaciente.TipoSangrePacientesC = Convert.ToInt32(dr["tiposangre_pacientes_c"]);
                        oPaciente.DonantePacientes = dr["donante_pacientes"].ToString();
                        oPaciente.EstadoCivilPacientesC = Convert.ToInt32(dr["estadocivil_pacientes_c"]);
                        oPaciente.FormacionProfesionalPacientesC = Convert.ToInt32(dr["formacionprofesional_pacientes_c"]);
                        oPaciente.TelefonoFijoPacientes = Convert.ToInt32(dr["telefonofijo_pacientes"]);
                        oPaciente.TelefonoCelularPacientes = Convert.ToInt32(dr["telefonocelular_pacientes"]);
                        oPaciente.EmailPacientes = dr["email_pacientes"].ToString();
                        oPaciente.NacionalidadPacientesL = Convert.ToInt32(dr["nacionalidad_pacientes_l"]);
                        oPaciente.ProvinciaPacientesL = Convert.ToInt32(dr["provincia_pacientes_l"]);
                        oPaciente.DireccionPacientes = dr["direccion_pacientes"].ToString();
                        oPaciente.OcupacionPacientes = dr["ocupacion_pacientes"].ToString();
                        oPaciente.EmpresaPacientes = dr["empresa_pacientes"].ToString();
                        oPaciente.SeguroSaludPacientesC = dr["segurosalud_pacientes_c"].ToString();

                    }
                }

            }

            return oPaciente;
        }



        private Cita MapCita(SqlDataReader dr)
        {
            return new Cita
            {
                IdCitas = Convert.ToInt32(dr["id_citas"]),
                FechacreacionCitas = Convert.ToDateTime(dr["fechacreacion_citas"]),
                UsuarioCreacionCitas = dr["usuariocreacion_citas"] is DBNull ? string.Empty : dr["usuariocreacion_citas"].ToString(),
                FechadelacitaCitas = Convert.ToDateTime(dr["fechadelacita_citas"]),
                MedicoCitasU = Convert.ToInt32(dr["medico_citas_u"]),
                PacienteCitasP = Convert.ToInt32(dr["paciente_citas_p"]),
                ConsultaCitasCo = Convert.ToInt32(dr["consulta_citas_co"]),
                TipoconsultaCitasCa = Convert.ToInt32(dr["tipoconsulta_citas_ca"]),
                EspecialidadCitasCa = Convert.ToInt32(dr["especialidad_citas_ca"])
            };
        }
    }
}
