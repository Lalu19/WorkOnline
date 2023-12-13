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
	public class UnitService : IUnit
	{
		private readonly ApplicationDBContext _Context;
		private readonly ISqlRepository<Unit> _unitRepo;
		public UnitService(ApplicationDBContext Context, ISqlRepository<Unit> unitRepo)
		{

			_Context = Context;
			_unitRepo = unitRepo;
		}
		public MessageEnum UnitCreate(UnitDTO unitDTO)
		{
			var objCheck = _Context.Units.SingleOrDefault(opt => opt.UnitId == unitDTO.UnitId && opt.Deleted == false);
			try
			{
				if (objCheck == null)
				{

					Unit unit = new Unit();
					unit.UnitName = unitDTO.UnitName;
					unit.ShortName = unitDTO.ShortName;
					unit.UnitGroupId = unitDTO.UnitGroupId;
					unit.CreatedBy = unitDTO.CreatedBy;
					var obj = _unitRepo.Insert(unit);

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

		public MessageEnum UnitDelete(Int64 unitId, Int64 DeletedBy)
		{
			try
			{
				var a = _Context.Units.Where(x => x.UnitId == unitId).FirstOrDefault();
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

		public MessageEnum UnitUpdate(UnitDTO unitDTO)
		{
			try
			{
				var bank = _Context.Units.Where(x => x.UnitId != unitDTO.UnitId && x.UnitName == unitDTO.UnitName && x.Deleted == false).FirstOrDefault();
				if (bank == null)
				{
					var a = _Context.Units.Where(x => x.UnitId == unitDTO.UnitId).FirstOrDefault();
					if (a != null)
					{
						a.UnitName = unitDTO.UnitName;
						a.ShortName = unitDTO.ShortName;
						a.UnitGroupId = unitDTO.UnitGroupId;
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
		public List<Unit> GetUnit()
		{
			try
			{
				return _Context.Units.Include(s => s.UnitGroup).Where(x => x.Deleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}

		public Unit GetUnitByUnitId(Int64 unitId)
		{
			try
			{
				return _Context.Units.Where(x => x.UnitId == unitId && x.Deleted == false).SingleOrDefault();

			}
			catch
			{
				throw;
			}
		}

	}
}
