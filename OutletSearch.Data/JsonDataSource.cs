using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using OutletSearch.Domain.Model;

namespace OutletSearch.Data
{
    public class JsonDataSource : IJsonDataSource
    {
        private readonly string _jsonDataFolderPath;
        private readonly string _outletsDatafile;
        private readonly string _contactsDatafile;

        public JsonDataSource(string dataFolderLocation)
        {
            _jsonDataFolderPath = dataFolderLocation;
            _outletsDatafile = Path.Combine(_jsonDataFolderPath, "Json/Outlets.json");
            _contactsDatafile = Path.Combine(_jsonDataFolderPath, "Json/Contacts.json");
        }

        public IEnumerable<Outlet> GetAllOutlets()
        {
            using (var sr = File.OpenText(_outletsDatafile))
            {
                var js = new JsonSerializer();
                return (IEnumerable<Outlet>) js.Deserialize(sr, typeof (IEnumerable<Outlet>));
            }
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            using (var sr = File.OpenText(_contactsDatafile))
            {
                var js = new JsonSerializer();
                return (IEnumerable<Contact>)js.Deserialize(sr, typeof(IEnumerable<Contact>));
            }
        }
    }
}
