using Internship.Models.DTOs;
using Internship.Models.Entities;

namespace Internship.Services
{
    public interface IAccountService
    {
        Task<Account?> LogInAccountAsync(LogInAccountDTO dto);

        Task? CreateAccountAsync(CreateAccountDTO dto);

        Task<Account?> GetAccountAsync(int id);

        Task? UpdateAccountAsync(int id, string email, string password, string name);

        Task? DeleteAccountAsync(Account account);
    }
}
