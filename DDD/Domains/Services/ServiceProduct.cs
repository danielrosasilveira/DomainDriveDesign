using Domains.Interfaces.InterfaceProduct;
using Domains.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProduct _IProduct;
        public ServiceProduct(IProduct IProduct)
        {
            _IProduct = IProduct;
        }
        
        public async Task AddProduct(Product product)
        {
            var validarNome = product.ValidarPropriedadeString(product.Nome, "Nome");
            var validarPreco = product.ValidarPropriedadeDecimal(product.Preco, "Preco");

            if (validarNome && validarPreco)
            {
                product.Ativo = true;
                await _IProduct.Add(product);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            var validarNome = product.ValidarPropriedadeString(product.Nome, "Nome");
            var validarPreco = product.ValidarPropriedadeDecimal(product.Preco, "Preco");

            if (validarNome && validarPreco)
            {                
                await _IProduct.Update(product);
            }
        }
    }
}
