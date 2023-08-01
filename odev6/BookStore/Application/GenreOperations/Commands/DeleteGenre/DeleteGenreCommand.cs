using BookStore.DBOperations;

namespace BookStore.Application.GenreOperations.Commands.DeleteBook;

public class DeleteGenreCommand
{
    public int GenreId { get; set; }

    private readonly BookStoreDbContext _dbContext;
    public DeleteGenreCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);
        if (genre == null)
        {
            throw new InvalidOperationException("Silinmek istenen kitap türü mevcut değil");
        }

        _dbContext.Genres.Remove(genre);
        _dbContext.SaveChanges();

    }
}
