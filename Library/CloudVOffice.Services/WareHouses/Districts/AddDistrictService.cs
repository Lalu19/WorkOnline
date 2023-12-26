using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Data.DTO.WareHouses.Districts;
using CloudVOffice.Data.DTO.WareHouses.GSTs;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Districts
{
	public class AddDistrictService: IAddDistrictService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<AddDistrict> _addDistrictRepo;

		public AddDistrictService(ApplicationDBContext dbContext,
								   ISqlRepository<AddDistrict> addDistrictRepo

									)
		{
			_dbContext = dbContext;
			_addDistrictRepo = addDistrictRepo;

		}
		public MessageEnum AddDistrictCreate(AddDistrictDTO addDistrictDTO)
		{
			try
			{
				var objcheck = _dbContext.AddDistricts.SingleOrDefault(opt => opt.Deleted == false && opt.DistrictName == addDistrictDTO.DistrictName);
				if (objcheck == null)
				{
					AddDistrict sc = new AddDistrict();
					sc.DistrictName = addDistrictDTO.DistrictName;
					sc.CreatedBy = addDistrictDTO.CreatedBy;
					sc.CreatedDate = System.DateTime.Now;
					var obj = _addDistrictRepo.Insert(sc);
					return MessageEnum.Success;
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
		public List<AddDistrict> GetAddDistrictList()
		{
			try
			{
				return _dbContext.AddDistricts.Where(x => x.Deleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}
		public MessageEnum AddDistrictUpdate(AddDistrictDTO addDistrictDTO)
		{
			try
			{
				var updateAddDistrict = _dbContext.AddDistricts.Where(x => x.AddDistrictId != addDistrictDTO.AddDistrictId && x.DistrictName == addDistrictDTO.DistrictName && x.Deleted == false).FirstOrDefault();
				if (updateAddDistrict == null)
				{
					var a = _dbContext.AddDistricts.Where(x => x.AddDistrictId == addDistrictDTO.AddDistrictId).FirstOrDefault();
					if (a != null)
					{
						a.DistrictName = addDistrictDTO.DistrictName;
						a.UpdatedBy = addDistrictDTO.CreatedBy;
						a.UpdatedDate = DateTime.Now;
						_dbContext.SaveChanges();
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
		public AddDistrict GetAddDistrictById(Int64 AddDistrictId)
		{
			return _dbContext.AddDistricts.Where(x => x.AddDistrictId == AddDistrictId && x.Deleted == false).SingleOrDefault();
		}

		public MessageEnum AddDistrictDelete(Int64 AddDistrictId, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.AddDistricts.Where(x => x.AddDistrictId == AddDistrictId).FirstOrDefault();

				if (a != null)
				{
					a.Deleted = true;
					a.UpdatedBy = DeletedBy;
					a.UpdatedDate = DateTime.Now;
					_dbContext.SaveChanges();
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
	}
}
