using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Models;

namespace GestionDeCitas.Services.Pacientes
{
    public interface IPacienteRepository
    {
        IEnumerable<Paciente> GetAll();
        Paciente GetIdPatient(int id);
        Paciente GetStringPatient(string estado);
        void CreatePatient(Paciente paciente);
        void UpdatePatient(Paciente paciente);

    }
}