﻿using AutoMapper;
using BookStore.DbOperation;
using BookStore.DBOperation;
using BookStore.Entities;

namespace BookStore.Application.AutorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }

        private readonly IBookStoreDbContext _dbContext;

        private readonly IMapper _mapper;
        public CreateAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);

            if (author is not null)
                throw new InvalidOperationException("Yazar zaten mevcut");

            author = new Author();
            author.Name = Model.Name;
            author.Surname = Model.Surname;

            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }

        public class CreateAuthorModel
        {
            public string Name { get; set; }

            public string Surname { get; set; }

            public string DateOfBirth { get; set; }

        }
    }
}
