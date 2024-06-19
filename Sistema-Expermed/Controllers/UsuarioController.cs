using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Sistema_Expermed.Datos;
using Sistema_Expermed.Models;
using System.Data;


namespace Sistema_Expermed.Controllers
{
    public class UsuarioController:Controller
    {

        UsuarioDatos _UsuarioDatos = new UsuarioDatos();

        //INICIO LISTAR
        public IActionResult Listar()
        {
            //lista de Usuarios
            var oLista = _UsuarioDatos.Listar();


            return View(oLista);
        }
        //FIN LISTAR

        //INICIO GUARDAR
        public IActionResult Guardar()
        {
            var perfiles = _UsuarioDatos.ObtenerPerfiles();
            ViewData["Perfiles"] = perfiles;

            return View();
        }


        [HttpPost]
        public IActionResult Guardar(Usuario gUsuario)
        {
            //guardar usuario

            if (!ModelState.IsValid) //Valida si esta vacio el campo
                return View();

            var respuesta = _UsuarioDatos.Guardar(gUsuario);


            if (respuesta)
                return RedirectToAction("Listar");
            else

                return View();
        }

        //FIN GUARDAR

        //INICIO EDITAR
        public IActionResult Editar(int IdUsuario)
        {
            //devuelve vista html

            var eUsuario = _UsuarioDatos.Obtener(IdUsuario);
            return View(eUsuario);

         }


        [HttpPost]
        public IActionResult Editar(Usuario edUsuario)
        {
            //guardar usuario

            if (!ModelState.IsValid) //Valida si esta vacio el campo
                return View();

            var respuesta = _UsuarioDatos.Editar(edUsuario);


            if (respuesta)
                return RedirectToAction("Listar");
            else

                return View();
        }
        //FIN EDITAR


        //INICIO ELIMINAR
        public IActionResult Eliminar(int IdUsuario)
        {
            //devuelve vista html

            var eUsuario = _UsuarioDatos.Obtener(IdUsuario);
            return View(eUsuario);

        }


        [HttpPost]
        public IActionResult Eliminar(Usuario eUsuario)
        {
            //guardar usuario

         
            var respuesta = _UsuarioDatos.Eliminar(eUsuario.IdUsuario);


            if (respuesta)
                return RedirectToAction("Listar");
            else

                return View();
        }
        //FIN ELIMINAR




        // GET: Usuario/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Usuario/Login
        [HttpPost]
        public IActionResult Login(Usuario loginRequest)
        {
           

            int perfilUsuario;
            var isValid = _UsuarioDatos.ValidarCredenciales(loginRequest.LoginUsuario, loginRequest.ClaveUsuario, out perfilUsuario);

            if (!isValid || perfilUsuario == 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }

            // Guardar el perfil del usuario en la sesión
            HttpContext.Session.SetInt32("PerfilUsuario", perfilUsuario);
            // Si las credenciales son válidas, redirigir a una acción adecuada
            return RedirectToAction("Index", "Home");
        }


    }
}
