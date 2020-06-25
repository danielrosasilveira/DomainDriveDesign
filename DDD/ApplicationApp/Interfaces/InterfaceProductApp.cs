using ApplicationApp.Interfaces.Generics;
using Entities.Entities;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceProductApp : InterfaceGenericaApp<Product>
    {
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
    }
}
