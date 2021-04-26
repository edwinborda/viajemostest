using BookDomain = Viajemos.Test.Book.Domain.Book;
using System.Collections.Generic;

namespace Viajemos.Test.Book.Infraestructure.Interfaces
{
    public interface IBookRepository: IRepository<BookDomain>
    {
        IEnumerable<BookDomain> GetRepositoryWithNestedEntity();
    }
}
