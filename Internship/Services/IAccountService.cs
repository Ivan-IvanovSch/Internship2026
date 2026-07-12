using Internship.Models.Entities;

namespace Internship.Services
{
    public interface IAccountService
    {
        Task<Account?> GetAccountAsync(int id);
    }
}
