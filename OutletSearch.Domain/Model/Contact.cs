using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutletSearch.Domain.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public int OutletId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Profile { get; set; }

        public Outlet Outlet { get; set; }

    }
}
