using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using webapiASP.Models;

namespace webapiASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableRateLimiting("fixedWindow")]
    public class registrationProgramController : ControllerBase
    {
        private DataContext _db;

        public registrationProgramController(DataContext db)
        {
            _db = db;
        }

        [HttpGet("most-affordable/{regularity}")]
        [Authorize]
        public async Task<IActionResult> GetMostAffordablePrograms(int regularity)
        {
            var programs = await _db.RegistrationProgram
                .Where(p => p.Regularity == regularity)
                .OrderBy(p => p.Price)
                .ToListAsync();

            if (!programs.Any())
            {
                return NotFound(new { message = "Программы с подходящей регулярностью не найдены" });
            }

            return Ok(new { message = "Подходящие программы найдены: ", programs });
        }


        [HttpGet]
        [Authorize]
        public IAsyncEnumerable<RegistrationProgram> GetRegistrationProgram()
        {
            return _db.RegistrationProgram.AsAsyncEnumerable();
        }

        [HttpGet("{id}")]
        [DisableRateLimiting]
        [Authorize]
        public async Task<IActionResult> GetRegistrationProgram(long id)
        {
            RegistrationProgram? prices = await _db.RegistrationProgram.FindAsync(id);
            if (prices == null) return NotFound();
            return Ok(prices);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddAsync([FromBody] RegistrationProgram registrationProgram)
        {
            _db.RegistrationProgram.Add(registrationProgram);
            await _db.SaveChangesAsync();

            return Ok(registrationProgram);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateAsync(long id, [FromBody] RegistrationProgram registrationProgram)
        {
            var existingRegistrationProgram = await _db.RegistrationProgram.FindAsync(id);
            if (existingRegistrationProgram == null)
            {
                return NotFound(); 
            }

            try
            {
                existingRegistrationProgram.ProgramDate = registrationProgram.ProgramDate;
                existingRegistrationProgram.ProgramName = registrationProgram.ProgramName;
                existingRegistrationProgram.Duration = registrationProgram.Duration;
                existingRegistrationProgram.ProgramCode = registrationProgram.ProgramCode;
                existingRegistrationProgram.Regularity = registrationProgram.Regularity;
                existingRegistrationProgram.Price = registrationProgram.Price;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "The record was updated or deleted by another user." });
            }

            return Ok(existingRegistrationProgram);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            var registrationProgram = await _db.RegistrationProgram.FindAsync(id);
            if (registrationProgram == null) return NotFound();

            _db.RegistrationProgram.Remove(registrationProgram);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}

