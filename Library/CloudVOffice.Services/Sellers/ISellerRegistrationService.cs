using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.RetailerModel;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Data.DTO.RetailerModel;
using CloudVOffice.Data.DTO.Sellers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Sellers
{
    public interface ISellerRegistrationService
    {
        public MessageEnum SellerRegistrationCreate(SellerRegistrationDTO sellerRegistrationDTO);
        public List<SellerRegistration> GetSellerRegistrationList();
        public MessageEnum SellerRegistrationUpdate(SellerUpdateDTO sellerUpdateDTO);
        public MessageEnum DeleteSellerRegistration(Int64 sellerRegistrationId, Int64 DeletedBy);
        public SellerRegistration GetSellerRegistrationById(Int64 sellerRegistrationId);
    }
}
