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

        [HttpGet (Name = "GetAccount")]
        public async Task<IActionResult> GetAccount()
        {
            var account = await _accountService.GetAccountAsync(1);

            if (account is null) return NotFound();

            return Ok(account);
        }
    }
}
