using Glossary.Api.Data;
using Glossary.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Glossary.Api.Application.Services.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> Create(Book book)
        {
            _context.books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task Delete(int id)
        {
            var book = await _context.books.FindAsync(id);
            if (book != null)
            {
                _context.books.Remove(book);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.books.ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            var book = await _context.books.FindAsync(id);
            if (book != null)
                return book;
            return null;
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
