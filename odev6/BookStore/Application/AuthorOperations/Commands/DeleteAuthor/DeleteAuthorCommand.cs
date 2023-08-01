using BookStore.DBOperations;

namespace BookStore.Application.AuthorOperations.Commands.DeleteAuthor;

public class DeleteAuthorCommand
{
    public int AuthorId { get; set; }

    private readonly BookStoreDbContext _dbContext;
    public DeleteAuthorCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
        if (author == null)
        {
            throw new InvalidOperationException("Silinmek istenen yazar mevcut değil");
        }

        var book = _dbContext.Books.Where(x => x.AuthorId == AuthorId).SingleOrDefault();
        if (book is not null)
        {
            throw new InvalidOperationException("Silinmek istenen yazarın kitapları mevcut");
        }


        _dbContext.Authors.Remove(author);
        _dbContext.SaveChanges();

    }
}
