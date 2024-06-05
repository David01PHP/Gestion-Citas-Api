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
    
    public class CrearMedicoController : Controller
    {
        private readonly IMedicoRepository _medicoRepository;

        public CrearMedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult PostDoctor([FromBody] Medico medico)
        {
            _medicoRepository.CreateDoctor(medico);
            return Ok();
        }
    }
}