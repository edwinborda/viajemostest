namespace Viajemos.Test.Book.Infraestructure.Interfaces
{
    public interface IUnitOfWork
    {
        IEditorialRepository EditorialRepository { get; }
        IBookRepository BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        bool SaveChanges();
    }
}
