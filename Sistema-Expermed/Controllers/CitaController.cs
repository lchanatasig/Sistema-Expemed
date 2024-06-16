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
        //INICIO LISTAR
        public IActionResult Listar()
        {
            //lista de Usuarios
            var oLista = _CitaDatos.Listar();


            return View(oLista);
        }
        //FIN LISTAR

        //INICIO GUARDAR
        public IActionResult Guardar()
        {
            //devuelve vista html
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Cita gCita)
        {
            //guardar usuario

            //if (!ModelState.IsValid) //Valida si esta vacio el campo
            //    return View();

            var respuesta = _CitaDatos.Guardar(gCita);


            if (respuesta)
                return RedirectToAction("Listar");
            else

                return View();
        }

        //FIN GUARDAR

        //INICIO EDITAR
        public IActionResult Editar(int IdCita)
        {
            //devuelve vista html

            var eCita = _CitaDatos.Obtener(IdCita);
            return View(eCita);

        }


        [HttpPost]
        public IActionResult Editar(Cita edCita)
        {
            //guardar usuario

            if (!ModelState.IsValid) //Valida si esta vacio el campo
                return View();

            var respuesta = _CitaDatos.Editar(edCita);


            if (respuesta)
                return RedirectToAction("Listar");
            else

                return View();
        }
        //FIN EDITAR


        //INICIO ELIMINAR
        public IActionResult Eliminar(int IdCitas)
        {
            //devuelve vista html

            var eCita = _CitaDatos.Obtener(IdCitas);
            return View(eCita);

        }
        
        

        [HttpPost]
        public IActionResult Eliminar(Cita eCita)
        {
            //guardar usuario


            var respuesta = _CitaDatos.Eliminar(eCita.IdCitas);


            if (respuesta)
                return RedirectToAction("Listar");
            else

                return View();
        }
        //FIN ELIMINAR
    }
}
