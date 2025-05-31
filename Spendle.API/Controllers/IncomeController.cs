using Microsoft.AspNetCore.Mvc;
using Spendle.API.Models;

namespace Spendle.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController : ControllerBase
    {
        private static readonly List<Income> _incomes = new();

        [HttpGet]
        public ActionResult<IEnumerable<Income>> Get() => Ok(_incomes);

        [HttpPost]
        public ActionResult<Income> Create([FromBody] Income income)
        {
            _incomes.Add(income);
            return CreatedAtAction(nameof(Get), new { id = income.Id }, income);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var income = _incomes.FirstOrDefault(income => income.Id == id);
            if (income == null) return NotFound();

            _incomes.Remove(income);
            return NoContent();
        }
    }
}