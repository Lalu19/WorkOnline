using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Data.DTO.WareHouses.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Sellers
{
    public interface ISellerProductEntryService
    {
        public MessageEnum CreateSellerProductEntry(SellerProductEntryDTO sellerProductEntryDTO);
        public MessageEnum UpdateSellerProductEntry(SellerProductEntryDTO sellerProductEntryDTO);
        public SellerProductEntry GetSellerProductEntryById(Int64 sellerProductEntryId);
        public List<SellerProductEntry> GetSellerProductEntryList();
        public MessageEnum DeleteSellerProductEntry(Int64 sellerProductEntryId, Int64 DeletedBy);
        public List<SellerProductEntry> GetSellerProductEntrylistByBrandId(Int64 BrandId);
        public List<SellerProductEntry> GetSellerProductEntrylistByCategoryId(int CategoryId);
        
    }
}
