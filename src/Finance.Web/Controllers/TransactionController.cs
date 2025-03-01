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
    public async Task<IActionResult> CreateTransaction([FromBody] Transaction? transaction)
    {
        await _transactionService.AddTransactionAsync(transaction);
        return Ok("Transaction created successfully!");
    }
    
    [HttpPatch]
    public async Task<IActionResult> UpdateTransaction([FromBody] Transaction transaction)
    {
        await _transactionService.UpdateTransactionAsync(transaction);
        return Ok("Transaction updated successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactions()
    {
        var transactions = await _transactionService.GetTransactionsAsync();
        return Ok(transactions);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransactionsById(Guid id)
    {
        var transaction = await _transactionService.GetTransactionByIdAsync(id);
        
        if (transaction == null)
        {
            return NotFound();
        }

        return Ok(transaction);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransactions(Guid id)
    {
        await _transactionService.DeleteTransactionAsync(id);
        return Ok("Transaction delete successfully!");
    }

}