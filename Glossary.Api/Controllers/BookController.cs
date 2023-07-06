using Glossary.Api.Application.Services.Repositories;
using Glossary.Api.Application.ViewModel;
using Glossary.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Glossary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _bookRepository.GetAll();
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _bookRepository.GetById(id);
            if (result == null)
                return NoContent();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateAsync([FromForm] BookViewModel bookViewModel)
        {
            var result = new Book(bookViewModel.Title, bookViewModel.Description, bookViewModel.Author);
            await _bookRepository.Create(result);
            if (ModelState.IsValid)
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest();
            await _bookRepository.Update(book);
            return Ok(book);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _bookRepository.GetById(id);
            if (result != null)
                await _bookRepository.Delete(result.Id);
            return NoContent();
        }
    }
}
