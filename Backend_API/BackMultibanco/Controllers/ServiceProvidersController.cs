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
    public class ServiceProvidersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServiceProvidersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceProviders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ServiceProvider>>> GetServiceProviders()
        {
            return await _context.ServiceProviders.ToListAsync();
        }

        // GET: api/ServiceProviders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.ServiceProvider>> GetServiceProvider(int id)
        {
            var serviceProvider = await _context.ServiceProviders.FindAsync(id);

            if (serviceProvider == null)
            {
                return NotFound();
            }

            return serviceProvider;
        }

        // PUT: api/ServiceProviders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceProvider(int id, Models.ServiceProvider serviceProvider)
        {
            if (id != serviceProvider.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceProvider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceProviderExists(id))
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

        // POST: api/ServiceProviders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.ServiceProvider>> PostServiceProvider(Models.ServiceProvider serviceProvider)
        {

            // ----------- Inicio validações -----------------

            if (string.IsNullOrWhiteSpace(serviceProvider.Name) ||
                string.IsNullOrWhiteSpace(serviceProvider.EntityCode) ||
                string.IsNullOrWhiteSpace(serviceProvider.Category))
            {
                return BadRequest(new { mensagem = "Fullfill all the camps!" });
            }

      
            if (serviceProvider.EntityCode.Length != 5)
            {
                return BadRequest(new { mensagem = "Entity must have 9 numbers!" });
            }

            if (!serviceProvider.EntityCode.All(char.IsDigit))
            {
                return BadRequest(new { mensagem = "Entity must contain only letters!" });
            }

            bool entityExists = await _context.ServiceProviders.AnyAsync(s => s.EntityCode == serviceProvider.EntityCode);
            if (entityExists)
            {
                return BadRequest(new { mensagem = "Entity already in use!" });
            }

            if (serviceProvider.Name.Any(char.IsDigit))
            {
                return BadRequest(new { mensagem = "Company name cant haver numbers!" });
            }

            string cleanName = serviceProvider.Name.Trim().ToLower();
            bool nameExists = await _context.ServiceProviders.AnyAsync(s => s.Name.Trim().ToLower() == cleanName);
            if (nameExists)
            {
                return BadRequest(new { mensagem = "Already exists an company with that name!" });
            }

            
            if (!serviceProvider.Category.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                return BadRequest(new { mensagem = "Category cant have numbers or specials characteres" });
            }

            // ----------- Fim validações -----------------
            _context.ServiceProviders.Add(serviceProvider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceProvider", new { id = serviceProvider.Id }, serviceProvider);
        }

        // DELETE: api/ServiceProviders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceProvider(int id)
        {
            var serviceProvider = await _context.ServiceProviders.FindAsync(id);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            _context.ServiceProviders.Remove(serviceProvider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceProviderExists(int id)
        {
            return _context.ServiceProviders.Any(e => e.Id == id);
        }
    }
}
