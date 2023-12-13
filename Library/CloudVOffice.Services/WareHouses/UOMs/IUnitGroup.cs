using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using CloudVOffice.Data.DTO.WareHouses.UOMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.UOMs
{
	public interface IUnitGroup
	{
		public MessageEnum UnitGroupCreate(UnitGroupDTO unitGroupDTO);
		public List<UnitGroup> GetUnitGroup();
		public UnitGroup GetUnitGroupByGetUnitGroupId(Int64 unitGroupId);
		public MessageEnum UnitGroupUpdate(UnitGroupDTO unitGroupDTO);
		public MessageEnum UnitGroupDelete(Int64 unitGroupId, Int64 DeletedBy);
	}
}
