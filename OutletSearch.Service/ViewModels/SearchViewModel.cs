using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OutletSearch.Service.ViewModels
{
    public class SearchViewModel
    {
        public IEnumerable<ContactViewModel> Contacts { get; set; }
        public string SearchTerms { get; set; }
    }
}