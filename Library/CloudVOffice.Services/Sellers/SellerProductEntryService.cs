using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Data.DTO.WareHouses.Months;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Sellers
{
    public class SellerProductEntryService: ISellerProductEntryService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<SellerProductEntry> _sellerProductEntryRepo;

        public SellerProductEntryService(ApplicationDBContext dbContext,
                                   ISqlRepository<SellerProductEntry> sellerProductEntryRepo

                                    )
        {
            _dbContext = dbContext;
            _sellerProductEntryRepo = sellerProductEntryRepo;

        }
        public MessageEnum CreateSellerProductEntry(SellerProductEntryDTO sellerProductEntryDTO)
        {
            try
            {
                var objcheck = _dbContext.SellerProductEntrys.SingleOrDefault(opt => opt.Deleted == false && opt.ProductName == sellerProductEntryDTO.ProductName);
                if (objcheck == null)
                {
                    SellerProductEntry sc = new SellerProductEntry();
                    sc.ProductName = sellerProductEntryDTO.ProductName;
                    sc.SellerProductCode = sellerProductEntryDTO.SellerProductCode;
                    sc.CategoryId = sellerProductEntryDTO.CategoryId;
                    sc.SubCategory1Id = sellerProductEntryDTO.SubCategory1Id;
                    sc.SubCategory2Id = sellerProductEntryDTO.SubCategory2Id;
                    sc.HSN = sellerProductEntryDTO.HSN;
                    sc.CompanyName = sellerProductEntryDTO.CompanyName;
                    sc.BrandId = sellerProductEntryDTO.BrandId;
                    sc.ProductWeight = sellerProductEntryDTO.ProductWeight;
                    sc.UnitId = sellerProductEntryDTO.UnitId;
                    sc.CaseWeight = sellerProductEntryDTO.CaseWeight;
                    sc.UnitPerCase = sellerProductEntryDTO.UnitPerCase;
                    sc.ManufactureDate = sellerProductEntryDTO.ManufactureDate;
                    sc.ExpiryDate = sellerProductEntryDTO.ExpiryDate;
                    sc.MRP = sellerProductEntryDTO.MRP;
                    sc.MRPCaseCost = sellerProductEntryDTO.MRPCaseCost;
                    sc.SalesCost = sellerProductEntryDTO.SalesCost;
                    sc.SalesCaseCost = sellerProductEntryDTO.SalesCaseCost;
                    sc.GSTId = sellerProductEntryDTO.GSTId;
                    sc.HandlingTypeId = sellerProductEntryDTO.HandlingTypeId;

                    if (sellerProductEntryDTO.Images != null && sellerProductEntryDTO.Images.Any())
                    {
                        sc.Images = string.Join(",", sellerProductEntryDTO.Images);
                    }
                    else
                    {
                        sc.Images = null; 
                    }
                    sc.Thumbnail = sellerProductEntryDTO.Thumbnail;
                    sc.CreatedBy = sellerProductEntryDTO.CreatedBy;
                    sc.CreatedDate = System.DateTime.Now;
                    var obj = _sellerProductEntryRepo.Insert(sc);
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
        public List<SellerProductEntry> GetSellerProductEntryList()
        {
            var a = _dbContext.SellerProductEntrys
			.Include(s => s.Category)
            .Include(s => s.SubCategory1)
            .Include(s => s.SubCategory2)
            .Include(s => s.Brand)
            .Include(s => s.Unit    )
            .Include(s => s.GST)
            .Include(s => s.HandlingType)
            .Where(x => x.Deleted == false).ToList();

            return a;

        }
        public MessageEnum UpdateSellerProductEntry(SellerProductEntryDTO sellerProductEntryDTO)
        {
            try
            {
                var updateSellerProductEntry = _dbContext.SellerProductEntrys.Where(x => x.SellerProductEntryId != sellerProductEntryDTO.SellerProductEntryId && x.ProductName == sellerProductEntryDTO.ProductName && x.Deleted == false).FirstOrDefault();
                if (updateSellerProductEntry == null)
                {
                    var a = _dbContext.SellerProductEntrys.Where(x => x.SellerProductEntryId == sellerProductEntryDTO.SellerProductEntryId).FirstOrDefault();
                    if (a != null)
                    {
                        a.ProductName = sellerProductEntryDTO.ProductName;
                        a.SellerProductCode = sellerProductEntryDTO.SellerProductCode;
                        a.CategoryId = sellerProductEntryDTO.CategoryId;
                        a.SubCategory1Id = sellerProductEntryDTO.SubCategory1Id;
                        a.SubCategory2Id = sellerProductEntryDTO.SubCategory2Id;
                        a.HSN = sellerProductEntryDTO.HSN;
                        a.CompanyName = sellerProductEntryDTO.CompanyName;
                        a.BrandId = sellerProductEntryDTO.BrandId;
                        a.ProductWeight = sellerProductEntryDTO.ProductWeight;
                        a.UnitId = sellerProductEntryDTO.UnitId;
                        a.CaseWeight = sellerProductEntryDTO.CaseWeight;
                        a.UnitPerCase = sellerProductEntryDTO.UnitPerCase;
                        a.ManufactureDate = sellerProductEntryDTO.ManufactureDate;
                        a.ExpiryDate = sellerProductEntryDTO.ExpiryDate;
                        a.MRP = sellerProductEntryDTO.MRP;
                        a.MRPCaseCost = sellerProductEntryDTO.MRPCaseCost;
                        a.SalesCost = sellerProductEntryDTO.SalesCost;
                        a.SalesCaseCost = sellerProductEntryDTO.SalesCaseCost;
                        a.GSTId = sellerProductEntryDTO.GSTId;
                        a.HandlingTypeId = sellerProductEntryDTO.HandlingTypeId;
                        if (sellerProductEntryDTO.Images != null && sellerProductEntryDTO.Images.Any())
                        {
                            a.Images = string.Join(",", sellerProductEntryDTO.Images);
                        }
                        a.Thumbnail = sellerProductEntryDTO.Thumbnail;
                        a.UpdatedBy = sellerProductEntryDTO.CreatedBy;
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
        public SellerProductEntry GetSellerProductEntryById(Int64 sellerProductEntryId)
        {
            return _dbContext.SellerProductEntrys.Where(x => x.SellerProductEntryId == sellerProductEntryId && x.Deleted == false).SingleOrDefault();
        }

        public MessageEnum DeleteSellerProductEntry(Int64 sellerProductEntryId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.SellerProductEntrys.Where(x => x.SellerProductEntryId == sellerProductEntryId).FirstOrDefault();

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
        public List<SellerProductEntry> GetSellerProductEntrylistByBrandId(Int64 BrandId)
        {
            return _dbContext.SellerProductEntrys.Where(x => x.BrandId == BrandId && x.Deleted == false).ToList();
        }
        public List<SellerProductEntry> GetSellerProductEntrylistByCategoryId(int CategoryId)
        {
            return _dbContext.SellerProductEntrys.Where(x => x.CategoryId == CategoryId && x.Deleted == false).ToList();
        }
    }
}
