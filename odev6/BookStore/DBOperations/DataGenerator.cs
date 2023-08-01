using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
           using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre { Name = "Personal Growth" },
                    new Genre { Name = "Science Fiction" },
                    new Genre { Name = "Romance" });

                context.Authors.AddRange(
                    new Author { Name = "Adam", Surname = "Fawer", DateOfBirth = new DateTime(1945, 04, 12) },
                    new Author { Name = "Murat", Surname = "Menteş", DateOfBirth = new DateTime(1975, 05, 10) },
                    new Author { Name = "Franz", Surname = "Kafka", DateOfBirth = new DateTime(1945, 04, 12) },
                    new Author { Name = "Halil", Surname = "Cibran", DateOfBirth = new DateTime(1945, 04, 12) },
                    new Author { Name = "Peyami", Surname = "Safa", DateOfBirth = new DateTime(1945, 04, 12) }
                    );


                context.Books.AddRange(
                    new Book
                    {
                        Title = "Test",
                        GenreId = 1, //Kişisel gelişim
                        PageCount = 200,
                        AuthorId = 1,
                        PublishDate = new DateTime(2001, 04, 12)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Test 2",
                        GenreId = 2,  //bilim kurgu
                        PageCount = 250,
                        AuthorId = 2,
                        PublishDate = new DateTime(2001, 04, 12)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Test 3",
                        GenreId = 2,
                        PageCount = 300,
                        AuthorId = 5,
                        PublishDate = new DateTime(2001, 04, 12)
                    },
                    new Book
                    {
                        //Id = 4,
                        Title = "Test 4",
                        GenreId = 1, //Kişisel gelişim
                        PageCount = 200,
                        AuthorId = 3,
                        PublishDate = new DateTime(2001, 04, 12)
                    },
                    new Book
                    {
                        //Id = 5,
                        Title = "Test 5",
                        GenreId = 1, //Kişisel gelişim
                        PageCount = 200,
                        AuthorId = 2,
                        PublishDate = new DateTime(2001, 04, 12)
                    }
                    );


                context.SaveChanges();
            }
            
        }
    }
}
