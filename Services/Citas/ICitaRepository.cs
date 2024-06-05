using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Models;

namespace GestionDeCitas.Services
{
    public interface ICitaRepository
    {
        IEnumerable<Cita> GetAll();
        Cita GetIdAppointment(int id);
        Cita GetConfirmadasAppointment();
        void CreateAppointment(Cita cita);
        void UpdateAppointment(Cita cita);
    }
}