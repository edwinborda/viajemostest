using BookDomain = Viajemos.Test.Book.Domain.Book;
using Viajemos.Test.Book.Domain;
using Viajemos.Test.Book.Infraestructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Viajemos.Test.Book.API.Infraestructure
{
    public class BookService : IBookService
    {
        #region Fields

        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Constructors

        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public bool AddBook(int isbn, string title, string sypnosis, string numberOfPages, Editorial editorial, params Author[] authors)
        {
            unitOfWork.BookRepository.Add(new BookDomain(title, sypnosis, numberOfPages, editorial, isbn, authors));

            return unitOfWork.SaveChanges();
        }

        public IEnumerable<BookDomain> GetBooks()
        {
            return unitOfWork.BookRepository.GetRepositoryWithNestedEntity();
        }

        #endregion
    }
}
