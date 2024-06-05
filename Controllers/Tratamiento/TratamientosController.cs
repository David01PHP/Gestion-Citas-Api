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
    public class TratamientosController : Controller
    {
        private readonly ITratamientoRepository _tratamientoRepository;

        public TratamientosController(ITratamientoRepository tratamientoRepository)
        {
            _tratamientoRepository = tratamientoRepository;
        }

        [HttpGet]
        [Route("api/[controller]/List")]
        public IEnumerable<Tratamiento> GetTreatment()
        {
            return _tratamientoRepository.GetAll();

        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Tratamiento GetTreatmentById(int id)
        {
            return _tratamientoRepository.GetIdTreatment(id);

        }
    }
}