using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.Employees;
using CloudVOffice.Data.DTO.WareHouses.Districts;
using CloudVOffice.Data.DTO.WareHouses.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Districts
{
	public interface IDistrictService
	{
		public MessageEnum DistrictCreate(DistrictDTO districtDTO);
		public District GetDistrictById(Int64 districtId);
		public List<District> GetDistrictList();
		public MessageEnum DistrictUpdate(DistrictDTO districtDTO);
		public MessageEnum DistrictDelete(Int64 districtId, Int64 DeletedBy);
	}
}
