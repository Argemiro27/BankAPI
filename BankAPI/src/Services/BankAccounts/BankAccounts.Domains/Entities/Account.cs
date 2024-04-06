using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccounts.Domains.Entities
{
    public class AccountModel
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        public string ClientName { get; set; }

        public string PhoneNumber { get; set; } // Alterado para string para lidar com diferentes formatos de números

        [StringLength(11)] // Definindo o tamanho do CPF
        public string DocNumber { get; set; } // Alterado para string para lidar com diferentes formatos e evitar perda de zeros à esquerda

        [StringLength(16)] // Definindo o tamanho do número da conta
        public string AccountNumber { get; set; } // Alterado para string para lidar com formatos que incluem zeros à esquerda

        public string AccountType { get; set; }

        public string AccountStatus { get; set; }

        public string AccountPass { get; set; } // Alterado para string para armazenar senhas de forma segura

        [StringLength(16)] // Definindo o tamanho do número do cartão
        public string CardNumber { get; set; } // Alterado para string para lidar com formatos que incluem zeros à esquerda e evitar perda de precisão em números longos

        public decimal AccountBalance { get; set; } // Alterado para decimal para valores monetários
    }
}
