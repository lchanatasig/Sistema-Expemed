using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Acceso()
        {
            //lista de Usuarios
           

            return View();
        }
        [HttpPost]
        public ActionResult Acceso(string loginUsuario, string clave)
        {
            string perfilUsuario = new UsuarioDatos().ValidarCredenciales(loginUsuario, clave);

            if (perfilUsuario != "0")
            {
                // Login successful, redirect to dashboard or profile page
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                // Login failed, display error message
                ViewBag.ErrorMessage = "Invalid username or password";
                return View("Login");
            }
        }




    }
}
