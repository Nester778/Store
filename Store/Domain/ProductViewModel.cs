using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string Description { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime ModificationData { get; set; }
        public string Manager { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public string City { get; set; }
        public SelectListItem Prods { get; set; }

    }
}
