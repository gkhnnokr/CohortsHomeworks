﻿using AutoMapper;
using BookStore.Common;
using BookStore.DbOperation;
using BookStore.DBOperation;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BookOperations.GetBookDetail;

public class GetBookDetailQuery
{

    private readonly IBookStoreDbContext _dbContext;

    private readonly IMapper _mapper;

    public int BookId { set; get; }
    public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public BookDetailViewModel Handle()
    {
        var book = _dbContext.Books.Include(x => x.Genre).Where(book => book.Id == BookId).SingleOrDefault();

        if (book is null)
            throw new InvalidOperationException("Kitap Bulunamadı");

        BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
        return vm;
    }
}

public class BookDetailViewModel
{
    public string Title { get; set; }

    public string Genre { get; set; }

    public int PageCount { get; set; }

    public string PublishDate { get; set; }
}
