using System.Text.Json.Serialization;

namespace GestionDeCitas.Models
{
    public class Cita
    {
        public int Id {get; set;}
        public int MedicoId {get; set;}
        public Medico Medico {get; set;}
        public int PacienteId {get; set;}
        public Paciente Paciente {get; set;}
        public DateTime Fecha {get; set;}
        public string? Estado {get; set;}
        [JsonIgnore]
        public List<Tratamiento>? Tratamiento {get; set;}
    }
}