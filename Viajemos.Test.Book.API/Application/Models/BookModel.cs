using System.Collections.Generic;

namespace Viajemos.Test.Book.API.Application.Models
{
    /// <summary>
    /// Book model
    /// </summary>
    public class BookModel
    {
        /// <summary>
        /// Book Key 
        /// </summary>
        public int ISBN { get; set; }

        /// <summary>
        /// Book's name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Book's Sypnosis
        /// </summary>
        public string Sypnosis { get; set; }

        /// <summary>
        /// Book's number pages
        /// </summary>
        public string NumberPages { get; set; }

        /// <summary>
        /// Book's authors
        /// </summary>
        public List<AuthorModel> Authors { get; set; }

        /// <summary>
        /// Book's editorial
        /// </summary>
        public EditorialModel Editorial { get; set; }
    }
}
