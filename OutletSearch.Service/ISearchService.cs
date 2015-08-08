using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutletSearch.Domain.Model;
using OutletSearch.Service.ViewModels;

namespace OutletSearch.Service
{
    public interface ISearchService
    {
        SearchViewModel SearchContacts(string searchTerms);
    }
}
