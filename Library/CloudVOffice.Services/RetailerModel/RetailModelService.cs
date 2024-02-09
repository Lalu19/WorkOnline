using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.RetailerModel;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.RetailerModel;
//using CloudVOffice.Data.Migrations;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.RetailerModel
{
    public class RetailModelService : IRetailModelService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<RetailModel> _RetailerModelRepo;
        public RetailModelService(ApplicationDBContext dbContext, ISqlRepository<RetailModel> RetailerModelRepo)
        {
            _dbContext = dbContext;
            _RetailerModelRepo = RetailerModelRepo;
        }
        public MessageEnum RetailModelCreate(RetailModelDTO retailModelDTO)
        {
            try
            {
                var objcheck = _dbContext.RetailModels.SingleOrDefault(opt => opt.Deleted == false && opt.RetailerName == retailModelDTO.RetailerName);
                if (objcheck == null)
                {
                    RetailModel rm = new RetailModel();
                    rm.RetailerName = retailModelDTO.RetailerName;
                    rm.CreatedBy = retailModelDTO.CreatedBy;
                    rm.CreatedDate = System.DateTime.Now;
                    var obj = _RetailerModelRepo.Insert(rm);
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
        public List<RetailModel> GetRetailModelList()
        {
            try
            {
                var a = _dbContext.RetailModels.Where(x => x.Deleted == false).ToList();

                return a;
            }
            catch
            {
                throw;
            }
        }
        public RetailModel GetRetailModelById(int RetailModelId)
        {
            return _dbContext.RetailModels.Where(x => x.RetailModelId == RetailModelId && x.Deleted == false).SingleOrDefault();
        }
        public MessageEnum RetailModelUpdate(RetailModelDTO retailModelDTO)
        {
            try
            {
                var updateRetail = _dbContext.RetailModels.Where(x => x.RetailModelId != retailModelDTO.RetailModelId && x.RetailerName == retailModelDTO.RetailerName && x.Deleted == false).FirstOrDefault();
                if (updateRetail == null)
                {
                    var a = _dbContext.RetailModels.Where(x => x.RetailModelId == retailModelDTO.RetailModelId).FirstOrDefault();
                    if (a != null)
                    {
                        a.RetailerName = retailModelDTO.RetailerName;
                        a.UpdatedBy = retailModelDTO.CreatedBy;
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

        public MessageEnum DeleteRetailModel(int RetailModelId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.RetailModels.Where(x => x.RetailModelId == RetailModelId).FirstOrDefault();
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
