using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPI.RepositoryLayer
{
    interface IProductRepository<T>  where T : class
    {
        bool AddProduct(T product);
        bool BookProduct(int id);
        bool SaveProduct(int id);
        List<T> GetAllProducts();
    }
}
