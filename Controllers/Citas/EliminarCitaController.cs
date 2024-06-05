using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Models;
using GestionDeCitas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionDeCitas.Controllers.Citas
{
    
    public class EliminarCitaController : Controller
    {
        private readonly ICitaRepository _citaRepository;

        public EliminarCitaController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteAppointment(int id,string estado)
        {

              // Buscar el cupón en la base de datos
            var CitaExistente = _citaRepository.GetIdAppointment(id);

            if (CitaExistente == null)
            {
                return NotFound("Cita no encontrado.");
            }


            CitaExistente.Estado = estado;

            
                try
                {
                _citaRepository.UpdateAppointment(CitaExistente);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar el Cita con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(500, new { message = "Ocurrió un error al actualizar el Cita.", details = ex.Message });
                }
        }
    }
}