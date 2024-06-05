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

    public class EspecialidadesController : Controller
    {
        private readonly IEspecialidadRepository _especialidadRepository;

        public EspecialidadesController(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        [HttpGet]
        [Route("api/[controller]/List")]
        public IEnumerable<Especialidad> GetSpecialty()
        {
            return _especialidadRepository.GetAll();
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Especialidad GetIdSpecialty(int id)
        {
            return _especialidadRepository.GetIdSpecialty(id);
        }
         [HttpGet]
        [Route("api/Especialidad/confirmada/{estado}")]
        public Especialidad GetStringSpecialty(string estado)
        {
            return _especialidadRepository.GetStringSpecialty(estado);

        }
    }
}