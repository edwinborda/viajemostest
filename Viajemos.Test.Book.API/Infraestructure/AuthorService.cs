using Viajemos.Test.Book.Domain;
using Viajemos.Test.Book.Infraestructure.Interfaces;
using System.Collections.Generic;

namespace Viajemos.Test.Book.API.Infraestructure
{
    public class AuthorService : IAuthorService
    {
        #region Fields
        public readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public AuthorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public IEnumerable<Author> getAuthors()
        {
            return unitOfWork.AuthorRepository.Get();
        } 
        #endregion
    }
}
