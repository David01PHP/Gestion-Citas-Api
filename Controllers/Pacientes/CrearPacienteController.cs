using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Models;
using GestionDeCitas.Services.Pacientes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionDeCitas.Controllers.Pacientes
{
    
    public class CrearPacienteController : Controller
    {
       private readonly IPacienteRepository _pacienteRepository;

        public CrearPacienteController(IPacienteRepository pacientesRepository)
        {
            _pacienteRepository = pacientesRepository;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult PostPatient([FromBody] Paciente paciente)
        {
            _pacienteRepository.CreatePatient(paciente);
            return Ok();
        }
    }
}