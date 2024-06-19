using Microsoft.AspNetCore.Mvc;
using Sistema_Expermed.Datos;
using Sistema_Expermed.Models;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_Expermed.Controllers
{
    public class CitaController : Controller
    {
        CitaDatos _CitaDatos = new CitaDatos();
        // INICIO LISTAR
        public IActionResult Listar()
        {
            var oLista = _CitaDatos.Listar();
            return View(oLista);
        }
        // FIN LISTAR

        // INICIO GUARDAR
        public IActionResult Guardar(int IdPacientes)
        {
          

            var cita = new Cita
            {
                PacienteCitasP = IdPacientes, // Asignar el id del paciente recibido al atributo de la cita
               
            };

            return View(cita); // Devolver la vista con el objeto de cita creado para que se pueda confirmar o modificar antes de guardar
        }

        [HttpPost]
        public IActionResult Guardar(Cita gCita)
        {
            if (!ModelState.IsValid)
            {
                return View(gCita);
            }

            // Aquí podrías cargar los detalles del paciente si es necesario
            var paciente = _CitaDatos.ObtenerP(gCita.PacienteCitasP); // Ejemplo: función hipotética para obtener detalles del paciente

            // Si necesitas realizar alguna validación adicional o cargar más detalles del paciente antes de guardar, hazlo aquí.

            var respuesta = _CitaDatos.Guardar(gCita);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(gCita);
            }
        }

        // FIN GUARDAR

        // INICIO EDITAR
        public IActionResult Editar(int IdCitas)
        {
            var eCita = _CitaDatos.Obtener(IdCitas);
            return View(eCita);
        }

        [HttpPost]
        public IActionResult Editar(Cita edCita)
        {
            if (!ModelState.IsValid)
            {
                return View(edCita);
            }

            var respuesta = _CitaDatos.Editar(edCita);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(edCita);
            }
        }
        // FIN EDITAR

        // INICIO ELIMINAR
        public IActionResult Eliminar(int IdCitas)
        {
            var eCita = _CitaDatos.Obtener(IdCitas);
            return View(eCita);
        }

        [HttpPost]
        public IActionResult Eliminar(Cita eCita)
        {
            var respuesta = _CitaDatos.Eliminar(eCita.IdCitas);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(eCita);
            }
        }
        // FIN ELIMINAR
    }
}
