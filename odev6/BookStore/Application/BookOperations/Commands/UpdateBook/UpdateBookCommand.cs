﻿using BookStore.DBOperations;

namespace BookStore.Application.BookOperations.Commands.UpdateBook;

public class UpdateBookCommand
{
    public UpdateBookModel Model { get; set; }
    public int BookId { get; set; }

    private readonly BookStoreDbContext _dbContext;
    public UpdateBookCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
        if (book == null)
        {
            throw new InvalidOperationException("Güncellenmek istenen kitap mevcut değil");
        }

        book.Title = Model.Title != default ? Model.Title : book.Title;
        book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
        book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
        book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
        _dbContext.SaveChanges();

    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }

}
