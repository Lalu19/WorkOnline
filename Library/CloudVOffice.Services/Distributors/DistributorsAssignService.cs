using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Distributors;
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
                    DistributorAssign DistributorAssign = new DistributorAssign();
                    DistributorAssign.DistributorRegistrationId = DistributorAssignDTO.DistributorRegistrationId;
                    foreach (var PinCodeId in DistributorAssignDTO.PinCodeId)
                    {
                        DistributorAssign.PinCodeId = PinCodeId;
                    }
                    foreach (var BrandId in DistributorAssignDTO.BrandId)
                    {
                        DistributorAssign.BrandId = BrandId;
                    }
                    DistributorAssign.CreatedBy = DistributorAssignDTO.CreatedBy;
                    DistributorAssign.CreatedDate = System.DateTime.Now;
                    var obj = _DistributorAssignRepo.Insert(DistributorAssign);
                    
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
    }
}
