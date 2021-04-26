using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Viajemos.Test.Book.API.Application.Models;
using Viajemos.Test.Book.API.Infraestructure;

namespace Viajemos.Test.Book.API.Controllers
{
    /// <summary>
    /// Editorial controller
    /// </summary>
    [Route("api/v1/editorials")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        #region Fields

        private readonly IEditorialService editorialService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes editorial
        /// </summary>
        /// <param name="editorialService"></param>
        public EditorialController(IEditorialService editorialService)
        {
            this.editorialService = editorialService;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Get all editorial list
        /// </summary>
        /// <response code="200">Returns a Editorial's list</response>
        /// <response code="404">Not found a Editorial list</response>
        /// <response code="500">Internal server error and it can't get editorial's list </response>
        /// <returns>A paged list of results</returns>
        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                var list = editorialService.GetEditorials();

                if (!list.Any())
                    return NotFound();

                return Ok(list);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        /// <summary>
        /// Add a editorial register
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Returns that Editorial created on Successs</response>
        /// <response code="40o">Invalid data Send </response>
        /// <response code="500">Internal server error and it can't add editorial</response>
        /// <returns>A paged list of results</returns>
        [HttpPost()]
        public IActionResult Post([FromBody] EditorialModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = editorialService.AddEditorial(model.Name, model.Campus);

                if (!result)
                    return StatusCode(500, "Editorial don't create");

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        #endregion
    }
}