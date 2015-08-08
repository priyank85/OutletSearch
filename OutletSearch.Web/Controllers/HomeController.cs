using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OutletSearch.Service;

namespace OutletSearch.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService _searchService;
        public HomeController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchterms)
        {
            var result = _searchService.SearchContacts(searchterms.Trim());

            return View("Index", result);
        }
    }
}
