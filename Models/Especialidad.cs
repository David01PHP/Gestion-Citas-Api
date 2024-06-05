using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionDeCitas.Models
{
    public class Especialidad
    {
        public int Id {get; set;}
        public string? Nombre {get; set;}
        public string? Descripcion {get; set;}
        public string? Estado {get; set;}
        [JsonIgnore]
        public Medico? Medicos{get; set;}
    }
}