using CloudVOffice.Core.Domain.Banners;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.DeliveryPartners;
using CloudVOffice.Data.DTO.DeliveryPartners;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;

namespace CloudVOffice.Services.DeliveryPartners
{
    public class DeliveryPartnerService : IDeliveryPartnerService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<DeliveryPartner> _deliveryPartnerRepo;

        public DeliveryPartnerService(ApplicationDBContext dbContext, ISqlRepository<DeliveryPartner> deliveryPartnerRepoRepo)
        {

            _dbContext = dbContext;
            _deliveryPartnerRepo = deliveryPartnerRepoRepo;
        }

        public MessageEnum CreateDeliveryPartner(DeliveryPartnerDTO deliveryPartnerDTO)
        {
            try
            {
                var objcheck = _dbContext.DeliveryPartners.SingleOrDefault(opt => opt.Deleted == false && opt.VehicleNumber == deliveryPartnerDTO.VehicleNumber);
                if (objcheck == null)
                {
                    DeliveryPartner deliveryPartner = new DeliveryPartner();

                    deliveryPartner.WareHuoseId = deliveryPartnerDTO.WareHuoseId;
                    deliveryPartner.DriverName = deliveryPartnerDTO.DriverName;
                    deliveryPartner.DriverContact = deliveryPartnerDTO.DriverContact;
                    deliveryPartner.OwnerName = deliveryPartnerDTO.OwnerName;
                    deliveryPartner.OwnerContact = deliveryPartnerDTO.OwnerContact;
                    deliveryPartner.Address = deliveryPartnerDTO.Address;
                    deliveryPartner.FuelType = deliveryPartnerDTO.FuelType;
                    deliveryPartner.VehicleType = deliveryPartnerDTO.VehicleType;
                    deliveryPartner.RegistrationType = deliveryPartnerDTO.RegistrationType;
                    deliveryPartner.LoadCapacity = deliveryPartnerDTO.LoadCapacity;
                    deliveryPartner.VehicleName = deliveryPartnerDTO.VehicleName;
                    deliveryPartner.EngineNumber = deliveryPartnerDTO.EngineNumber;
                    deliveryPartner.ChassisNumber = deliveryPartnerDTO.ChassisNumber;
                    deliveryPartner.RegistrationYear = deliveryPartnerDTO.RegistrationYear;
                    deliveryPartner.VehicleNumber = deliveryPartnerDTO.VehicleNumber;
                    deliveryPartner.PollutionCertificate = deliveryPartnerDTO.PollutionCertificate;
                    deliveryPartner.Insurance = deliveryPartnerDTO.Insurance;
                    deliveryPartner.Mileage = deliveryPartnerDTO.Mileage    ;
                    deliveryPartner.OwnerPhoto = deliveryPartnerDTO.OwnerPhoto;
                    deliveryPartner.DriverPhoto = deliveryPartnerDTO.DriverPhoto;
                    deliveryPartner.VehicleFrontPhoto = deliveryPartnerDTO.VehicleFrontPhoto;
                    deliveryPartner.VehicleBackPhoto = deliveryPartnerDTO.VehicleBackPhoto;

                    deliveryPartner.CreatedBy = deliveryPartnerDTO.CreatedBy;
                    deliveryPartner.CreatedDate = System.DateTime.Now;
                    var obj = _deliveryPartnerRepo.Insert(deliveryPartner);
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
        public MessageEnum UpdateDeliveryPartner(DeliveryPartnerDTO deliveryPartnerDTO)
        {
            try
            {
                var a = _dbContext.DeliveryPartners.Where(x => x.DeliveryPartnerId != deliveryPartnerDTO.DeliveryPartnerId && x.VehicleNumber == deliveryPartnerDTO.VehicleNumber && x.Deleted == false).FirstOrDefault();

                if (a == null)
                {
                    var partner = _dbContext.DeliveryPartners.Where(x => x.DeliveryPartnerId == deliveryPartnerDTO.DeliveryPartnerId).FirstOrDefault();

                    if (partner != null)
                    {
                        partner.WareHuoseId = deliveryPartnerDTO.WareHuoseId;
                        partner.DriverName = deliveryPartnerDTO.DriverName;
                        partner.DriverContact = deliveryPartnerDTO.DriverContact;
                        partner.OwnerName = deliveryPartnerDTO.OwnerName;
                        partner.OwnerContact = deliveryPartnerDTO.OwnerContact;
                        partner.Address = deliveryPartnerDTO.Address;
                        partner.FuelType = deliveryPartnerDTO.FuelType;
                        partner.VehicleType = deliveryPartnerDTO.VehicleType;
                        partner.RegistrationType = deliveryPartnerDTO.RegistrationType;
                        partner.LoadCapacity = deliveryPartnerDTO.LoadCapacity;
                        partner.VehicleName = deliveryPartnerDTO.VehicleName;
                        partner.EngineNumber = deliveryPartnerDTO.EngineNumber;
                        partner.ChassisNumber = deliveryPartnerDTO.ChassisNumber;
                        partner.RegistrationYear = deliveryPartnerDTO.RegistrationYear;
                        partner.VehicleNumber = deliveryPartnerDTO.VehicleNumber;
                        partner.PollutionCertificate = deliveryPartnerDTO.PollutionCertificate;
                        partner.Insurance = deliveryPartnerDTO.Insurance;
                        partner.Mileage = deliveryPartnerDTO.Mileage;
                        partner.OwnerPhoto = deliveryPartnerDTO.OwnerPhoto;
                        partner.DriverPhoto = deliveryPartnerDTO.DriverPhoto;
                        partner.VehicleFrontPhoto = deliveryPartnerDTO.VehicleFrontPhoto;
                        partner.VehicleBackPhoto = deliveryPartnerDTO.VehicleBackPhoto;

                        partner.UpdatedDate = DateTime.Now;
                        _dbContext.SaveChanges();

                        return MessageEnum.Updated;
                    }
                    else
                    {
                        return MessageEnum.Invalid;
                    }
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
        public DeliveryPartner GetDeliveryPartnerById(Int64 deliveryPartnerId)
        {

            try
            {
                var a = _dbContext.DeliveryPartners.Where(x => x.DeliveryPartnerId == deliveryPartnerId && x.Deleted == false).FirstOrDefault();
                return a;
            }
            catch
            {
                throw;
            }
        }

        public List<DeliveryPartner> GetDeliveryPartnerList()
        {
            try
            {
                var a = _dbContext.DeliveryPartners.Where(x => x.Deleted == false).ToList();
                return a;
            }
            catch
            {
                throw;
            }
        }
        public MessageEnum DeleteDeliveryPartner(Int64 deliveryPartnerId, long DeletedBy)
        {
            try
            {
                var a = _dbContext.DeliveryPartners.Where(x => x.DeliveryPartnerId == deliveryPartnerId).FirstOrDefault();
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
