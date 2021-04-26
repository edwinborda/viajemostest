using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookDomain = Viajemos.Test.Book.Domain.Book;
using Viajemos.Test.Book.Infraestructure.Interfaces;
using System.Collections.Generic;

namespace Viajemos.Test.Book.Infraestructure.Repositories
{
    public class BookRepository: Repository<BookDomain>, IBookRepository
    {
        private readonly Context context;

        public BookRepository(Context context)
            :base(context)
        {
            this.context = context;
        }

        public IEnumerable<BookDomain> GetRepositoryWithNestedEntity()
        {
            return context.Books.Include(it => it.Editorial)
                                .Include(it => it.AuthorsHasBooks)
                                    .ThenInclude(it => it.Author) //roslyn tiene un problema
                                .ToList();
        }
    }
}
