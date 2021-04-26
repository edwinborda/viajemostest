using Viajemos.Test.Book.Infraestructure.Interfaces;

namespace Viajemos.Test.Book.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context context;

        public UnitOfWork(IEditorialRepository editorialRepository,
                          IBookRepository bookRepository,
                          IAuthorRepository authorRepository,
                          Context context)
        {
            EditorialRepository = editorialRepository;
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;
            this.context = context;
        }

        public IEditorialRepository EditorialRepository { get; }

        public IBookRepository BookRepository { get; }

        public IAuthorRepository AuthorRepository { get; }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
