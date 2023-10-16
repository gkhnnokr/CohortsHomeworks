using AutoMapper;
using BookStore.Application.AutorOperations.Queries.GetAuthorDetail;
using BookStore.Application.AutorOperations.Queries.GetAutors;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.GetBooks;
using BookStore.Entities;
using static BookStore.Application.GenreOperations.Queries.GetGenres.GetGenreDetailQuery;
using static BookStore.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;
using static BookStore.BooksOperations.CreateBook.CreateBookCommand;

namespace BookStore.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookModel, Book>();
        CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
        CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
        CreateMap<Genre, GenresViewModel>();
        CreateMap<Genre, GenreDetailViewModel>();
        CreateMap<Author, AuthorsViewModel>();
        CreateMap<Author, AuthorDetailViewModel>();
    }
}
