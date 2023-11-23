using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouse.PinCodeMapping;
using CloudVOffice.Core.Domain.WareHouse.PinCodes;
using CloudVOffice.Data.DTO.WareHouse.PinCodeMapping;
using CloudVOffice.Data.DTO.WareHouse.PinCodes;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouse.PinCodeMappings
{
	public class PinCodeMappingService : IPinCodeMappingService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<PinCodeMapping> _pinCodeMappingRepo;
		public PinCodeMappingService(ApplicationDBContext dbContext, ISqlRepository<PinCodeMapping> pinCodeMappingRepo)
		{

			_dbContext = dbContext;
			_pinCodeMappingRepo = pinCodeMappingRepo;
		}

		public MessageEnum PinMappingCreate(PinCodeMappingDTO pinCodeMappingDTO)
		{
			try
			{
				var pinMapping = _dbContext.PinCodeMappings.Where(x => x.UserId == pinCodeMappingDTO.UserId && x.Deleted == false).FirstOrDefault();
				if (pinMapping == null)
				{
					PinCodeMapping pinCodeMapping = new PinCodeMapping();

					pinCodeMapping.UserId = pinCodeMapping.UserId;
					pinCodeMapping.PinCodeId = pinCodeMappingDTO.PinCodeId;
					pinCodeMapping.CreatedBy = pinCodeMapping.CreatedBy;
					var obj = _pinCodeMappingRepo.Insert(pinCodeMapping);

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
		public MessageEnum PinMappingUpdate(PinCodeMappingDTO pinCodeMappingDTO)
		{
			try
			{
				var pinMapping = _dbContext.PinCodeMappings.Where(x => x.PinCodeMappingId != pinCodeMappingDTO.PinCodeMappingId && x.UserId == pinCodeMappingDTO.UserId && x.Deleted == false).FirstOrDefault();
				if (pinMapping == null)
				{
					var a = _dbContext.PinCodeMappings.Where(x => x.PinCodeMappingId == pinCodeMappingDTO.PinCodeMappingId).FirstOrDefault();
					if (a != null)
					{
						a.UserId = pinCodeMappingDTO.UserId;
						a.PinCodeId = pinCodeMappingDTO.PinCodeId;
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
		public PinCodeMapping GetPinMappingByPinCodeId(Int64 pinCodeMappingId)
		{
			try
			{
				return _dbContext.PinCodeMappings.Where(x => x.PinCodeMappingId == pinCodeMappingId && x.Deleted == false).SingleOrDefault();

			}
			catch
			{
				throw;
			}
		}
		public List<PinCodeMapping> GetPinMappingList()
		{
			try
			{
				return _dbContext.PinCodeMappings.Where(x => x.Deleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}
		public MessageEnum PinMappingDelete(Int64 pinCodeMappingId, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.PinCodeMappings.Where(x => x.PinCodeMappingId == pinCodeMappingId).FirstOrDefault();
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
