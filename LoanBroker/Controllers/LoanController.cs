using LoanBroker.Data;
using Microsoft.AspNetCore.Mvc;

namespace LoanBroker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoanController : ControllerBase
{
    private IBankProvider.IBankProvider bankProvider;

    public LoanController()
    {
        
    }
    
    [HttpGet("/")]
    public async Task<ActionResult<LoanResponse>> RequestLoan(LoanRequest loanRequest)
    {
        var resp = bankProvider.CalculateLoan(loanRequest);
        return Ok(resp);
    }
}