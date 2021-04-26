using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Viajemos.Test.Web.Infraestructure;
using Viajemos.Test.Web.Models;
using RestSharp;

namespace Viajemos.Test.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private readonly IProxy<EditorialModel> editorialProxy;
        private readonly EditorialServices editorialServices;

        #endregion


        #region Constructors

        public HomeController(
            IProxy<EditorialModel> editorialProxy,
            IOptionsSnapshot<EditorialServices> editorialSnapshot)
        {
            this.editorialProxy = editorialProxy;
            this.editorialServices = editorialSnapshot.Value;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            var editorials = editorialProxy.Get(editorialServices.BaseUrl, editorialServices.Endpoint);

            return View(editorials);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new EditorialModel());
        }

        [HttpPost]
        public IActionResult Create(EditorialModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = String.Join(',', ModelState.Values
                                                            .SelectMany(it => it.Errors)
                                                            .Select(it2 => it2.ErrorMessage));
                return View(model);
            }

            IRestResponse response = editorialProxy.Post(editorialServices.BaseUrl, editorialServices.Endpoint, model);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ViewBag.Error = "No fue posible crear una editorial";
                return View();
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}