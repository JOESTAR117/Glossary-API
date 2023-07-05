using Glossary.Api.Models;

namespace Glossary.Api.Services.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<Book> Create(Book book);
        Task Update (Book book);
        Task Delete (int id);

        
    }
}
