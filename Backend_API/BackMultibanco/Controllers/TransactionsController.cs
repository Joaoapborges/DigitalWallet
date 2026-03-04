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
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
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

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {

            // ---------- Inicio validações ----------------

            /*
             Transferência: Precisa de Sender e Receiver. Aplica a taxa de 1€ 
            se os bancos forem diferentes. Tira de um, põe no outro.

            Depósito: Só precisa de Receiver. O dinheiro "aparece" 
            (vem do bolso). O Sender fica a null.

            Levantamento: 
            Só precisa de Sender. O dinheiro "sai" (vai para a mão). O Receiver fica a null.
             */


            if (transaction.Amount <= 0)
            {
                return BadRequest(new { mensagem = "Erro: O valor (Amount) tem de ser maior que zero." });
            }

            
            transaction.CreatedAt = DateTime.UtcNow;
            transaction.Fee = 0; // Começa a zero, muda se for transferência interbancária

            //  buscar os cartões (se os IDs foram enviados)
            //  FindAsync para ser rápido
            var senderCard = await _context.Cards.FindAsync(transaction.SenderCardId);
            var receiverCard = await _context.Cards.FindAsync(transaction.ReceiverCardId);

            // logica dependendo da operação

            switch (transaction.Type.ToLower())
            {
                case "deposit":

                    if (receiverCard != null)
                    {
                        return BadRequest(new { mensagem = "Destination card cant be null!" });
                    }

                    receiverCard.Balance += transaction.Amount;
                    transaction.SenderCardId = null;

                    break;

                case "withdraw":

                    if (senderCard != null)
                    {
                        return BadRequest(new { mensagem = "Origin card cant be null!" });
                    }

                    if (senderCard.Balance < transaction.Amount)
                        return BadRequest(new { mensagem = "You dont have that much money!" });

                    senderCard.Balance -= transaction.Amount;
                    transaction.ReceiverCardId = null;

                    break;

                case "transfer":

                    if (senderCard == null || receiverCard == null)
                    {
                        return BadRequest(new { mensagem = "Its necessary an origin and destination card!" });
                    }

                    if(senderCard.Id == receiverCard.Id)
                    {
                        return BadRequest(new { mensagem = "Reciver and origin card cant be the same!" });
                    }

                    // caso sejam bancos diferentes

                    decimal taxa = 0;

                    if (senderCard.BankId != receiverCard.BankId)
                    {
                        taxa = 1.0m; 
                    }

                    decimal totalATirar = transaction.Amount + taxa;

                    if (senderCard.Balance < totalATirar)
                        return BadRequest(new { mensagem = $"You dont have enough money! Value: {transaction.Amount} + Fee: {taxa}." });

                    // Executar a Transferência
                    senderCard.Balance -= totalATirar; // Tira valor + taxa
                    receiverCard.Balance += transaction.Amount; // Recebe só o valor

                    // Guardar o valor da taxa no histórico para saberes quanto lucraste
                    transaction.Fee = taxa;


                    break;

                default:
                    return BadRequest(new { mensagem = "Type of transaction invalid. Use 'deposit', 'withdraw' ou 'transfer'." });
            }





            // ---------- Fim validações ----------------
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaction", new { id = transaction.Id }, transaction);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
