using Viajemos.Test.Book.Domain;
using System.Collections.Generic;

namespace Viajemos.Test.Book.API.Infraestructure
{
    public interface IAuthorService
    {
        IEnumerable<Author> getAuthors();
    }
}
