using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.PinCodes
{
    public class PinCode : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 PinCodeId { get; set; }
        public string Pin { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public bool IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
