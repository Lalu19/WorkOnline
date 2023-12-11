using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.WareHouses.Vendors;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Vendors
{
    public class VendorOnboardingService : IVendorOnboarding
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<VendorOnboarding> _vendorOnboardingRepo;
        public VendorOnboardingService(ApplicationDBContext dbContext, ISqlRepository<VendorOnboarding> vendorOnboardingRepo)
        {
            _dbContext = dbContext;
            _vendorOnboardingRepo = vendorOnboardingRepo;
        }
        public MessageEnum VendorOnboardingCreate(VendorOnboardingDTO vendorOnboardingDTO)
        {
            try
            {
                    VendorOnboarding ct = new VendorOnboarding();
                    ct.SectorId = vendorOnboardingDTO.SectorId;
                    ct.VendorId = vendorOnboardingDTO.VendorId;

                    ct.CreatedBy = vendorOnboardingDTO.CreatedBy;
                    ct.CreatedDate = System.DateTime.Now;
                    var obj = _vendorOnboardingRepo.Insert(ct);
                    _dbContext.SaveChanges();

                    return MessageEnum.Success;
            }
            catch
            {
                throw;
            }
        }
        public List<VendorOnboarding> GetVendorOnboardingList()
        {
            try
            {
                return _dbContext.VendorOnboardings.Where(x => x.Deleted == false).ToList();
            }
            catch
            {
                throw;
            }
        }
        public VendorOnboarding GetVendorByVendorOnboardingId(int VendorOnboardingId)
        {
            return _dbContext.VendorOnboardings.Where(x => x.VendorOnboardingId == VendorOnboardingId && x.Deleted == false).SingleOrDefault();
        }
        public MessageEnum VendorOnboardingUpdate(VendorOnboardingDTO vendorOnboardingDTO)
        {
            try
            {
                var updatevendor = _dbContext.VendorOnboardings.Where(x => x.VendorOnboardingId != vendorOnboardingDTO.VendorOnboardingId && x.Deleted == false).FirstOrDefault();
                if (updatevendor == null)
                {
                    var a = _dbContext.VendorOnboardings.Where(x => x.VendorOnboardingId == vendorOnboardingDTO.VendorOnboardingId).FirstOrDefault();
                    if (a != null)
                    {
                        a.SectorId = vendorOnboardingDTO.SectorId;
                        a.VendorId = vendorOnboardingDTO.VendorId;
                        a.UpdatedBy = vendorOnboardingDTO.CreatedBy;
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
        public MessageEnum VendorOnboardingDelete(int VendorOnboardingId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.VendorOnboardings.Where(x => x.VendorOnboardingId == VendorOnboardingId).FirstOrDefault();
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
