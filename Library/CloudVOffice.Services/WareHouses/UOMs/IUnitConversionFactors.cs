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
	public interface IUnitConversionFactors
	{
		public MessageEnum UnitConversionFactorsCreate(UnitConversionFactorsDTO unitConversionFactorsDTO);
		public List<UnitConversionFactors> GetUnitConversionFactors();
		public UnitConversionFactors GetUnitConversionFactorsByUnitConversionFactorsId(Int64 unitConversionFactorsId);
		public MessageEnum UnitConversionFactorsUpdate(UnitConversionFactorsDTO unitConversionFactorsDTO);
		public MessageEnum UnitConversionFactorsDelete(Int64 unitConversionFactorsId, Int64 DeletedBy);
	}
}
