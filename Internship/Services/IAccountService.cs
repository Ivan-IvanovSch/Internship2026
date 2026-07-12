using Internship.Models.Entities;

namespace Internship.Services
{
    public interface IAccountService
    {
        Task? CreateAccountAsync(string username, string email, string password, string name);

        Task<Account?> GetAccountAsync(int id);

        Task? UpdateAccountAsync(int id, string email, string password, string name);

        Task? DeleteAccountAsync(int id);
    }
}
