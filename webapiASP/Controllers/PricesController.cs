using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using webapiASP.Models;
using Microsoft.EntityFrameworkCore;

namespace webapiASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableRateLimiting("fixedWindow")]
    public class PricesController : ControllerBase
    {
        private DataContext _db;

        public PricesController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Authorize]
        public IAsyncEnumerable<Prices> GetPrices()
        {
            return _db.Prices.AsAsyncEnumerable();
        }

        [HttpGet("{id}")]
        [DisableRateLimiting]
        [Authorize]
        public async Task<IActionResult> GetPrice(long id)
        {
            Prices? prices = await _db.Prices.FindAsync(id);
            if (prices == null) return NotFound();
            return Ok(prices);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddAsync([FromBody] Prices price)
        {
            _db.Prices.Add(price);
            await _db.SaveChangesAsync();

            return Ok(price);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateAsync(long id, [FromBody] Prices price)
        {
            var existingPrice = await _db.Prices.FindAsync(id);
            if (existingPrice == null)
            {
                return NotFound(); 
            }

            try
            {
                existingPrice.ProgramCode = price.ProgramCode;
                existingPrice.ProgramName = price.ProgramName;
                existingPrice.MinutePrice = price.MinutePrice;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "The record was updated or deleted by another user." });
            }

            return Ok(existingPrice);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            var price = await _db.Prices.FindAsync(id);
            if (price == null) return NotFound();
            
            var registrationPrograms = _db.RegistrationProgram.Where(rp => rp.Prices.PricesId == id);
            _db.RegistrationProgram.RemoveRange(registrationPrograms);
            
            _db.Prices.Remove(price);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}