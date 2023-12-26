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
		private readonly ISqlRepository<DistrictMapping> _districtMappingRepo;

		public DistrictMappingService(ApplicationDBContext dbContext,
								   ISqlRepository<DistrictMapping> districtMappingRepo

									)
		{
			_dbContext = dbContext;
            _districtMappingRepo = districtMappingRepo;

		}
        //public MessageEnum DistrictMappingCreate(DistrictMappingDTO districtMappingDTO)
        //{
        //    try
        //    {

        //        var objcheck = _dbContext.DistrictMappings.Where(opt => opt.Deleted == false && opt.AddDistrictId == districtMappingDTO.AddDistrictId).SingleOrDefault();

        //        if (objcheck == null)
        //        {
        //            foreach (var districtMappingId in districtMappingDTO.PinCodeId)
        //            {
        //                DistrictMapping districtMapping = new DistrictMapping();

        //                districtMapping.PinCodeId = districtMappingId;
        //                districtMapping.AddDistrictId = (long)districtMappingDTO.AddDistrictId;
        //                districtMapping.CreatedBy = districtMappingDTO.CreatedBy;
        //                districtMapping.CreatedDate = System.DateTime.Now;
        //                var obj = _districtMappingRepo.Insert(districtMapping);

        //            }
        //            return MessageEnum.Success;
        //        }
        //        else if (objcheck != null)
        //        {
        //            return MessageEnum.Duplicate;
        //        }

        //        return MessageEnum.UnExpectedError;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public MessageEnum DistrictMappingCreate(DistrictMappingDTO districtMappingDTO)
        {
            try
            {
                var districtExists = _dbContext.DistrictMappings.Any(opt => opt.Deleted == false && opt.AddDistrictId == districtMappingDTO.AddDistrictId);

                if (!districtExists)
                {
                    foreach (var districtMappingId in districtMappingDTO.PinCodeId)
                    {
                        var pinCodeExists = _dbContext.DistrictMappings.Any(opt => opt.Deleted == false && opt.PinCodeId == districtMappingId);

                        if (!pinCodeExists)
                        {
                            DistrictMapping districtMapping = new DistrictMapping
                            {
                                PinCodeId = districtMappingId,
                                AddDistrictId = (long)districtMappingDTO.AddDistrictId,
                                CreatedBy = districtMappingDTO.CreatedBy,
                                CreatedDate = DateTime.UtcNow // Use UTC time
                            };

                            _districtMappingRepo.Insert(districtMapping);
                        }
                        else
                        {
                            return MessageEnum.Duplicate;
                        }
                    }

                    return MessageEnum.Success;
                }
                else
                {
                    return MessageEnum.Duplicate;
                }
            }
            catch (SpecificException ex)
            {
                // Handle specific exception
                return MessageEnum.UnExpectedError;
            }
        }




        public List<DistrictMapping> GetDistrictMappingList()
		{
            try
            {
                return _dbContext.DistrictMappings.Where(x => x.Deleted == false).ToList();
            }
            catch
            {
                throw;
            }

        }
        public MessageEnum DistrictMappingUpdate(DistrictMappingDTO districtMappingDTO)
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
        public DistrictMapping GetDistrictMappingById(Int64 districtMappingId)
		{
			return _dbContext.DistrictMappings.Where(x => x.DistrictMappingId == districtMappingId && x.Deleted == false).SingleOrDefault();
		}

		public MessageEnum DistrictMappingDelete(Int64 DistrictMappingId, Int64 DeletedBy)
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
