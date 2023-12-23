using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.Vendors;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Vendors
{
    public class VendorService : IVendorService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Vendor> _vendorRepo;
        private readonly IVendorOnboarding _vendorOnboardingRepo;
        public VendorService(ApplicationDBContext dbContext, ISqlRepository<Vendor> vendorRepo, IVendorOnboarding vendorOnboardingRepo)
        {
            _dbContext = dbContext;
            _vendorRepo = vendorRepo;
            _vendorOnboardingRepo = vendorOnboardingRepo;
        }

        public MessageEnum VendorCreate(VendorDTO vendorDTO)
        {
            try
            {
                var check = _dbContext.Vendors.Where(x => x.VendorName == vendorDTO.VendorName && x.Deleted == false).FirstOrDefault();
                if (check == null)
                {
                    foreach (var vendorid in vendorDTO.WareHuoseId)
                    {
                        Vendor vendor = new Vendor();
                        vendor.VendorName = vendorDTO.VendorName;
                        vendor.CompanyName = vendorDTO.CompanyName;
                        vendor.GSTNumber = vendorDTO.GSTNumber;
                        vendor.Address = vendorDTO.Address;
                        vendor.Telephone = vendorDTO.Telephone;
                        vendor.Mobile1 = vendorDTO.Mobile1;
                        vendor.Mobile2 = vendorDTO.Mobile2;
                        vendor.MailId = vendorDTO.MailId;
                        vendor.PoCName = vendorDTO.PoCName;
                        vendor.SectorId = vendorDTO.SectorId;
                        vendor.CategoryId = vendorDTO.CategoryId;
                        vendor.WareHuoseId = vendorid;
                        vendor.IsActive = vendorDTO.IsActive;
                        vendor.CreatedBy = vendorDTO.CreatedBy;
                        var obj = _vendorRepo.Insert(vendor);

                        var vob = _vendorOnboardingRepo.VendorOnboardingCreate(new VendorOnboardingDTO
                        {
                            VendorId = vendor.VendorId,
                            SectorId = vendor.SectorId,
                            CreatedBy = vendor.CreatedBy,
                        });

                    }

                    //Vendor vendor = new Vendor();
                    //vendor.VendorName = vendorDTO.VendorName;
                    //vendor.CompanyName = vendorDTO.CompanyName;
                    //vendor.GSTNumber = vendorDTO.GSTNumber;
                    //vendor.Address = vendorDTO.Address;
                    //vendor.Telephone = vendorDTO.Telephone;
                    //vendor.Mobile1 = vendorDTO.Mobile1;
                    //vendor.Mobile2 = vendorDTO.Mobile2;
                    //vendor.MailId = vendorDTO.MailId;
                    //vendor.PoCName = vendorDTO.PoCName;
                    //vendor.SectorId = vendorDTO.SectorId;
                    //vendor.CategoryId = vendorDTO.CategoryId;
                    //vendor.WareHuoseId = vendorid;
                    //vendor.IsActive = vendorDTO.IsActive;
                    //vendor.CreatedBy = vendorDTO.CreatedBy;
                    //var obj = _vendorRepo.Insert(vendor);

                    //var vob = _vendorOnboardingRepo.VendorOnboardingCreate(new VendorOnboardingDTO
                    //{
                    //   VendorId = vendor.VendorId,
                    //   SectorId = vendor.SectorId,
                    //   CreatedBy = vendor.CreatedBy,
                    //});

                    //_vendorOnboardingRepo.VendorOnboardingCreate((int)obj.VendorId, vendorDTO.SectorId, vendorDTO.CreatedBy);

                    //for (int i = 0; i < vendorDTO.VendorOnboardings.Count; i++)
                    //{

                    //    vendorDTO.VendorOnboardings[i].VendorId = obj.VendorId;
                    //    vendorDTO.VendorOnboardings[i].SectorId = obj.SectorId;
                    //    vendorDTO.VendorOnboardings[i].CreatedBy = vendorDTO.CreatedBy;

                    //    _vendorOnboardingRepo.VendorOnboardingCreate(vendorDTO.VendorOnboardings[i]);
                    //}

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
                        foreach (var vendorid in vendorDTO.WareHuoseId)
                        {
                            a.VendorName = vendorDTO.VendorName;
                            a.CompanyName = vendorDTO.CompanyName;
                            a.GSTNumber = vendorDTO.GSTNumber;
                            a.Address = vendorDTO.Address;
                            a.Telephone = vendorDTO.Telephone;
                            a.Mobile1 = vendorDTO.Mobile1;
                            a.Mobile2 = vendorDTO.Mobile2;
                            a.MailId = vendorDTO.MailId;
                            a.PoCName = vendorDTO.PoCName;
                            a.SectorId = vendorDTO.SectorId;
                            a.CategoryId = vendorDTO.CategoryId;
                            a.WareHuoseId = vendorid;
                            a.IsActive = vendorDTO.IsActive;
                            a.UpdatedBy = vendorDTO.CreatedBy;
                            a.UpdatedDate = DateTime.Now;

                            //var b = _dbContext.VendorOnboardings.Where(x => x.VendorId == vendorDTO.VendorId).FirstOrDefault();
                            //if (b != null)
                            //{
                            //    b.VendorId = (long)vendorDTO.VendorId;
                            //    b.SectorId = vendorDTO.SectorId;
                            //    b.UpdatedDate = DateTime.Now;
                            //}
                            var vendorOnboardingToUpdate = _dbContext.VendorOnboardings
                                                            .Where(x => x.VendorId == vendorDTO.VendorId)
                                                            .FirstOrDefault();

                            if (vendorOnboardingToUpdate != null)
                            {
                                vendorOnboardingToUpdate.SectorId = vendorDTO.SectorId;
                                vendorOnboardingToUpdate.VendorId = (long)vendorDTO.VendorId;
                                vendorOnboardingToUpdate.CreatedBy = vendorDTO.CreatedBy;
                                vendorOnboardingToUpdate.UpdatedBy = vendorDTO.CreatedBy;
                                vendorOnboardingToUpdate.UpdatedDate = DateTime.Now;

                            }
                            _dbContext.SaveChanges();

                        }


                        //a.VendorName = vendorDTO.VendorName;
                        //a.CompanyName = vendorDTO.CompanyName;
                        //a.GSTNumber = vendorDTO.GSTNumber;
                        //a.Address = vendorDTO.Address;
                        //a.Telephone = vendorDTO.Telephone;
                        //a.Mobile1 = vendorDTO.Mobile1;
                        //a.Mobile2 = vendorDTO.Mobile2;
                        //a.MailId = vendorDTO.MailId;
                        //a.PoCName = vendorDTO.PoCName;
                        //a.SectorId = vendorDTO.SectorId;
                        //a.CategoryId = vendorDTO.CategoryId;
                        //a.WareHuoseId = vendorDTO.WareHuoseId;
                        //a.IsActive = vendorDTO.IsActive;
                        //a.UpdatedBy = vendorDTO.CreatedBy;
                        //a.UpdatedDate = DateTime.Now;

                        ////var b = _dbContext.VendorOnboardings.Where(x => x.VendorId == vendorDTO.VendorId).FirstOrDefault();
                        ////if (b != null)
                        ////{
                        ////    b.VendorId = (long)vendorDTO.VendorId;
                        ////    b.SectorId = vendorDTO.SectorId;
                        ////    b.UpdatedDate = DateTime.Now;
                        ////}
                        //var vendorOnboardingToUpdate = _dbContext.VendorOnboardings
                        //								.Where(x => x.VendorId == vendorDTO.VendorId)
                        //								.FirstOrDefault();

                        //if (vendorOnboardingToUpdate != null)
                        //{
                        //	vendorOnboardingToUpdate.SectorId = vendorDTO.SectorId;
                        //	vendorOnboardingToUpdate.VendorId = (long)vendorDTO.VendorId;
                        //	vendorOnboardingToUpdate.CreatedBy = vendorDTO.CreatedBy;
                        //	vendorOnboardingToUpdate.UpdatedBy = vendorDTO.CreatedBy;
                        //	vendorOnboardingToUpdate.UpdatedDate = DateTime.Now;

                        //}
                        //_dbContext.SaveChanges();

                        ////var vob = _vendorOnboardingRepo.VendorOnboardingCreate(new VendorOnboardingDTO
                        ////{
                        ////	VendorId = vendorDTO.VendorId,
                        ////	SectorId = vendorDTO.SectorId,
                        ////	CreatedBy = vendorDTO.CreatedBy,
                        ////});

                        ////_vendorOnboardingRepo.VendorOnboardingCreate((int)vendorDTO.VendorId, vendorDTO.SectorId, vendorDTO.CreatedBy);

                        ////var Vendoronboarding = _dbContext.VendorOnboardings.Where(x => x.VendorId == a.VendorId).ToList();

                        ////foreach (var vendor in Vendoronboarding)
                        ////{
                        ////    vendor.Deleted = true;
                        ////    _dbContext.SaveChanges();
                        ////}
                        ////for (int i = 0; i < vendorDTO.VendorOnboardings.Count; i++)
                        ////{

                        ////    vendorDTO.VendorOnboardings[i].VendorId = a.VendorId;
                        ////    vendorDTO.VendorOnboardings[i].SectorId = a.SectorId;
                        ////    vendorDTO.VendorOnboardings[i].CreatedBy = vendorDTO.SectorId;

                        ////    _vendorOnboardingRepo.VendorOnboardingUpdate(vendorDTO.VendorOnboardings[i]);
                        ////}

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
                //return _dbContext.Vendors
                // .Include(s => s.Sector)
                // .Include(s => s.Category)
                // .Include(s => s.WareHuose)
                // .Include(s => s.Gst)
                // .Where(x => x.Deleted == false).ToList();
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
					var b = _dbContext.VendorOnboardings.Where(x => x.VendorId == vendorId).FirstOrDefault();
					if (b != null)
					{
						b.Deleted = true;
						b.UpdatedBy = DeletedBy;
						b.UpdatedDate = DateTime.Now;
						_dbContext.SaveChanges();
						return MessageEnum.Deleted;
					}
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

