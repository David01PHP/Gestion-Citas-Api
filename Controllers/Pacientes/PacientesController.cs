using GestionDeCitas.Models;
using GestionDeCitas.Services.Pacientes;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeCitas.Controllers.Pacientes
{

    public class PacientesController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacientesController(IPacienteRepository pacientesRepository)
        {
            _pacienteRepository = pacientesRepository;
        }


        [HttpGet]
        [Route("api/[controller]/List")]
        public IEnumerable<Paciente> GetPatients()
        {
            return _pacienteRepository.GetAll();

        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Paciente GetPatientById(int id)
        {
            return _pacienteRepository.GetIdPatient(id);
        }

         [HttpGet]
        [Route("api/[controller]/confirmada/{estado}")]
        public Paciente GetStringPatient(string estado)
        {
            return _pacienteRepository.GetStringPatient(estado);

        }

    }
}