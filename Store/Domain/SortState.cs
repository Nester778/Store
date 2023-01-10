using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain
{
    public enum SortState
    {
        IdAsc,
        IdDesc,
        ProviderNameAsc,
        ProviderNameDesc,
        DescriptionAsc,
        DescriptionDesc,
        CreationDataAsc,
        CreationDataDesc,
        ModificationDataAsc,
        ModificationDataDesc,
        ManagerAsc,
        ManagerDesc,
        QuantityAsc,
        QuantityDesc,
        AmountAsc,
        AmountDesc,
        CityAsc,
        CityDesc,
    }
}
