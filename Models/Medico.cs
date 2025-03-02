using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionDeCitas.Models
{
    public class Medico
    {
        public int Id {get; set;}
        public string? NombreCompleto {get; set;}
        public int EspecialidadId {get; set;}
        public Especialidad? Especialidad {get; set;}
        public string? Correo {get; set;}
        public string? Telefono {get; set;}
        public string? Estado {get; set;}
        [JsonIgnore]
        public List<Cita> Citas { get; set;}
    }
}