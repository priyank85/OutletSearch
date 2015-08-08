using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutletSearch.Domain.Model
{
    public class Outlet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Contact> Contacts { get; set; }
    }
}
