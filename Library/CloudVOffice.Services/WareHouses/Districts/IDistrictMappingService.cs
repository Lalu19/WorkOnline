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
	public interface IDistrictMappingService
	{
		public MessageEnum DistrictCreate(DistrictMappingDTO districtMappingDTO);
		public DistrictMapping GetDistrictById(Int64 districtMappingId);
		public List<DistrictMapping> GetDistrictList();
		public MessageEnum DistrictUpdate(DistrictMappingDTO districtMappingDTO);
		public MessageEnum DistrictDelete(Int64 districtMappingId, Int64 DeletedBy);
	}
}
