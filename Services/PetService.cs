using MascotasBack.Context;
using MascotasBack.Entities;
using MascotasBack.Interfaces;
using MascotasBack.Models;
using Microsoft.EntityFrameworkCore;

namespace MascotasBack.Services
{
    public class PetService : IPetService
    {
        private readonly ApplicationDbContext _context;

        public PetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pets>> GetPets()
        {
            try
            {
                var pets = await _context.Pets.ToListAsync();
                return pets;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to get pets" + ex.Message);
            }
        }

        public async Task CreatePet(PetCreationDto request)
        {
            try
            {
                var petCreation = new Pets
                {
                    Name = request.Name,
                    Type = request.Type,
                    Breed = request.Breed,
                    Age = request.Age,
                    Owner = request.Owner,
                    CreationUser = request.User,
                    CreationDate = DateTime.Now
                };

                _context.Pets.Add(petCreation);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error to create pet" + ex.Message);
            }
        }

        public async Task UpdatePet(int id, PetCreationDto request)
        {
            try
            {
                var petUpdate = await _context.Pets.FindAsync(id);
                if (petUpdate == null)
                    throw new Exception("Pet not found");

                petUpdate.Name = request.Name;
                petUpdate.Type = request.Type;
                petUpdate.Breed = request.Breed;
                petUpdate.Age = request.Age;
                petUpdate.Owner = request.Owner;
                petUpdate.ModificationUser = request.User;
                petUpdate.ModificationDate = DateTime.Now;

                await _context.SaveChangesAsync();  
            }
            catch (Exception ex)
            { 
                throw new Exception("Error to update pet. " + ex.Message);
            }
        }

        public async Task DeletePet(int id)
        {
            try
            {
                var petDelete = await _context.Pets.FindAsync(id);
                if (petDelete == null)
                    throw new Exception("Pet not found");

                _context.Pets.Remove(petDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error to delete pet. " + ex.Message);
            }
        }
    }
}
