using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Viajemos.Test.Web.Infraestructure;
using Viajemos.Test.Web.Models;
using RestSharp;

namespace Viajemos.Test.Web.Controllers
{
    public class BookController : Controller
    {
        #region Fields

        private readonly IProxy<BookModel> bookProxy;
        private readonly IProxy<EditorialModel> editorialProxy;
        private readonly BookServices bookServices;
        private readonly EditorialServices editorialServices;

        #endregion

        #region Constructors

        public BookController(
            IProxy<BookModel> bookProxy,
            IProxy<EditorialModel> editorialProxy,
            IOptionsSnapshot<BookServices> bookSnapshot,
            IOptionsSnapshot<EditorialServices> editorialSnapshot)
        {
            this.bookProxy = bookProxy;
            this.editorialProxy = editorialProxy;
            this.bookServices = bookSnapshot.Value;
            this.editorialServices = editorialSnapshot.Value;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            var books = bookProxy.Get(bookServices.BaseUrl, bookServices.Endpoint);

            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var editorialitems = editorialProxy.Get(editorialServices.BaseUrl, editorialServices.Endpoint);
            ViewBag.Editorial = new SelectList(editorialitems.Select(it => new { it.Id, Name = $"{it.Name} - {it.Campus}" }).ToList(), "Id", "Name");

            return View(new BookModel());
        }

        [HttpPost]
        public IActionResult Create(BookModel model)
        {
            if (!ModelState.IsValid)
            {
                var error = String.Join(',', ModelState.Values.SelectMany(it => it.Errors)
                                                                  .Select(it2 => $" {it2.ErrorMessage} "));
                return BadRequest(error);
            }

            IRestResponse restResponse = bookProxy.Post(bookServices.BaseUrl, bookServices.Endpoint, model);
            if (restResponse.StatusCode != System.Net.HttpStatusCode.OK) 
            {
                return StatusCode(500, "No fue posible crear un libro");
            }
            
            return Ok();
        }

        #endregion
    }
}