using Sistema_Expermed.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Sistema_Expermed.Datos


{
    public class UsuarioDatos
    {

        public List<Usuario> Listar()
        {

            var oLista = new List<Usuario>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("SP_LISTAR_USUARIOS", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {


                    while (dr.Read())
                    {
                        var usuario = new Usuario();




                        usuario.IdUsuario = Convert.ToInt32(dr["id_usuario"]);
                        usuario.CiUsuario = Convert.ToInt32(dr["ci_usuario"]);
                        usuario.NombresUsuario = dr["nombres_usuario"].ToString();
                        usuario.ApellidosUsuario = dr["apellidos_usuario"].ToString();
                        usuario.TelefonoUsuario = dr["telefono_usuario"].ToString();
                        usuario.EmailUsuario = dr["email_usuario"].ToString();
                        usuario.EstablecimientoUsuario = dr["establecimiento_usuario"].ToString();
                        usuario.direcccionestable_usuario = dr["direcccionestable_usuario"].ToString();
                        usuario.FechacreacionUsuario = Convert.ToDateTime(dr["fechacreacion_usuario"]);

                        if (!(dr["fechamodificacion_usuario"] is DBNull))
                            usuario.FechamodificacionUsuario = Convert.ToDateTime(dr["fechamodificacion_usuario"]);
                        usuario.LoginUsuario = dr["login_usuario"].ToString();
                        usuario.ClaveUsuario = dr["clave_usuario"].ToString();
                        usuario.ActivoUsuario = Convert.ToInt32(dr["activo_usuario"]);
                        usuario.PerfilUsuarioP = Convert.ToInt32(dr["perfil_usuario_p"]);
                        usuario.CodigoUsuario = dr["codigo_usuario"].ToString();

                        oLista.Add(usuario);

                    }
                }

            }

            return oLista;
        }



        public Usuario Obtener(int idUsuario)
        {

            var oUsuario = new Usuario();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("SP_OBTENER_USUARIOS", conexion);

                cmd.Parameters.AddWithValue("id_usuario", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oUsuario.IdUsuario = Convert.ToInt32(dr["id_usuario"]);
                        oUsuario.CiUsuario = Convert.ToInt32(dr["ci_usuario"]);
                        oUsuario.NombresUsuario = dr["nombres_usuario"].ToString();
                        oUsuario.ApellidosUsuario = dr["apellidos_usuario"].ToString();
                        oUsuario.TelefonoUsuario = dr["telefono_usuario"].ToString();
                        oUsuario.EmailUsuario = dr["email_usuario"].ToString();
                        oUsuario.EstablecimientoUsuario = dr["establecimiento_usuario"].ToString();
                        oUsuario.direcccionestable_usuario = dr["direcccionestable_usuario"].ToString();
                        oUsuario.ciudad_usuario = dr["ciudad_usuario"].ToString();
                        oUsuario.provincia_usuario = dr["provincia_usuario"].ToString();
                        oUsuario.FechacreacionUsuario = Convert.ToDateTime(dr["fechacreacion_usuario"]);
                        

                        oUsuario.IdUsuario = Convert.ToInt32(dr["id_usuario"]);
                        if (dr["fechamodificacion_usuario"] != DBNull.Value)
                        {
                            oUsuario.FechamodificacionUsuario = Convert.ToDateTime(dr["fechamodificacion_usuario"]);
                        }
                        else
                        {
                            // Decide qué hacer cuando el valor es DBNull
                            // En este ejemplo, asignamos un valor predeterminado o dejamos la fecha como DateTime.MinValue
                            oUsuario.FechamodificacionUsuario = DateTime.MinValue; // O cualquier otro valor predeterminado que desees usar
                        }

                        oUsuario.LoginUsuario = dr["login_usuario"].ToString();
                        oUsuario.ClaveUsuario = dr["clave_usuario"].ToString();
                        oUsuario.ActivoUsuario = Convert.ToInt32(dr["activo_usuario"]);
                        oUsuario.PerfilUsuarioP = Convert.ToInt32(dr["perfil_usuario_p"]);
                        oUsuario.descripcionperfil_usuario = dr["descripcionperfil_usuario"].ToString();
                        oUsuario.CodigoUsuario = dr["codigo_usuario"].ToString();
                    }
                }

            }

            return oUsuario;
        }



        public bool Guardar(Usuario gusuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("INSERTAR_USUARIO", conexion);

                    cmd.Parameters.AddWithValue("@ci_usuario", gusuario.CiUsuario);
                    cmd.Parameters.AddWithValue("@nombres_usuario", gusuario.NombresUsuario);
                    cmd.Parameters.AddWithValue("@apellidos_usuario", gusuario.ApellidosUsuario);
                    cmd.Parameters.AddWithValue("@telefono_usuario", gusuario.TelefonoUsuario);
                    cmd.Parameters.AddWithValue("@email_usuario", gusuario.EmailUsuario);
                    cmd.Parameters.AddWithValue("@establecimiento_usuario", gusuario.EstablecimientoUsuario);
                    cmd.Parameters.AddWithValue("@direcccionestable_usuario", gusuario.direcccionestable_usuario);
                    cmd.Parameters.AddWithValue("@ciudad_usuario", gusuario.ciudad_usuario);
                    cmd.Parameters.AddWithValue("@provincia_usuario", gusuario.provincia_usuario);
                    cmd.Parameters.AddWithValue("@fechacreacion_usuario",DateTime.Now);

                    cmd.Parameters.AddWithValue("@login_usuario", gusuario.LoginUsuario);
                    cmd.Parameters.AddWithValue("@clave_usuario", gusuario.ClaveUsuario);
                    cmd.Parameters.AddWithValue("@activo_usuario", gusuario.ActivoUsuario);
                    cmd.Parameters.AddWithValue("@perfil_usuario_p", gusuario.PerfilUsuarioP);
                    cmd.Parameters.AddWithValue("@descripcionperfil_usuario", gusuario.descripcionperfil_usuario);
                    cmd.Parameters.AddWithValue("@codigo_usuario", gusuario.CodigoUsuario);
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



        public bool Editar(Usuario eusuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("EDITAR_USUARIO", conexion);


                    cmd.Parameters.AddWithValue("@ci_usuario", eusuario.CiUsuario);
                    cmd.Parameters.AddWithValue("@nombres_usuario", eusuario.NombresUsuario);
                    cmd.Parameters.AddWithValue("@apellidos_usuario", eusuario.ApellidosUsuario);
                    cmd.Parameters.AddWithValue("@telefono_usuario", eusuario.TelefonoUsuario);
                    cmd.Parameters.AddWithValue("@email_usuario", eusuario.EmailUsuario);
                    cmd.Parameters.AddWithValue("@establecimiento_usuario", eusuario.EstablecimientoUsuario);
                    cmd.Parameters.AddWithValue("@direcccionestable_usuario", eusuario.direcccionestable_usuario);
                    cmd.Parameters.AddWithValue("@ciudad_usuario", eusuario.ciudad_usuario);
                    cmd.Parameters.AddWithValue("@provincia_usuario", eusuario.provincia_usuario);
                    cmd.Parameters.AddWithValue("@fechacreacion_usuario", eusuario.FechacreacionUsuario);
                    cmd.Parameters.AddWithValue("@fechamodificacion_usuario", eusuario.FechamodificacionUsuario);
                    cmd.Parameters.AddWithValue("@login_usuario", eusuario.LoginUsuario);
                    cmd.Parameters.AddWithValue("@clave_usuario", eusuario.ClaveUsuario);
                    cmd.Parameters.AddWithValue("@activo_usuario", eusuario.ActivoUsuario);
                    cmd.Parameters.AddWithValue("@perfil_usuario_p", eusuario.PerfilUsuarioP);
                    cmd.Parameters.AddWithValue("@descripcionperfil_usuario", eusuario.descripcionperfil_usuario);
                    cmd.Parameters.AddWithValue("@codigo_usuario", eusuario.CodigoUsuario);
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


        public bool Eliminar(int idusuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR_USUARIOS", conexion);

                    cmd.Parameters.AddWithValue("id_usuario", idusuario);

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

        public List<Perfil> ObtenerPerfiles()
        {
            var perfiles = new List<Perfil>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                using (var cmd = new SqlCommand("SP_LISTAR_PERFILES", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var perfil = new Perfil
                            {
                                IdPerfil = Convert.ToInt32(dr["id_perfil"]),
                                DescripcionPerfil = dr["descripcion_perfil"].ToString()
                            };
                            perfiles.Add(perfil);
                        }
                    }
                }
            }

            return perfiles;
        }



    }
}
