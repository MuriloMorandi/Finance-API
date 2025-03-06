using Finance.Application.Services;
using Finance.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionCategoryController : ControllerBase
{
    private readonly TransactionCategoryService _transactionCategoryService;
    
    public TransactionCategoryController(TransactionCategoryService transactionCategoryServiceService)
    {
        _transactionCategoryService = transactionCategoryServiceService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTransactionCatergory([FromBody] TransactionCategory? transactionCategory)
    {
        await _transactionCategoryService.AddTransactionAsync(transactionCategory);
        return Ok("Transaction created successfully!");
    }
    
    [HttpPatch]
    public async Task<IActionResult> UpdateTransactionCategory([FromBody] TransactionCategory transactionCategory)
    {
        await _transactionCategoryService.UpdateTransactionAsync(transactionCategory);
        return Ok("Transaction updated successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactionsCatergory()
    {
        var transactions = await _transactionCategoryService.GetTransactionsAsync();
        return Ok(transactions);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransactionsCategoryById(Guid id)
    {
        var transaction = await _transactionCategoryService.GetTransactionByIdAsync(id);
        
        if (transaction == null)
        {
            return NotFound();
        }

        return Ok(transaction);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransactionsCategory(Guid id)
    {
        await _transactionCategoryService.DeleteTransactionAsync(id);
        return Ok("Transaction Caategory delete successfully!");
    }

}