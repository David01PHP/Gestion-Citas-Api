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
    
    public class CrearTratamientoController : Controller
    {
        private readonly ITratamientoRepository _tratamientoRepository;

        public CrearTratamientoController(ITratamientoRepository tratamientoRepository)
        {
            _tratamientoRepository = tratamientoRepository;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult PostTreatment([FromBody] Tratamiento tratamiento)
        {
            _tratamientoRepository.CreateTreatment(tratamiento);
            return Ok();
        }
    }
}