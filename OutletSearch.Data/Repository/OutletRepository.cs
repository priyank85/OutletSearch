using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutletSearch.Domain.Model;

namespace OutletSearch.Data.Repository
{
    public class OutletRepository : IOutletRepository
    {
        private readonly IJsonDataSource _dataSource;
        public OutletRepository(IJsonDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Outlet> GetAll()
        {
            var outlets = _dataSource.GetAllOutlets();
            var contacts = _dataSource.GetAllContacts();

            outlets.ToList().ForEach(o =>
                {
                    o.Contacts = contacts.Where(c => c.OutletId == o.Id).ToList();
                });

            return outlets;
        }
    }
}
