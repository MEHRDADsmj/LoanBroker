namespace BankAProvider;

public class BankAProvider : IBankProvider.IBankProvider
{
    public readonly float interestRate = 0.2f;
    private int numberOfInstallments = 10;
    public readonly int loanAmountUpperLimit = Int32.MaxValue;
    
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
        return amount < 0.0f || amount > loanAmountUpperLimit;
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