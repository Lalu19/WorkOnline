using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
using CloudVOffice.Data.DTO.WareHouses.GSTs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.GSTs
{
    public interface IGSTService
    {
        public MessageEnum GSTCreate(GSTDTO gstDTO);
        public GST GetGSTByGSTId(Int64 gstId);
        public List<GST> GetGSTList();
        public MessageEnum GSTUpdate(GSTDTO gstDTO);
        public MessageEnum GSTDelete(Int64 gstId, Int64 DeletedBy);

        public string GetGstForSeller(int SellerRegistrationId);
    }
}
