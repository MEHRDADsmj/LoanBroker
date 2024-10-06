namespace BankProviderFactory.Tests;

public class testBankProviderFactory
{
    private BankProviderFactory factory;
    
    [SetUp]
    public void Setup()
    {
        factory = new BankProviderFactory();
    }

    [Test]
    [TestCase("bank_a")]
    [TestCase("Bank_A")]
    [TestCase("BANK_A")]
    [TestCase("BANK_b")]
    [TestCase("BANK_C")]
    public void testGetBankProviderSuccess(string bankName)
    {
        var provider = factory.GetBankProvider(bankName);
        Assert.IsNotNull(provider);
    }
    
    [Test]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("loremIpsum")]
    public void testGetBankProviderFailure(string bankName)
    {
        try
        {
            var provider = factory.GetBankProvider(bankName);
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
            Assert.Pass();
        }

        Assert.Fail();
    }
}