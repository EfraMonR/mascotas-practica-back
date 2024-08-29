using MascotasBack.Context;
using MascotasBack.Entities;
using MascotasBack.Interfaces;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace MascotasBack.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RegisterAsync(Users request)
        { 
            request.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

            _context.Users.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateUserAsync(string email, string pass)
        { 
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(pass, user.PasswordHash);
        }
    }
}
