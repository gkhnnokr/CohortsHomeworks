﻿using AutoMapper;
using BookStore.DbOperation;
using BookStore.DBOperation;

namespace BookStore.Application.GenreOperations.Queries.GetGenres;

public class GetGenreDetailQuery
{
    public int GenreId { get; set; }

    public readonly IBookStoreDbContext _context;

    public readonly IMapper _mapper;
    public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GenreDetailViewModel Handle()
    {
        var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
        if (genre == null)
            throw new InvalidOperationException("Kitap Bulunamadı.");
        return _mapper.Map<GenreDetailViewModel>(genre);
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
