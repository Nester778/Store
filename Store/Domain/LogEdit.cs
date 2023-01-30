using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class LogEdit
    {
        public Product NewEdit { get; set; }
        public Product OldEdit { get; set; }
    }
}
