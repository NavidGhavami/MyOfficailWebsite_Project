using System.Collections.Generic;

namespace _01_Query.Contract.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetLatestArrivals();
    }
}
