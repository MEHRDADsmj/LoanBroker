using LoanBroker.Data;

namespace BankProviders.Tests
{
    public class testBankCProvider
    {
        private BankCProvider.BankCProvider provider;
        
        [SetUp]
        public void Setup()
        {
            provider = new BankCProvider.BankCProvider();
        }

        [Test]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(16)]
        [TestCase(20)]
        [TestCase(100)]
        [TestCase(250)]
        [TestCase(500)]
        [TestCase(1000)]
        public void testCalculateLoanSuccess(long amount)
        {
            var loan = PrepareLoan(amount);
            try
            {
                var response = provider.CalculateLoan(loan);
                float sum = response.Sum(res => res * res);

                if (Math.Abs(sum - amount * amount) < 0.1f)
                {
                    Assert.Pass();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }

            Assert.Fail();
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(long.MaxValue)]
        [TestCase(long.MinValue)]
        public void testCalculateLoanFail(long amount)
        {
            var loan = PrepareLoan(amount);
            try
            {
                var response = provider.CalculateLoan(loan);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
                Assert.Pass();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                Assert.Pass();
            }

            Assert.Fail();
        }

        private float PrepareLoan(float amount)
        {
            return amount;
        }
    }
}