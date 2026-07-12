using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Internship.Services;
using Internship.Models.Entities;

namespace Internship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost(Name = "CreateAccount")]

        public async Task<IActionResult> CreateAccount(string username, string email, string password, string name)
        {
            await _accountService.CreateAccountAsync(username, email, password, name);

            return Ok();
        }

        [HttpGet (Name = "GetAccount")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await _accountService.GetAccountAsync(id);

            if (account is null) return NotFound();

            return Ok(account);
        }

        [HttpPut (Name = "UpdateAccount")]

        public async Task<IActionResult> UpdateAccount(int id, string email, string password, string name)
        {
            await _accountService.UpdateAccountAsync(id, email, password, name);

            return Ok();
        }

        [HttpDelete (Name = "DeleteAccount")]

        public async Task<IActionResult> DeleteAccount(int id)
        {
            await _accountService.DeleteAccountAsync(id);

            return Ok();
        }
    }
}
