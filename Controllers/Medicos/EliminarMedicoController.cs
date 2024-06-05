using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Models;
using GestionDeCitas.Services.Medicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionDeCitas.Controllers.Medicos
{
    
    public class EliminarMedicoController : Controller
    {
        private readonly IMedicoRepository _medicoRepository;

        public EliminarMedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteDoctor(int id,string estado)
        {
        
             var MedicoExistente = _medicoRepository.GetIdDoctor(id);

            if (MedicoExistente == null)
            {
                return NotFound("Paciente no encontrado.");
            }


            MedicoExistente.Estado = estado;

            
                try
                {
                _medicoRepository.UpdateDoctor(MedicoExistente);
                return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar el medico con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(500, new { message = "Ocurrió un error al actualizar el medico.", details = ex.Message });
                }
        }
    }
}