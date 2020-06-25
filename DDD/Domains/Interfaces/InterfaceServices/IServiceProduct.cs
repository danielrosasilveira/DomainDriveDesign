using Entities.Entities;
using System.Threading.Tasks;

namespace Domains.Interfaces.InterfaceServices
{
    public interface IServiceProduct
    {
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
    }
}
