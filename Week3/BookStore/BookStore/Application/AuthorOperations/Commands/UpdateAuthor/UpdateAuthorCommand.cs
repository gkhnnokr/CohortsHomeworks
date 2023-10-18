using BookStore.DbOperation;
using BookStore.DBOperation;

namespace BookStore.Application.AutorOperations.Commands.UpdateAutor
{
    public class UpdateAuthorCommand
    {
        private readonly IBookStoreDbContext _context;
        public int AuthorId { get; set; }

        public UpdateAuthorModel Model { get; set; }

        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
            {
                throw new InvalidOperationException("Güncellenecek Yazar Bulunamadı!");
            }

            author.Name = Model.Name == default ? author.Name : Model.Name;
            author.Surname = Model.Surname == default ? author.Surname : Model.Surname ;
            author.DateOfBirth = Convert.ToDateTime(Model.DateOfBirth);

            _context.SaveChanges();
        }

        public class UpdateAuthorModel
        {
            public string Name { get; set; }

            public string Surname { get; set; }

            public string DateOfBirth { get; set; }
        }
    }
}
