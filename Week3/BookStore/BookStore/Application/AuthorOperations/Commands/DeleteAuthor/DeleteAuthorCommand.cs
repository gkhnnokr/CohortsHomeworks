﻿using BookStore.DbOperation;
using BookStore.DBOperation;

namespace BookStore.Application.AutorOperations.Commands.DeleteAutor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Silinecek Yazar Bulunamadı!!");
            }

            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}
