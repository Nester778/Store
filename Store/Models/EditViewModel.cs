using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class EditViewModel
    {
        public List<Product> products { get; set; }
        public Product product { get; set; }
        public string DataType { get; set; }
    }
}
