using CloudVOffice.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Distributors
{
    public interface IDPOItemsService
    {
        public MessageEnum DPOItemsCreate(Int64 DPOId, int ItemId, Int64 Quantity, Int64 createdBy);
    }
}
