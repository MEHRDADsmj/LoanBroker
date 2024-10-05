using LoanBroker.Data;

namespace BankProviders.Tests
{
    public class testBankAProvider
    {
        private BankAProvider.BankAProvider provider;
        
        [SetUp]
        public void Setup()
        {
            provider = new BankAProvider.BankAProvider();
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(1000)]
        [TestCase(long.MaxValue)]
        [TestCase(long.MinValue)]
        public void testCalculateLoan(long amount)
        {
            var loan = PrepareLoan(amount);
            try
            {
                var response = provider.CalculateLoan(loan);
                float sum = response.Installments.Sum();

                if (Math.Abs(sum - amount * (1 + provider.interestRate)) < 1.0f)
                {
                    Assert.Pass();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
                if (amount < 0 || amount >= provider.loanAmountUpperLimit)
                {
                    Assert.Pass();
                }
            }

            Assert.Fail();
        }

        private LoanRequest PrepareLoan(long amount)
        {
            return new LoanRequest()
            {
                Amount = amount,
            };
        }
    }
}