﻿using CloudVOffice.Core.Domain.Common;
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
		public MessageEnum DistrictMappingCreate(DistrictMappingDTO districtMappingDTO);
		public DistrictMapping GetDistrictMappingById(Int64 districtMappingId);
		public List<DistrictMapping> GetDistrictMappingList();
		public MessageEnum DistrictMappingUpdate(DistrictMappingDTO districtMappingDTO);
		public MessageEnum DistrictMappingDelete(Int64 districtMappingId, Int64 DeletedBy);
	}
}
