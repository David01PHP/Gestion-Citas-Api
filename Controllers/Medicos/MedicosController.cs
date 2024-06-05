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

    public class MedicosController : Controller
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicosController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpGet]
        [Route("api/Medicos/List")]
        public IEnumerable<Medico> GetDoctors()
        {
            return _medicoRepository.GetAll();
        }

        [HttpGet]
        [Route("api/Medicos/{id}")]
        public Medico GetDoctorById(int id)
        {
            return _medicoRepository.GetIdDoctor(id);

        }

        [HttpGet]
        [Route("api/medicos/confirmada/{estado}")]
        public Medico GetStringDoctor(string estado)
        {
            return _medicoRepository.GetStringDoctor(estado);

        }
    }
}