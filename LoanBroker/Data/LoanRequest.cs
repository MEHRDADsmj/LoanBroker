using System.ComponentModel.DataAnnotations;

namespace LoanBroker.Data;

public class LoanRequest
{
    [Required]
    public string BankName { get; set; } = null!;
    
    [Required]
    public float Amount { get; set; }
}