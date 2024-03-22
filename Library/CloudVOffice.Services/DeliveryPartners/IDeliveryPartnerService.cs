using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.DeliveryPartners;
using CloudVOffice.Data.DTO.DeliveryPartners;

namespace CloudVOffice.Services.DeliveryPartners
{
    public interface IDeliveryPartnerService
    {
        public MessageEnum CreateDeliveryPartner(DeliveryPartnerDTO deliveryPartnerDTO);
        public List<DeliveryPartner> GetDeliveryPartnerList();
        public DeliveryPartner GetDeliveryPartnerById(Int64 deliveryPartnerId);
        public MessageEnum UpdateDeliveryPartner(DeliveryPartnerDTO deliveryPartnerDTO);
        public MessageEnum DeleteDeliveryPartner(Int64 deliveryPartnerId, Int64 DeletedBy);
        public DeliveryPartner ChangeAvailabiltyStatus(Int64 DeliveryPartnerId);
        public List<DeliveryPartner> GetDeliveryAgentsByManagerId(Int64 WHouseManagerId);
        public List<DeliveryPartner> GetDeliveryPartnersByWareHouseId(Int64 WareHouseId);
    }
}
