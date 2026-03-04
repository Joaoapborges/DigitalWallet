using BackMultibanco.Data;
using BackMultibanco.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BackMultibanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicePaymentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ServicePayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicePayment>>> GetServicePayments()
        {
            return await _context.ServicePayments.ToListAsync();
        }

        // GET: api/ServicePayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicePayment>> GetServicePayment(int id)
        {
            var servicePayment = await _context.ServicePayments.FindAsync(id);

            if (servicePayment == null)
            {
                return NotFound();
            }

            return servicePayment;
        }

        // PUT: api/ServicePayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicePayment(int id, ServicePayment servicePayment)
        {
            if (id != servicePayment.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicePayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicePaymentExists(id))
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

        // POST: api/ServicePayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServicePayment>> PostServicePayment(int cardId, decimal amount, ServicePayment servicePayment)
        {
            using var transactionScope = await _context.Database.BeginTransactionAsync();

           
            try
            {

                if (amount <= 0) return BadRequest(new { mensagem = "Amount must be > 0." });

                if (servicePayment.Reference.Length != 9 || !servicePayment.Reference.All(char.IsDigit))
                {
                    return BadRequest(new { mensagem = "Reference must have 9 digits!" });
                }

                // VERIFICAR SE O FORNECEDOR EXISTE
                var provider = await _context.ServiceProviders.FindAsync(servicePayment.ServiceProviderId);
                if (provider == null) return BadRequest(new { mensagem = "Provider doesnt exist." });

                // VERIFICAR CARTÃO E SALDO
                var card = await _context.Cards.FindAsync(cardId);
                if (card == null) return BadRequest(new { mensagem = "Card not found." });
                if (card.Balance < amount) return BadRequest(new { mensagem = "Saldo insuficiente." });

                // CRIAR  histórico
                BackMultibanco.Models.Transaction newTransaction = new BackMultibanco.Models.Transaction
                {
                    Amount = amount,
                    Type = "Service Payment",
                    Description = $"Payment to {provider.Name} (Ref: {servicePayment.Reference})",
                    CreatedAt = DateTime.UtcNow,
                    SenderCardId = cardId,
                    ReceiverCardId = null // Dinheiro sai do sistema para o fornecedor
                };

                _context.Transactions.Add(newTransaction);
                await _context.SaveChangesAsync();

                // ATUALIZAR SALDO DO CARTÃO
                card.Balance -= amount;

                // CRIAR O REGISTO DO PAGAMENTO
                servicePayment.TransactionId = newTransaction.Id;
                servicePayment.Entity = provider.EntityCode;

                _context.ServicePayments.Add(servicePayment);
                await _context.SaveChangesAsync();

                await transactionScope.CommitAsync();

                return CreatedAtAction("GetServicePayment", new { id = servicePayment.Id }, servicePayment);
            }
            catch (Exception ex)
            {
                await transactionScope.RollbackAsync();
                return BadRequest(new { mensagem = "payment error: " + ex.Message });
            }
        }

        // DELETE: api/ServicePayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicePayment(int id)
        {
            var servicePayment = await _context.ServicePayments.FindAsync(id);
            if (servicePayment == null)
            {
                return NotFound();
            }

            _context.ServicePayments.Remove(servicePayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicePaymentExists(int id)
        {
            return _context.ServicePayments.Any(e => e.Id == id);
        }
    }
}
