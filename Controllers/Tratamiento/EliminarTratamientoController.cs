using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Models;
using GestionDeCitas.Services.Tratamientos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionDeCitas.Controllers
{
    
    public class EliminarTratamientoController : Controller
    {
         private readonly ITratamientoRepository _tratamientoRepository;

        public EliminarTratamientoController(ITratamientoRepository tratamientoRepository)
        {
            _tratamientoRepository = tratamientoRepository;
        }
        [HttpPatch]
        [Route("api/[controller]/{Id}")]
        public IActionResult DeleteTreatment(int id,string estado)
        {
           
            return Ok();
            var TratamientoExistente = _tratamientoRepository.GetIdTreatment(id);

            if (TratamientoExistente == null)
            {
                return NotFound("Paciente no encontrado.");
            }


            TratamientoExistente.Estado = estado;

            
                try
                {
                _tratamientoRepository.UpdateTreatment(TratamientoExistente);
                return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar el Tratamiento con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(500, new { message = "Ocurrió un error al actualizar el PaTratamiento.", details = ex.Message });
                }
        }
    }
}