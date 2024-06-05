using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using GestionDeCitas.Models;
using GestionDeCitas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionDeCitas.Controllers.Citas
{

    public class CrearCitaController : Controller
    {
        private readonly ICitaRepository _citaRepository;

        public CrearCitaController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult PostAppointment([FromBody] Cita cita)
        {

            MailController Email = new MailController();
            Email.EnviarCorreo();
            
            _citaRepository.CreateAppointment(cita);
            return Ok();
        }


    }
}