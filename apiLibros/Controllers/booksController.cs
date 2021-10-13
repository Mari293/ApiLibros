using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiLibros.Data;
using apiLibros.Models;

namespace apiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        private readonly apiLibrosContext _context;

        public booksController(apiLibrosContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<book>>> Getbook()
        {
            return await _context.book.ToListAsync();
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<book>> Getbook(int id)
        {
            var book = await _context.book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbook(int id, book book)
        {
            if (id != book.id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookExists(id))
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

        // POST: api/books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<book>> Postbook(book book)
        {
            _context.book.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbook", new { id = book.id }, book);
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebook(int id)
        {
            var book = await _context.book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.book.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool bookExists(int id)
        {
            return _context.book.Any(e => e.id == id);
        }
    }
}
