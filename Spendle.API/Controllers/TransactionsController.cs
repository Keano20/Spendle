using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spendle.API.Data;
using Spendle.API.Models;
using System.Threading.Tasks;

namespace Spendle.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly SpendleDbContext _context;

    public TransactionsController(SpendleDbContext context)
    {
        _context = context;
    }

    // 1. Fetches transactions
    [HttpGet]
    public async Task<IActionResult> GetTransactions()
    {
        // Actually grabs the data from Azure!
        var transactions = await _context.Transactions
            .OrderByDescending(t => t.Date)
            .ToListAsync();
            
        return Ok(transactions);
    }

    // 2. Adds transactions
    [HttpPost]
    public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction)
    {
        if (transaction == null) return BadRequest("Transaction data is missing.");

        // Save to Azure
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return Ok(new { 
            message = "Transaction added successfully!", 
            transaction = transaction 
        });
    }
}