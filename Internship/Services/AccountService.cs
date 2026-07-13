using Internship.Controllers;
using Internship.Models.DTOs;
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

        public async Task<Account?> LogInAccountAsync(LogInAccountDTO dto)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == dto.Username);

            if (account is null || account.Password != dto.Password) return null;

            return account;
        }

        public async Task? CreateAccountAsync(CreateAccountDTO dto)
        {
            if (_context.Accounts.Any(a => a.Username == dto.Username || a.Email == dto.Email)) throw new ArgumentException("Account already exists");

            Account account = new Account
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password,
                Name = dto.Name
            };

            _context.Accounts.Add(account);

            await _context.SaveChangesAsync();

            return;
        }

        public async Task<Account?> GetAccountAsync(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
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

        public async Task? DeleteAccountAsync(Account account)
        {
            _context.Accounts.Remove(account);

            await _context.SaveChangesAsync();

            return;
        }
    }
}
