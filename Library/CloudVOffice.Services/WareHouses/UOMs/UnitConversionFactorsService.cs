using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using CloudVOffice.Data.DTO.WareHouses.UOMs;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.UOMs
{
	public class UnitConversionFactorsService : IUnitConversionFactors
	{
		private readonly ApplicationDBContext _Context;
		private readonly ISqlRepository<UnitConversionFactors> _unitConversionFactorsRepo;
		public UnitConversionFactorsService(ApplicationDBContext Context, ISqlRepository<UnitConversionFactors> unitConversionFactorsRepo)
		{

			_Context = Context;
			_unitConversionFactorsRepo = unitConversionFactorsRepo;
		}
		public MessageEnum UnitConversionFactorsCreate(UnitConversionFactorsDTO unitConversionFactorsDTO)
		{
			var objCheck = _Context.UnitConversionFactors.SingleOrDefault(opt => opt.UnitConversionFactorsId == unitConversionFactorsDTO.UnitConversionFactorsId && opt.Deleted == false);
			try
			{
				if (objCheck == null)
				{

					UnitConversionFactors unitConversionFactors = new UnitConversionFactors();
					unitConversionFactors.FromUnitId = unitConversionFactorsDTO.FromUnitId;
					unitConversionFactors.ToUnitId = unitConversionFactorsDTO.ToUnitId;
					unitConversionFactors.Value = unitConversionFactorsDTO.Value;
					unitConversionFactors.CreatedBy = unitConversionFactorsDTO.CreatedBy;
					var obj = _unitConversionFactorsRepo.Insert(unitConversionFactors);

					return MessageEnum.Success;
				}
				else if (objCheck != null)
				{
					return MessageEnum.Duplicate;
				}

				return MessageEnum.UnExpectedError;
			}
			catch
			{
				throw;
			}
		}

		public MessageEnum UnitConversionFactorsDelete(Int64 unitConversionFactorsId, Int64 DeletedBy)
		{
			try
			{
				var a = _Context.UnitConversionFactors.Where(x => x.UnitConversionFactorsId == unitConversionFactorsId).FirstOrDefault();
				if (a != null)
				{
					a.Deleted = true;
					a.UpdatedBy = DeletedBy;
					a.UpdatedDate = DateTime.Now;
					_Context.SaveChanges();
					return MessageEnum.Deleted;
				}
				else
					return MessageEnum.Invalid;
			}
			catch
			{
				throw;
			}
		}

		public MessageEnum UnitConversionFactorsUpdate(UnitConversionFactorsDTO unitConversionFactorsDTO)
		{
			try
			{
				var bank = _Context.UnitConversionFactors.Where(x => x.UnitConversionFactorsId != unitConversionFactorsDTO.UnitConversionFactorsId && x.FromUnitId == unitConversionFactorsDTO.FromUnitId && x.Deleted == false).FirstOrDefault();
				if (bank == null)
				{
					var a = _Context.UnitConversionFactors.Where(x => x.UnitConversionFactorsId == unitConversionFactorsDTO.UnitConversionFactorsId).FirstOrDefault();
					if (a != null)
					{
						a.FromUnitId = unitConversionFactorsDTO.FromUnitId;
						a.ToUnitId = unitConversionFactorsDTO.ToUnitId;
						a.Value = unitConversionFactorsDTO.Value;
						a.UpdatedDate = DateTime.Now;
						_Context.SaveChanges();
						return MessageEnum.Updated;
					}
					else
						return MessageEnum.Invalid;
				}
				else
				{
					return MessageEnum.Duplicate;
				}

			}
			catch
			{
				throw;
			}
		}
		public List<UnitConversionFactors> GetUnitConversionFactors()
		{
			try
			{
				return _Context.UnitConversionFactors.Include(s => s.Unit).Where(x => x.Deleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}

		public UnitConversionFactors GetUnitConversionFactorsByUnitConversionFactorsId(long unitConversionFactorsId)
		{
			try
			{
				return _Context.UnitConversionFactors.Where(x => x.UnitConversionFactorsId == unitConversionFactorsId && x.Deleted == false).SingleOrDefault();

			}
			catch
			{
				throw;
			}
		}
	}
}
