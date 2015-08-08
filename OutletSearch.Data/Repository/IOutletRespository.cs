using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OutletSearch.Domain.Model;

namespace OutletSearch.Data.Repository
{
    public interface IOutletRepository
    {
        IEnumerable<Outlet> GetAll();
    }
}
