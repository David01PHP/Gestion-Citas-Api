using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Data;
using GestionDeCitas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeCitas.Services.Tratamientos
{
    public class TratamientoRepository : ITratamientoRepository
    {

        private readonly GestionContext _context;
        public TratamientoRepository(GestionContext context)
        {
            _context = context;
        }
        public void CreateTreatment(Tratamiento tratamiento)
        {
            _context.Tratamientos.Add(tratamiento);
            _context.SaveChanges();
        }

        public IEnumerable<Tratamiento> GetAll()
        {
            return _context.Tratamientos.Include(t => t.Cita).ToList();
        }

        public Tratamiento GetIdTreatment(int id)
        {
            return _context.Tratamientos.Find(id);
        }

        public void UpdateTreatment(Tratamiento tratamiento)
        {
            _context.Tratamientos.Update(tratamiento);
            _context.SaveChanges();
        }


    }
}