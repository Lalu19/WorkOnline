using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.ProductCategories
{
    public interface IProductService
    {
        public MessageEnum CreateProduct(ProductDTO productDTO);
        public List<Product> GetProduct();

        public List<Product> GetGroupProducts();
        public Product GetProductsById(Int64 productsId);
        public MessageEnum ProductsUpdate(ProductDTO productDTO);
        public MessageEnum ProductsDelete(Int64 productsId, Int64 DeletedBy);

       // public List<Product> GetNonGroupProducts();
    }
}
