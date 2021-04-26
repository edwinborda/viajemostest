using System.ComponentModel.DataAnnotations.Schema;

namespace Viajemos.Test.Book.Domain
{
    public class Editorial
    {
        protected Editorial()
        {

        }

        public Editorial(string name, string campus, int? id = null)
        {
            Name = name;
            Campus = campus;
            Id = id ?? 0;
        }
            
        public int Id { get; private set; }

        [Column("Nombre")]
        public string Name { get; private set; }

        [Column("Sede")]
        public string Campus { get; private set; }
    }
}
