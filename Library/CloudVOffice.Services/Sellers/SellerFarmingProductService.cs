using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace CloudVOffice.Services.Sellers
{
	public class SellerFarmingProductService : ISellerFarmingProductService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<SellerFarmingProduct> _sellerFarmingProductRepo;
		public SellerFarmingProductService(ApplicationDBContext dbContext,
			                               ISqlRepository<SellerFarmingProduct> sellerFarmingProductRepo
			                              )
		{
			_dbContext = dbContext;
			_sellerFarmingProductRepo = sellerFarmingProductRepo;
		}
		public MessageEnum SellerFarmingProductCreate(SellerFarmingProductDTO sellerFarmingProductDTO)
		{
			try
			{
				var Sellerproducts = _dbContext.SellerFarmingProducts.Where(x => x.ProductName == sellerFarmingProductDTO.ProductName && x.Deleted == false).FirstOrDefault();
				if (Sellerproducts == null)
				{
					SellerFarmingProduct sellerFarmingProduct = new SellerFarmingProduct();

					sellerFarmingProduct.CategoryId = sellerFarmingProductDTO.CategoryId;
					sellerFarmingProduct.SubCategory1Id = sellerFarmingProductDTO.SubCategory1Id;
					sellerFarmingProduct.SubCategory2Id = sellerFarmingProductDTO.SubCategory2Id;
					sellerFarmingProduct.ProductName = sellerFarmingProductDTO.ProductName;
					sellerFarmingProduct.MinQty = sellerFarmingProductDTO.MinQty;
					sellerFarmingProduct.GSTId = sellerFarmingProductDTO.GSTId;
					sellerFarmingProduct.HSN = sellerFarmingProductDTO.HSN;
					sellerFarmingProduct.Price = sellerFarmingProductDTO.Price;
					sellerFarmingProduct.QtyPerKg = sellerFarmingProductDTO.QtyPerKg;
					sellerFarmingProduct.CompanyName = sellerFarmingProductDTO.CompanyName;
					sellerFarmingProduct.BrandId = sellerFarmingProductDTO.BrandId;
					sellerFarmingProduct.ProductWeight = sellerFarmingProductDTO.ProductWeight;
					sellerFarmingProduct.UnitId = sellerFarmingProductDTO.UnitId;
					sellerFarmingProduct.HarvestDate = sellerFarmingProductDTO.HarvestDate;

					sellerFarmingProduct.Thumbnail = sellerFarmingProductDTO.Thumbnail;

					if (sellerFarmingProductDTO.Images != null && sellerFarmingProductDTO.Images.Any())
					{
						// Join the list of images into a comma-separated string
						sellerFarmingProduct.Images = string.Join(",", sellerFarmingProductDTO.Images);
					}
					else
					{
						sellerFarmingProduct.Images = null; // or an empty string depending on your database schema
					}

					sellerFarmingProduct.CreatedBy = sellerFarmingProductDTO.CreatedBy;

					var obj = _sellerFarmingProductRepo.Insert(sellerFarmingProduct);

					return MessageEnum.Success;
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
		public MessageEnum SellerFarmingProductUpdate(SellerFarmingProductDTO sellerFarmingProductDTO)
		{
			try
			{
				var Sellerproducts = _dbContext.SellerFarmingProducts.Where(x => x.SellerFarmingProductId != sellerFarmingProductDTO.SellerFarmingProductId && x.ProductName == sellerFarmingProductDTO.ProductName && x.Deleted == false).FirstOrDefault();
				if (Sellerproducts == null)
				{
					var a = _dbContext.SellerFarmingProducts.Where(x => x.SellerFarmingProductId == sellerFarmingProductDTO.SellerFarmingProductId).FirstOrDefault();
					if (a != null)
					{
						a.CategoryId = sellerFarmingProductDTO.CategoryId;
						a.SubCategory1Id = sellerFarmingProductDTO.SubCategory1Id;
						a.SubCategory2Id = sellerFarmingProductDTO.SubCategory2Id;
						a.ProductName = sellerFarmingProductDTO.ProductName;
						a.MinQty = sellerFarmingProductDTO.MinQty;
						a.GSTId = sellerFarmingProductDTO.GSTId;
						a.HSN = sellerFarmingProductDTO.HSN;
						a.Price = sellerFarmingProductDTO.Price;
						a.QtyPerKg = sellerFarmingProductDTO.QtyPerKg;
						a.CompanyName = sellerFarmingProductDTO.CompanyName;
						a.BrandId = sellerFarmingProductDTO.BrandId;
						a.ProductWeight = sellerFarmingProductDTO.ProductWeight;
						a.UnitId = sellerFarmingProductDTO.UnitId;
						a.HarvestDate = sellerFarmingProductDTO.HarvestDate;

						a.Thumbnail = sellerFarmingProductDTO.Thumbnail;

						if (sellerFarmingProductDTO.Images != null && sellerFarmingProductDTO.Images.Any())
						{
							// Join the list of images into a comma-separated string
							a.Images = string.Join(",", sellerFarmingProductDTO.Images);
						}

						a.UpdatedDate = DateTime.Now;
						_dbContext.SaveChanges();
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
		public SellerFarmingProduct GetSellerFarmingProductById(Int64 sellerFarmingProductId)
		{
			try
			{
				return _dbContext.SellerFarmingProducts.Where(x => x.SellerFarmingProductId == sellerFarmingProductId && x.Deleted == false).SingleOrDefault();

			}
			catch
			{
				throw;
			}
		}

		public List<SellerFarmingProduct> GetSellerFarmingProductList()
		{
			var a = _dbContext.SellerFarmingProducts
			   .Include(s => s.Category)
			   .Include(s => s.SubCategory1)
			   .Include(s => s.SubCategory2)
			   .Include(s => s.Brand)
			   .Include(s => s.Unit)
			   .Include(s => s.GST)
			   .Where(x => x.Deleted == false).ToList();

			return a;
		}
		public MessageEnum SellerFarmingProductDelete(Int64 sellerFarmingProductId, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.SellerFarmingProducts.Where(x => x.SellerFarmingProductId == sellerFarmingProductId).FirstOrDefault();
				if (a != null)
				{
					a.Deleted = true;
					a.UpdatedBy = DeletedBy;
					a.UpdatedDate = DateTime.Now;
					_dbContext.SaveChanges();
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
