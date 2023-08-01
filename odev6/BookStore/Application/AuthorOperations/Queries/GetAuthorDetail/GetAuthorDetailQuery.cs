using AutoMapper;
using BookStore.DBOperations;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;

public class GetAuthorDetailQuery
{
    public int AuthorId { get; set; }

    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public AuthorDetailViewModel Handle()
    {
        var author = _dbContext.Authors.Where(x => x.Id == AuthorId).SingleOrDefault();
        if(author is null)
        {
            throw new InvalidOperationException("Yazar bulunamadı");
        }
        AuthorDetailViewModel viewModel = _mapper.Map<AuthorDetailViewModel>(author);
        return viewModel;
    }
    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

