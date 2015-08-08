using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutletSearch.Domain.Model;

namespace OutletSearch.Data.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IJsonDataSource _dataSource;
        public ContactRepository(IJsonDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Contact> GetAll()
        {
            var allContacts = _dataSource.GetAllContacts();
            var allOutlets = _dataSource.GetAllOutlets();

            allContacts.ToList().ForEach(c =>
                {
                    c.Outlet = allOutlets.FirstOrDefault(o => o.Id == c.OutletId);
                });

            return allContacts;
        }
    }
}
