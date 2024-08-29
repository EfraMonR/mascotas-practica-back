namespace MascotasBack.Models
{
    public class PetCreationDto
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }
        public string? User { get; set; }
    }
}
