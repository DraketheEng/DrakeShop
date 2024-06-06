using DrakeShop.Catalog.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrakeShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        List<ProductDetail> GetAll();
        Task<ProductDetail> GetById(string id);
        Task<bool> Create(ProductDetail productDetail);
        Task<bool> Delete(string id);
        Task<bool> Update(ProductDetail productDetail);
    }
}