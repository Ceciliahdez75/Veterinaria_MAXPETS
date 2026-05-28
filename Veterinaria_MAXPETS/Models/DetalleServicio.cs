namespace Veterinaria_MaxPets.Models
{
    public class DetalleServicio
    {
        public int Id { get; set; }
        public int CitaId { get; set; }           // FK a Cita
        public int ServicioApiId { get; set; }    // ID del servicio que viene de la API del profesor
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Cita Cita { get; set; } = null!;
    }
}