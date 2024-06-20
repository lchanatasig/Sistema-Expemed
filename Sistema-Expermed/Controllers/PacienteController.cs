using Microsoft.AspNetCore.Mvc;
using Sistema_Expermed.Datos;
using Sistema_Expermed.Models;

namespace Sistema_Expermed.Controllers
{
    public class PacienteController : Controller
    {
        PacienteDatos _PacienteDatos = new PacienteDatos();


        //INICIO LISTAR
        public IActionResult Listar()
        {
            //lista de Usuarios
            var oLista = _PacienteDatos.Listar();
            var nacionalidad = _PacienteDatos.ObtenerNacionalidad();
            ViewData["Nacionalidades"] = nacionalidad;


            return View(oLista);
        }
        //FIN LISTAR

        //INICIO GUARDAR
        public IActionResult Guardar()
        {
            var nacionalidad = _PacienteDatos.ObtenerNacionalidad();
            ViewData["Nacionalidades"] = nacionalidad;
            //devuelve vista html
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Paciente gPaciente)
        {
            //guardar usuario

            //if (!ModelState.IsValid) //Valida si esta vacio el campo
            //    return View();

            var respuesta = _PacienteDatos.Guardar(gPaciente);


            if (respuesta)
                return RedirectToAction("Listar");
            else

                return View();
        }

        //FIN GUARDAR

        // INICIO EDITAR
        public IActionResult Editar(int IdPaciente)
        {
            var ePaciente = _PacienteDatos.Obtener(IdPaciente);
            return View(ePaciente);
        }

        [HttpPost]
        public IActionResult Editar(Paciente ePaciente)
        {
            // Validar si el modelo es válido (opcional, dependiendo de tus necesidades)
            if (!ModelState.IsValid)
            {
                return View(ePaciente);
            }

            // Obtener UsuarioModificacion de la sesión
            string usuarioModificacion = HttpContext.Session.GetString("UsuarioModificacion");

            if (string.IsNullOrEmpty(usuarioModificacion))
            {
                ModelState.AddModelError(string.Empty, "No se pudo obtener el usuario de modificación de la sesión.");
                return View(ePaciente);
            }

            // Asignar UsuarioModificacion al objeto ePaciente
            ePaciente.UsuarioModificacionPacientes = usuarioModificacion;

            // Llamar al método para editar en los datos
            var respuesta = _PacienteDatos.Editar(ePaciente);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(ePaciente);
            }
        }
        // FIN EDITAR


        //INICIO ELIMINAR
        public IActionResult Eliminar(int IdPaciente)
        {
            //devuelve vista html

            var ePaciente = _PacienteDatos.Obtener(IdPaciente);
            return View(ePaciente);

        }


        [HttpPost]
        public IActionResult Eliminar(Paciente ePaciente)
        {
            //guardar usuario


            var respuesta = _PacienteDatos.Eliminar(ePaciente.IdPacientes);


            if (respuesta)
                return RedirectToAction("Listar");
            else

                return View();
        }
        //FIN ELIMINAR
    }
}
