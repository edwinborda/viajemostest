using Viajemos.Test.Book.Domain;
using Viajemos.Test.Book.Infraestructure.Interfaces;

namespace Viajemos.Test.Book.Infraestructure.Repositories
{
    public class EditorialRepository: Repository<Editorial>, IEditorialRepository
    {
        public EditorialRepository(Context context)
            : base(context)
        {

        }
    }
}
