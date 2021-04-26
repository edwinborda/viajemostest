using Microsoft.AspNetCore.Mvc;
using Viajemos.Test.Book.API.Infraestructure;
using System.Linq;

namespace Viajemos.Test.Book.API.Controllers
{
    /// <summary>
    /// author's Controller
    /// </summary>
    [Route("api/v1/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;

        /// <summary>
        /// Initializes controllers
        /// </summary>
        /// <param name="authorService"></param>
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        /// <summary>
        /// Get a author list
        /// </summary>
        /// <response code="200">Returns a author's list</response>
        /// <response code="404">Not found a author list</response>
        /// <response code="500">Internal server error and it can't get author's list </response>
        /// <returns>A paged list of results</returns>
        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                var list = authorService.getAuthors();

                if (!list.Any())
                    return NotFound();

                return Ok(list);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
            
        }

    }
}