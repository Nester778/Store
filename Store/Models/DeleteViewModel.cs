using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class DeleteViewModel
    {
        public List<ProductViewModel> productViewModel { get; set; }
        public string DataType { get; set; }
        public string SearchString { get; set; }
    }
}
