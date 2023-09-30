﻿using BookStore.DBOperation;
using Microsoft.AspNetCore.Mvc;
using static BookStore.BooksOperations.CreateBook.CreateBookCommand;
using BookStore.BooksOperations.CreateBook;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.UpdateBook;
using static BookStore.BookOperations.UpdateBook.UpdateBookCommand;
using BookStore.BookOperations.DeleteBook;
using AutoMapper;
using BookStore.BookOperations.CreateBook;
using FluentValidation.Results;
using FluentValidation;

namespace BookStore.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);
        }


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
                command.Model = newBook;

                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                ValidationResult result = validator.Validate(command);
                validator.ValidateAndThrow(command);
                command.Handle();

                //if (!result.IsValid) 
                //{
                //    foreach (var item in result.Errors)
                //    {
                //        Console.WriteLine("Property: " + item.PropertyName + "- Error Message: " + item.ErrorMessage);
                //    }
                //}
                //else
                //{
                //    command.Handle();
                //}

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;

                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidation validator = new DeleteBookCommandValidation();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
            
        }





    }
}
