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

                var objcheck = _dbContext.DistributorAssigns.SingleOrDefault(opt => opt.Deleted == false);

                if (objcheck == null)
                {
                    foreach (var PinCodeId in DistributorAssignDTO.PinCodeId)
                    {
                        foreach (var BrandId in DistributorAssignDTO.BrandId)
                        {
                            DistributorAssign DistributorAssign = new DistributorAssign();
                            DistributorAssign.DistributorRegistrationId = DistributorAssignDTO.DistributorRegistrationId;
                            DistributorAssign.PinCodeId = PinCodeId;
                            DistributorAssign.BrandId = BrandId;
                            DistributorAssign.CreatedBy = DistributorAssignDTO.CreatedBy;
                            DistributorAssign.CreatedDate = System.DateTime.Now;

                            var obj = _DistributorAssignRepo.Insert(DistributorAssign);
                        }
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
            };
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
