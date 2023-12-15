using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.Districts;
using CloudVOffice.Data.DTO.WareHouses.Employees;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Districts
{
	public class DistrictService: IDistrictService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<District> _districtRepo;

		public DistrictService(ApplicationDBContext dbContext,
								   ISqlRepository<District> districtRepo

									)
		{
			_dbContext = dbContext;
			_districtRepo = districtRepo;

		}
		public MessageEnum DistrictCreate(DistrictDTO districtDTO)
		{
			try
			{

				var objcheck = _dbContext.Districts.SingleOrDefault(opt => opt.Deleted == false);

				if (objcheck == null)
				{
					foreach (var districtid in districtDTO.PinCodeId)
					{
						District district = new District();

						district.PinCodeId = districtid;
						district.DistrictName = districtDTO.DistrictName;
						district.CreatedBy = districtDTO.CreatedBy;
						district.CreatedDate = System.DateTime.Now;
						var obj = _districtRepo.Insert(district);

					}
					return MessageEnum.Success;
				}
				else if (objcheck != null)
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
		public List<District> GetDistrictList()
		{
			try
			{
				return _dbContext.Districts.Where(x => x.Deleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}
		public MessageEnum DistrictUpdate(DistrictDTO districtDTO)
		{
			try
			{
				var updatedistrict = _dbContext.Districts.Where(x => x.DistrictId != districtDTO.DistrictId && districtDTO.PinCodeId.Contains(x.PinCodeId) && x.DistrictName == districtDTO.DistrictName && x.Deleted == false).FirstOrDefault();
                //var updatedistrict = _dbContext.Districts.Where(em => em.DistrictId != districtDTO.DistrictId && districtDTO.PinCodeId.Contains(em.PinCodeId) && em.DistrictName == districtDTO.DistrictName && em.Deleted == false).FirstOrDefault();
                if (updatedistrict == null)
                {
					var a = _dbContext.Districts.Where(x => x.DistrictId == districtDTO.DistrictId).FirstOrDefault();
					if (a != null)
					{
						foreach (var districtid in districtDTO.PinCodeId)
						{
							a.DistrictName = districtDTO.DistrictName;
							a.PinCodeId = districtid;

							a.UpdatedBy = districtDTO.CreatedBy;
							a.UpdatedDate = DateTime.Now;
							_dbContext.SaveChanges();

						}
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
		public District GetDistrictById(Int64 DistrictId)
		{
			return _dbContext.Districts.Where(x => x.DistrictId == DistrictId && x.Deleted == false).SingleOrDefault();
		}

		public MessageEnum DistrictDelete(Int64 DistrictId, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.Districts.Where(x => x.DistrictId == DistrictId).FirstOrDefault();

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
