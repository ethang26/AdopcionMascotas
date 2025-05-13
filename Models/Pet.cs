namespace AdopcionMascotas.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Tipo { get; set; }
        public string EstadoAdopcion { get; set; } // Disponible / Adoptada

        public Adoption? Adoption { get; set; } // Relación 1 a 1
    }
}


namespace AdopcionMascotas.Models
{
    public class Adopter
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        public required ICollection<Adoption> Adoptions { get; set; }
    }
}


namespace AdopcionMascotas.Models
{
    public class Adoption
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public int AdopterId { get; set; }
        public Adopter Adopter { get; set; }

        public DateTime FechaAdopcion { get; set; }
    }
}
