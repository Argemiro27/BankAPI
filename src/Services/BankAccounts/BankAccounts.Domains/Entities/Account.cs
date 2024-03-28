using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public long PhoneNumber { get; set; }

        public long DocNumber { get; set; }

        public long AccountNumber { get; set; }

        public string AccountType { get; set; }

        public string AccountStatus { get; set; }

        public long AccountPass { get; set; }

        public long CardNumber { get; set; }

        public double AccountBalance { get; set; }
    }
}
