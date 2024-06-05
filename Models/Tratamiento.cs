using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCitas.Models
{
    public class Tratamiento
    {
        public int Id {get; set;}
        public int CitaId {get; set;}
        public string? Descripcion {get; set;}
        public string? Estado {get; set;}
        public Cita? Cita {get; set;}
    }
}