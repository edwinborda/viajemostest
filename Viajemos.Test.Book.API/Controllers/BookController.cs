using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Viajemos.Test.Book.API.Application.Models;
using Viajemos.Test.Book.API.Infraestructure;
using Viajemos.Test.Book.Domain;

namespace Viajemos.Test.Book.API.Controllers
{
    /// <summary>
    /// Book's api
    /// </summary>
    [Route("api/v1/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        #region Fields

        private readonly IBookService bookService;
        private readonly IMapper mapper;

        #endregion
        #region Constructors

        /// <summary>
        /// Initialize controller
        /// </summary>
        /// <param name="bookService"></param>
        /// <param name="mapper"></param>
        public BookController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }
        #endregion

        /// <summary>
        /// Gets book's list
        /// </summary>
        /// <response code="200">Returns book's list</response>
        /// <response code="404">Not found book's list</response>
        /// <response code="500">Internal server error and it can't get book's list </response>
        /// <returns>A paged list of results</returns>
        #region Methods
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = bookService.GetBooks();
                if (!list.Any())
                    return NotFound();

                var listBookModel = mapper.Map<List<BookModel>>(list);
                return Ok(listBookModel);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <param name="model">Book Model</param>
        /// <response code="200">Returns that book created on success</response>
        /// <response code="400">Invalid data sent</response>
        /// <response code="500">Internal server error and it can't create book </response>
        /// <returns>A paged list of results</returns>
        [HttpPost]
        public IActionResult Post([FromBody] BookModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var authors = model.Authors.Select(it => new Author(it.Name, it.LastName, it.Id)).ToArray();
                var result = bookService.AddBook(model.ISBN, model.Title, model.Sypnosis, model.NumberPages, new Editorial(model.Editorial.Name, model.Editorial.Campus, model.Editorial.Id), authors);

                if (!result)
                    return StatusCode(500, "Book was not create");

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