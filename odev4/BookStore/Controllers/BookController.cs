using AutoMapper;
using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBook;
using BookStore.BookOperations.GetBook;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.UpdateBook;
using BookStore.DBOperations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.BookOperations.GetBook.GetBookDetailQuery;
using static BookStore.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
      
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookDetailQuery.BookDetailViewModel result = new GetBookDetailQuery.BookDetailViewModel();
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //[HttpGet]
        //public Book Get([FromQuery] string id)
        //{
        //    var book = BookList.Where(x => x.Id == Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //}

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
    
                command.Handle();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }  
        }

        [HttpPut]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {

            
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
              
                command.BookId = id;
                command.Model = updatedBook;
                ValidationResult results = validator.Validate(command);
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) 
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            try
            {
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
