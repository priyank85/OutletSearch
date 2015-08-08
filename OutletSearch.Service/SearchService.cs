using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OutletSearch.Data.Repository;
using OutletSearch.Domain.Model;
using OutletSearch.Service.ViewModels;

namespace OutletSearch.Service
{
    public class SearchService : ISearchService
    {
        private readonly IOutletRepository _outletRepo;
        private readonly IContactRepository _contactRepo;
        public SearchService(IOutletRepository outletRepository, IContactRepository contactRepository)
        {
            _outletRepo = outletRepository;
            _contactRepo = contactRepository;
        }

        public SearchViewModel SearchContacts(string searchTerms)
        {
            var allcontacts = _contactRepo.GetAll();

            var result = allcontacts.Where(c =>
                {
                    var otl = false;
                    if (c.Outlet != null)
                        otl = c.Outlet.Name.IndexOf(searchTerms, StringComparison.InvariantCultureIgnoreCase) != -1;

                    var ln = c.LastName == searchTerms;
                    var t = c.Title == searchTerms;
                    var p = c.Profile.IndexOf(searchTerms, StringComparison.InvariantCultureIgnoreCase) != -1;

                    return otl || ln || t || p;
                });

            return new SearchViewModel
                {
                    SearchTerms = searchTerms,
                    Contacts = result.Select(cr => new ContactViewModel
                        {
                            ContactFullName = string.Format("{0} {1}", cr.FirstName, cr.LastName),
                            ContactProfile = cr.Profile,
                            ContactTitle = cr.Title,
                            OutletName = cr.Outlet != null ? cr.Outlet.Name : string.Empty
                        })
                };
        }
    }
}
