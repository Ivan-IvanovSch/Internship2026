using Internship.Controllers;
using Internship.Models.Entities;
using Internship.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Internship.Services
{

    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly ShopContext _context;

        public AccountService(ILogger<AccountService> logger, ShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Account?> GetAccountAsync(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
