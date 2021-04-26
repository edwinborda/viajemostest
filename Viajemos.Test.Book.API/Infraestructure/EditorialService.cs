using Viajemos.Test.Book.Domain;
using Viajemos.Test.Book.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viajemos.Test.Book.API.Infraestructure
{
    public class EditorialService : IEditorialService
    {
        #region Fields

        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Constructors

        public EditorialService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        } 

        #endregion

        public bool AddEditorial(string name, string campus)
        {
            unitOfWork.EditorialRepository.Add(new Editorial(name, campus));

            return unitOfWork.SaveChanges();
        }

        public IEnumerable<Editorial> GetEditorials()
        {
            return unitOfWork.EditorialRepository.Get();
        }
    }
}
