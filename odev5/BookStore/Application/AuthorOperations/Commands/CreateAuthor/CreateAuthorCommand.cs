using AutoMapper;
using BookStore.Application.BookOperations.Commands.CreateBook;
using BookStore.DBOperations;
using BookStore.Entities;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor;

public class CreateAuthorCommand
{
    public CreateAuthorModel Model { get; set; }
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public void Handle()
    {
        var author = _mapper.Map<Author>(Model);
        _dbContext.Authors.Add(author);
        _dbContext.SaveChanges();
    }
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}


