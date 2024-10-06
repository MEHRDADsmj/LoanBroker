namespace BankCProvider;

public class BankCProvider : IBankProvider.IBankProvider
{
    public readonly int loanAmountUpperBound = 10000;
    
    public List<float> CalculateLoan(float loan)
    {
        if (IsAmountOutOfBounds(loan * loan))
        {
            throw new ArgumentOutOfRangeException(nameof(loan), "loan is not a natural number");
        }
        else
        {
            var installments = FindSquareSum((int)loan, (int)(loan * loan));
            if (installments.Count <= 1)
            {
                throw new InvalidOperationException("Could not find a suitable installment");
            }
            return installments;
        }
    }

    private bool IsAmountOutOfBounds(float amount)
    {
        // Check if is a natural number
        return amount < 0 || Math.Abs(amount - Math.Floor(amount)) > 0.01f || amount > loanAmountUpperBound * loanAmountUpperBound;
    }
    
    private List<float> FindSquareSum(int n, int squaredValue)
    {
        List<float> numbers = new List<float>();
        FindCombination(n - 1, squaredValue, numbers);
        return numbers;
    }
    
    private bool FindCombination(int current, int target, List<float> combination)
    {
        if (target == 0)
        {
            return true;
        }

        if (current <= 0 || target < 0)
        {
            return false;
        }
        
        combination.Add(current);
        if (FindCombination(current - 1, target - (current * current), combination))
        {
            return true;
        }
        
        combination.RemoveAt(combination.Count - 1);
        return FindCombination(current - 1, target, combination);
    }
}