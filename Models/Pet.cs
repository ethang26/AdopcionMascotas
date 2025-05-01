namespace AdopcionMascotas.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Tipo { get; set; }
        public string EstadoAdopcion { get; set; } // Disponible / Adoptada
    }
}
public class Adopter
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }

    public ICollection<Adoption> Adoptions { get; set; }
}

public class Adoption
{
    public int Id { get; set; }
    public int PetId { get; set; }
    public Pet Pet { get; set; }

    public int AdopterId { get; set; }
    public Adopter Adopter { get; set; }

    public DateTime FechaAdopcion { get; set; }
}