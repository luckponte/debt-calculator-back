using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using debt_calculator_api.Data;
using debt_calculator_api.Models;

namespace debt_calculator_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtsController : ControllerBase
    {
        private readonly DataContext _context;

        public DebtsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Debts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Debts>>> GetDebts()
        {
            return await _context.Debts.ToListAsync();
        }

        // GET: api/Debts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Debts>> GetDebts(int id)
        {
            var debts = await _context.Debts.FindAsync(id);

            if (debts == null)
            {
                return NotFound();
            }

            return debts;
        }

        // PUT: api/Debts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDebts(int id, Debts debts)
        {
            if (id != debts.debtId)
            {
                return BadRequest();
            }

            _context.Entry(debts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DebtsExists(id))
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

        // POST: api/Debts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Debts>> PostDebts(Debts debts)
        {
            _context.Debts.Add(debts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDebts", new { id = debts.debtId }, debts);
        }

        // DELETE: api/Debts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Debts>> DeleteDebts(int id)
        {
            var debts = await _context.Debts.FindAsync(id);
            if (debts == null)
            {
                return NotFound();
            }

            _context.Debts.Remove(debts);
            await _context.SaveChangesAsync();

            return debts;
        }

        private bool DebtsExists(int id)
        {
            return _context.Debts.Any(e => e.debtId == id);
        }
    }
}
