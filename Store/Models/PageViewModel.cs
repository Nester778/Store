using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class PageViewModel
    {
        public int PageNumber { get; private set; }
        public bool NextPage { get; private set; }

        public PageViewModel(int pageNumber, bool nextPage)
        {
            PageNumber = pageNumber;
            NextPage = nextPage;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return NextPage;
            }
        }
    }
}
