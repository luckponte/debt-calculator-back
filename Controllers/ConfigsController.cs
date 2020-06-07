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
    public class ConfigsController : ControllerBase
    {
        private readonly DataContext _context;

        public ConfigsController(DataContext context)
        {
            bool v = context.Database.EnsureCreated();
            _context = context;
        }

        // GET: api/Configs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Configs>>> GetConfigs()
        {
            return await _context.Configs.ToListAsync();
        }

        // GET: api/Configs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Configs>> GetConfigs(int id)
        {
            var configs = await _context.Configs.FindAsync(id);

            if (configs == null)
            {
                return NotFound();
            }

            return configs;
        }

        // PUT: api/Configs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfigs(int id, Configs configs)
        {
            if (id != configs.configId)
            {
                return BadRequest();
            }

            _context.Entry(configs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigsExists(id))
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

        // POST: api/Configs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Configs>> PostConfigs(Configs configs)
        {
            _context.Configs.Add(configs);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConfigs), new { id = configs.configId }, configs);
        }

        // DELETE: api/Configs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Configs>> DeleteConfigs(int id)
        {
            var configs = await _context.Configs.FindAsync(id);
            if (configs == null)
            {
                return NotFound();
            }

            _context.Configs.Remove(configs);
            await _context.SaveChangesAsync();

            return configs;
        }

        private bool ConfigsExists(int id)
        {
            return _context.Configs.Any(e => e.configId == id);
        }
    }
}
