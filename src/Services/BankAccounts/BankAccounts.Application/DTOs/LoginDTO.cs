
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Application.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string TokenID { get; set; }
    }
}
