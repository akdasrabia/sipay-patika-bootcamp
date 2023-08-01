using AutoMapper;
using BookStore.Application.BookOperations.Commands.CreateBook;
using BookStore.Application.BookOperations.Commands.DeleteBook;
using BookStore.Application.BookOperations.Commands.UpdateBook;
using BookStore.Application.BookOperations.Queries.GetBookDetail;
using BookStore.Application.BookOperations.Queries.GetBooks;
using BookStore.Application.GenreOperations.Commands.CreateBook;
using BookStore.Application.GenreOperations.Commands.DeleteBook;
using BookStore.Application.GenreOperations.Commands.UpdateBook;
using BookStore.Application.GenreOperations.Queries;
using BookStore.Application.GenreOperations.Queries.GetGenreDetail;
using BookStore.DBOperations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookStore.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static BookStore.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using static BookStore.Application.GenreOperations.Commands.CreateBook.CreateGenreCommand;
using static BookStore.Application.GenreOperations.Commands.UpdateBook.UpdateGenreCommand;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Console.WriteLine(id);
            GetGenreDetailQuery.GenreDetailViewModel result = new GetGenreDetailQuery.GenreDetailViewModel();
            try
            {
                GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
                query.GenreId = id;
                GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
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
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            try
            {
                command.Model = newGenre;
                CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
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
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updatedGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            try
            {
                UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();

                command.GenreId = id;
                command.Model = updatedGenre;
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
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            try
            {
                command.GenreId = id;
                DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
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
