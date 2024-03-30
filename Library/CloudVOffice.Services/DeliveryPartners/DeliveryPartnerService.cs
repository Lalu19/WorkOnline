using CloudVOffice.Core.Domain.Banners;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.DeliveryPartners;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Data.DTO.DeliveryPartners;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Org.BouncyCastle.Asn1.Mozilla;
using Pipelines.Sockets.Unofficial;

namespace CloudVOffice.Services.DeliveryPartners
{
    public class DeliveryPartnerService : IDeliveryPartnerService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<DeliveryPartner> _deliveryPartnerRepo;

        public DeliveryPartnerService(ApplicationDBContext dbContext, ISqlRepository<DeliveryPartner> deliveryPartnerRepo)
        {

            _dbContext = dbContext;
            _deliveryPartnerRepo = deliveryPartnerRepo;
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
                    deliveryPartner.Password = deliveryPartnerDTO.Password;
                    deliveryPartner.RetailModelId = 5;
                    deliveryPartner.AssignedCode = deliveryPartnerDTO.AssignedCode;
                    deliveryPartner.Availability = deliveryPartnerDTO.Availability;

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
                        partner.RetailModelId = 5;
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
                        partner.Password = deliveryPartnerDTO.Password;
                        partner.AssignedCode = deliveryPartnerDTO.AssignedCode;
                        partner.Availability = deliveryPartnerDTO.Availability;
                        partner.NotificationSent = deliveryPartnerDTO.NotificationSent;
                        partner.TaskAccepted = deliveryPartnerDTO.TaskAccepted;
                        partner.TaskRejected = deliveryPartnerDTO.TaskRejected;


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
        public MessageEnum DeleteDeliveryPartner(Int64 deliveryPartnerId, Int64 DeletedBy)
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

        public DeliveryPartner ChangeAvailabiltyStatus(Int64 DeliveryPartnerId)
        {
            try
            {
                var agent = _dbContext.DeliveryPartners.FirstOrDefault(a=> a.DeliveryPartnerId == DeliveryPartnerId);

                if (agent == null)
                {
                    return null;
                }
                agent.Availability = !agent.Availability;

                _dbContext.SaveChanges();
                return agent;
            }
            catch
            {
                throw;
            }
        }

        public List<DeliveryPartner> GetDeliveryAgentsByManagerId(Int64 WHouseManagerId)
        {
            try
            {
                var mapping = _dbContext.UserWareHouseMappings.Where(z => z.UserId == WHouseManagerId).FirstOrDefault();
                WareHuose warehouse = new WareHuose();

                if(mapping != null)
                {
                    warehouse = _dbContext.WareHouses.FirstOrDefault(z => z.WareHuoseId == mapping.WareHuoseId);
                }

                if (warehouse != null)
                {


                    var agents = _dbContext.DeliveryPartners.Where(a => a.Availability == true && a.AssignedCode == warehouse.AssignmentCode).ToList();
                    return agents;
                }

                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }        


        public List<DeliveryPartner> GetDeliveryPartnersByWareHouseId(Int64 WareHouseId)
        {
            try
            {
                var warehouse = _dbContext.WareHouses.FirstOrDefault(z => z.WareHuoseId == WareHouseId);

                if (warehouse != null)
                {
                    var agents = _dbContext.DeliveryPartners.Where(a => a.Availability == true && a.AssignedCode == warehouse.AssignmentCode).ToList();
                    return agents;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        public List<DeliveryPartner> GetDeliveryPartnersByDistributorId(Int64 DistributorId)
        {
            try
            {
                var distributorAssignedCode = _dbContext.DistributorRegistrations.Where(a=> a.DistributorRegistrationId == DistributorId).Select(z=> z.AssignmentCode).FirstOrDefault();
                
                if (distributorAssignedCode != null)
                {
                    var deliveryAgents = _dbContext.DeliveryPartners.Where(z => z.AssignedCode == distributorAssignedCode).ToList();
                    return deliveryAgents;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }


        public List<DeliveryPartner> GetDeliveryPartnersbyAssignedCode(string AssignedCode)
        {
            try
            {
                var deliPartners = _dbContext.DeliveryPartners.Where(z=> z.AssignedCode ==  AssignedCode).ToList();
                return deliPartners;
            }
            catch
            {
                throw;
            }
        }

        public List<DeliveryPartner> GetDAWithCapacityByTaskId(Int64 WHouseManagerId, Int64 TaskId)
        {
            try
            {
                var mapping = _dbContext.UserWareHouseMappings.Where(z => z.UserId == WHouseManagerId).FirstOrDefault();
                WareHuose warehouse = new WareHuose();

                if (mapping != null)
                {
                    warehouse = _dbContext.WareHouses.FirstOrDefault(z => z.WareHuoseId == mapping.WareHuoseId);
                }

                if (warehouse != null)
                {

                    var task = _dbContext.DATasksWarehouses.Where(a => a.DATasksWarehouseId == TaskId).FirstOrDefault();

                    var agents = _dbContext.DeliveryPartners.Where(a => a.Availability == true && a.AssignedCode == warehouse.AssignmentCode && a.LoadCapacity <= task.Orderweight).ToList();

                    return agents;
                }

                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }


        public List<DeliveryPartner> GetDAByTaskId(Int64 TaskId)
        {
            try
            {

                var task = _dbContext.DATasksWarehouses.FirstOrDefault(z => z.DATasksWarehouseId == TaskId);

                if (task != null)
                {

                    var DAgents = _dbContext.DeliveryPartners.Where(a=> a.LoadCapacity >= task.Orderweight && a.AssignedCode == task.AssignmentCode).ToList();

                    return DAgents;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
