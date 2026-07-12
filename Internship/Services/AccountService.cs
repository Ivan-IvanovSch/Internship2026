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

        public async Task<Account?> LogInAccountAsync(string username, string password)
        {
            var account = await _context.Accounts.FirstAsync(a => a.Username == username);

            if (account is null || account.Password != password) return null;

            return account;
        }

        public async Task? CreateAccountAsync(string username, string email, string password, string name)
        {
            if (_context.Accounts.Any(a => a.Username == username || a.Email == email)) throw new ArgumentException("Account already exists");

            Account account = new Account
            {
                Username = username,
                Email = email,
                Password = password,
                Name = name
            };

            _context.Accounts.Add(account);

            await _context.SaveChangesAsync();

            return;
        }

        public async Task<Account?> GetAccountAsync(int id)
        {
            return await _context.Accounts.FirstAsync(a => a.Id == id);
        }

        public async Task? UpdateAccountAsync(int id, string email, string password, string name)
        {
            var account = _context.Accounts.First(a => a.Id == id);

            if (account is null) throw new ArgumentException("Account doesn't exist");

            account.Email = email;
            account.Password = password;
            account.Name = name;

            await _context.SaveChangesAsync();

            return;
        }

        public async Task? DeleteAccountAsync(int id)
        {
            _context.Accounts.Remove(_context.Accounts.First(a => a.Id == id));

            await _context.SaveChangesAsync();

            return;
        }
    }
}
