using System.ComponentModel.DataAnnotations;

namespace LoanBroker.Data;

public class LoanRequest
{
    [Required]
    public string BankName { get; set; } = null!;
    
    [Required]
    [Range(0.0f, float.MaxValue)]
    public float Amount { get; set; }
}