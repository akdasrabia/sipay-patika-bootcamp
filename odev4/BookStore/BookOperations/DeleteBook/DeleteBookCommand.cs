using BookStore.DBOperations;

namespace BookStore.BookOperations.DeleteBook;

public class DeleteBookCommand
{
    public int BookId { get; set; }

    private readonly BookStoreDbContext _dbContext;
    public DeleteBookCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
        if (book == null)
        {
            throw new InvalidOperationException("Silinmek istenen kitap mevcut değil");
        }

        _dbContext.Books.Remove(book);
        _dbContext.SaveChanges();
        
    }
}
