using MascotasBack.Entities;

namespace MascotasBack.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(Users request);
        Task<bool> ValidateUserAsync(string email, string pass);
    }
}
