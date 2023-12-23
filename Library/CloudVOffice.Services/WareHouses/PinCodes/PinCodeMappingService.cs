using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.PinCodes
{
	public class PinCodeMappingService : IPinCodeMappingService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<PinCodeMapping> _pinCodeMappingRepo;

		public PinCodeMappingService(ApplicationDBContext dbContext,
								   ISqlRepository<PinCodeMapping> pinCodeMappingRepo

									)
		{
			_dbContext = dbContext;
			_pinCodeMappingRepo = pinCodeMappingRepo;

		}

		public MessageEnum PinCodeMappingCreate(PinCodeMappingDTO pinCodeMappingDTO)
		{
			try
			{
				//var objcheck = _dbContext.PinCodeMappings.Where(x => x.Deleted == false).FirstOrDefault();
				var objcheck = _dbContext.PinCodeMappings.FirstOrDefault(opt => opt.Deleted == false && opt.WareHuoseId == pinCodeMappingDTO.WareHuoseId);

				if (objcheck == null)
				{
					foreach (var pinmappingid in pinCodeMappingDTO.PinCodeId)
					{
						PinCodeMapping pinCodeMapping = new PinCodeMapping();

						pinCodeMapping.PinCodeId = pinmappingid;
						pinCodeMapping.WareHuoseId = pinCodeMappingDTO.WareHuoseId;
						pinCodeMapping.CreatedBy = pinCodeMappingDTO.CreatedBy;
						pinCodeMapping.CreatedDate = System.DateTime.Now;
						var obj = _pinCodeMappingRepo.Insert(pinCodeMapping);

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



		public List<PinCodeMapping> GetPinCodeMappingList()
		{
			return _dbContext.PinCodeMappings
				.Include(s => s.WareHuose)
				.Include(s => s.PinCode)
				.Where(x => x.Deleted == false).ToList();
		}
		public MessageEnum PinCodeMappingUpdate(PinCodeMappingDTO pinCodeMappingDTO)
		{
			try
			{
				var updatepinCodeMapping = _dbContext.PinCodeMappings.Where(x => x.PinCodeMappingId != pinCodeMappingDTO.PinCodeMappingId && pinCodeMappingDTO.PinCodeId.Contains(x.PinCodeId) && x.WareHuoseId == pinCodeMappingDTO.WareHuoseId && x.Deleted == false).FirstOrDefault();

				if (updatepinCodeMapping == null)
				{
					var a = _dbContext.PinCodeMappings.Where(x => x.PinCodeMappingId == pinCodeMappingDTO.PinCodeMappingId).FirstOrDefault();
					if (a != null)
					{
						foreach (var pinmappingid in pinCodeMappingDTO.PinCodeId)
						{
							a.WareHuoseId = pinCodeMappingDTO.WareHuoseId;
							a.PinCodeId = pinmappingid;
							
							a.UpdatedBy = pinCodeMappingDTO.CreatedBy;
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
		public PinCodeMapping GetPinCodeMappingById(Int64 PinCodeMappingId)
		{
			return _dbContext.PinCodeMappings.Where(x => x.PinCodeMappingId == PinCodeMappingId && x.Deleted == false).SingleOrDefault();
		}
		
        public MessageEnum PinCodeMappingDelete(Int64 PinCodeMappingId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.PinCodeMappings.Where(x => x.PinCodeMappingId == PinCodeMappingId).FirstOrDefault();

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
