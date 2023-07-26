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
                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Test",
                        GenreId = 1, //Kişisel gelişim
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 04, 12)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Test 2",
                        GenreId = 2,  //bilim kurgu
                        PageCount = 250,
                        PublishDate = new DateTime(2001, 04, 12)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Test 3",
                        GenreId = 2,
                        PageCount = 300,
                        PublishDate = new DateTime(2001, 04, 12)
                    },
                    new Book
                    {
                        //Id = 4,
                        Title = "Test 4",
                        GenreId = 1, //Kişisel gelişim
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 04, 12)
                    },
                    new Book
                    {
                        //Id = 5,
                        Title = "Test 5",
                        GenreId = 1, //Kişisel gelişim
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 04, 12)
                    }
                    );


                context.SaveChanges();
            }
            
        }
    }
}
