﻿using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class IndexViewModel
    {
        public string DataType { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public string SearchString { get; set; }
    }
}
