using Finance.Application.Services;
using Finance.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly TransactionService _transactionService;
    
    public TransactionController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
    {
        await _transactionService.AddTransactionAsync(transaction);
        return Ok("Transaction created successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactions()
    {
        var transactions = await _transactionService.GetTransactionsAsync();
        return Ok(transactions);
    }

}