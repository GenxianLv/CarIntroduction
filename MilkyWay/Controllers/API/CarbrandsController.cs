using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkyWay.Data;
using MilkyWay.Models;

namespace MilkyWay.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarbrandsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarbrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api
        [HttpGet("{id}/cars")]
        public async Task<IActionResult> GetCars(string id)
        {
            var carbrands = await _context.Carbrands
               .Include(t => t.Cars)
               .FirstOrDefaultAsync(i => i.Name == id);

            if (carbrands == null)
                return NotFound();

            return Ok(carbrands.Cars);
        }

        // GET: api/Carbrands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carbrand>>> GetCarbrands()
        {
            return await _context
                .Carbrands
                .Include(c => c.Cars)
                .ToListAsync();
        }


        // PUT: api/Carbrands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarbrand(string id, Carbrand carbrand)
        {
            if (id != carbrand.Name)
            {
                return BadRequest();
            }

            _context.Entry(carbrand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarbrandExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Carbrands
        [HttpPost]
        public async Task<ActionResult<Carbrand>> PostCarbrand(Carbrand carbrand)
        {
            _context.Carbrands.Add(carbrand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarbrand", new { id = carbrand.Name }, carbrand);
        }

        // DELETE: api/Carbrands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Carbrand>> DeleteCarbrand(string id)
        {
            var carbrand = await _context.Carbrands.FindAsync(id);
            if (carbrand == null)
            {
                return NotFound();
            }

            _context.Carbrands.Remove(carbrand);
            await _context.SaveChangesAsync();

            return carbrand;
        }

        private bool CarbrandExists(string id)
        {
            return _context.Carbrands.Any(e => e.Name == id);
        }
    }
}
