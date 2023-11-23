using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Company;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.Company;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouse.PinCodes
{
    public class PinCodeService : IPinCodeService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<PinCode> _pinCodeRepo;
        public PinCodeService(ApplicationDBContext dbContext, ISqlRepository<PinCode> pinCodeRepo)
        {

            _dbContext = dbContext;
            _pinCodeRepo = pinCodeRepo;
        }


        public MessageEnum PinCodeCreate(PinCodeDTO pinCodeDTO)
        {
            try
            {
                var pin = _dbContext.PinCodes.Where(x => x.Pin == pinCodeDTO.Pin && x.Deleted == false).FirstOrDefault();
                if (pin == null)
                {
                    PinCode pinCode = new PinCode();
                    pinCode.Pin=pinCodeDTO.Pin;
                    pinCode.Lat=pinCodeDTO.Lat;
                    pinCode.Long=pinCodeDTO.Long;
                    pinCode.IsActive = pinCodeDTO.IsActive;
                    pinCode.CreatedBy=pinCodeDTO.CreatedBy;
                    var obj = _pinCodeRepo.Insert(pinCode);

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
        public MessageEnum PinUpdate(PinCodeDTO pinCodeDTO)
        {
            try
            {
                var pin = _dbContext.PinCodes.Where(x => x.PinCodeId != pinCodeDTO.PinCodeId && x.Pin == pinCodeDTO.Pin && x.Deleted == false).FirstOrDefault();
                if (pin == null)
                {
                    var a = _dbContext.PinCodes.Where(x => x.PinCodeId == pinCodeDTO.PinCodeId).FirstOrDefault();
                    if (a != null)
                    {
                        a.Pin = pinCodeDTO.Pin;
                        a.Lat = pinCodeDTO.Lat;
                        a.Long = pinCodeDTO.Long;
                        a.IsActive = pinCodeDTO.IsActive;
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
        public PinCode GetPinByPinCodeId(Int64 pinCodeId)
        {
            try
            {
                return _dbContext.PinCodes.Where(x => x.PinCodeId == pinCodeId && x.Deleted == false).SingleOrDefault();

            }
            catch
            {
                throw;
            }
        }
        public List<PinCode> GetPinList()
        {
            try
            {
                return _dbContext.PinCodes.Where(x => x.Deleted == false).ToList();
            }
            catch
            {
                throw;
            }
        }
		public MessageEnum PinDelete(Int64 pinCodeId, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.PinCodes.Where(x => x.PinCodeId == pinCodeId).FirstOrDefault();
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
