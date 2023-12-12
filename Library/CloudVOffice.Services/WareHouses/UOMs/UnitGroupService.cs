using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using CloudVOffice.Data.DTO.WareHouses.UOMs;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.UOMs
{
	public class UnitGroupService : IUnitGroup
	{
		private readonly ApplicationDBContext _Context;
		private readonly ISqlRepository<UnitGroup> _unitGroupRepo;
		public UnitGroupService(ApplicationDBContext Context, ISqlRepository<UnitGroup> unitGroup)
		{

			_Context = Context;
			_unitGroupRepo = unitGroup;
		}
		public MessageEnum UnitGroupCreate(UnitGroupDTO unitGroupDTO)
		{
			var objCheck = _Context.UnitGroups.SingleOrDefault(opt => opt.UnitGroupId == unitGroupDTO.UnitGroupId && opt.Deleted == false);
			try
			{
				if (objCheck == null)
				{

					UnitGroup unitgro = new UnitGroup();
					unitgro.UnitGroupName = unitGroupDTO.UnitGroupName;
					unitgro.CreatedBy = unitGroupDTO.CreatedBy;
					var obj = _unitGroupRepo.Insert(unitgro);

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

		public MessageEnum UnitGroupDelete(Int64 unitGroupId, Int64 DeletedBy)
		{
			try
			{
				var a = _Context.UnitGroups.Where(x => x.UnitGroupId == unitGroupId).FirstOrDefault();
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

		public MessageEnum UnitGroupUpdate(UnitGroupDTO unitGroupDTO)
		{
			try
			{
				var bank = _Context.UnitGroups.Where(x => x.UnitGroupId != unitGroupDTO.UnitGroupId && x.UnitGroupName == unitGroupDTO.UnitGroupName && x.Deleted == false).FirstOrDefault();
				if (bank == null)
				{
					var a = _Context.UnitGroups.Where(x => x.UnitGroupId == unitGroupDTO.UnitGroupId).FirstOrDefault();
					if (a != null)
					{
						a.UnitGroupName = unitGroupDTO.UnitGroupName;
						a.CreatedBy = unitGroupDTO.CreatedBy;
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

		public List<UnitGroup> GetUnitGroup()
		{
			try
			{
				return _Context.UnitGroups.Where(x => x.Deleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}

		public UnitGroup GetUnitGroupByGetUnitGroupId(Int64 unitGroupId)
		{
			try
			{
				return _Context.UnitGroups.Where(x => x.UnitGroupId == unitGroupId && x.Deleted == false).SingleOrDefault();

			}
			catch
			{
				throw;
			}
		}

	}
}
