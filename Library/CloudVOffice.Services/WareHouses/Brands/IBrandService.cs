using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Data.DTO.WareHouses.Months;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Brands
{
    public interface IBrandService
    {
        public MessageEnum BrandCreate(BrandDTO brandDTO);
        public Brand GetBrandById(Int64 BrandId);
        public List<Brand> GetBrandList();
        public MessageEnum BrandUpdate(BrandDTO brandDTO);
        public MessageEnum BrandDelete(Int64 BrandId, Int64 DeletedBy);
    }
}
