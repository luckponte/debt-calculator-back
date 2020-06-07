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
            bool v = context.Database.EnsureCreated();
            _context = context;
        }

        // GET: api/Debts/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetDebts(int userId)
        {
            var debts = await (
                from d in _context.Debts 
                select new CalculatedDebts
                {
                    debtId = d.debtId,
                    deadlineDate = d.deadlineDate,
                    debtValue = d.debtValue,
                    phone = d.phone,
                    userId = d.userId,
                }).Where(d=> d.userId == userId).ToListAsync();
            var conf = await _context.Configs.FirstAsync();

            if (debts == null)
            {
                return NotFound();
            }

            // Realiza os cálculos de atualização da dívida
            long delay;
            foreach (var debt in debts)
            {
                debt.maxParcels = conf.maxParcels;

                delay = ((long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds) - debt.deadlineDate;

                if(delay <= 0)
                {
                    delay = 0;
                }

                debt.interestValue = (conf.interestRate) * ( delay/86400000) * debt.debtValue;
                debt.finalValue = debt.interestValue + debt.debtValue;
            }

            return Ok(debts);
        }
        
        private bool DebtsExists(int id)
        {
            return _context.Debts.Any(e => e.debtId == id);
        }
    }
}
