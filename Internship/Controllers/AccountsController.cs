using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Internship.Services;
using Internship.Models.Entities;
using Internship.Models.DTOs;

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

        [HttpPost("LogIn")]

        public async Task<IActionResult> LogInAccount(LogInAccountDTO dto)
        {
            var account = await _accountService.LogInAccountAsync(dto);

            if (account is null) return Unauthorized();

            return Ok(account);
        }

        [HttpPost("SignUp")]

        public async Task<IActionResult> CreateAccount(CreateAccountDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _accountService.CreateAccountAsync(dto);

            return Ok();
        }

        [HttpGet ("FindAccount")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await _accountService.GetAccountAsync(id);

            if (account is null) return NotFound();

            return Ok(account);
        }

        [HttpPut ("EditAccount")]

        public async Task<IActionResult> UpdateAccount(int id, string email, string password, string name)
        {
            await _accountService.UpdateAccountAsync(id, email, password, name);

            return Ok();
        }

        [HttpDelete ("DeleteAccount")]

        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _accountService.GetAccountAsync(id);

            if (account is null) return NotFound();

            await _accountService.DeleteAccountAsync(account);

            return Ok();
        }
    }
}
