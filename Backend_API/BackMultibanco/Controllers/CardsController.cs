using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackMultibanco.Data;
using BackMultibanco.Models;
using Microsoft.AspNetCore.Authorization; 
using System.Security.Claims;

namespace BackMultibanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cards
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards()
        {

            
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                          ?? User.FindFirst("sub")?.Value;

            if (string.IsNullOrEmpty(claimId))
            {
                return Unauthorized(new { mensagem = "User not find." });
            }

            int meuClientId = int.Parse(claimId);

            
            var meusCartoes = await _context.Cards
                .Include(c => c.Account) 
                .Where(c => c.Account.ClientId == meuClientId)
                .ToListAsync();

            return Ok(meusCartoes);
        }

        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            var card = await _context.Cards.FindAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return card;
        }

        // PUT: api/Cards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }

            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
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

        // POST: api/Cards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card card)
        {

            //-------------- Inicio validações-------------

            var account = await _context.Accounts.FindAsync(card.AccountId);
            if (account == null)
            {
                return BadRequest(new { mensagem = "This account doesnt exist!" });
            }

            var bank = await _context.Banks.FindAsync(card.BankId);
            if (bank == null)
            {
                return BadRequest(new { mensagem = "This Bank doesnt exist!" });
            }


            //-------------- Fim validações-------------

            // --- criação cartão ---

            Random random = new Random();
            string randomNumbers = "";

            for (int i = 0; i < 12; i++) { randomNumbers += random.Next(0, 10).ToString(); }

            card.Number = bank.Code + randomNumbers;

            if (string.IsNullOrWhiteSpace(card.Type))
            {
                card.Type = "Externo";
            }

            _context.Cards.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCard", new { id = card.Id }, card);
        }

        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }
    }
}
