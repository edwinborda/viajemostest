using Viajemos.Test.Book.Domain;
using System.Collections.Generic;

namespace Viajemos.Test.Book.API.Infraestructure
{
    public interface IEditorialService
    {
        IEnumerable<Editorial> GetEditorials();
        bool AddEditorial(string name, string campus);
    }
}
