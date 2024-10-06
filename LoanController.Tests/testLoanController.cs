using LoanBroker.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LoanController.Tests;

public class testLoanController
{
    private LoanBroker.Controllers.LoanController controller;
    private Mock<IBankProviderFactory.IBankProviderFactory> factory;
    private Mock<IBankProvider.IBankProvider> provider;

    [SetUp]
    public void Setup()
    {
        provider = new Mock<IBankProvider.IBankProvider>();
        provider.Setup(provider => provider.CalculateLoan(It.IsAny<float>())).Returns(new List<float>() { 10.0f, 10.0f });
        factory = new Mock<IBankProviderFactory.IBankProviderFactory>();
        factory.Setup(factory => factory.GetBankProvider("bank_a")).Returns(provider.Object);
        factory.Setup(factory => factory.GetBankProvider("bank_b")).Returns(provider.Object);
        factory.Setup(factory => factory.GetBankProvider("bank_c")).Returns(provider.Object);
        controller = new LoanBroker.Controllers.LoanController(factory.Object);
    }

    [Test]
    [TestCase(10.0f, "bank_a")]
    [TestCase(10.0f, "bank_b")]
    [TestCase(10.0f, "bank_c")]
    public async Task testRequestLoan(float amount, string bankName)
    {
        var req = new LoanRequest()
                  {
                      Amount = amount,
                      BankName = bankName,
                  };
        var response = await controller.RequestLoan(req);
        var result = (OkObjectResult)response.Result!;
        Assert.IsInstanceOf<LoanResponse>(result.Value!);
    }
}