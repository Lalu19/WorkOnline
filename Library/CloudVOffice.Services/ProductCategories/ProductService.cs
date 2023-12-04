using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.ProductCategories
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext _Context;
        private readonly ISqlRepository<Product> _ProductRepo;

        public ProductService(ApplicationDBContext Context, ISqlRepository<Product> ProductRepo)
        {

            _Context = Context;
            _ProductRepo = ProductRepo;
        }

        public MessageEnum CreateProduct(ProductDTO productDTO)
        {

            var objCheck = _Context.Products.SingleOrDefault(opt => opt.ProductId == productDTO.ProductId && opt.Deleted == false);
            try
            {
                if (objCheck == null)
                {

                    Product pp = new Product();
                    pp.ProductName = productDTO.ProductName;
                    pp.ParentGroupId = productDTO.ParentGroupId;
                    pp.Image = productDTO.Image;
                    pp.CreatedBy = productDTO.CreatedBy;
                    var obj = _ProductRepo.Insert(pp);

                    return MessageEnum.Success;
                }
                else if (objCheck != null)
                {
                    return MessageEnum.Duplicate;
                }

                return MessageEnum.UnExpectedError;
            }
            catch
            {
                throw;
            }
        }
        public MessageEnum ProductsUpdate(ProductDTO productDTO)
        {
            try
            {
                var Product = _Context.Products.Where(x => x.ProductId != productDTO.ProductId && x.ProductName == productDTO.ProductName && x.Deleted == false).FirstOrDefault();
                if (Product == null)
                {
                    var a = _Context.Products.Where(x => x.ProductId == productDTO.ProductId).FirstOrDefault();
                    if (a != null)
                    {
                        a.ProductName = productDTO.ProductName;
                        a.ParentGroupId = productDTO.ParentGroupId;
                        a.Image = productDTO.Image;
                        a.UpdatedBy = productDTO.CreatedBy;
                        a.UpdatedDate = DateTime.Now;
                        _Context.SaveChanges();
                        return MessageEnum.Updated;
                    }
                    else
                        return MessageEnum.Invalid;
                }
                else
                {
                    return MessageEnum.Duplicate;
                }
            }
            catch
            {
                throw;
            }
        }

        //public List<Product> GetProduct()
        //{

        //    try
        //    {
        //        var products = new List<Product>();

        //        var c = _Context.Products.Where(x => x.Deleted == false && x.Parent == null).ToList();

        //        return products;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        public Product GetProductsById(Int64 productsId)
        {
            try
            {
                return _Context.Products.Where(x => x.ProductId == productsId && x.Deleted == false).SingleOrDefault();
            }
            catch
            {
                throw;
            }
        }

		//public List<Product> GetGroupProducts()
		//{

		//    try
		//    {

		//        var products = new List<Product>();
		//        var c = _Context.Products.Where(x => x.Deleted == false && x.Parent == null).ToList();
		//        return products;
		//    }
		//    catch
		//    {
		//        throw;
		//    }

		//}

		public List<Product> GetProduct()
		{
			try
			{
				var cc = new List<Product>();

				var c = _Context.Products.Where(x =>  x.Deleted == false && x.Parent == null).ToList();

				foreach (var nemployee in c)
				{

					List<Product> cr = GetSubProducts(nemployee.ProductId);
					nemployee.Subordinates = cr;

					var listofSubcontinents = GetProductsSubContinent(nemployee.ProductId);
				
					cc.Add(nemployee);
				}

				return cc;
			}
			catch
			{
				throw;
			}
		}
		public List<Product> GetGroupProducts()
		{
			try
			{
				var products = new List<Product>();
				var c = _Context.Products.Where(x => x.Deleted == false && x.Parent == null).ToList();
				foreach (var nemployee in c)
				{
					List<Product> cr = GetGroupofSubProducts(nemployee.ProductId);
					nemployee.Subordinates = cr.ToList();
					products.Add(nemployee);
				}
				return products;
			}
			catch
			{
				throw;
			}
		}
		private List<Product> GetGroupofSubProducts(long ParentsId)
		{
			var prod = new List<Product>();
			//result.Add(employee);
			var employees = _Context.Products

				.Where(e => e.ParentGroupId == ParentsId && e.Deleted == false)
				.ToList();
			foreach (var nemployee in employees)
			{

				List<Product> cr = GetGroupofSubProducts(nemployee.ProductId);
				nemployee.Subordinates = cr;
				prod.Add(nemployee);
			}
			return prod;
		}
		private List<Product> GetSubProducts(long ParentsId)
		{
			var prod = new List<Product>();
			//result.Add(employee);
			var employees = _Context.Products

				.Where(e => e.ParentGroupId == ParentsId && e.Deleted == false)
				.ToList();

			foreach (var nemployee in employees)
			{
				List<Product> cr = GetSubProducts(nemployee.ProductId);
				var listofSubcontinents = GetProductsSubContinent(nemployee.ProductId);
				
				nemployee.Subordinates = cr;
				prod.Add(nemployee);
			}
			return prod;
		}
		public List<int> GetProductsSubContinent(int ProductId)
		{
			try
			{
				Product pp = _Context.Products.Where(x => x.ProductId == ProductId).SingleOrDefault();
				if (pp != null)
				{
					var result = new List<int>();
					result.Add(pp.ProductId);
					var ps = _Context.Products

						.Where(e => e.ParentGroupId == ProductId)
						.ToList();

					foreach (var nproduct in ps)
					{
						result.Add(nproduct.ProductId);
						result.AddRange(GetProductsSubContinent(nproduct.ProductId));
					}
					return result;
				}
				else
				{
					return null;
				}
			}
			catch
			{
				throw;
			}
		}


		public MessageEnum ProductsDelete(Int64 productsId, Int64 DeletedBy)
        {
            try
            {
                var a = _Context.Products.Where(x => x.ProductId == productsId).FirstOrDefault();
                if (a != null)
                {
                    a.Deleted = true;
                    a.UpdatedBy = DeletedBy;
                    a.UpdatedDate = DateTime.Now;
                    _Context.SaveChanges();
                    return MessageEnum.Deleted;
                }
                else
                    return MessageEnum.Invalid;
            }
            catch
            {
                throw;
            }
        }




    }
}
