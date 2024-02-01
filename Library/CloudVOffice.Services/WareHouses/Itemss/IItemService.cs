using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.WareHouses.Items;

namespace CloudVOffice.Services.WareHouses.Itemss
{
    public interface IItemService
    {
        public ItemDTO CreateItem(ItemDTO itemDTO);
		public MessageEnum UpdateItem(ItemDTO itemDTO);
        public void GenerateAndSaveBarcodeImage(string itemId);
		public Item GetItemByItemId(Int64 itemId);
		public Item GetItemById(Int64 itemId);
        public List<Item> GetItemList();
        public MessageEnum DeleteItem(Int64 itemId, Int64 DeletedBy);
        public List<Item> GetItemlistByBrandId(Int64 BrandId);
        public List<Item> GetItemlistByCategoryId(int CategoryId);
        public List<Item> GetItemlistBySubCategory1Id(int SubCategory1Id);
        public List<Item> GetItemlistBySubCategory2Id(int SubCategory2Id);
        public List<Item> GetItemlistBySectorId(int SectorId);
        public List<Item> ItemListByCategoryId(int CategoryId);

    }
}
