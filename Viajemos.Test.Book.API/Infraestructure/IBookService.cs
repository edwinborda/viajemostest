using BookDomain = Viajemos.Test.Book.Domain.Book;
using Viajemos.Test.Book.Domain;
using System.Collections.Generic;

namespace Viajemos.Test.Book.API.Infraestructure
{
    public interface IBookService
    {
        IEnumerable<BookDomain> GetBooks();
        bool AddBook(int isbn, string title, string sypnosis, string numberOfPages, Editorial editorial, params Author[] authors);
    }
}
