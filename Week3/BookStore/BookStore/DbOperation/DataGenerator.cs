﻿using BookStore;
using BookStore.DBOperation;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

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

            context.Authors.AddRange(
                new Author
                {
                    Name = "GGGG",
                    Surname = "bbbbbb"
                },
                new Author
                {
                    Name = "OOOOO",
                    Surname = "bbbbbb"
                },
                new Author
                {
                    Name = "MMMMM",
                    Surname = "bbbbbb"
                }
            );


            context.Genres.AddRange(
                new Genre
                {
                    Name = "Personal Growth"
                },
                new Genre
                {
                    Name = "Science Fiction"
                },
                new Genre
                {
                    Name = "Romance"
                }
            );

            context.Books.AddRange(
                new Book
                {
                    // Id = 1,
                    Title = "Lean Startup",
                    GenreId = 1, // Personal Growth
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12)
                },
                new Book
                {
                    // Id = 2,
                    Title = "Lord Of The Rings",
                    GenreId = 2, // Science Fiction
                    PageCount = 250,
                    PublishDate = new DateTime(2010, 05, 23)
                },
                new Book
                {
                    // Id = 3,
                    Title = "Dune",
                    GenreId = 2, // Science Fiction
                    PageCount = 540,
                    PublishDate = new DateTime(2001, 12, 21)
                }
            );

            context.SaveChanges();
        }
    }
}