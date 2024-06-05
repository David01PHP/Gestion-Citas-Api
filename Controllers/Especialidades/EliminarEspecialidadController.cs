using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Models;
using GestionDeCitas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionDeCitas.Controllers.Especialidades
{
    
    public class EliminarEspecialidadController : Controller
    {
          private readonly IEspecialidadRepository _EspecialidadRepository;

        public EliminarEspecialidadController(IEspecialidadRepository especialidadRepository)
        {
            _EspecialidadRepository = especialidadRepository;
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult Post(int id,string estado)
        {

            
            var EspecialidadExistente = _EspecialidadRepository.GetIdSpecialty(id);

            if (EspecialidadExistente == null)
            {
                return NotFound("Paciente no encontrado.");
            }


            EspecialidadExistente.Estado = estado;

            
                try
                {
                _EspecialidadRepository.UpdateSpecialty(EspecialidadExistente);
                return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar el Especialidad con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(500, new { message = "Ocurrió un error al actualizar el Especialidad.", details = ex.Message });
                }
        }
    }
}