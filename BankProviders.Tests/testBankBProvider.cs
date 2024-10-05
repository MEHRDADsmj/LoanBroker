using LoanBroker.Data;

namespace BankProviders.Tests
{
    public class testBankBProvider
    {
        private BankBProvider.BankBProvider provider;
        
        [SetUp]
        public void Setup()
        {
            provider = new BankBProvider.BankBProvider();
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(100)]
        [TestCase(250)]
        [TestCase(500)]
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
                if (amount < provider.loanAmountLowerLimitInMillions || amount >= provider.loanAmountUpperLimitInMillions)
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