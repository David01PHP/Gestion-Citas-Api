using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GestionDeCitas.Models;
using GestionDeCitas.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionDeCitas.Controllers
{
    public class ActualizarCitaController : Controller
    {
        private readonly ICitaRepository _citaRepository;

        public ActualizarCitaController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateAppointment(int id,[FromBody]Cita cita)
        {

              // Buscar el cupón en la base de datos
            var CitaExistente = _citaRepository.GetIdAppointment(id);

            if (CitaExistente == null)
            {
                return NotFound("Cita no encontrado.");
            }


            CitaExistente.Estado = CitaExistente.Estado;
            CitaExistente.MedicoId = CitaExistente.MedicoId;
            CitaExistente.PacienteId = CitaExistente.PacienteId;
            CitaExistente.Fecha = CitaExistente.Fecha;
            CitaExistente.Estado = CitaExistente.Estado;

            
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