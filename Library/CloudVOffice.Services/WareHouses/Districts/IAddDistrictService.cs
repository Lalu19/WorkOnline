using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Data.DTO.WareHouses.Districts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Districts
{
	public interface IAddDistrictService
	{
		public MessageEnum AddDistrictCreate(AddDistrictDTO addDistrictDTO);
		public AddDistrict GetAddDistrictById(Int64 addDistrictId);
		public List<AddDistrict> GetAddDistrictList();
		public MessageEnum AddDistrictUpdate(AddDistrictDTO addDistrictDTO);
		public MessageEnum AddDistrictDelete(Int64 addDistrictId, Int64 DeletedBy);
	}
}
