using GestionDeCitas.Models;

namespace GestionDeCitas.Services.Tratamientos
{
    public interface ITratamientoRepository
    {
        IEnumerable<Tratamiento> GetAll();
        Tratamiento GetIdTreatment(int id);
        void CreateTreatment(Tratamiento tratamiento);
        void UpdateTreatment(Tratamiento tratamiento);
    }
}