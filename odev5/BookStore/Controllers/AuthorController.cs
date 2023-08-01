using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.CreateAuthor;
using BookStore.Application.AuthorOperations.Commands.DeleteAuthor;
using BookStore.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.Application.AuthorOperations.Queries.GetAuthors;
using BookStore.Application.BookOperations.Queries.GetBookDetail;
using BookStore.Application.BookOperations.Queries.GetBooks;
using BookStore.Application.GenreOperations.Commands.CreateBook;
using BookStore.Application.GenreOperations.Commands.DeleteBook;
using BookStore.Application.GenreOperations.Commands.UpdateBook;
using BookStore.DBOperations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookStore.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static BookStore.Application.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;
using static BookStore.Application.GenreOperations.Commands.CreateBook.CreateGenreCommand;
using static BookStore.Application.GenreOperations.Commands.UpdateBook.UpdateGenreCommand;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetAuthorDetailQuery.AuthorDetailViewModel result = new GetAuthorDetailQuery.AuthorDetailViewModel();
            try
            {
                GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
                query.AuthorId = id;
                GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            Console.WriteLine(newAuthor.Surname);
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            try
            {
                command.Model = newAuthor;
                CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updated)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            try
            {
                UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
                command.AuthorId = id;
                command.Model = updated;
                ValidationResult results = validator.Validate(command);

                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            try
            {
                command.AuthorId = id;
                DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
