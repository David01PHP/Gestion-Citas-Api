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
    
    public class CrearEspecialidadController : Controller
    {
        private readonly IEspecialidadRepository _especialidadRepository;

        public CrearEspecialidadController(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult PostSpecialty([FromBody] Especialidad paciente)
        {
            _especialidadRepository.CreateSpecialty(paciente);
            return Ok();
        }
    }
}