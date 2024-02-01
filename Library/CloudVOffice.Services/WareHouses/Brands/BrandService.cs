using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Core.Domain.WareHouses.Stocks;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Data.DTO.WareHouses.Months;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Brands
{
    public class BrandService: IBrandService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Brand> _brandRepo;

        public BrandService(ApplicationDBContext dbContext,
                                   ISqlRepository<Brand> brandRepo

                                    )
        {
            _dbContext = dbContext;
            _brandRepo = brandRepo;

        }
        public MessageEnum BrandCreate(BrandDTO brandDTO)
        {
            try
            {
                var objcheck = _dbContext.Brands.SingleOrDefault(opt => opt.Deleted == false && opt.BrandName == brandDTO.BrandName);
                if (objcheck == null)
                {
                    Brand sc = new Brand();
                    sc.BrandName = brandDTO.BrandName;
                    sc.BrandImage = brandDTO.BrandImage;
                    sc.CreatedBy = brandDTO.CreatedBy;
                    sc.CreatedDate = System.DateTime.Now;
                    var obj = _brandRepo.Insert(sc);
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
        public List<Brand> GetBrandList()
        {
            try
            {
                return _dbContext.Brands.Where(x => x.Deleted == false).ToList();
            }
            catch
            {
                throw;
            }
        }
        public MessageEnum BrandUpdate(BrandDTO brandDTO)
        {
            try
            {
                var updateMonth = _dbContext.Brands.Where(x => x.BrandId != brandDTO.BrandId && x.BrandName == brandDTO.BrandName && x.Deleted == false).FirstOrDefault();
                if (updateMonth == null)
                {
                    var a = _dbContext.Brands.Where(x => x.BrandId == brandDTO.BrandId).FirstOrDefault();
                    if (a != null)
                    {
                        a.BrandName = brandDTO.BrandName;
                        a.BrandImage = brandDTO.BrandImage;
                        a.UpdatedBy = brandDTO.CreatedBy;
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
        public Brand GetBrandById(Int64 BrandId)
        {
            return _dbContext.Brands.Where(x => x.BrandId == BrandId && x.Deleted == false).SingleOrDefault();
        }

        public MessageEnum BrandDelete(Int64 BrandId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.Brands.Where(x => x.BrandId == BrandId).FirstOrDefault();

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

        public List<Brand> GetBrandsBySectorId(Int64 sectorId)
        {
            var sectors = _dbContext.Items.Where(sec => sec.SectorId == sectorId).ToList();
            List<Int64?> list = new List<Int64?>();
            List<Brand> brands = new List<Brand>();

            foreach (var Idbrand in sectors)
            {
                Int64? brandId = Idbrand.BrandId;
                list.Add(brandId);
            }


            foreach (var brandId in list)
            {
                Brand brand = _dbContext.Brands.FirstOrDefault(i => i.BrandId == brandId);
                brands.Add(brand);
            }

            return brands;
        }


        public Int64 GetBrandIdByBrandName(string brandName)
        {
            var brand = _dbContext.Brands.FirstOrDefault(x=> x.BrandName == brandName);

            Int64 id = brand.BrandId;
            return id;
        }


        public List<Brand> GetBrandListByCategoryId(Int64 categoryId)
        {
            var items = _dbContext.Items.Where(i => i.CategoryId == categoryId).ToList();

            List<Brand> brands = new List<Brand>();

            foreach (var item in items)
            {
                var brand = _dbContext.Brands.FirstOrDefault(b => b.BrandId == item.BrandId);
                brands.Add(brand);
            }

            return brands;
        }
    }
}
