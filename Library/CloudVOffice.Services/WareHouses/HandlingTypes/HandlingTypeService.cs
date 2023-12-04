using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Core.Domain.WareHouses.HandlingTypes;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.WareHouses.GSTs;
using CloudVOffice.Data.DTO.WareHouses.HandlingTypes;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.HandlingTypes
{
    public class HandlingTypeService: IHandlingTypeService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<HandlingType> _HandlingTypeRepo;
        public HandlingTypeService(ApplicationDBContext dbContext, ISqlRepository<HandlingType> HandlingTypeRepo)
        {
            _dbContext = dbContext;
            _HandlingTypeRepo = HandlingTypeRepo;
        }
        public MessageEnum HandlingTypeCreate(HandlingTypeDTO handlingtypeDTO)
        {

            try
            {
                var objcheck = _dbContext.HandlingTypes.SingleOrDefault(opt => opt.Deleted == false && opt.HandlingTypeName == handlingtypeDTO.HandlingTypeName);
                if (objcheck == null)
                {
                    HandlingType sc = new HandlingType();
                    sc.HandlingTypeName = handlingtypeDTO.HandlingTypeName;
                    sc.CreatedBy = handlingtypeDTO.CreatedBy;
                    sc.CreatedDate = System.DateTime.Now;
                    var obj = _HandlingTypeRepo.Insert(sc);
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
        public List<HandlingType> GetHandlingTypeList()
        {
            try
            {
                return _dbContext.HandlingTypes.Where(x => x.Deleted == false).ToList();

            }
            catch
            {
                throw;
            }
        }
        public HandlingType GetHandlingTypeByHandlingTypeId(Int64 handlingTypeId)
        {
            return _dbContext.HandlingTypes.Where(x => x.HandlingTypeId == handlingTypeId && x.Deleted == false).SingleOrDefault();
        }
        public MessageEnum HandlingTypeUpdate(HandlingTypeDTO handlingtypeDTO)
        {
            try
            {
                var updateHandlingType = _dbContext.HandlingTypes.Where(x => x.HandlingTypeId != handlingtypeDTO.HandlingTypeId && x.HandlingTypeName == handlingtypeDTO.HandlingTypeName && x.Deleted == false).FirstOrDefault();
                if (updateHandlingType == null)
                {
                    var a = _dbContext.HandlingTypes.Where(x => x.HandlingTypeId == handlingtypeDTO.HandlingTypeId).FirstOrDefault();
                    if (a != null)
                    {
                        a.HandlingTypeName = handlingtypeDTO.HandlingTypeName;
                        a.UpdatedBy = handlingtypeDTO.CreatedBy;
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

        public MessageEnum HandlingTypeDelete(Int64 handlintypeId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.HandlingTypes.Where(x => x.HandlingTypeId ==handlintypeId).FirstOrDefault();
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
