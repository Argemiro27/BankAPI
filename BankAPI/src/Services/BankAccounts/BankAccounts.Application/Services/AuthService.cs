using BankAccounts.Application.DTOs;
using BankAccounts.Application.Services.Interfaces;
using BankAccounts.Domains.Entities;
using BankAccounts.InfraRead.Repositories.Interfaces;
using BankAccounts.InfraWrite.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BankAccounts.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserQuery _userQuery;
        private readonly IUserCommand _userCommand;
        private readonly IAuthCommand _authCommand;
        private readonly IAccountQuery _accountQuery;
        public AuthService(IUserQuery userQuery,
                            IUserCommand userCommand, 
                            IAuthCommand authCommand,
                            IAccountQuery accountQuery)
        {
            _userQuery = userQuery;
            _userCommand = userCommand;
            _authCommand = authCommand;
            _accountQuery = accountQuery;
        }

        public async Task<LoginDTO> Get(string email, string senha)
        {
            try
            {
                // Verificar se o usuário existe, recupera o usuário
                UserModel dadosUsuario = await _userQuery.GetByEmailAsync(email);

                if (dadosUsuario == null) { throw new Exception("Nenhum usuário foi encontrado com o email informado!"); }

                Task<bool> passwordsMatch = CompareHashMD5Async(senha, dadosUsuario.Password);

                if (!await passwordsMatch) { throw new Exception("Credenciais informadas são inválidas!"); }

                DotNetEnv.Env.Load();
                string secretKey = Environment.GetEnvironmentVariable("AUTH_SECRET_KEY");

                // Verifica se o usuário já tem uma conta criada
                AccountModel dataAccount = await _accountQuery.GetByIdUserAsync(dadosUsuario.UserId);

                // Retorna os dados criptografados. Se o usuário possuir uma conta, retorna os dados da conta
                string authToken = GenerateJwtToken(dadosUsuario.Username, dadosUsuario.Email, dadosUsuario.UserId, dataAccount, secretKey);

                LoginDTO infoLogin = new LoginDTO
                {
                    TokenID = authToken
                };

                return infoLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UserModel> Create(UserModel user)
        {
            try
            {

                UserModel checkUsername = await _userQuery.GetByUsernameAsync(user.Username);

                // Verificar se o usuário já existe
                if (checkUsername != null)
                {
                    throw new Exception("Usuário já cadastrado no banco de dados!");
                }


                var passwordHashed = await getHashAsync(user.Password);

                user.Password = passwordHashed.ToString();

                // Verificar se o token foi gerado
                if (passwordHashed == null) { throw new Exception("Geração de token mal-sucedido!"); }

                var result = await _authCommand.Register(user);

                // Verificar se o banco retornou ok à consulta
                if (result == null) { throw new Exception("Erro ao cadastrar usuário no banco de dados! "); }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GenerateSecretKey(int keyLength)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var chars = new char[keyLength];

            for (int i = 0; i < keyLength; i++)
            {
                chars[i] = validChars[random.Next(validChars.Length)];
            }

            return new string(chars);
        }


        public static string GenerateJwtToken(string username, string email, int userId, AccountModel dataAccount, string chaveSecreta)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(chaveSecreta);

            // Serializa o objeto AccountModel para JSON
            var accountDataJson = JsonConvert.SerializeObject(dataAccount);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim("username", username),
            new Claim("email", email),
            new Claim("userId", userId.ToString()),
            new Claim("dataAccount", accountDataJson) // Adiciona os dados serializados como uma reivindicação
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        public static async Task<string> getHashAsync(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = await Task.Run(() => md5.ComputeHash(inputBytes));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static async Task<bool> CompareHashMD5Async(string password, string dbPassword)
        {
            string hashedPassword = await getHashAsync(password);
            return string.Equals(hashedPassword, dbPassword, StringComparison.OrdinalIgnoreCase);
        }

    }
}
