using AspNetCoreCRUD.Models;
using System.Collections.Generic;

namespace AspNetCoreCRUD.ViewModel
{
    public class ClientIndexData
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Founder> Founders { get; set; }
    }
}
