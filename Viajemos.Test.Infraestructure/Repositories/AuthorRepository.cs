using Viajemos.Test.Book.Domain;
using Viajemos.Test.Book.Infraestructure.Interfaces;

namespace Viajemos.Test.Book.Infraestructure.Repositories
{
    public class AuthorRepository: Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(Context context)
            :base(context)
        {

        }
    }
}
