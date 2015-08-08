using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutletSearch.Domain.Model;

namespace OutletSearch.Data
{
    public interface IJsonDataSource
    {
        IEnumerable<Outlet> GetAllOutlets();
        IEnumerable<Contact> GetAllContacts();
    }
}
