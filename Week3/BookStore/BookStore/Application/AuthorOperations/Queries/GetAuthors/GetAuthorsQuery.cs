using AutoMapper;
using BookStore.DBOperation;

namespace BookStore.Application.AutorOperations.Queries.GetAutors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var autorsList = _dbContext.Authors.OrderBy(x => x.Id);

            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(autorsList);
            return vm;
        }
    }

    public class AuthorsViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string DateOfBirth { get; set; }
    }
}
