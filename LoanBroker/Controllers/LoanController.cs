using LoanBroker.Data;
using Microsoft.AspNetCore.Mvc;

namespace LoanBroker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoanController : ControllerBase
{
    private readonly IBankProviderFactory.IBankProviderFactory factory;
    private IBankProvider.IBankProvider bankProvider;

    public LoanController(IBankProviderFactory.IBankProviderFactory factory)
    {
        this.factory = factory;
    }
    
    [HttpPost("request")]
    public async Task<ActionResult<LoanResponse>> RequestLoan(LoanRequest loanRequest)
    {
        try
        {
            bankProvider = factory.GetBankProvider(loanRequest.BankName);
            var resp = new LoanResponse()
                       {
                           Installments = bankProvider.CalculateLoan(loanRequest.Amount)
                       };
            return Ok(resp);
        }
        catch (KeyNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (ArgumentOutOfRangeException e)
        {
            return BadRequest(e.Message);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }
}