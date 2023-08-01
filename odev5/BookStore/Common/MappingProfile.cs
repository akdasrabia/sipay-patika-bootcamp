using AutoMapper;
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.Application.AuthorOperations.Queries.GetAuthors;
using BookStore.Application.BookOperations.Queries.GetBooks;
using BookStore.Application.GenreOperations.Queries;
using BookStore.Entities;
using static BookStore.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static BookStore.Application.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;
using static BookStore.Application.AuthorOperations.Queries.GetAuthorDetail.GetAuthorDetailQuery;
using static BookStore.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static BookStore.Application.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using static BookStore.Application.GenreOperations.Queries.GetGenreDetailQuery;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();


            CreateMap<CreateAuthorModel, Author>();
            CreateMap<UpdateAuthorModel, Author>();
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();


        }
    }
}
