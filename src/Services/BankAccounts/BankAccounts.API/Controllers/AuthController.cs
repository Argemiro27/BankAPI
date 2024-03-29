using BankAccounts.Application.DTOs;
using BankAccounts.Application.Services.Interfaces;
using BankAccounts.Domains.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace BankAccounts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private IAuthService _authService;
        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login (string email, string senha)
        {
            try
            {
                if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(senha)) { throw new Exception("É obrigatório informar algum valor!"); }

                LoginDTO resultado = await _authService.Get(email, senha);

                if(resultado == null) { throw new Exception("Ocorreu um erro ao tentar fazer login!"); }

                return Ok(resultado);
            }catch (Exception ex)
            {
                Console.WriteLine($"Erro ao logar com o usuário: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            try
            {
                // Verifica se o modelo é válido
                if (user == null)
                {
                    throw new ArgumentNullException("Nenhum valor foi informado!");
                }

                // Cria o usuário
                UserModel newUser = await _authService.Create(user);

                // Retorna o usuário recém-criado
                return Ok(newUser); // Alteração feita aqui para retornar um código 200 OK junto com o usuário criado
            }
            catch (Exception ex)
            {
                // Logue o erro para análise posterior
                Console.WriteLine($"Erro ao criar o usuário: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Verifica se o modelo é válido
                if (id.Equals(0) || id == null)
                {
                    throw new Exception("O ID informado não pode ser zero ou nulo!");
                }

                // Deleta o usuário
                await _userService.DeleteAsync(id);

                // Retorna um código de sucesso
                return Ok();
            }
            catch (Exception ex)
            {
                // Logue o erro para análise posterior
                Console.WriteLine($"Erro ao deletar o usuário: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }



    }
}
