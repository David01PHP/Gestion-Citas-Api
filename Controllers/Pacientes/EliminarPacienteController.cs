
using GestionDeCitas.Models;
using GestionDeCitas.Services.Pacientes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionDeCitas.Controllers.Pacientes
{
    
    public class EliminarPacienteController : Controller
    {

        private readonly IPacienteRepository _pacienteRepository;

        public EliminarPacienteController(IPacienteRepository pacientesRepository)
        {
            _pacienteRepository = pacientesRepository;
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult DeletePatient(int id,string estado)
        {
            var PacienteExistente = _pacienteRepository.GetIdPatient(id);

            if (PacienteExistente == null)
            {
                return NotFound("Paciente no encontrado.");
            }


            PacienteExistente.Estado = estado;

            
                try
                {
                _pacienteRepository.UpdatePatient(PacienteExistente);
                return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar el Paciente con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(500, new { message = "Ocurrió un error al actualizar el Paciente.", details = ex.Message });
                }
        }
    }
}