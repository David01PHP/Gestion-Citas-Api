using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Models;

namespace GestionDeCitas.Services
{
    public interface IEspecialidadRepository
    {
        IEnumerable<Especialidad> GetAll();
        Especialidad GetIdSpecialty(int id);
        Especialidad GetStringSpecialty(string estado);
        void CreateSpecialty(Especialidad tratamiento);
        void UpdateSpecialty(Especialidad tratamiento);
    }
}