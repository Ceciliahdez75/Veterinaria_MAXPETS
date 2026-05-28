namespace Veterinaria_MaxPets.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public int MascotaId { get; set; }        // FK obligatoria
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } = "Pendiente";

        public Mascota Mascota { get; set; } = null!;
        public ICollection<DetalleServicio> Detalles { get; set; } = new List<DetalleServicio>();
    }
}