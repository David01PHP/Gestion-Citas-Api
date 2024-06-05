using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Data;
using GestionDeCitas.Models;

namespace GestionDeCitas.Services.Especialidades
{
    public class EspecialidadRepository : IEspecialidadRepository
    {

        private readonly GestionContext _context;
        public EspecialidadRepository(GestionContext context)
        {
            _context = context;
        }
        public void CreateSpecialty(Especialidad tratamiento)
        {
            _context.Especialidades.Add(tratamiento);
            _context.SaveChanges();
        }

        public IEnumerable<Especialidad> GetAll()
        {
            return _context.Especialidades.ToList();
        }

        public Especialidad GetIdSpecialty(int id)
        {
            return _context.Especialidades.Find(id);
        }

        public Especialidad GetStringSpecialty(string estado)
        {
             var especialidad = _context.Especialidades.FirstOrDefault(c => c.Estado == estado);

            return especialidad;
        }

        public void UpdateSpecialty(Especialidad tratamiento)
        {
            _context.Especialidades.Update(tratamiento);
            _context.SaveChanges();
        }
    }
}