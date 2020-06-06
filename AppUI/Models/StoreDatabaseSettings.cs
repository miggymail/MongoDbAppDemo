using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUI.Models
{

    public class StoreDatabaseSettings : IStoreDatabaseSettings
    {
        public string ProductsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
