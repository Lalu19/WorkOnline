using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Company;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.Company;
using CloudVOffice.Data.DTO.WareHouses.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Itemss
{
	public interface IDamageItemService
	{
		public MessageEnum DamageItemCreate(DamageItemDTO damageItemDTO);
		public DamageItem GetDamageItemByDamageItemId(int damageItemId);
		public List<DamageItem> GetDamageItemList();
		public DamageItem GetDamageItem();
		public MessageEnum DamageItemUpdate(DamageItemDTO damageItemDTO);
		public MessageEnum DamageItemDelete(int damageItemId, int DeletedBy);
	}
}
