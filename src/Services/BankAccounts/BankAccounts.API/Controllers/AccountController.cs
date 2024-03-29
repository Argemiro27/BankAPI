using BankAccounts.Application.DTOs;
using BankAccounts.Application.Services.Interfaces;
using BankAccounts.Domains.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BankAccounts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AccountModel account)
        {
            try
            {
                // Recebe o resultado das tratativas da aplicação
                AccountModel newAccount = await _accountService.Create(account);

                // Retorna a nova conta criada
                return Ok(newAccount);
            }
            catch (Exception ex)
            {
                // Logue o erro para análise posterior
                Console.WriteLine($"Erro ao criar o usuário: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
