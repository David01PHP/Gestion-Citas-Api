using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Data;
using GestionDeCitas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeCitas.Services.Citas
{
    public class CitaRepository : ICitaRepository
    {


        private readonly GestionContext _context;
        public CitaRepository(GestionContext context)
        {
            _context = context;
        }
        public void CreateAppointment(Cita cita)
        {
            _context.Citas.Add(cita);
            _context.SaveChanges();
        }

        public IEnumerable<Cita> GetAll()
        {
            return _context.Citas.Include(u => u.Medico).Include(u => u.Paciente).ToList();
        }

        public Cita GetIdAppointment(int id)
        {
            return _context.Citas.Find(id);
        }

        public Cita GetConfirmadasAppointment()
        {
             var cita = _context.Citas.FirstOrDefault(c => c.Estado == "Confirmada");

            return cita;
        }

        public void UpdateAppointment(Cita cita)
        {
            _context.Citas.Update(cita);
            _context.SaveChanges();
        }
    }
}