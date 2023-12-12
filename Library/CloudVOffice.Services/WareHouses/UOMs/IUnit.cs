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
	public interface IUnit
	{
		public MessageEnum UnitCreate(UnitDTO unitDTO);
		public List<Unit> GetUnit();
		public Unit GetUnitByUnitId(Int64 unitId);
		public MessageEnum UnitUpdate(UnitDTO unitDTO);
		public MessageEnum UnitDelete(Int64 unitId, Int64 DeletedBy);
	}
}
