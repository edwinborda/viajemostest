using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajemos.Test.Book.Domain
{
    public class Author
    {
        protected Author()
        {

        }

        public Author(string name, string lastName, int? id = null)
        {
            Name = name;
            Lastname = lastName;
            Id = id ?? 0;
        }

        public int Id { get; private set; }

        [Column("Nombre")]
        public string Name { get; private set; }

        [Column("apellidos")]
        public string Lastname { get; private set; }

        public virtual ICollection<AuthorHasBook> AuthorsHasBooks { get; private set; }
    }
}
