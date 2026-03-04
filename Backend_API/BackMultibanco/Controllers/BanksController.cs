using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackMultibanco.Data;
using BackMultibanco.Models;

namespace BackMultibanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BanksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Banks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank>>> GetBanks()
        {
            return await _context.Banks.ToListAsync();
        }

        // GET: api/Banks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bank>> GetBank(int id)
        {
            var bank = await _context.Banks.FindAsync(id);

            if (bank == null)
            {
                return NotFound();
            }

            return bank;
        }

        // PUT: api/Banks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBank(int id, Bank bank)
        {
            if (id != bank.Id)
            {
                return BadRequest();
            }

            _context.Entry(bank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankExists(id))
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

        // POST: api/Banks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bank>> PostBank(Bank bank)
        {
            // ------------ inicio validaçõess -----------


            if (string.IsNullOrWhiteSpace(bank.Name) ||
                string.IsNullOrWhiteSpace(bank.Code))
            {
                return BadRequest(new { mensagem = "Fullfill all the camps!" });
            }

            if (!bank.Code.All(char.IsDigit))
            {
                return BadRequest(new { mensagem = "Error: Bank Code must contain only numbers!" });
            }

            if (bank.Code.Length != 3)
            {
                return BadRequest(new { mensagem = "Bank code must have only 3 numbers!" });

            }

            bool CodeExists = await _context.Banks.AnyAsync(b => b.Code == bank.Code);
            if (CodeExists)
            {
                return BadRequest(new { mensagem = "Bank Code already exists!" });
            }

            string cleanName = bank.Name.Trim().ToLower();

            bool NameExists = await _context.Banks.AnyAsync(b => b.Name.Trim().ToLower() == cleanName);
            if (NameExists)
            {
                return BadRequest(new { mensagem = "Bank Name already exists!" });
            }

            // ------------ fim validaçõess -----------


            _context.Banks.Add(bank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBank", new { id = bank.Id }, bank);
        }

        // DELETE: api/Banks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank(int id)
        {
            var bank = await _context.Banks.FindAsync(id);
            if (bank == null)
            {
                return NotFound();
            }

            _context.Banks.Remove(bank);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BankExists(int id)
        {
            return _context.Banks.Any(e => e.Id == id);
        }
    }
}
