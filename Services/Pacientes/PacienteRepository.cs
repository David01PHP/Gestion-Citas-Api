using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Data;
using GestionDeCitas.Models;

namespace GestionDeCitas.Services.Pacientes
{
    public class PacienteRepository : IPacienteRepository
    {

        private readonly GestionContext _context;
        public PacienteRepository(GestionContext context)
        {
            _context = context;
        }
        public void CreatePatient(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }

        public IEnumerable<Paciente> GetAll()
        {
            return _context.Pacientes.ToList();
        }

        public Paciente GetIdPatient(int id)
        {
            return _context.Pacientes.Find(id);
        }

         public Paciente GetStringPatient(string estado)
        {
             var paciente = _context.Pacientes.FirstOrDefault(c => c.Estado == estado);

            return paciente;
        }


        public void UpdatePatient(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }
    }
}