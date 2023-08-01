using AutoMapper;
using BookStore.Common;
using BookStore.DBOperations;
using System.Data.Entity;
using System.Runtime.Intrinsics.X86;

namespace BookStore.Application.BookOperations.Queries.GetBookDetail;

public class GetBookDetailQuery
{
    public int BookId { get; set; }

    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public BookDetailViewModel Handle()
    {
        var book = _dbContext.Books.Include(x => x.Genre).Where(book => book.Id == BookId).SingleOrDefault();
        if (book is null)
        {
            throw new InvalidOperationException("Kitap bulunamadı");
        }
        BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);

        return vm;
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }

}
