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
	public class DistrictMappingService: IDistrictMappingService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<DistrictMapping> _districtRepo;

		public DistrictMappingService(ApplicationDBContext dbContext,
								   ISqlRepository<DistrictMapping> districtRepo

									)
		{
			_dbContext = dbContext;
			_districtRepo = districtRepo;

		}
        public MessageEnum DistrictCreate(DistrictMappingDTO districtMappingDTO)
        {
            try
            {

                var objcheck = _dbContext.DistrictMappings.SingleOrDefault(opt => opt.Deleted == false);

                if (objcheck == null)
                {
                    foreach (var districtMappingId in districtMappingDTO.PinCodeId)
                    {
                        DistrictMapping districtMapping = new DistrictMapping();

                        districtMapping.PinCodeId = districtMappingId;
                        districtMapping.AddDistrictId = (long)districtMappingDTO.AddDistrictId;
                        districtMapping.CreatedBy = districtMappingDTO.CreatedBy;
                        districtMapping.CreatedDate = System.DateTime.Now;
                        var obj = _districtRepo.Insert(districtMapping);

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
        public List<DistrictMapping> GetDistrictList()
		{
            return _dbContext.DistrictMappings
                .Include(s => s.AddDistrictId)
                .Include(s => s.PinCodeId)
                .Where(x => x.Deleted == false).ToList();
        }
        public MessageEnum DistrictUpdate(DistrictMappingDTO districtMappingDTO)
        {
            try
            {
                var updatedistrict = _dbContext.DistrictMappings.Where(x => x.DistrictMappingId != districtMappingDTO.DistrictMappingId && districtMappingDTO.PinCodeId.Contains(x.PinCodeId) && x.AddDistrictId == districtMappingDTO.AddDistrictId && x.Deleted == false).FirstOrDefault();

                if (updatedistrict == null)
                {
                    var a = _dbContext.DistrictMappings.Where(x => x.DistrictMappingId == districtMappingDTO.DistrictMappingId).FirstOrDefault();
                    if (a != null)
                    {
                        foreach (var districtMappingId in districtMappingDTO.PinCodeId)
                        {
                            a.AddDistrictId = (long)districtMappingDTO.AddDistrictId;
                            a.PinCodeId = districtMappingId;
                            a.UpdatedBy = districtMappingDTO.CreatedBy;
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
        public DistrictMapping GetDistrictById(Int64 districtMappingId)
		{
			return _dbContext.DistrictMappings.Where(x => x.DistrictMappingId == districtMappingId && x.Deleted == false).SingleOrDefault();
		}

		public MessageEnum DistrictDelete(Int64 DistrictMappingId, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.DistrictMappings.Where(x => x.DistrictMappingId == DistrictMappingId).FirstOrDefault();

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
