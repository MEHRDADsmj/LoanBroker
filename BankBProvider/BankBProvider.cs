using LoanBroker.Data;

namespace BankBProvider;

public class BankBProvider : IBankProvider.IBankProvider
{
    public readonly int interestRateUpperLimit = 50;
    public readonly int interestRateLowerLimit = -20;
    public readonly float interestRate;
    private int numberOfInstallments = 8;
    public readonly long loanAmountUpperLimit = 500000000;
    public readonly long loanAmountLowerLimit = 100000000;

    public BankBProvider()
    {
        var rnd = new Random();
        interestRate = rnd.Next(interestRateLowerLimit, interestRateUpperLimit + 1) / 100.0f;
    }
    
    public LoanResponse CalculateLoan(LoanRequest loan)
    {
        if (IsAmountOutOfBounds(loan.Amount))
        {
            throw new ArgumentOutOfRangeException(nameof(loan), "loan.Amount is out of bounds");
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
        return amount < loanAmountLowerLimit || amount > loanAmountUpperLimit;
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