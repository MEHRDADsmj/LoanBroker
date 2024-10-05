using LoanBroker.Data;

namespace IBankProvider;

public interface IBankProvider
{
    LoanResponse CalculateLoan(LoanRequest loan);
}