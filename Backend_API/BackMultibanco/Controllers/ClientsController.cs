using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackMultibanco.Data;
using BackMultibanco.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BackMultibanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {

            // ----------- Inicio validações -----------------

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                if (string.IsNullOrWhiteSpace(client.Name) ||
               string.IsNullOrWhiteSpace(client.Nif) ||
               string.IsNullOrWhiteSpace(client.Password) ||
               string.IsNullOrWhiteSpace(client.Email))
                {
                    return BadRequest(new { mensagem = "Fullfill all the camps!" });
                }


                bool EmailExists = await _context.Clients.AnyAsync(c => c.Email == client.Email);
                if (EmailExists)
                {
                    return BadRequest(new { mensagem = "Email already exists!" });
                }


                bool NifExists = await _context.Clients.AnyAsync(c => c.Nif == client.Nif);
                if (NifExists)
                {
                    return BadRequest(new { mensagem = "NIF already exists!" });
                }

                if (client.Password.Length < 4)
                {
                    return BadRequest(new { mensagem = "Password length must have 4 or more characters" });
                }

                if (client.Nif.Length != 9)
                {
                    return BadRequest(new { mensagem = "NIF must have 9 numbers!" });
                }

                if (!client.Nif.All(char.IsDigit))
                {
                    return BadRequest(new { mensagem = "NIF only contains numbers!" });
                }

                if (!client.Email.Contains("@") || !client.Email.Contains("."))
                {
                    return BadRequest(new { mensagem = "Email must have '@' and '.'!" });
                }


                // ------------- fim validações -------------------
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();

                // criar a conta


                Account newAccount = new Account
                {
                    ClientId = client.Id,
                    CreatedAt = DateTime.UtcNow
                };

                // fim criar conta
                _context.Accounts.Add(newAccount);
                await _context.SaveChangesAsync();

                // criar cartão

                int meuBancoId = 1;
                var bancoDaApp = await _context.Banks.FindAsync(meuBancoId);

                Random random = new Random();

                string randomCard = "";
                for (int i = 0; i < 12; i++) { randomCard += random.Next(0, 10).ToString(); }

                Card newCard = new Card
                {
                    AccountId = newAccount.Id,

                    BankId = meuBancoId,

                    Number = bancoDaApp.Code + randomCard,

                    Type = "Digital",

                    Balance = 50
                };

                // fim de criar cartão

                _context.Cards.Add(newCard);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return CreatedAtAction("GetClient", new { id = client.Id }, client);
            
            }

            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                var innerMessage = ex.InnerException != null ? ex.InnerException.Message : "";
                return BadRequest(new
                {
                    mensagem = "Error in DataBase!",
                    detalhe = ex.Message,
                    segredo = innerMessage 
                });
            }
        }

           

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
