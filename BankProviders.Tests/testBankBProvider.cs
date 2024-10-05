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
        [TestCase(1000)]
        [TestCase(100000000)]   // 100 Million
        [TestCase(250000000)]   // 250 Million
        [TestCase(500000000)]   // 500 Million
        [TestCase(1000000000)]  // 1 Billion
        [TestCase(long.MaxValue)]
        [TestCase(long.MinValue)]
        public void testCalculateLoan(long amount)
        {
            var loan = PrepareLoan(amount);
            try
            {
                var response = provider.CalculateLoan(loan);
                long sum = response.Installments.Sum();

                if (Math.Abs(sum - amount * (1 + provider.interestRate)) < 1.0f)
                {
                    Assert.Pass();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
                if (amount < provider.loanAmountLowerLimit || amount >= provider.loanAmountUpperLimit)
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