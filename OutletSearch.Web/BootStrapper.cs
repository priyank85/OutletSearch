using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OutletSearch.Data;
using OutletSearch.Data.Repository;
using OutletSearch.Service;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace OutletSearch.Web
{
    public class BootStrapper
    {
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x => x.AddRegistry<ControllerRegistry>());
        }

        public class ControllerRegistry : Registry
        {
            public ControllerRegistry()
            {
                For<ISearchService>().Use<SearchService>();
                For<IOutletRepository>().Use<OutletRepository>();
                For<IContactRepository>().Use<ContactRepository>();
                For<IJsonDataSource>()
                    .Use<JsonDataSource>()
                    .Ctor<string>("dataFolderLocation")
                    .Is(HttpRuntime.BinDirectory);
            }
        }
    }
}