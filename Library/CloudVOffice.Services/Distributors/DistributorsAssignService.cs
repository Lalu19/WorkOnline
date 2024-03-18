using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Distributors;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Data.DTO.Distributor;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Distributors
{
    public class DistributorsAssignService : IDistributorsAssignService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<DistributorAssign> _DistributorAssignRepo;

        public DistributorsAssignService(ApplicationDBContext dbContext,
                                   ISqlRepository<DistributorAssign> DistributorAssignRepo

                                    )
        {
            _dbContext = dbContext;
            _DistributorAssignRepo = DistributorAssignRepo;

        }
        public MessageEnum DistributorAssign(DistributorAssignDTO DistributorAssignDTO)
        {
            try
            {
                foreach (var PinCodeId in DistributorAssignDTO.PinCodeId)
                {
                    foreach (var BrandId in DistributorAssignDTO.BrandId)
                    {
                        var assign = _dbContext.DistributorAssigns.Any(opt =>
                            opt.Deleted == false &&
                            opt.PinCodeId == PinCodeId &&
                            opt.BrandId == BrandId);

                        if (!assign) 
                        {
                            var assignDistributor = _dbContext.DistributorAssigns.SingleOrDefault(opt =>
                                opt.Deleted == false &&
                                opt.DistributorRegistrationId != DistributorAssignDTO.DistributorRegistrationId &&
                                opt.PinCodeId == PinCodeId &&
                                opt.BrandId == BrandId);

                            if (assignDistributor == null) 
                            {
                                DistributorAssign distributorAssign = new DistributorAssign();
                                distributorAssign.DistributorRegistrationId = DistributorAssignDTO.DistributorRegistrationId;
                                distributorAssign.PinCodeId = PinCodeId;
                                distributorAssign.BrandId = BrandId;
                                distributorAssign.CreatedBy = DistributorAssignDTO.CreatedBy;
                                distributorAssign.CreatedDate = DateTime.Now;

                                _DistributorAssignRepo.Insert(distributorAssign);
                            }
                            else
                            {
                                return MessageEnum.Duplicate;
                            }
                        }
                        else
                        {
                            return MessageEnum.Duplicate;
                        }
                    }
                }

                return MessageEnum.Success;
            }
            catch
            {
                throw;
            }
        }

        public List<DistributorAssign> DAssignListbyWareHouseId(Int64 WareHuoseId)
        {
            return _dbContext.DistributorAssigns
                .Include(x => x.PinCodes)
                .Include(x => x.DistributorRegistrations)
                .Include(x => x.Brands)
                .Where(x => x.Deleted == false && x.DistributorRegistrations.WareHuoseId == WareHuoseId).ToList();
        }

        public MessageEnum DistributorAssignDelete(Int64 DistributorAssignId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.DistributorAssigns.Where(x => x.DistributorAssignId == DistributorAssignId).FirstOrDefault();
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
