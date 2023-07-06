using System.ComponentModel.DataAnnotations;

namespace Glossary.Api.Models
{
    public class Book
    {
        public Book(string title, string description, string author)
        {
            Title = title;
            Description = description;
            Author = author;
        }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
