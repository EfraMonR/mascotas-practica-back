using MascotasBack.Entities;
using MascotasBack.Models;

namespace MascotasBack.Interfaces
{
    public interface IPetService
    {
        Task CreatePet(PetCreationDto request);
        Task DeletePet(int id);
        Task<List<Pets>> GetPets();
        Task UpdatePet(int id, PetCreationDto request);
    }
}
