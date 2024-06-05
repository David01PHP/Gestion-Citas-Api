using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GestionDeCitas.Models;
using GestionDeCitas.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionDeCitas.Controllers.Citas
{
    
    public class CitasController : Controller
    {
       private readonly ICitaRepository _citaRepository;

        public CitasController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpGet]
        [Route("api/[controller]/List")]
        public IEnumerable<Cita> GetAppointmentty()
        {
            return _citaRepository.GetAll();

        }

        [HttpGet]
        [Route("api/Cita")]
        public Cita GetAppointmentById(int id)
        {
            return _citaRepository.GetIdAppointment(id);

        }
        [HttpGet]
        [Route("api/Citas/confimdas")]
        public Cita GetConfirmadasAppointment()
        {
            return _citaRepository.GetConfirmadasAppointment();

        }


    }
}