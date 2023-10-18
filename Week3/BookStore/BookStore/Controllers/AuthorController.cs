using AutoMapper;
using BookStore.Application.AutorOperations.Commands.CreateAuthor;
using BookStore.Application.AutorOperations.Commands.DeleteAutor;
using BookStore.Application.AutorOperations.Commands.UpdateAutor;
using BookStore.Application.AutorOperations.Queries.GetAuthorDetail;
using BookStore.Application.AutorOperations.Queries.GetAutorDetail;
using BookStore.Application.AutorOperations.Queries.GetAutors;
using BookStore.DbOperation;
using BookStore.DBOperation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static BookStore.Application.AutorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static BookStore.Application.AutorOperations.Commands.UpdateAutor.UpdateAuthorCommand;

namespace BookStore.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();

            return Ok(result);
        }


        [HttpGet("id")]
        public IActionResult GetAuthorDetail(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorId = id;
            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = newAuthor;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = id;
            command.Model = updatedAuthor;

            UpdateAuthorCommandValidator validations = new UpdateAuthorCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;

            DeleteAuthorCommandValidator validations = new DeleteAuthorCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}
