using Sistema_Expermed.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Sistema_Expermed.Datos
{
    public class PacienteDatos
    {

        public List<Paciente> Listar()
        {
            var oLista = new List<Paciente>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("SP_LISTAR_PACIENTES", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var paciente = new Paciente();

                        paciente.IdPacientes = Convert.ToInt32(dr["id_pacientes"]);

                        // Manejo de fechas
                        if (!(dr["fechacreacion_pacientes"] is DBNull))
                            paciente.FechaCreacionPacientes = Convert.ToDateTime(dr["fechacreacion_pacientes"]);

                        paciente.UsuarioCreacionPacientes = dr["usuariocreacion_pacientes"].ToString();

                        // Manejo de fechas
                        if (!(dr["fechamodificacion_pacientes"] is DBNull))
                            paciente.FechaModificacionPacientes = Convert.ToDateTime(dr["fechamodificacion_pacientes"]);

                        paciente.UsuarioModificacionPacientes = dr["usuariomodificacion_pacientes"].ToString();
                        paciente.ActivoPacientes = dr["activo_pacientes"] != DBNull.Value ? Convert.ToInt32(dr["activo_pacientes"]) : 0;
                        paciente.TipoDocumentoPacientesC = Convert.ToInt32(dr["tipodocumento_pacientes_c"]);
                        paciente.CiPacientes = Convert.ToInt32(dr["ci_pacientes"]);
                        paciente.PrimerNombrePacientes = dr["primernombre_pacientes"].ToString();
                        paciente.SegundoNombrePacientes = dr["segundonombre_pacientes"].ToString();
                        paciente.PrimerApellidoPacientes = dr["primerapellido_pacientes"].ToString();
                        paciente.SegundoApellidoPacientes = dr["segundoapellido_pacientes"].ToString();
                        paciente.SexoPacientesC = Convert.ToInt32(dr["sexo_pacientes_c"]);

                        // Manejo de fechas
                        if (!(dr["fechanacimiento_pacientes"] is DBNull))
                            paciente.FechaNacimientoPacientes = Convert.ToDateTime(dr["fechanacimiento_pacientes"]);

                        paciente.Edad = Convert.ToInt32(dr["edad"]);
                        paciente.TipoSangrePacientesC = Convert.ToInt32(dr["tiposangre_pacientes_c"]);
                        paciente.DonantePacientes = dr["donante_pacientes"].ToString();
                        paciente.EstadoCivilPacientesC = Convert.ToInt32(dr["estadocivil_pacientes_c"]);
                        paciente.FormacionProfesionalPacientesC = Convert.ToInt32(dr["formacionprofesional_pacientes_c"]);
                        paciente.TelefonoFijoPacientes = Convert.ToInt32(dr["telefonofijo_pacientes"]);
                        paciente.TelefonoCelularPacientes = Convert.ToInt32(dr["telefonocelular_pacientes"]);
                        paciente.EmailPacientes = dr["email_pacientes"].ToString();
                        paciente.NacionalidadPacientesL = Convert.ToInt32(dr["nacionalidad_pacientes_l"]);
                        paciente.ProvinciaPacientesL = Convert.ToInt32(dr["provincia_pacientes_l"]);
                        paciente.DireccionPacientes = dr["direccion_pacientes"].ToString();
                        paciente.OcupacionPacientes = dr["ocupacion_pacientes"].ToString();
                        paciente.EmpresaPacientes = dr["empresa_pacientes"].ToString();
                        paciente.SeguroSaludPacientesC = dr["segurosalud_pacientes_c"].ToString();

                        oLista.Add(paciente);
                    }
                }
            }

            return oLista;
        }





        public Paciente Obtener(int idPaciente)
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


        public bool Guardar(Paciente gpaciente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SP_INSERTAR_PACIENTES", conexion);

                    cmd.Parameters.AddWithValue("@fechacreacion_pacientes", DateTime.Today);
                    cmd.Parameters.AddWithValue("@usuariocreacion_pacientes", gpaciente.UsuarioCreacionPacientes);
                    cmd.Parameters.AddWithValue("@activo_pacientes", gpaciente.ActivoPacientes);
                    cmd.Parameters.AddWithValue("@tipodocumento_pacientes_c", gpaciente.TipoDocumentoPacientesC);
                    cmd.Parameters.AddWithValue("@ci_pacientes", gpaciente.CiPacientes);
                    cmd.Parameters.AddWithValue("@primernombre_pacientes", gpaciente.PrimerNombrePacientes);
                    cmd.Parameters.AddWithValue("@segundonombre_pacientes", gpaciente.SegundoNombrePacientes);
                    cmd.Parameters.AddWithValue("@primerapellido_pacientes", gpaciente.PrimerApellidoPacientes);
                    cmd.Parameters.AddWithValue("@segundoapellido_pacientes", gpaciente.SegundoApellidoPacientes);
                    cmd.Parameters.AddWithValue("@sexo_pacientes_c", gpaciente.SexoPacientesC);
                    cmd.Parameters.AddWithValue("@fechanacimiento_pacientes", gpaciente.FechaNacimientoPacientes);
                    cmd.Parameters.AddWithValue("@edad", gpaciente.Edad);
                    cmd.Parameters.AddWithValue("@tiposangre_pacientes_c", gpaciente.TipoSangrePacientesC);
                    cmd.Parameters.AddWithValue("@donante_pacientes", gpaciente.DonantePacientes);
                    cmd.Parameters.AddWithValue("@estadocivil_pacientes_c", gpaciente.EstadoCivilPacientesC);
                    cmd.Parameters.AddWithValue("@formacionprofesional_pacientes_c", gpaciente.FormacionProfesionalPacientesC);
                    cmd.Parameters.AddWithValue("@telefonofijo_pacientes", gpaciente.TelefonoFijoPacientes);
                    cmd.Parameters.AddWithValue("@telefonocelular_pacientes", gpaciente.TelefonoCelularPacientes);
                    cmd.Parameters.AddWithValue("@email_pacientes", gpaciente.EmailPacientes);
                    cmd.Parameters.AddWithValue("@nacionalidad_pacientes_l", gpaciente.NacionalidadPacientesL);
                    cmd.Parameters.AddWithValue("@provincia_pacientes_l", gpaciente.ProvinciaPacientesL);
                    cmd.Parameters.AddWithValue("@direccion_pacientes", gpaciente.DireccionPacientes);
                    cmd.Parameters.AddWithValue("@ocupacion_pacientes", gpaciente.OcupacionPacientes);
                    cmd.Parameters.AddWithValue("@empresa_pacientes", gpaciente.EmpresaPacientes);
                    cmd.Parameters.AddWithValue("@segurosalud_pacientes_c", gpaciente.SeguroSaludPacientesC);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }

            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }

            return rpta;


        }


        public bool Editar(Paciente opaciente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SP_EDITAR_PACIENTES", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPacientes", opaciente.IdPacientes);
                    cmd.Parameters.AddWithValue("@FechaCreacionPacientes", opaciente.FechaCreacionPacientes); // Adding the missing parameter
                    cmd.Parameters.AddWithValue("@UsuarioCreacionPacientes", opaciente.UsuarioCreacionPacientes);
                    cmd.Parameters.AddWithValue("@FechaModificacionPacientes", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UsuarioModificacionPacientes", opaciente.UsuarioModificacionPacientes);
                    cmd.Parameters.AddWithValue("@ActivoPacientes", opaciente.ActivoPacientes);
                    cmd.Parameters.AddWithValue("@TipoDocumentoPacientesC", opaciente.TipoDocumentoPacientesC);
                    cmd.Parameters.AddWithValue("@CiPacientes", opaciente.CiPacientes);
                    cmd.Parameters.AddWithValue("@PrimerNombrePacientes", opaciente.PrimerNombrePacientes);
                    cmd.Parameters.AddWithValue("@SegundoNombrePacientes", opaciente.SegundoNombrePacientes);
                    cmd.Parameters.AddWithValue("@PrimerApellidoPacientes", opaciente.PrimerApellidoPacientes);
                    cmd.Parameters.AddWithValue("@SegundoApellidoPacientes", opaciente.SegundoApellidoPacientes);
                    cmd.Parameters.AddWithValue("@SexoPacientesC", opaciente.SexoPacientesC);
                    cmd.Parameters.AddWithValue("@FechaNacimientoPacientes", opaciente.FechaNacimientoPacientes);
                    cmd.Parameters.AddWithValue("@Edad", opaciente.Edad);
                    cmd.Parameters.AddWithValue("@TipoSangrePacientesC", opaciente.TipoSangrePacientesC);
                    cmd.Parameters.AddWithValue("@DonantePacientes", opaciente.DonantePacientes);
                    cmd.Parameters.AddWithValue("@EstadoCivilPacientesC", opaciente.EstadoCivilPacientesC);
                    cmd.Parameters.AddWithValue("@FormacionProfesionalPacientesC", opaciente.FormacionProfesionalPacientesC);
                    cmd.Parameters.AddWithValue("@TelefonoFijoPacientes", opaciente.TelefonoFijoPacientes);
                    cmd.Parameters.AddWithValue("@TelefonoCelularPacientes", opaciente.TelefonoCelularPacientes);
                    cmd.Parameters.AddWithValue("@EmailPacientes", opaciente.EmailPacientes);
                    cmd.Parameters.AddWithValue("@NacionalidadPacientesL", opaciente.NacionalidadPacientesL);
                    cmd.Parameters.AddWithValue("@ProvinciaPacientesL", opaciente.ProvinciaPacientesL);
                    cmd.Parameters.AddWithValue("@DireccionPacientes", opaciente.DireccionPacientes);
                    cmd.Parameters.AddWithValue("@OcupacionPacientes", opaciente.OcupacionPacientes);
                    cmd.Parameters.AddWithValue("@EmpresaPacientes", opaciente.EmpresaPacientes);
                    cmd.Parameters.AddWithValue("@SeguroSaludPacientesC", opaciente.SeguroSaludPacientesC);

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }


        public bool Eliminar(int idPaciente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR_PACIENTES", conexion);

                    cmd.Parameters.AddWithValue("id_pacientes", idPaciente);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }

            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }

            return rpta;


        }


        public List<Localidad> ObtenerNacionalidad()
        {
            var nacionalidad = new List<Localidad>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                using (var cmd = new SqlCommand("SP_LISTAR_LOCALIDAD", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var localidad = new Localidad
                            {
                                IdLocalidad = Convert.ToInt32(dr["id_localidad"]),
                                GentilicioLocalidad = dr["gentilicio_localidad"].ToString()
                            };
                            nacionalidad.Add(localidad);
                        }
                    }
                }
            }

            return nacionalidad;
        }

        public List<Catalogo> ObtenerCatalogo(string categoria)
        {
            var catalogo = new List<Catalogo>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                using (var cmd = new SqlCommand("SP_LISTAR_CATALOGO", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Pasamos el parámetro de categoría al stored procedure
                    cmd.Parameters.AddWithValue("@Categoria", categoria);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var item = new Catalogo
                            {
                                IdCatalogo = Convert.ToInt32(dr["id_catalogo"]),
                                Descripcion = dr["descripcion_catalogo"].ToString()
                            };
                            catalogo.Add(item);
                        }
                    }
                }
            }

            return catalogo;
        }




    }
}
