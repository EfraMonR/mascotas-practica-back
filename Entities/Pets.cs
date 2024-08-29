namespace MascotasBack.Entities
{
    public class Pets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string? CreationUser { get; set; }
        public string? ModificationUser { get; set; }
    }
}
