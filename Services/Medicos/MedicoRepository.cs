using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Data;
using GestionDeCitas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeCitas.Services.Medicos
{
    public class MedicoRepository : IMedicoRepository
    {

        private readonly GestionContext _context;
        public MedicoRepository(GestionContext context)
        {
            _context = context;
        }
        public void CreateDoctor(Medico medico)
        {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
        }

        public IEnumerable<Medico> GetAll()
        {
            return _context.Medicos.Include(u => u.Especialidad).ToList();
        }
        
        public Medico GetStringDoctor(string estado)
        {
             var medicos = _context.Medicos.FirstOrDefault(c => c.Estado == estado);

            return medicos;
        }

        public Medico GetIdDoctor(int id)
        {
            return _context.Medicos.Find(id);
        }

        public void UpdateDoctor(Medico medico)
        {
            _context.Medicos.Update(medico);
            _context.SaveChanges();
        }
    }
}