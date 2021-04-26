
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajemos.Test.Book.Domain
{
    public class AuthorHasBook
    {
        protected AuthorHasBook()
        {

        }

        public AuthorHasBook(Author author, int ISBN)
        {
            if(author.Id > 0)
                AuthorId = author.Id;
            else
                Author = author;
            
            BookISBN = ISBN;
        }

        [Column("Autores_Id")]
        public int AuthorId { get; private set; }

        [Column("Libros_ISBN")]
        public int BookISBN { get; private set; }
        public virtual Author Author { get; private set; }
        public virtual Book Book{ get; private set; }
    }
}
