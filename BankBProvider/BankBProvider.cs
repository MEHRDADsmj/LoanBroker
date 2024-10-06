namespace BankBProvider;

public class BankBProvider : IBankProvider.IBankProvider
{
    public readonly int interestRateUpperLimit = 50;
    public readonly int interestRateLowerLimit = -20;
    public readonly float interestRate;
    private int numberOfInstallments = 8;
    public readonly int loanAmountUpperLimitInMillions = 500;
    public readonly int loanAmountLowerLimitInMillions = 100;

    public BankBProvider()
    {
        var rnd = new Random();
        interestRate = rnd.Next(interestRateLowerLimit, interestRateUpperLimit + 1) / 100.0f;
    }
    
    public List<float> CalculateLoan(float loan)
    {
        if (IsAmountOutOfBounds(loan))
        {
            throw new ArgumentOutOfRangeException(nameof(loan), "loan is out of bounds");
        }
        else
        {
            var totalValue = CalculateTotalLoanAndInterest(loan);
            return ExtractInstallments(totalValue);
        }
    }
    
    private bool IsAmountOutOfBounds(float amount)
    {
        return amount < loanAmountLowerLimitInMillions || amount > loanAmountUpperLimitInMillions;
    }

    private float CalculateTotalLoanAndInterest(float amount)
    {
        return amount * (interestRate + 1.0f);
    }

    private List<float> ExtractInstallments(float totalAmount)
    {
        float installmentAmount = totalAmount / numberOfInstallments;
        List<float> installments = new List<float>();
        for (int i = 0; i < numberOfInstallments; i++)
        {
            installments.Add(installmentAmount);
        }

        return installments;
    }
}