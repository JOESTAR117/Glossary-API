using Glossary.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Glossary.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> books { get; set; }
    }
}
