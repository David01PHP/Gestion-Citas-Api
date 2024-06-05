using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionDeCitas.Models
{
    public class Paciente
    {
        public int Id {get; set;}
        public string? Nombres {get; set;}
        public string? apellidos {get; set;}
        public DateTime FechaNacimiento {get; set;}
        public string? Correo {get; set;}
        public string? Telefono {get; set;}
        public string? Direccion {get; set;}
        public string? Estado {get; set;}
        [JsonIgnore]
        public List<Cita> Citas { get; set;}
    }
}