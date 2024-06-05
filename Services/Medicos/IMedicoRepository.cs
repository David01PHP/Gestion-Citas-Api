using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Models;

namespace GestionDeCitas.Services.Medicos
{
    public interface IMedicoRepository
    {
        IEnumerable<Medico> GetAll();
        Medico GetIdDoctor(int id);
        Medico GetStringDoctor(string estado);
        void CreateDoctor(Medico medico);
        void UpdateDoctor(Medico medico);
    }
}