using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeCitas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeCitas.Data
{
    public class GestionContext: DbContext
    {
       public GestionContext(DbContextOptions<GestionContext> options): base(options){
            
        }
        public DbSet<Paciente> Pacientes { get;set;}
        public DbSet<Tratamiento> Tratamientos { get;set;}
        public DbSet<Especialidad> Especialidades { get;set;}
        public DbSet<Cita> Citas { get;set;}
        public DbSet<Medico> Medicos { get;set;}
    }
}