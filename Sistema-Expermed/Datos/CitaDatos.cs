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

            var oLista = new List<Cita>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("SP_LISTAR_CITAS", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {


                    while (dr.Read())
                    {
                        var cita = new Cita();




                        cita.IdCitas = Convert.ToInt32(dr["id_citas"]);
                        cita.FechacreacionCitas = Convert.ToDateTime(dr["fechacreacion_citas"]);
                        cita.UsuarioCreacionCitas = dr["usuariocreacion_citas"].ToString();
                        cita.FechadelacitaCitas = Convert.ToDateTime(dr["fechadelacita_citas"]);
                        cita.MedicoCitasU = Convert.ToInt32(dr["medico_citas_u"]);
                        cita.PacienteCitasP = Convert.ToInt32(dr["paciente_citas_p"]);
                        cita.ConsultaCitasCo = Convert.ToInt32(dr["consulta_citas_co"]);
                        cita.TipoconsultaCitasCa = Convert.ToInt32(dr["tipoconsulta_citas_ca"]);
                        cita.EspecialidadCitasCa = Convert.ToInt32(dr["especialidad_citas_ca"]);
                        oLista.Add(cita);

                    }
                }

            }

            return oLista;
        }


        public Cita Obtener(int idCita)
        {

            var oCita = new Cita();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("SP_OBTENER_CITAS", conexion);

                cmd.Parameters.AddWithValue("id_citas", idCita);
                cmd.CommandType = CommandType.StoredProcedure;

                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    oCita.IdCitas = Convert.ToInt32(dr["id_citas"]);
                    oCita.FechacreacionCitas = Convert.ToDateTime(dr["fechacreacion_citas"]);

                    // Manejo de fechas
                    if (!(dr["usuariocreacion_citas"] is DBNull))
                    {
                        oCita.UsuarioCreacionCitas = dr["usuariocreacion_citas"].ToString();
                    }

                    oCita.FechadelacitaCitas = Convert.ToDateTime(dr["fechadelacita_citas"]);
                    oCita.MedicoCitasU = Convert.ToInt32(dr["medico_citas_u"]);
                    oCita.PacienteCitasP = Convert.ToInt32(dr["paciente_citas_p"]);
                    oCita.ConsultaCitasCo = Convert.ToInt32(dr["consulta_citas_co"]);
                    oCita.TipoconsultaCitasCa = Convert.ToInt32(dr["tipoconsulta_citas_ca"]);
                    oCita.EspecialidadCitasCa = Convert.ToInt32(dr["especialidad_citas_ca"]);
                }

            }

            return oCita;
        }






        public bool Guardar(Cita gcita)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SP_INSERTAR_CITA", conexion);

                    cmd.Parameters.AddWithValue("@fechacreacion_citas", gcita.FechacreacionCitas);
                    cmd.Parameters.AddWithValue("@usuariocreacion_citas", gcita.UsuarioCreacionCitas);
                    cmd.Parameters.AddWithValue("@fechadelacita_citas", gcita.FechadelacitaCitas);
                    cmd.Parameters.AddWithValue("@medico_citas_u", gcita.MedicoCitasU);
                    cmd.Parameters.AddWithValue("@paciente_citas_p", gcita.PacienteCitasP);
                    cmd.Parameters.AddWithValue("@consulta_citas_co", gcita.ConsultaCitasCo);
                    cmd.Parameters.AddWithValue("@tipoconsulta_citas_ca", gcita.TipoconsultaCitasCa);
                    cmd.Parameters.AddWithValue("@especialidad_citas_ca", gcita.EspecialidadCitasCa);
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


        public bool Editar(Cita ecita)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SP_EDITAR_CITA", conexion);


                    cmd.Parameters.AddWithValue("@fechacreacion_citas", ecita.FechacreacionCitas);
                    cmd.Parameters.AddWithValue("@usuariocreacion_citas", ecita.UsuarioCreacionCitas);
                    cmd.Parameters.AddWithValue("@fechadelacita_citas", ecita.FechadelacitaCitas);
                    cmd.Parameters.AddWithValue("@medico_citas_u", ecita.MedicoCitasU);
                    cmd.Parameters.AddWithValue("@paciente_citas_p", ecita.PacienteCitasP);
                    cmd.Parameters.AddWithValue("@consulta_citas_co", ecita.ConsultaCitasCo);
                    cmd.Parameters.AddWithValue("@tipoconsulta_citas_ca", ecita.TipoconsultaCitasCa);
                    cmd.Parameters.AddWithValue("@especialidad_citas_ca", ecita.EspecialidadCitasCa);
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


        public bool Eliminar(int idCita)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR_CITA", conexion);

                    cmd.Parameters.AddWithValue("id_citas", idCita);

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

    }
}
