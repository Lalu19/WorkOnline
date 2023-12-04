using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
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
    public class VendorService: IVendorService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Vendor> _vendorRepo;
        public VendorService(ApplicationDBContext dbContext, ISqlRepository<Vendor> vendorRepo)
        {

            _dbContext = dbContext;
            _vendorRepo = vendorRepo;
        }

        public MessageEnum VendorCreate(VendorDTO vendorDTO)
        {
            try
            {
                var check = _dbContext.Vendors.Where(x => x.VendorName == vendorDTO.VendorName && x.Deleted == false).FirstOrDefault();
                if (check == null)
                {
                    Vendor vendor = new Vendor();
                    vendor.VendorName = vendorDTO.VendorName;
                    vendor.CompanyName = vendorDTO.CompanyName;
                    vendor.GST = vendorDTO.GST;
                    vendor.Address = vendorDTO.Address;
                    vendor.Telephone = vendorDTO.Telephone;
                    vendor.Mobile1 = vendorDTO.Mobile1;
                    vendor.Mobile2 = vendorDTO.Mobile2;
                    vendor.MailId = vendorDTO.MailId;
                    vendor.PoCName = vendorDTO.PoCName;
                    vendor.Segment = vendorDTO.Segment;
                    vendor.Category = vendorDTO.Category;
                    vendor.WarehousesAffiliated = vendorDTO.WarehousesAffiliated;
                    vendor.IsActive = vendorDTO.IsActive;
                    vendor.CreatedBy = vendorDTO.CreatedBy;
                    var obj = _vendorRepo.Insert(vendor);

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
        public MessageEnum VendorUpdate(VendorDTO vendorDTO)
        {
            try
            {
                var check = _dbContext.Vendors.Where(x => x.VendorId != vendorDTO.VendorId && x.VendorName == vendorDTO.VendorName && x.Deleted == false).FirstOrDefault();
                if (check == null)
                {
                    var a = _dbContext.Vendors.Where(x => x.VendorId == vendorDTO.VendorId).FirstOrDefault();
                    if (a != null)
                    {
                        a.VendorName = vendorDTO.VendorName;
                        a.CompanyName = vendorDTO.CompanyName;
                        a.GST = vendorDTO.GST;
                        a.Address = vendorDTO.Address;
                        a.Telephone = vendorDTO.Telephone;
                        a.Mobile1 = vendorDTO.Mobile1;
                        a.Mobile2 = vendorDTO.Mobile2;
                        a.MailId = vendorDTO.MailId;
                        a.PoCName = vendorDTO.PoCName;
                        a.Segment = vendorDTO.Segment;
                        a.Category = vendorDTO.Category;
                        a.WarehousesAffiliated = vendorDTO.WarehousesAffiliated;
                        a.IsActive = vendorDTO.IsActive;
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
        public Vendor GetVendorByVendorId(Int64 vendorId)
        {
            try
            {
                return _dbContext.Vendors.Where(x => x.VendorId == vendorId && x.Deleted == false).SingleOrDefault();

            }
            catch
            {
                throw;
            }
        }
        public List<Vendor> GetVendorList()
        {
            try
            {
                return _dbContext.Vendors.Where(x => x.Deleted == false).ToList();
            }
            catch
            {
                throw;
            }
        }
        public MessageEnum VendorDelete(Int64 vendorId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.Vendors.Where(x => x.VendorId == vendorId).FirstOrDefault();
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

