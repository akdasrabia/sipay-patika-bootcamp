using BookStore.DBOperations;
using BookStore.Entities;

namespace BookStore.Application.GenreOperations.Commands.UpdateBook;

public class UpdateGenreCommand
{
    public UpdateGenreModel Model { get; set; }
    public int GenreId { get; set; }

    private readonly BookStoreDbContext _dbContext;
    public UpdateGenreCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);
        if (genre == null)
        {
            throw new InvalidOperationException("Güncellenmek istenen kitap türü mevcut değil");
        }

        Console.WriteLine("1" + genre.Name);
        Console.WriteLine("2" + Model.Name);

        Console.WriteLine(genre.Name = Model.Name != default ? Model.Name : genre.Name);

        genre.Name = Model.Name != default ? Model.Name : genre.Name;
        _dbContext.SaveChanges();

    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
    }

}
