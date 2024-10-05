using LoanBroker.Data;

namespace BankAProvider;

public class BankAProvider : IBankProvider.IBankProvider
{
    public readonly float interestRate = 0.2f;
    private int numberOfInstallments = 10;
    public readonly long loanAmountUpperLimit = 999999999999;
    
    public LoanResponse CalculateLoan(LoanRequest loan)
    {
        if (IsAmountOutOfBounds(loan.Amount))
        {
            throw new ArgumentOutOfRangeException(nameof(loan), "loan.Amount is less than 0");
        }
        else
        {
            var totalValue = CalculateTotalLoanAndInterest(loan.Amount);
            return new LoanResponse()
                   {
                       Installments = ExtractInstallments(totalValue),
                   };
        }
    }
    
    private bool IsAmountOutOfBounds(long amount)
    {
        return amount < 0.0f || amount > loanAmountUpperLimit;
    }

    private long CalculateTotalLoanAndInterest(long amount)
    {
        return (long)(amount * (interestRate + 1.0f));
    }

    private List<long> ExtractInstallments(long totalAmount)
    {
        var installmentAmount = totalAmount / numberOfInstallments;
        List<long> installments = new List<long>();
        for (int i = 0; i < numberOfInstallments; i++)
        {
            installments.Add(installmentAmount);
        }

        return installments;
    }
}